using System;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        var numberOfDigits = number.ToString().Length;
        return (int)number.ToString().Sum(num => Math.Pow(char.GetNumericValue(num), numberOfDigits)) == number;
    }
}