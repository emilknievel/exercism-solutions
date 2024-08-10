using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsValidLine(string text) => Regex.IsMatch(text, @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]");

    public string[] SplitLogLine(string text) => Regex.Split(text, "<[*^=-]*>");

    public int CountQuotedPasswords(string lines) =>
        Regex.Matches(lines, @""".*?password.*?""", RegexOptions.IgnoreCase | RegexOptions.Multiline).Count;

    public string RemoveEndOfLineText(string line) => Regex.Replace(line, @"end-of-line\d+", "");

    public string[] ListLinesWithPasswords(string[] lines) =>
        (from line in lines
            let match = Regex.Match(line, @"password\S+", RegexOptions.IgnoreCase)
            select match.Success ? $"{match.Value}: {line}" : $"--------: {line}").ToArray();
}
