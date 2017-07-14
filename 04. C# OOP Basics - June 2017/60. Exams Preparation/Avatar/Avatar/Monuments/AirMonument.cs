public class AirMonument : Monument
{
    private int airAffinity;

    public AirMonument(string name, int airAffinity)
        : base(name)
    {
        this.AirAffinity = airAffinity;
    }

    public int AirAffinity
    {
        get
        {
            return this.airAffinity;
        }
        set
        {
            this.airAffinity = value;
        }
    }

    public override int TotalMonumentPower()
    {
        return this.AirAffinity;
    }

    public override string ToString()
    {
        return base.ToString() + $", Air Affinity: {this.AirAffinity}";
    }
}