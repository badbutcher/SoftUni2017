public class FireMonument : Monument
{
    private int fireAffinity;

    public FireMonument(string name, int fireAffinity)
        : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    public int FireAffinity
    {
        get
        {
            return this.fireAffinity;
        }
        set
        {
            this.fireAffinity = value;
        }
    }

    public override int TotalMonumentPower()
    {
        return this.FireAffinity;
    }

    public override string ToString()
    {
        return base.ToString() + $", Fire Affinity: {this.FireAffinity}";
    }
}