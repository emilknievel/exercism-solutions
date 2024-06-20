using System;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {
        try
        {
            int result = operation switch
            {
                "/" => SimpleOperation.Division(operand1, operand2),
                "*" => SimpleOperation.Multiplication(operand1, operand2),
                "+" => SimpleOperation.Addition(operand1, operand2),
                "" => throw new ArgumentException("Operation can not be an empty string."),
                null => throw new ArgumentNullException(nameof(operation)),
                _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
            };

            return $"{operand1} {operation} {operand2} = {result}";
        }
        catch (DivideByZeroException e)
        {
            return "Division by zero is not allowed.";
        }
    }
}
