using System;

public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        var sections = phoneNumber.Split("-");
        string dialingCode = sections[0];
        string prefixCode = sections[1];
        string lastDigits = sections[2];

        return (dialingCode == "212", prefixCode == "555", lastDigits);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
        => phoneNumberInfo.IsFake;
}
