using System;
using System.Collections.Generic;
using Xunit;

namespace _29_DivideTwoIntegers
{
  public class Solution
  {
    private bool isQuotientNegative(int a, int b)
    {
      bool isANegative = a < 0;
      bool isBNegative = b < 0;
      bool isQuotientNegative = (isANegative && !isBNegative) || (!isANegative && isBNegative);
      return isQuotientNegative;
    }

    public int Divide(int dividend, int divisor)
    {
      if (divisor == 0)
      {
        return 0;
      }

      bool isNegativeQuotient = isQuotientNegative(dividend, divisor);
      if (divisor == -1)
      {
        return dividend == int.MinValue ? int.MaxValue : -dividend;
      }
      if (divisor == 1)
      {
        return dividend;
      }

      long longDividend = Math.Abs((long)dividend);
      long longDivisor = Math.Abs((long)divisor);
      if (longDividend < longDivisor)
      {
        return 0;
      }

      long quotient = 0;

      while (longDividend > 0)
      {
        longDividend -= longDivisor;
        quotient++;
      }

      if (longDividend < 0)
      {
        quotient--;
      }

      if (quotient > int.MaxValue && isNegativeQuotient)
      {
        quotient = (long)int.MaxValue + 1;
      }
      else if (quotient > int.MaxValue)
      {
        quotient = int.MaxValue;
      }

      return isNegativeQuotient ? -((int)quotient) : (int)quotient;
    }
  }

  public class SolutionTest
  {
    public static IEnumerable<object[]> generateXUnitCompatibleTestInputs()
    {
      var testParameters = new List<(int, int, int)>() {
        (10, 3, 10 / 3),
        (7, -3, 7 / -3),
        (0, 1, 0),
        (1, 1, 1),
        (1, 2, 0),
        (int.MaxValue, 1, int.MaxValue),
        (int.MinValue, 1, int.MinValue),
        (-1, -1, 1),
        (-1, 1, -1),
        (1, 1, 1),
        (1, -1, -1),
        (int.MinValue, -1, int.MaxValue),
        (int.MinValue, -2, int.MinValue / -2),
        (int.MaxValue, -1, int.MinValue + 1),
        (int.MaxValue, -2, int.MaxValue / -2),
        (int.MaxValue, -3, int.MaxValue / -3),
        (1, int.MinValue, 0),
        (1, int.MaxValue, 0),
      };
      foreach (var param in testParameters)
      {
        yield return new object[] { param };
      }
    }

    [Theory]
    [MemberData(nameof(generateXUnitCompatibleTestInputs))]
    public void ShouldNotDivideByZero((int dividend, int divisor, int expected) testParameters)
    {
      var actual = new Solution().Divide(testParameters.dividend, testParameters.divisor);
      Assert.Equal(testParameters.expected, actual);
    }
  }
}
