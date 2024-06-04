using System;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        switch (shirtNum)
        {
            case 1:
                return "goalie";
            case 2:
                return "left back";
            case 3:
            case 4:
                return "center back";
            case 5:
                return "right back";
            case 6:
            case 7:
            case 8:
                return "midfielder";
            case 9:
                return "left wing";
            case 10:
                return "striker";
            case 11:
                return "right wing";
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public static string AnalyzeOffField(object report)
    {
        switch (report)
        {
            case int supporterCount:
                return $"There are {supporterCount} supporters at the match.";
            case string textReport:
                return textReport;
            case Incident incident:
                return GetIncidentReport(incident);
            case Manager manager:
                return manager.Club is not null ? $"{manager.Name} ({manager.Club})" : manager.Name;
            default:
                throw new ArgumentException();
        }
    }

    private static string GetIncidentReport(Incident incident)
    {
        switch (incident)
        {
            case Injury injury:
                return $"Oh no! {injury.GetDescription()} Medics are on the field.";
            default:
                return incident.GetDescription();
        }
    }
}