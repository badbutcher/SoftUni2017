using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private List<string> warHistoryRecord = new List<string>();

    private Dictionary<string, Nation> nations = new Dictionary<string, Nation>()
        {
            {"Air", new Nation() },
            {"Water", new Nation() },
            {"Fire", new Nation() },
            {"Earth", new Nation() }
        };

    public void AssignBender(List<string> benderArgs)
    {
        string type = benderArgs[1];
        string name = benderArgs[2];
        int power = int.Parse(benderArgs[3]);
        double benderSecondStat = double.Parse(benderArgs[4]);

        switch (type)
        {
            case "Air":
                this.nations[type].AddBender(new AirBender(name, power, benderSecondStat));
                break;
            case "Water":
                this.nations[type].AddBender(new WaterBender(name, power, benderSecondStat));
                break;
            case "Fire":
                this.nations[type].AddBender(new FireBender(name, power, benderSecondStat));
                break;
            case "Earth":
                this.nations[type].AddBender(new EarthBender(name, power, benderSecondStat));
                break;
            default:
                break;
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[1];
        string name = monumentArgs[2];
        int affinity = int.Parse(monumentArgs[3]);

        switch (type)
        {
            case "Air":
                this.nations[type].AddMonument(new AirMonument(name, affinity));
                break;
            case "Water":
                this.nations[type].AddMonument(new WaterMonument(name, affinity));
                break;
            case "Fire":
                this.nations[type].AddMonument(new FireMonument(name, affinity));
                break;
            case "Earth":
                this.nations[type].AddMonument(new EarthMonument(name, affinity));
                break;
            default:
                break;
        }
    }

    public string GetStatus(string nationInfo)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{nationInfo} Nation").Append(this.nations[nationInfo]);

        return sb.ToString();
    }

    public void IssueWar(string warStarterNation)
    {
        double victoriousPower = this.nations.Max(a => a.Value.GetTotalPower());

        foreach (var item in this.nations.Values)
        {
            if (item.GetTotalPower() != victoriousPower)
            {
                item.DeclareDefeat();
            }
        }

        this.warHistoryRecord.Add($"War {this.warHistoryRecord.Count + 1} issued by {warStarterNation}");
    }

    public string GetWarRecords()
    {
        return string.Join(Environment.NewLine, this.warHistoryRecord);
    }
}