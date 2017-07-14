using System.Collections.Generic;

public class PerformanceCar : Car
{
    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability, List<string> addOns)
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.HorsePower += this.HorsePower * 50 / 100;
        this.Suspension -= this.Suspension * 25 / 100;
        this.AddOns = addOns;
    }

    public List<string> AddOns
    {
        get
        {
            return this.addOns;
        }
        set
        {
            this.addOns = value;
        }
    }

    public override void Tune(int tuneIndex, string addon)
    {
        base.Tune(tuneIndex, addon);
        this.AddOns.Add(addon);
    }

    public override string ToString()
    {
        if (AddOns.Count != 0)
        {
            return base.ToString() + $"Add-ons: {string.Join(", ", AddOns)}";
        }
        else
        {
            return base.ToString() + $"Add-ons: None";
        }
    }
}