using System;
using System.Linq;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey) => shiftKey is < 0 or > 26
            ? throw new ArgumentOutOfRangeException($"Key value {shiftKey} is outside the allowed range: `0 <= k <= 26`")
            : new string(text.Select(c => Rotate(c, shiftKey)).ToArray());

    private static char Rotate(char c, int shiftKey)
    {
        if (!char.IsLetter(c)) return c;

        var start = char.IsLower(c) ? 'a' : 'A';
        return (char)(start + (c - start + shiftKey) % 26);
    }
}
