//namespace _001
//{
    using System.Collections.Generic;

    public class WeeklyCalendar
    {
        public WeeklyCalendar()
        {
            this.WeeklySchedule = new List<WeeklyEntry>();
        }

        public void AddEntry(string weekday, string notes)
        {
            this.WeeklySchedule.Add(new WeeklyEntry(weekday, notes));
        }

        public List<WeeklyEntry> WeeklySchedule { get; private set; }
    }
//}