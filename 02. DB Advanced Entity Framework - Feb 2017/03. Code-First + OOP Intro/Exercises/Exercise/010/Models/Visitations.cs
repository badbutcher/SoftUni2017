namespace _010
{
    using _010.Models;
    using System;

    public class Visitations
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Comment { get; set; }

        public Patients Patients { get; set; }

        public Doctors Doctors { get; set; }
    }
}