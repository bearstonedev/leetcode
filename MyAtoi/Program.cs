using System;

namespace leetcode
{
  public class Solution
  {
    private bool isPositive(char c)
    {
      return c == '+';
    }

    private bool isNegative(char c)
    {
      return c == '-';
    }

    private bool isNumeric(char c)
    {
      return this.isDigit(c) || this.isNegative(c) || this.isPositive(c);
    }

    private bool isDigit(char c)
    {
      return char.IsDigit(c);
    }

    private string reverse(string aString)
    {
      var result = "";
      for (int i = aString.Length - 1; i >= 0; i--)
      {
        result += aString[i];
      }

      return result;
    }

    private int convertToInteger(string theString, bool isNegative)
    {
      long multiplier = isNegative ? -1 : 1;
      long result = 0;
      foreach (char c in theString)
      {
        result = result * 10 + (c - '0') * multiplier;
        if (isNegative && result < Int32.MinValue)
        {
          return Int32.MinValue;
        }
        if (!isNegative && result > Int32.MaxValue)
        {
          return Int32.MaxValue;
        }
      }

      return Convert.ToInt32(result);
    }

    public int MyAtoi(string s)
    {
      s = s.TrimStart();
      if (s == string.Empty)
      {
        return 0;
      }

      var nextChar = s[0];
      if (!this.isNumeric(nextChar))
      {
        return 0;
      }

      var isNegative = this.isNegative(nextChar);
      if (!this.isDigit(nextChar))
      {
        s = s.Substring(1);
      }

      var numberSubstring = string.Empty;
      foreach (var c in s)
      {
        if (!isDigit(c))
        {
          break;
        }

        numberSubstring += c;
      }

      var result = this.convertToInteger(numberSubstring, isNegative);
      return result;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      var solution = new Solution();
      var testCases = new string[] {
        "hello",
        "1",
        "+1",
        "-1",
        "    +1",
        "    -1",
        "123",
        "word some 123",
        "123 word some",
        Int32.MinValue.ToString(),
        Int32.MaxValue.ToString(),
        Int64.MinValue.ToString(),
        Int64.MaxValue.ToString(),
        "   00000000123",
        "2147483648",
        "-6147483648",
        "10000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000522545459",
        "--2"
      };

      var expected = new int[] {
        0,
        1,
        1,
        -1,
        1,
        -1,
        123,
        0,
        123,
        Int32.MinValue,
        Int32.MaxValue,
        Int32.MinValue,
        Int32.MaxValue,
        123,
        Int32.MaxValue,
        Int32.MinValue,
        Int32.MaxValue,
        0
      };

      var actual = new int[expected.Length];
      for (int i = 0; i < testCases.Length; i++)
      {
        actual[i] = solution.MyAtoi(testCases[i]);
        if (actual[i] != expected[i])
        {
          throw new Exception($"Test case \"{testCases[i]}\" failed. Expected {actual[i].ToString()} to be {expected[i].ToString()}.");
        }
        System.Console.WriteLine($"Test case \"{testCases[i]}\": {actual[i]}");
      }
    }
  }
}
