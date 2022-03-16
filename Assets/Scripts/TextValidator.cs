using System.Text.RegularExpressions;
using UnityEngine;

public class TextValidator
{
    public bool TryMatchInteger(string input, out int result)
    {
        if (Regex.IsMatch(input, @"^[0-9]+$"))
        {
            result = int.Parse(input);
            result = (int)Mathf.Clamp(result, 0, 1f);
            return true;
        }

        result = 0;
        return false;
    }

    public bool TryMatchFloat(string input, out float result)
    {
        if (Regex.IsMatch(input, @"^[0-9]*\.[0]+$"))
        {
            result = 0;
            return false;
        }
        
        if (Regex.IsMatch(input, @"^[0-9]*\.[0-9]+$"))
        {
            result = float.Parse(input);
            result = Mathf.Clamp(result, 0, 1f);
            return true;
        }

        result = 0;
        return false;
    }

    public static string ValidateToInt(string text)
    {
        return Regex.Replace(text, @"[^0-9]", "");
    }

    public static string ValidateToFloat(string text)
    {
        var input = RemoveWrongCharacters(text);

        if (input == ".")
        {
            return "0.";
        }

        if (input == "1.")
        {
            return "1";
        }

        if (TryRemoveRecurringDots(input, out var result))
        {
            return result;
        }

        return input;
    }

    private static string RemoveWrongCharacters(string text)
    {
        return Regex.Replace(text, @"[^0-9\.]", "");
    }

    private static bool TryRemoveRecurringDots(string input, out string result)
    {
        if (Regex.IsMatch(input, @"[0-9]+\.{2,}"))
        {
            result = Regex.Match(input, @"[0-9]+\.").Value;
            return true;
        }

        result = null;
        return false;
    }
}
