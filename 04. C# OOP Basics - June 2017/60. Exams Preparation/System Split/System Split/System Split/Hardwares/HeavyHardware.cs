public class HeavyHardware : Hardware
{
    public HeavyHardware(string name, string type, int maximumCapacity, int maximumMemory)
        : base(name, type, maximumCapacity, maximumMemory)
    {
        this.MaximumCapacity += this.MaximumCapacity;
        this.MaximumMemory -= (this.MaximumMemory * 25) / 100;
    }
}