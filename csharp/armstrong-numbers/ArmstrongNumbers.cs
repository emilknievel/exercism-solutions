using System;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number) =>
        (int)number.ToString().Sum(num => Math.Pow(char.GetNumericValue(num), number.ToString().Length)) == number;
}