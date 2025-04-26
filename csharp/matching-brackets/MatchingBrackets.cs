public static class MatchingBrackets
{
    private static readonly Dictionary<char, char> BracketPairs = new()
    {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' }
    };

    public static bool IsPaired(string input)
    {
        if (string.IsNullOrEmpty(input))
            return true;

        Stack<char> stack = new();

        foreach (var c in input)
        {
            if (BracketPairs.ContainsKey(c))
            {
                stack.Push(c);
            }
            else if (BracketPairs.ContainsValue(c))
            {
                // If the stack is empty, we have a closing bracket without an opening one
                if (stack.Count == 0)
                    return false;

                // Get the last opening bracket
                char lastOpening = stack.Pop();

                // Check if the current closing bracket matches the last opening bracket
                if (BracketPairs[lastOpening] != c)
                    return false;
            }
        }

        // If the stack is empty, all brackets were properly matched
        return stack.Count == 0;
    }
}