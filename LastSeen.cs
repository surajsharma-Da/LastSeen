using System;

public class LastSeenUtility
{
    public string ShowLastSeen(DateTime ls)
    {
        string lastseen;
        DateTime current = DateTime.Now;
        int diffinY = DifferenceInYears(ls, current);
        int diffinM = DifferenceInMonths(ls, current);
        int diffinD = DifferenceInDays(ls, current);
        int diffinH = DifferenceInHours(ls, current);
        int diffinMin = CountMinutes(ls,current);
        if (current.CompareTo(ls) < 0) return "The provided last seen DateTime is later than the current DateTime";
        lastseen = (diffinY > 0) ? diffinY.ToString() + " years" : "";                   
        lastseen = (String.IsNullOrEmpty(lastseen) && (diffinM > 0)) ? diffinM.ToString() + " months" :lastseen+"" ;
        lastseen = (String.IsNullOrEmpty(lastseen) && (diffinD > 0)) ? diffinD.ToString() + " Days" :lastseen+"" ;
        lastseen = (String.IsNullOrEmpty(lastseen) && (diffinH > 0)) ? diffinH.ToString() + " hours" :lastseen+"" ;
        lastseen = (String.IsNullOrEmpty(lastseen) && (diffinMin > 0)) ? diffinMin.ToString() + " minutes" : lastseen + "";
        return "Last Seen "+ lastseen;
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
            return (12 - start.Month) + end.Month;
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
