using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;

    public Nation()
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }

    public double GetTotalPower()
    {
        int monumentpercentageIncrease = this.monuments.Sum(a => a.TotalMonumentPower());
        double totalBenderPower = this.benders.Sum(a => a.GetPower());
        double totalPower = totalBenderPower / 100 * monumentpercentageIncrease;

        return totalBenderPower + totalPower;
    }

    public void AddBender(Bender bender)
    {
        this.benders.Add(bender);
    }

    public void AddMonument(Monument monument)
    {
        this.monuments.Add(monument);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Benders:");
        if (this.benders.Any())
        {
            sb.AppendLine().AppendLine(string.Join(Environment.NewLine, this.benders.Select(a => $"###{a}")));
        }
        else
        {
            sb.AppendLine(" None");
        }

        sb.Append("Monuments:");
        if (this.monuments.Any())
        {
            sb.AppendLine().Append(string.Join(Environment.NewLine, this.monuments.Select(a => $"###{a}")));
        }
        else
        {
            sb.Append(" None");
        }

        return sb.ToString();
    }

    public void DeclareDefeat()
    {
        this.benders.Clear();
        this.monuments.Clear();
    }
}