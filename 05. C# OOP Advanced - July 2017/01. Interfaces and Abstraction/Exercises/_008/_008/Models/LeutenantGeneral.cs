namespace _008.Models
{
    using _008.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        public LeutenantGeneral(string id, string firstName, string lastName, double salary, IList<ISoldier> soldiers)
            : base(id, firstName, lastName, salary)
        {
            this.Soldiers = soldiers;
        }

        public IList<ISoldier> Soldiers { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder($"{base.ToString()}" + Environment.NewLine);
            sb.AppendLine("Privates:");
            sb.AppendLine($"  {string.Join(Environment.NewLine + "  ", this.Soldiers)}");
            return sb.ToString().Trim();
        }
    }
}