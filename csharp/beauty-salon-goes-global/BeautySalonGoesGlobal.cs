using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location) =>
        TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(appointmentDateDescription), GetLocationTimeZoneInfo(location));

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) =>
        alertLevel switch
        {
            AlertLevel.Early => appointment.AddDays(-1),
            AlertLevel.Standard => appointment.AddHours(-1).AddMinutes(-45),
            AlertLevel.Late => appointment.AddMinutes(-30),
            _ => throw new ArgumentOutOfRangeException(
                nameof(appointment),
                $"Unexpected appointment value: {appointment}"
            )
        };

    public static bool HasDaylightSavingChanged(DateTime dt, Location location) =>
        GetLocationTimeZoneInfo(location).IsDaylightSavingTime(dt) !=
        GetLocationTimeZoneInfo(location).IsDaylightSavingTime(dt.AddDays(-7));

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        return DateTime.TryParse(dtStr, GetLocationCultureInfo(location), out var normalizedDateTime)
            ? normalizedDateTime
            : new DateTime(1, 1, 1);
    }

    private static TimeZoneInfo GetLocationTimeZoneInfo(Location location)
    {
        var locationsOsxLinux = new Dictionary<Location, string>()
        {
            { Location.NewYork, "America/New_York" },
            { Location.London, "Europe/London" },
            { Location.Paris, "Europe/Paris" }
        };

        var locationsWindows = new Dictionary<Location, string>()
        {
            { Location.NewYork, "Eastern Standard Time" },
            { Location.London, "GMT Standard Time" },
            { Location.Paris, "W. Europe Standard Time" }
        };

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return TimeZoneInfo.FindSystemTimeZoneById(locationsWindows[location]);
        }

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return TimeZoneInfo.FindSystemTimeZoneById(locationsOsxLinux[location]);
        }

        throw new PlatformNotSupportedException(
            $"Platforms other than {OSPlatform.Windows}, {OSPlatform.Linux} or {OSPlatform.OSX} are not supported."
        );
    }

    private static CultureInfo GetLocationCultureInfo(Location location)
    {
        var locationCultureInfoDict = new Dictionary<Location, CultureInfo>()
        {
            { Location.NewYork, new CultureInfo("en-US") },
            { Location.London, new CultureInfo("en-GB") },
            { Location.Paris, new CultureInfo("fr-FR") }
        };

        return locationCultureInfoDict[location];
    }
}
