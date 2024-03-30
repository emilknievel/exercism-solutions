using System;
using System.Collections.Generic;

public static class ProteinTranslation
{
    private static readonly Dictionary<string, string> proteins = new()
    {
        {"AUG", "Methionine"},

        {"UUU", "Phenylalanine"},
        {"UUC", "Phenylalanine"},

        {"UUA", "Leucine"},
        {"UUG", "Leucine"},

        {"UCU", "Serine"},
        {"UCC", "Serine"},
        {"UCA", "Serine"},
        {"UCG", "Serine"},

        {"UAU", "Tyrosine"},
        {"UAC", "Tyrosine"},

        {"UGU", "Cysteine"},
        {"UGC", "Cysteine"},

        {"UGG", "Tryptophan"},

        {"UAA", "STOP"},
        {"UAG", "STOP"},
        {"UGA", "STOP"},
    };

    public static string[] Proteins(string strand)
    {
        List<string> result = [];

        for (int i = 0; i < strand.Length; i += 3)
        {
            var codon = strand.Substring(i, 3);

            if (proteins.TryGetValue(codon, out string protein))
            {
                if (protein.Equals("STOP", StringComparison.Ordinal)) break;
                result.Add(protein);
            }
        }

        return [.. result];
    }
}
