public class Anagram
{
    private static string _baseWordLower = "";
    private static string _baseWordSorted = "";

    public Anagram(string baseWord)
    {
        if (string.IsNullOrEmpty(baseWord)) return;

        _baseWordLower = baseWord.ToLower();
        _baseWordSorted = String.Concat(_baseWordLower.OrderBy(c => c));
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        List<string> anagrams = new();

        foreach (string potentialMatch in potentialMatches)
        {
            var potentialMatchLower = potentialMatch.ToLower();
            if (potentialMatchLower.Equals(_baseWordLower)) continue;

            var sorted = String.Concat(potentialMatchLower.OrderBy(c => c));
            if (sorted.Equals(_baseWordSorted))
            {
                anagrams.Add(potentialMatch);
            }
        }

        return anagrams.ToArray();
    }
}
