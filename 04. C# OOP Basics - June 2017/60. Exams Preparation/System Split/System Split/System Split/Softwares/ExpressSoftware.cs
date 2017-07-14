public class ExpressSoftware : Software
{
    public ExpressSoftware(string name, string type, int capacityConsumption, int memoryConsumption)
        : base(name, type, capacityConsumption, memoryConsumption)
    {
        this.MemoryConsumption += this.MemoryConsumption;
    }
}