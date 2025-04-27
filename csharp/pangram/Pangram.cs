public static class Pangram
{
    private static readonly string Alphabet = "abcdefghijklmnopqrstuvwxyz";

    public static bool IsPangram(string input)
    {
        var inputLowerCase = input.ToLower();
        return Alphabet.All(inputLowerCase.Contains);
    }
}