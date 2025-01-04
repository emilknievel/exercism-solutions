using System;
using System.Collections.Generic;

public class Robot
{
    private string _name;

    public string Name
    {
        get
        {
            if (NameGenerator.Names.Contains(_name))
                return _name;

            _name = NameGenerator.NewName();
            return _name;
        }
    }

    public void Reset() => NameGenerator.Names.Remove(Name);
}

internal static class NameGenerator
{
    public static readonly List<string> Names = [];

    public static string NewName()
    {
        var name = GenerateName();
        while (Names.Contains(name))
        {
            name = GenerateName();
        }

        Names.Add(name);
        return name;
    }

    private static string GenerateName()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string digits = "0123456789";
        var random = new Random();

        return $"{chars[random.Next(chars.Length)]}" +
               $"{chars[random.Next(chars.Length)]}" +
               $"{digits[random.Next(digits.Length)]}" +
               $"{digits[random.Next(digits.Length)]}" +
               $"{digits[random.Next(digits.Length)]}";
    }
}
