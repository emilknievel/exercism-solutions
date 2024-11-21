using System;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        const int numberBase = 10;
        var digitsInNumber = (int)Math.Log10(number) + 1;
        var armstrong = 0;
        for (int i = 0; i < digitsInNumber; i++)
        {
            armstrong +=
                (int)Math.Pow(
                    (number % Math.Pow(numberBase, i + 1) - number % Math.Pow(numberBase, i)) / Math.Pow(numberBase, i),
                    digitsInNumber);
        }

        return armstrong == number;
    }
}