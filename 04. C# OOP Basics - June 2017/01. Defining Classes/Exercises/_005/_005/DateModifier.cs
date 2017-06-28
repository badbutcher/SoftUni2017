namespace _005
{
    using System;

    public class DateModifier
    {
        public int DifferenceInDates(DateTime start, DateTime end)
        {
            var result = Math.Abs((start - end).Days);
            return result;
        }
    }
}