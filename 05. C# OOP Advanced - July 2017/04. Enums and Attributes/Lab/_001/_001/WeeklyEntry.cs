//namespace _001
//{
using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    private WeekDay weekDay;

    public WeeklyEntry(string weekday, string notes)
    {
        Enum.TryParse(weekday, out this.weekDay);
        this.Notes = notes;
    }

    public WeekDay WeekDay
    {
        get
        {
            return this.weekDay;
        }
    }

    public string Notes { get; private set; }

    public int CompareTo(WeeklyEntry other)
    {
        if (this.WeekDay.CompareTo(other.WeekDay) > 0)
        {
            return this.WeekDay.CompareTo(other.WeekDay);
        }

        if (this.Notes.CompareTo(other.Notes) > 0)
        {
            return this.Notes.CompareTo(other.Notes);
        }

        return 0;
    }

    public override string ToString()
    {
        return $"{this.WeekDay} - {this.Notes}";
    }
}

//}