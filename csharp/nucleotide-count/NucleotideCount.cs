using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        var results = new Dictionary<char, int>()
        {
            { 'A', 0 },
            { 'C', 0 },
            { 'G', 0 },
            { 'T', 0 },
        };

        foreach (char c in sequence)
        {
            if (!results.ContainsKey(c))
                throw new ArgumentException($"{c} is not a valid nucleotide");

            results[c]++;
        }

        return results;
    }
}
