using System;
using System.Collections.Generic;
using Xunit;

namespace visa_hackerrank_2021_01_23
{
  class Result
  {
    static string sortString(string unsorted)
    {
      var array = unsorted.ToLower().ToCharArray();
      Array.Sort(array);
      return new string(array).Trim();
    }

    // Answers the question: does the array "text" contain the array "note"?
    // Time complexity is O(sortedNote.Length * sortedText.Length)
    public static bool canConstructLetter(string text, string note)
    {
      // Sort the arrays
      var sortedText = sortString(text);
      string sortedNote = sortString(note);
      // Traverse note until a mismatch is found
      var noteIndex = 0;
      var textIndex = 0;
      var lastMatchIndex = 0;
      // Check every letter in note
      for (noteIndex = 0; noteIndex < sortedNote.Length; noteIndex++)
      {
        // Check every letter in text, starting with the last match (to avoid reusing letters)
        for (textIndex = lastMatchIndex; textIndex < sortedText.Length; textIndex++)
        {
          if (sortedNote[noteIndex] == sortedText[textIndex])
          {
            lastMatchIndex = textIndex + 1;
            break;
          }
        }
        if (textIndex == sortedText.Length)
        {
          return false;
        }
      }
      // Return the result
      return true;
    }
  }

  public class VisaHackerrank_Test
  {
    public static IEnumerable<object[]> generateXUnitCompatibleTestInputs()
    {
      var testParameters = new List<(string, string, bool)>() {
        ("The quick brown fox jumps over the lazy dog", "visa", true),
        ("aabbccdd", "abc", true),
        ("abc", "aabbcc", false),
        ("abc", "aaa", false),
        ("abc", "abd", false),
        ("abc", "abd", false),
        ("abc", " abc", true),
        ("zyx", " xyz", true),
        ("", "", true),
        ("", "      ", true),
      };
      foreach (var param in testParameters)
      {
        yield return new object[] { param };
      }
    }

    [Theory]
    [MemberData(nameof(generateXUnitCompatibleTestInputs))]
    public void GivenInputVerifyOutput((string text, string note, bool expected) testParameters)
    {
      var actual = Result.canConstructLetter(testParameters.text, testParameters.note);
      Assert.Equal(testParameters.expected, actual);
    }
  }
}
