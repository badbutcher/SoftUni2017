public class LightSoftware : Software
{
    public LightSoftware(string name, string type, int capacityConsumption, int memoryConsumption)
        : base(name, type, capacityConsumption, memoryConsumption)
    {
        this.CapacityConsumption += (this.CapacityConsumption * 50) / 100;
        this.MemoryConsumption -= (this.MemoryConsumption * 50) / 100;
    }
}