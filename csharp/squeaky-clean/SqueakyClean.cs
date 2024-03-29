using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var sb = new StringBuilder();
        bool useUpper = false;

        foreach (char c in identifier)
        {
            sb.Append(c switch
            {
                _ when char.IsWhiteSpace(c) => '_',
                _ when char.IsControl(c) => "CTRL",
                _ when useUpper => char.ToUpperInvariant(c),
                _ when char.IsBetween(c, '\u03B1', '\u03C9') => default,
                _ when char.IsLetter(c) => c,
                _ => default
            });
            useUpper = c.Equals('-');
        }

        return sb.ToString();
    }
}
