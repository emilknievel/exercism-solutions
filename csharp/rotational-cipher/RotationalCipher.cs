using System;
using System.Text;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        if (shiftKey is < 0 or > 26)
        {
            throw new ArgumentOutOfRangeException($"Key value {shiftKey} is outside the allowed range: `0 <= k <= 26`");
        }

        var alphabet = "abcdefghijklmnopqrstuvwxyz";
        var alphabetCap = alphabet.ToUpperInvariant();

        StringBuilder sb = new();
        foreach (char c in text)
        {
            var index = alphabet.IndexOf(c);
            if (index < 0)
            {
                var cUpper = char.ToUpperInvariant(c);
                index = alphabetCap.IndexOf(cUpper);
                if (index < 0)
                {
                    sb.Append(c);
                    continue;
                }
                sb.Append(GetRotChar(alphabetCap, cUpper, shiftKey));
                continue;
            }
            sb.Append(GetRotChar(alphabet, c, shiftKey));
        }
        return sb.ToString();
    }

    private static char GetRotChar(string s, char c, int shiftKey) => s[(s.IndexOf(c) + shiftKey) % 26];
}
