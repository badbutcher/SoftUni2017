namespace _005
{
    using System;

    public class DateModifier
    {
        public int DifferenceInDates(DateTime start, DateTime end)
        {
            int result = Math.Abs((start - end).Days);
            return result;
        }
    }
}