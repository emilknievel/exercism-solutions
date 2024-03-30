using System.Linq;
using System.Text;

public static class RomanNumeralExtension
{
    public static string ToRoman(this int value)
    {
        var stringValue = value.ToString();
        var sb = new StringBuilder();

        for (int i = 0; i < stringValue.Length; i++)
        {
            var ones = "";
            var fives = "";
            var tens = "";

            if (Number_IsOnes(i, stringValue.Length))
            {
                ones = "I";
                fives = "V";
                tens = "X";
            }
            else if (Number_IsTens(i, stringValue.Length))
            {
                ones = "X";
                fives = "L";
                tens = "C";
            }
            else if (Number_IsHundreds(i, stringValue.Length))
            {
                ones = "C";
                fives = "D";
                tens = "M";
            }
            else if (Number_IsThousands(i, stringValue.Length))
            {
                ones = "M";
            }

            var str = stringValue[i] switch
            {
                var c and ('1' or '2' or '3') => Number_RepeatNumeral(ones, int.Parse(c.ToString())),
                '4' => $"{ones}{fives}",
                '5' => fives,
                var c and ('6' or '7' or '8')
                    => $"{fives}{Number_RepeatNumeral(ones, int.Parse(c.ToString()) - 5)}",
                '9' => $"{ones}{tens}",
                _ => ""
            };

            sb.Append(str);
        }

        return sb.ToString();
    }

    private static bool Number_IsOnes(int index, int size) => index == size - 1;
    private static bool Number_IsTens(int index, int size) => index == size - 2;
    private static bool Number_IsHundreds(int index, int size) => index == size - 3;
    private static bool Number_IsThousands(int index, int size) => index == size - 4;
    private static string Number_RepeatNumeral(string numeral, int times)
        => string.Concat(Enumerable.Repeat(numeral, times));
}
