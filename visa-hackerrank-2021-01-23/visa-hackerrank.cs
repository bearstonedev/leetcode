using System;
using System.Collections.Generic;
using Xunit;

namespace visa_hackerrank_2021_01_23
{
  public class Solution
  {

  }

  public class VisaHackerrank_Test
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
    public void GivenInputVerifyOutput((int dividend, int divisor, int expected) testParameters)
    {
      var actual = new Solution().Divide(testParameters.dividend, testParameters.divisor);
      Assert.Equal(testParameters.expected, actual);
    }
  }
}
