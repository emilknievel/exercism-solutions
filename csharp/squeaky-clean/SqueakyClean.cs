using System;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var sb = new StringBuilder();
        bool useUpper = false;

        foreach (char c in identifier)
        {
            if (c == ' ')
            {
                sb.Append('_');
                continue;
            }

            if (char.IsControl(c))
            {
                sb.Append("CTRL");
                continue;
            }

            if (c == '-')
            {
                useUpper = true;
                continue;
            }

            if (!char.IsLetter(c) || char.IsBetween(c, '\u03B1', '\u03C9'))
            {
                continue;
            }

            sb.Append(useUpper ? char.ToUpperInvariant(c) : c);
            useUpper = false;
        }

        return sb.ToString();
    }
}
