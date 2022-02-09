# omok

아래링크에서 코드에 대한 자세한 설명을 볼 수 있습니다.

[C#으로 오목 AI 구현해보기 #1](https://velog.io/@ohjinseo/C%EC%9C%BC%EB%A1%9C-%EC%98%A4%EB%AA%A9-AI-%EA%B5%AC%ED%98%84%ED%95%B4%EB%B3%B4%EA%B8%B0-1)

[C#으로 오목 AI 구현해보기 #2](https://velog.io/@ohjinseo/C%EC%9C%BC%EB%A1%9C-%EC%98%A4%EB%AA%A9-AI-%EA%B5%AC%ED%98%84%ED%95%B4%EB%B3%B4%EA%B8%B0-2)

<br />
<br />

Minimax와 Alpha-beta pruning 알고리즘을 이용한 오목 프로그램입니다. 

- pvp, AI 모드 선택 가능



### Minimax?
- 바둑, 체스와 같은 게임에서 상대의 수를 예측하기 위해 사용
-   나(AI)는 자신에게 유리한 수를 둘 것이고, 상대(유저) 또한 자신에게 유리한 수(나에겐 불리한 수)를 둘 것이므로 각 턴마다 최적의 수를 찾기 위해 사용



### Alpha-beta pruning?
- Minimax 알고리즘에서 탐색할 때 수를 둘 수 있는 경우의 수는 기하급수적으로 커지는데 이 문제를 해결하기 위해 **Alpha-beta pruning** 알고리즘을 적용
- 예를 들어 어떤 경우가 자신에게 유리한 것이 확정되어 더 이상의 탐색이 불필요할 때 **가지치기**를 하여 **시간복잡도를 단축시키는 목적**으로 사용

