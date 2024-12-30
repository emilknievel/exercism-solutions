using System;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

// TODO: use more datetime methods instead of manually calculating, e.g. AddDays() etc.
public class Meetup(int month, int year)
{
    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        switch (schedule)
        {
            case Schedule.Teenth:
            {
                for (int i = 13; i < 20; i++)
                {
                    var date = new DateTime(year, month, i);
                    if (date.DayOfWeek == dayOfWeek) return date;
                }

                break;
            }
            case Schedule.First:
            {
                for (int i = 1; i < 8; i++)
                {
                    var date = new DateTime(year, month, i);
                    if (date.DayOfWeek == dayOfWeek) return date;
                }

                break;
            }
            case Schedule.Second:
            {
                for (int i = 8; i < 15; i++)
                {
                    var date = new DateTime(year, month, i);
                    if (date.DayOfWeek == dayOfWeek) return date;
                }

                break;
            }
            case Schedule.Third:
            {
                for (int i = 15; i < 22; i++)
                {
                    var date = new DateTime(year, month, i);
                    if (date.DayOfWeek == dayOfWeek) return date;
                }

                break;
            }
            case Schedule.Fourth:
            {
                for (int i = 22; i < 29; i++)
                {
                    var date = new DateTime(year, month, i);
                    if (date.DayOfWeek == dayOfWeek) return date;
                }

                break;
            }
            case Schedule.Last when LongMonth(month):
            {
                for (int i = 31; i > 24; i--)
                {
                    var date = new DateTime(year, month, i);
                    if (date.DayOfWeek == dayOfWeek) return date;
                }

                break;
            }
            case Schedule.Last when month == 2:
            {
                if (DateTime.IsLeapYear(year))
                {
                    for (int i = 29; i > 22; i--)
                    {
                        var date = new DateTime(year, month, i);
                        if (date.DayOfWeek == dayOfWeek) return date;
                    }
                }
                else
                {
                    for (int i = 28; i > 21; i--)
                    {
                        var date = new DateTime(year, month, i);
                        if (date.DayOfWeek == dayOfWeek) return date;
                    }
                }

                break;
            }
            case Schedule.Last:
            {
                for (int i = 30; i > 23; i--)
                {
                    var date = new DateTime(year, month, i);
                    if (date.DayOfWeek == dayOfWeek) return date;
                }

                break;
            }
            default:
                throw new ArgumentOutOfRangeException(nameof(schedule), schedule, null);
        }

        throw new Exception("Invalid schedule");
    }

    private static bool LongMonth(int month) => month is 1 or 3 or 5 or 7 or 8 or 10 or 12;
}