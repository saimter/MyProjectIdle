
# 오브젝트 풀링

- 맵 배치
- 플레이어 배치
- 몬스터 소환
- 투사체 날리기
- 피격 시 진행할 이벤트
  - 정검
    - 몬스터 생성 완료
    - 몬스터 이동 로직 구현
    - 생성을 진행할 경우 너무 낳은 클론이 생겼을 경우
- 통합 매니저
- 앞으로 만들 모든 매니저에 대한 연결점
- 해당 매니저에 대한 접근(프로퍼티 접근)

- 풀 매니저
  - IPOOL 인터페이스 설계
    - 플에 대한 틀을 제공하는 용도
    - 틀랜스폼(풀 연결 위치)
    - 큐(풀 구현)
    - 몬스터 하나 얻어오는 기능
    - 반납하는 기능
  - string, IPool을 K,V로 가지는 딕셔너리 등록 경로를 전달 받아 키를 추가하는 함수 구현
  - 풀 매니저 멤버(변수나 함수) 설계
    - string, IPool을 K,V로 가지는 딕셔너리 등록 경로를 전달 받아 키를 추가하는 함수 구현
    - 경로를 전달 받아 오브젝트를 생성하고 지정된 트랜스폼 쪽에 연결해즈는 함수 구현
      - ※경로에 대하 정보로 설계를 진행해서 매니저 쪽에 추가 코드 작성
- 매니저 코드 수정

      

  
