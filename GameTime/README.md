# 게임 시간 시스템

게임 내 경과 시간을 표현하는 `GameTime` 구조체를 구현하시오. 이 구조체는 시(Hours), 분(Minutes), 초(Seconds) 
세 단위를 사용하며, 60초 = 1분, 60분 = 1시간 규칙에 따라 자동으로 정규화됨.

**요구사항:**

1. `GameTime` 구조체에 `Hours`(int), `Minutes`(int), `Seconds`(int) 필드를 정의
2. 생성자에서 초가 60 이상이면 분으로, 분이 60 이상이면 시간으로 자동 올림 처리 (정규화)
3. 다음 연산자를 오버로딩:
   - `+` : 두 시간을 더함
   - `-` : 두 시간을 뺌 (결과가 음수가 되면 0h 0m 0s로 처리)
   - `==`, `!=` : 동일 비교
   - `<`, `>` : 크기 비교
   - `*` (`GameTime * int`) : 시간을 정수 배수로 확대
4. `ToString()` 메서드를 재정의하여 `"Xh Ym Zs"` 형식으로 출력 (예: `"2h 30m 15s"`)
5. `GetTotalSeconds()` 메서드: 전체 시간을 초 단위로 환산하여 반환
6. `Equals()`와 `GetHashCode()`를 재정의
7. 다음 테스트 코드가 올바르게 동작해야 함:

```csharp
GameTime t1 = new GameTime(1, 30, 45);
GameTime t2 = new GameTime(0, 45, 30);

Console.WriteLine($"시간1: {t1}");
Console.WriteLine($"시간2: {t2}");

GameTime sum = t1 + t2;
Console.WriteLine($"합계: {sum}");

GameTime diff = t2 - t1;
Console.WriteLine($"차이: {diff}");

Console.WriteLine($"시간1 == 시간2: {t1 == t2}");
Console.WriteLine($"시간1 != 시간2: {t1 != t2}");
Console.WriteLine($"시간1 > 시간2: {t1 > t2}");
Console.WriteLine($"시간1 < 시간2: {t1 < t2}");

GameTime t3 = t2 * 3;
Console.WriteLine($"시간2 x 3: {t3}");

GameTime t4 = new GameTime(0, 0, 3700);
Console.WriteLine($"3700초 정규화: {t4}");
Console.WriteLine($"시간1 총 초: {t1.GetTotalSeconds()}");
```

## 예상 실행 결과

```
시간1: 1h 30m 45s
시간2: 0h 45m 30s
합계: 2h 16m 15s
차이: 0h 0m 0s
시간1 == 시간2: False
시간1 != 시간2: True
시간1 > 시간2: True
시간1 < 시간2: False
시간2 x 3: 2h 16m 30s
3700초 정규화: 1h 1m 40s
시간1 총 초: 5445
```
