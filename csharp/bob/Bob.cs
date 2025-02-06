using System.Linq;

public static class Bob
{
    public static string Response(string statement)
    {
        var trimmed = statement.Trim();
        bool isSilence = string.IsNullOrWhiteSpace(trimmed);
        bool isQuestion = trimmed.EndsWith('?');
        bool hasLetters = trimmed.Any(char.IsLetter);
        bool isYelling = trimmed == trimmed.ToUpper() && hasLetters;

        if (isSilence) return "Fine. Be that way!";
        if (isQuestion)
        {
            return isYelling ? "Calm down, I know what I'm doing!" : "Sure.";
        }

        return isYelling ? "Whoa, chill out!" : "Whatever.";
    }
}