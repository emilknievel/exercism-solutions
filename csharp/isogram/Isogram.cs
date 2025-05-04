public static class Isogram
{
    private static char[] _exceptions = [' ', '-'];

    public static bool IsIsogram(string word)
    {
        var seen = new HashSet<char>();

        foreach (char letter in word.ToLower())
        {
            if (_exceptions.Contains(letter)) continue;
            if (seen.Contains(letter)) return false;
            seen.Add(letter);
        }

        return true;
    }
}
