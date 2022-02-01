# omok

Minimax와 Alpha-beta pruning 알고리즘을 이용한 오목 프로그램입니다. (미완)

- pvp, AI 모드 선택 가능

### Minimax?
- 바둑, 체스와 같은 게임에서 상대의 수를 예측하기 위해 사용
-   나(AI)는 자신에게 유리한 수를 둘 것이고, 상대(유저) 또한 자신에게 유리한 수(나에겐 불리한 수)를 둘 것이므로 각 턴마다 최적의 수를 찾기 위해 사용

### Alpha-beta pruning?
- Minimax 알고리즘에서 탐색할 때 수를 둘 수 있는 경우의 수는 기하급수적으로 커지는데 이 문제를 해결하기 위해 **Alpha-beta pruning** 알고리즘을 적용
- 예를 들어 어떤 경우가 자신에게 유리한 것이 확정되어 더 이상의 탐색이 불필요할 때 **가지치기**를 하여 **시간복잡도를 단축시키는 목적**으로 사용
<br />
<br />
**다음은 Alpha-beta pruning에서 Alpha-cut을 하는 과정입니다.**
![image](https://user-images.githubusercontent.com/62508156/152056791-8eb9d6d3-121e-4da9-84a9-a4bfd4176e96.png)
