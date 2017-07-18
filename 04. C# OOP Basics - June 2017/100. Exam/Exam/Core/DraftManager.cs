using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private double totalEnergyStored;
    private double totalMinedPlumbus;
    private string mode;
    private List<Harvester> harvesters;
    private List<Provider> providers;

    public DraftManager()
    {
        this.totalEnergyStored = 0;
        this.totalMinedPlumbus = 0;
        this.mode = "Full";
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            string type = arguments[0];
            string id = arguments[1];
            double oreOutput = double.Parse(arguments[2]);
            double energyRequirement = double.Parse(arguments[3]);

            if (!CheckNamesExists(arguments))
            {
                foreach (var item in providers)
                {
                    totalEnergyStored += item.EnergyOutput;
                }

                Stuff();

                if (type == "Hammer")
                {
                    harvesters.Add(new HammerHarvester(id, oreOutput, energyRequirement));
                    return $"Successfully registered Hammer Harvester - {id}";
                }
                else
                {
                    harvesters.Add(new SonicHarvester(id, oreOutput, energyRequirement, int.Parse(arguments[4])));
                    return $"Successfully registered Sonic Harvester - {id}";
                }
            }
            else
            {
                foreach (var item in providers)
                {
                    totalEnergyStored += item.EnergyOutput;
                }
                Stuff();

                return $"Harvester is not registered, because of it's Id";
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            string type = arguments[0];
            string id = arguments[1];
            double energyOutput = double.Parse(arguments[2]);
            if (!CheckNamesExists(arguments))
            {
                foreach (var item in providers)
                {
                    totalEnergyStored += item.EnergyOutput;
                }
                Stuff();

                if (type == "Solar")
                {
                    providers.Add(new SolarProvider(id, energyOutput));
                    return $"Successfully registered Solar Provider - {id}";
                }
                else
                {
                    providers.Add(new PressureProvider(id, energyOutput));
                    return $"Successfully registered Solar Pressure - {id}";
                }
            }
            else
            {
                foreach (var item in providers)
                {
                    totalEnergyStored += item.EnergyOutput;
                }
                Stuff();

                return $"Provider is not registered, because of it's Id";
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string Day()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("A day has passed.");

        foreach (var item in providers)
        {
            totalEnergyStored += item.EnergyOutput;
        }

        var harvesterSum = harvesters.Sum(a => a.EnergyRequirement);
        var providersSum = providers.Sum(a => a.EnergyOutput);

        if (harvesterSum >= providersSum + totalEnergyStored)
        {
            sb.AppendLine($"Energy Provided: {providersSum}");
            sb.AppendLine($"Plumbus Ore Mined: 0");

            Stuff();

            return sb.ToString().Trim();
        }
        else
        {
            sb.AppendLine($"Energy Provided: {providersSum}");
            sb.AppendLine($"Plumbus Ore Mined: {harvesters.Sum(a => a.OreOutput)}");
            totalMinedPlumbus += harvesters.Sum(a => a.OreOutput);
            Stuff();
            return sb.ToString().Trim();
        }
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];

        foreach (var item in providers)
        {
            totalEnergyStored += item.EnergyOutput;
        }

        Stuff();
        return $"Successfully changed working mode to {arguments[0]} Mode";
    }

    public string Check(List<string> arguments)
    {
        Provider provider = providers.FirstOrDefault(a => a.Id == arguments[0]);
        Harvester harvester = harvesters.FirstOrDefault(a => a.Id == arguments[0]);

        if (provider == null && harvester == null)
        {
            return $"No element found with id – {arguments[0]}";
        }
        else if (provider == null)
        {
            foreach (var item in providers)
            {
                totalEnergyStored += item.EnergyOutput;
            }

            Stuff();
            return harvester.ToString();
        }
        else
        {
            foreach (var item in providers)
            {
                totalEnergyStored += item.EnergyOutput;
            }

            Stuff();
            return provider.ToString();
        }
    }

    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {totalEnergyStored}");
        sb.AppendLine($"Total Mined Plumbus Ore: {totalMinedPlumbus}");

        return sb.ToString().Trim();
    }

    private bool CheckNamesExists(List<string> arguments)
    {
        Provider provider = providers.FirstOrDefault(a => a.Id == arguments[1]);
        Harvester harvester = harvesters.FirstOrDefault(a => a.Id == arguments[1]);

        if (provider != null || harvester != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Stuff()
    {
        foreach (var item in harvesters)
        {
            if (item.EnergyRequirement <= totalEnergyStored)
            {
                totalEnergyStored -= item.EnergyRequirement;
            }
        }
    }
}