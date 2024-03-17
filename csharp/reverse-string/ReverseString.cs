using System;
using System.Linq;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        var inputArr = input.ToCharArray();
        Array.Reverse(inputArr);
        return new string(inputArr);
    }
}
