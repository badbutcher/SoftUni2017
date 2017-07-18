using System;

public abstract class Harvester
{
    private string id;
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public string Id
    {
        get
        {
            return this.id;
        }
        private set
        {
            this.id = value;
        }
    }

    public double OreOutput
    {
        get
        {
            return this.oreOutput;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's OreOutput");
            }

            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get
        {
            return this.energyRequirement;
        }
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's EnergyRequirement");
            }

            this.energyRequirement = value;
        }
    }

    //public void FullMode()
    //{
    //    this.EnergyRequirement = this.EnergyRequirement;
    //    this.OreOutput = this.OreOutput;
    //}

    //public void HalfMode()
    //{
    //    this.EnergyRequirement -= (this.EnergyRequirement * 60) / 100;
    //    this.OreOutput -= (this.OreOutput * 50) / 100;
    //}

    //public void EnergyMode()
    //{
    //    this.EnergyRequirement = 0;
    //    this.OreOutput -= 0;
    //}
}