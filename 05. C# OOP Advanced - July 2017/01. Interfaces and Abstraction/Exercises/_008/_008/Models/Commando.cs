namespace _008.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _008.Interfaces;

    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, double salary, string corp, IList<IMissions> missions)
            : base(id, firstName, lastName, salary, corp)
        {
            this.Missions = missions;
        }

        public IList<IMissions> Missions { get; private set; }

        public void CompleteMission()
        {
        }

        public override string ToString()
        {
            var sb = new StringBuilder($"{base.ToString()}" + Environment.NewLine);
            sb.AppendLine("Missions:");
            sb.AppendLine($"  {string.Join(Environment.NewLine + "  ", this.Missions)}");
            return sb.ToString().Trim();
        }
    }
}