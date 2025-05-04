public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var lowercaseLetters = word.ToLower().Where(l => char.IsLetter(l)).ToList();
        return lowercaseLetters.Distinct().Count() == lowercaseLetters.Count();
    }
}
