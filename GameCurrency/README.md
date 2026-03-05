# 게임 화폐 시스템

게임 내 화폐를 표현하는 `GameCurrency` 구조체를 구현하시오. 이 구조체는 Gold와 Silver 두 단위를 사용하며, 
100 Silver = 1 Gold 규칙에 따라 자동으로 정규화됨.

**요구사항:**

1. `GameCurrency` 구조체에 `Gold`(int)와 `Silver`(int) 필드를 정의
2. 생성자에서 Silver가 100 이상이면 자동으로 Gold로 올림 처리 (정규화)
3. 다음 연산자를 오버로딩:
   - `+` : 두 화폐를 더함
   - `-` : 두 화폐를 뺌 (결과가 음수가 되면 0G 0S로 처리)
   - `==`, `!=` : 동일 비교
   - `<`, `>` : 크기 비교
4. `ToString()` 메서드를 재정의하여 `"XG YS"` 형식으로 출력 (예: `"3G 50S"`)
5. `GetTotalSilver()` 메서드: 전체 금액을 Silver로 환산하여 반환 (예: 3G 50S = 350)
6. `Equals()`와 `GetHashCode()`를 재정의
7. 다음 테스트 코드가 올바르게 동작해야 함:

```csharp
GameCurrency wallet1 = new GameCurrency(3, 50);
GameCurrency wallet2 = new GameCurrency(1, 80);

Console.WriteLine($"지갑1: {wallet1}");
Console.WriteLine($"지갑2: {wallet2}");

GameCurrency sum = wallet1 + wallet2;
Console.WriteLine($"합계: {sum}");

GameCurrency diff = wallet2 - wallet1;
Console.WriteLine($"차액: {diff}");

Console.WriteLine($"지갑1 == 지갑2: {wallet1 == wallet2}");
Console.WriteLine($"지갑1 != 지갑2: {wallet1 != wallet2}");
Console.WriteLine($"지갑1 > 지갑2: {wallet1 > wallet2}");
Console.WriteLine($"지갑1 < 지갑2: {wallet1 < wallet2}");

GameCurrency wallet3 = new GameCurrency(0, 250);
Console.WriteLine($"250S 정규화: {wallet3}");
Console.WriteLine($"지갑1 총 Silver: {wallet1.GetTotalSilver()}");
```

## 예상 실행 결과

```
지갑1: 3G 50S
지갑2: 1G 80S
합계: 5G 30S
차액: 0G 0S
지갑1 == 지갑2: False
지갑1 != 지갑2: True
지갑1 > 지갑2: True
지갑1 < 지갑2: False
250S 정규화: 2G 50S
지갑1 총 Silver: 350
```
