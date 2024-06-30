using System;
using System.Globalization;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            return checked(@base * multiplier).ToString();
        }
        catch (OverflowException)
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier) =>
        DisplayDenomination((long)@base, (long)multiplier);

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            return (salaryBase * multiplier).ToString(CultureInfo.InvariantCulture);
        }
        catch (OverflowException)
        {
            return "*** Much Too Big ***";
        }
    }
}
