namespace Cars.Data.Models
{
    using System;
    using Cars.Data.Models.Enums;

    public class Log
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Operation Operation { get; set; }

        public string TableName { get; set; }

        public DateTime TimeOfModification { get; set; }
    }
}
