﻿public class WaterMonument : Monument
{
    private int waterAffinity;

    public WaterMonument(string name, int waterAffinity)
        : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    public int WaterAffinity
    {
        get
        {
            return this.waterAffinity;
        }
        set
        {
            this.waterAffinity = value;
        }
    }

    public override int TotalMonumentPower()
    {
        return this.WaterAffinity;
    }

    public override string ToString()
    {
        return base.ToString() + $", Water Affinity: {this.WaterAffinity}";
    }
}