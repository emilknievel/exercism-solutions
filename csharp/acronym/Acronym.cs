public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        const string delimiters = " -_";
        var previous = ' ';
        var result = new System.Text.StringBuilder();

        foreach (char c in phrase)
        {
            if (delimiters.Contains(previous) && !delimiters.Contains(c))
                result.Append(char.ToUpper(c));
            previous = c;
        }

        return result.ToString();
    }
}