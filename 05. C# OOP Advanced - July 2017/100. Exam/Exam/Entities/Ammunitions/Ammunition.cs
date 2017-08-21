public abstract class Ammunition : IAmmunition
{
    protected Ammunition(string name, double weight, double wearLevel)
    {
        this.Name = name;
        this.Weight = weight;
        this.WearLevel = wearLevel;
    }

    public string Name { get; private set; }

    public double Weight { get; private set; }

    public double WearLevel { get; private set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}