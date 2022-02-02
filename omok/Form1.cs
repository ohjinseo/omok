using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace omok
{
    public partial class Form1 : Form
    {
        const int margin = 40;
        const int gridSize = 40;
        const int stoneSize = 32;
        const int flowerSize = 10;
        const int limit = 2;
        const int INF = int.MaxValue;
        int aiX, aiY;
        int whiteX, whiteY;
        Boolean pvp = false;

        //↗,→,↘, ↓
        int[] omok_dirX = new int[] { -1, 0, 1, 1 };
        int[] omok_dirY = new int[] { 1, 1, 1, 0 };

        //짝수는 ↗,→,↘, ↓
        //홀수는 ↑, ←, ↖, ↙ 
        //돌의 양방향을 탐색하기 위한 방향키
        int[] dirX = new int[] { 1, -1, 0, 0, 1, -1, -1, 1 };
        int[] dirY = new int[] { 0, 0, 1, -1, 1, -1, 1, -1 };

        enum STONE { NONE, BLACK, WHITE };
        STONE[,] board = new STONE[19, 19];
        bool flag = false;  //flase = 흑돌, true = 흰돌
        bool isFirst = true;

        Graphics g;
        Pen pen;
        Brush wBrush, bBrush;
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawBoard();
        }

        private void DrawBoard()
        {
            g = panel1.CreateGraphics();

            for (int i = 0; i < 19; i++)
            {
                g.DrawLine(pen, new Point(margin + i * gridSize, margin),
                    new Point(margin + i * gridSize, margin + 18 * gridSize));
            }

            for (int i = 0; i < 19; i++)
            {
                g.DrawLine(pen, new Point(margin, margin + i * gridSize), new Point(margin + 18 * gridSize, margin + i * gridSize));
            }

            for (int x = 3; x <= 15; x += 6)
            {
                for (int y = 3; y <= 15; y += 6)
                {
                    g.FillEllipse(bBrush,
                      margin + gridSize * x - flowerSize / 2,
                      margin + gridSize * y - flowerSize / 2,
                      flowerSize, flowerSize);
                }
            }
        }
        public void init()
        {
            for (int i = 0; i < 19; i++)
            {
                for (int k = 0; k < 19; k++)
                {
                    board[i, k] = STONE.NONE;
                }
            }

            g.Clear(Color.Orange);
            DrawBoard();
        }

        private void Click_PVP(object sender, EventArgs e)
        {
            init();
            pvp = true;
        }

        private void Click_AI(object sender, EventArgs e)
        {
            init();
            pvp = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            int x = (e.X - margin + gridSize / 2) / gridSize;
            int y = (e.Y - margin + gridSize / 2) / gridSize;

            Rectangle r = new Rectangle(
                margin + gridSize * whiteY - stoneSize / 2,
                margin + gridSize * whiteX - stoneSize / 2,
                stoneSize, stoneSize);

            Pen p = new Pen(Color.White, 3);

            if (!isFirst)
            {
                g.FillEllipse(wBrush, r);
                g.DrawEllipse(p, r);
            }
            

            if (isFirst) isFirst = false;


            if (x < 0 || y < 0 || x >= 19 || y >= 19)
            {
                MessageBox.Show("테두리를 벗어났습니다.");
                return;
            }

            if (board[y, x] != STONE.NONE) return;

            r = new Rectangle(
                margin + gridSize * x - stoneSize / 2,
                margin + gridSize * y - stoneSize / 2,
                stoneSize, stoneSize);


            if (pvp)
            {
                //pvp 모드
                if (flag == false)
                {
                    g.FillEllipse(bBrush, r);
                    board[y, x] = STONE.BLACK;
                    if (isOmok(flag)) return;
                    flag = true;
                }
                else
                {
                    g.FillEllipse(wBrush, r);
                    board[y, x] = STONE.WHITE;
                    if (isOmok(flag)) return;
                    flag = false;
                }
            }
            else
            {
                //ai 모드
               

                board[y, x] = STONE.BLACK;
                g.FillEllipse(bBrush, r);
                if (isOmok(flag)) return;

                

                alphabetaPruning(0, int.MinValue, int.MaxValue);

                r = new Rectangle(
                    margin + gridSize * aiY - stoneSize / 2,
                    margin + gridSize * aiX - stoneSize / 2,
                    stoneSize, stoneSize);

                whiteX = aiX;
                whiteY = aiY;
                p = new Pen(Color.Red, 3);
                g.FillEllipse(wBrush, r);
                g.DrawEllipse(p, r);
                board[aiX, aiY] = STONE.WHITE;
                Console.WriteLine(aiX + " " + aiY);
                if (isOmok(!flag)) return;
            }
        }

        public Boolean isCorrectRange(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < 19 && y < 19) return true;
            return false;
        }

        public Boolean fourWaySearch(int x, int y, Boolean flag)
        {
            STONE currentStone = flag ? STONE.WHITE : STONE.BLACK;

            for (int i = 0; i < 4; i++)
            {
                int nx = x;
                int ny = y;
                Boolean s = true;

                for (int k = 0; k < 4; k++)
                {
                    nx += omok_dirX[i];
                    ny += omok_dirY[i];

                    if (!isCorrectRange(nx, ny) || currentStone != board[nx, ny])
                    {
                        s = false;
                    }
                }

                if (s == true)
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean isOmok(Boolean flag)
        {
            STONE currentStone = flag ? STONE.WHITE : STONE.BLACK;


            for (int i = 0; i < 19; i++)
            {
                for (int k = 0; k < 19; k++)
                {
                    if (currentStone == board[i, k])
                    {
                        if (fourWaySearch(i, k, flag))
                        {
                            MessageBox.Show(currentStone + "이 이겼습니다.");
                            return true;
                        }
                    }
                }
            }

            return false;
        }


        public int alphabetaPruning(int depth, int alpha, int beta)
        {
            if (depth == 3)
            {
                //Console.WriteLine(getStatus());
                return getStatus();
            }

            if (depth % 2 == 0) //AI 차례
            {
                int v = int.MinValue;   // AI 입장에선 최댓값을 구하기 위해 -INF 선언
                Boolean pruning = false;

                for (int x = 0; x < 19; x++)    //for each child of node
                {
                    for (int y = 0; y < 19; y++)
                    {
                        STONE curStone = board[x, y];
                        Boolean flag = false;

                        //현재 좌표에 돌이 없을 시 주변에 돌이 있을 시 돌을 놓음
                        if (curStone == STONE.NONE)
                        {
                            int nx, ny;

                            for (int k = 0; k < 8; k++)
                            {
                                nx = x + dirX[k];
                                ny = y + dirY[k];

                                if (!isCorrectRange(nx, ny)) continue;

                                if (board[nx, ny] != STONE.NONE)
                                {
                                    flag = true;
                                    break;
                                }
                            }

                            if (flag)
                            {
                                board[x, y] = STONE.WHITE;
                                int temp = alphabetaPruning(depth + 1, alpha, beta);

                                if (v < temp)
                                {
                                    v = temp;
                                    if (depth == 0)
                                    {
                                        aiX = x;
                                        aiY = y;
                                    }
                                }
                                board[x, y] = STONE.NONE;

                                alpha = Math.Max(alpha, v);

                                // 가지치기
                                if (beta <= alpha)
                                {
                                    pruning = true;
                                    break;
                                }
                            }
                        }
                        if (pruning) break;
                    }
                    if (pruning) break;
                }
                return v;
            }

            else //Player 차례
            {
                int v = int.MaxValue;
                Boolean pruning = false;

                for (int x = 0; x < 19; x++)    //for each child of node
                {
                    for (int y = 0; y < 19; y++)
                    {
                        STONE curStone = board[x, y];
                        Boolean flag = false;

                        //현재 좌표에 돌이 없을 시 주변에 돌이 있을 시 돌을 놓음
                        if (curStone == STONE.NONE)
                        {
                            int nx, ny;

                            for (int k = 0; k < 8; k++)
                            {
                                nx = x + dirX[k];
                                ny = y + dirY[k];
                                if (!isCorrectRange(nx, ny)) continue;
                                if (board[nx, ny] != STONE.NONE)
                                {
                                    flag = true;
                                    break;
                                }
                            }

                            if (flag)
                            {
                                board[x, y] = STONE.BLACK;
                                v = Math.Min(v, alphabetaPruning(depth + 1, alpha, beta));
                                board[x, y] = STONE.NONE;

                                beta = Math.Min(beta, v);

                                if (beta <= alpha)
                                {
                                    pruning = true; break;
                                }
                            }

                        }
                        if (pruning) break;
                    }
                    if (pruning) break;
                }

                return v;
            }
        }

        public int getStatus()
        {
            int aiWeight = 0;
            int playerWeight = 0;

            for (int x = 0; x < 19; x++)
            {
                for (int y = 0; y < 19; y++)
                {
                    if (board[x, y] == STONE.NONE) continue;

                    int stoneCnt, nx, ny;
                    Boolean flag;
                    Boolean isOneSpace;
                    Boolean isOneSideBlock;
                    STONE curStone = board[x, y];


                    for (int k = 0; k < 8; k += 2)
                    {
                        if (!isFitFive(x, y, k)) continue;  //만약 양방향으로 오목이 들어가지 않는다면 무시

                        nx = x;
                        ny = y;

                        //돌의 개수를 확인하고 돌이 한 칸 띄워진지 확인함
                        stoneCnt = 1;
                        flag = false;
                        isOneSpace = false;
                        isOneSideBlock = false;

                        //상하를 제외하고 x, y가 보드 끝에 있으면 한 쪽이 막힌 것으로 간주
                        if (k != 0 && (x == 0 || y == 0 || x == 18 || y == 18)) isOneSideBlock = true;

                        for (int i = 0; i < 4; i++)
                        {
                            //정방향 탐색
                            nx += dirX[k];
                            ny += dirY[k];

                            if (!isCorrectRange(nx, ny)) break;

                            //한 칸공백 true인데 돌이 없다는 것은 두 칸 공백이라는 뜻이므로 반복문 탈출함
                            if (board[nx, ny] == STONE.NONE && isOneSpace)
                            {
                                break;
                            }

                            if (board[nx, ny] == curStone)
                            {
                                stoneCnt++;
                                if (flag)
                                {
                                    isOneSpace = true;
                                    flag = false;
                                }

                                if (nx == 0 || ny == 0 || nx == 18 || ny == 18) isOneSideBlock = true;

                            }

                            else if (board[nx, ny] == STONE.NONE && !flag)
                            {
                                flag = true;
                            }

                            // 다른돌에 의해 막힘을 뜻함
                            else
                            {
                                if (!flag)   //공백이 있으면 그냥 탈출시킴
                                    isOneSideBlock = true;
                                break;
                            }
                        }


                        nx = x; ny = y;
                        flag = false;


                        for (int i = 0; i < 4; i++)
                        {
                            //역방향 탐색
                            nx += dirX[k + 1];
                            ny += dirY[k + 1];

                            if (!isCorrectRange(nx, ny)) break;

                            //한 칸공백 true인데 돌이 없다는 것은 두 칸 공백이라는 뜻이므로 반복문 탈출함
                            if (board[nx, ny] == STONE.NONE && isOneSpace)
                            {
                                break;
                            }

                            if (board[nx, ny] == curStone)
                            {
                                stoneCnt++;
                                if (flag)
                                {
                                    isOneSpace = true;
                                    flag = false;
                                }
                                if (nx == 0 || ny == 0 || nx == 18 || ny == 18) isOneSideBlock = true;

                            }

                            else if (board[nx, ny] == STONE.NONE && !flag)
                            {
                                flag = true;
                            }

                            // 다른돌에 의해 막힘을 뜻함
                            else
                            {
                                if (!flag)   //공백이 있으면 그냥 탈출시킴
                                    isOneSideBlock = true;
                                break;
                            }
                        }

                        int sum = 0;

                        //수가 1개일 때
                        if (stoneCnt == 1)
                        {
                            //한 쪽이 막혔을 때
                            if (isOneSideBlock && !isOneSpace)
                            {
                                sum += 5;
                            }

                            //안막혔을 때
                            else if (!isOneSideBlock && !isOneSpace)
                            {
                                sum += 10;
                            }
                        }

                        //수가 2개일 때
                        else if (stoneCnt == 2)
                        {
                            //한 쪽이 막혔을 때
                            if (isOneSideBlock && !isOneSpace)
                            {
                                sum += 30;
                            }
                            //한 쪽이 막히고 한 칸 띄워졌을 때
                            else if (isOneSideBlock && isOneSpace)
                            {
                                sum += 15;
                            }
                            //안막혔을 때
                            else if (!isOneSideBlock && !isOneSpace)
                            {
                                sum += 40;
                            }
                            //안막히고 한 칸 띄워졌을 때
                            else
                            {
                                sum += 30;
                            }

                        }

                        //수가 3개일 때
                        else if (stoneCnt == 3)
                        {
                            //한 쪽이 막혔을 때
                            if (isOneSideBlock && !isOneSpace)
                            {
                                sum += 60;
                            }
                            //한 쪽이 막히고 한 칸 띄워졌을 때
                            else if (isOneSideBlock && isOneSpace)
                            {
                                sum += 120;
                            }
                            //안막혔을 때
                            else if (!isOneSideBlock && !isOneSpace)
                            {
                                sum += 400;
                            }
                            //안막히고 한 칸 띄워졌을 때
                            else
                            {
                                sum += 360;
                            }
                        }

                        //수가 4개일 때
                        else if (stoneCnt == 4)
                        {
                            //한 쪽이 막혔을 때
                            if (isOneSideBlock && !isOneSpace)
                            {
                                sum += 200;
                            }
                            //한 쪽이 막히고 한 칸 띄워졌을 때
                            else if (isOneSideBlock && isOneSpace)
                            {
                                sum += 190;
                            }
                            //안막혔을 때
                            else if (!isOneSideBlock && !isOneSpace)
                            {
                                sum += 1500;
                            }
                            //안막히고 한 칸 띄워졌을 때
                            else
                            {
                                sum += 660;
                            }
                        }

                        //수가 5개 또는 6개일 때
                        else if(stoneCnt == 5 || stoneCnt == 6)
                        {
                            sum += 2000;
                        }

                        if (curStone == STONE.BLACK) playerWeight += sum;
                        else aiWeight += sum;
                    }
                }
            }
            //크다면 AI가 유리, 작다면 Player가 유리
            return aiWeight - playerWeight;
        }

        //(x, y) 좌표를 받고 양방향으로 오목이 들어갈 공간이 있는지 확인
        Boolean isFitFive(int x, int y, int k)
        {
            STONE curStone = board[x, y];
            int nx = x;
            int ny = y;
            int cnt = 0;

            for (int i = 0; i < 4; i++)
            {
                //정방향 탐색
                nx += dirX[k];
                ny += dirY[k];


                if (!isCorrectRange(nx, ny)) break;

                if (board[nx, ny] == STONE.NONE || board[nx, ny] == curStone) cnt++;
                else break;

            }

            if (cnt == 4) return true;

            nx = x;
            ny = y;
            for (int i = 0; i < 4; i++)
            {
                //역방향 탐색
                nx += dirX[k + 1];
                ny += dirY[k + 1];

                if (!isCorrectRange(nx, ny)) break;

                if (board[nx, ny] == STONE.NONE || board[nx, ny] == curStone) cnt++;
                else break;

                if (cnt == 4) return true;
            }
            return false;
        }

        public Form1()
        {
            InitializeComponent();


            this.Text = "OMOK";
            BackColor = Color.Orange;

            pen = new Pen(Color.Black);
            bBrush = new SolidBrush(Color.Black);
            wBrush = new SolidBrush(Color.White);

            this.ClientSize = new Size(2 * margin + 18 * gridSize, 2 * margin + 18 * gridSize);
        }
    }
}


/*
isFitFive 테스트
for (int i = 0; i < 8; i += 2)
{
    if (isFitFive(x, y, i))
    {
        Console.WriteLine(i + "번 째 5개가 들어갈 수 있습니다");
    }
    else
    {
        Console.WriteLine("------------ " + i + "번 쨰 5개가 들어갈 수 없습니다");
    }
}
//board 좌표 테스트
for (int i = 0; i < 10; i++)
{
    for (int k = 0; k < 10; k++)
    {
        Console.Write(board[i, k] + " ");
    }
    Console.WriteLine();
}
Console.WriteLine(); Console.WriteLine();
//status 함수 테스트
Console.WriteLine(curStone + " -> " + "(" + x + ", " + y + ") " + k + "방향 입니다. ------------------------");
Console.WriteLine("총 돌의 개수는 ? : " + stoneCnt);
Console.WriteLine("한 칸 띄워져 있는지 ? : " + isOneSpace);
Console.WriteLine("한 쪽이 막혀 있는지? : " + isOneSideBlock);
Console.WriteLine();
Console.WriteLine();
*/