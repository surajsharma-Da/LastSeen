using System;

public class Class1
{
    public static void Main()
    {
        Class1 x = new Class1();
        Console.WriteLine(DateTime.Now);
        Console.WriteLine(x.ShowLastSeen(new DateTime(2020, 4, 20, 23, 2, 1, 31)));
        Console.WriteLine(new DateTime(2020, 4, 20, 23, 2, 1, 31));
        Console.ReadKey();
    }

    public string ShowLastSeen(DateTime ls)
    {
        string lastseen;
        DateTime current = DateTime.Now;
        int diffinY = DifferenceInYears(ls, current);
        int diffinM = DifferenceInMonths(ls, current);
        int diffinD = DifferenceInDays(ls, current);
        int diffinH = DifferenceInHours(ls, current);
        if (diffinY > 0)
        {
            lastseen = diffinY.ToString() + "years";
            return "Last seen " + lastseen;
        }
        else
        {
            if (diffinM > 0)
            {
                lastseen = CountMonths(ls, current).ToString() + "months";
                return "Last seen " + lastseen;
            }
            else
            {
                if (diffinD > 0)
                {
                    lastseen = CountDays(ls, current).ToString() + "days";
                    return "Last seen " + lastseen;
                }
                else
                {
                    if (diffinH>0)
                    {
                        lastseen = CountHours(ls, current).ToString() + "hours";
                        return "Last seen " + lastseen;
                    }
                    else
                    {
                        lastseen = CountMinutes(ls,current).ToString() + "minutes";
                        return "Last seen " + lastseen;
                    }
                }
            }
        }
    }
    public int DifferenceInYears(DateTime start, DateTime end)
    {
        return (end.Year - start.Year - 1) +
            (((end.Month > start.Month) ||
            ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
    }
    public int DifferenceInMonths(DateTime start, DateTime end)
    {
        return (CountMonths(start,end)-1) +
            (((end.Day > start.Day) ||
            ((end.Day == start.Day) && (end.Hour >= start.Hour))) ? 1 : 0);
    }
    public int DifferenceInDays(DateTime start, DateTime end)
    {
        return (CountDays(start, end) - 1) +
            (((end.Hour > start.Hour) ||
            ((end.Hour == start.Hour) && (end.Minute >= start.Minute))) ? 1 : 0);
    }
    public int DifferenceInHours(DateTime start, DateTime end)
    {
        return (CountHours(start, end) - 1) +
            ((end.Minute>start.Minute) ? 1 : 0);
    }
    public int CountMonths(DateTime start, DateTime end)
    {
        if (start.Year != end.Year)
            return (12 - start.Month) + end.Month - 1;
        else
            return end.Month - start.Month;
    }
    public int CountDays(DateTime start, DateTime end)
    {
        if (start.Month != end.Month)
            return (DateTime.DaysInMonth(start.Year, start.Month) - start.Day) + end.Day;
        else
            return end.Day - start.Day;
    }
    public int CountHours(DateTime start, DateTime end)
    {
        if (start.Day != end.Day)
            return (24 - start.Hour) + end.Hour;
        else
            return end.Hour - start.Hour;
    }
    public int CountMinutes(DateTime start, DateTime end)
    {
        if (start.Hour != end.Hour)
            return (60 - start.Minute) + end.Minute;
        else return end.Minute - start.Minute;
    }
}
