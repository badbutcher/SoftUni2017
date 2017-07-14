using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SystemManager
{
    private List<Hardware> hardwares;
    private List<Software> softwares;

    public SystemManager()
    {
        this.hardwares = new List<Hardware>();
        this.softwares = new List<Software>();
    }

    public void RegisterPowerHardware(string name, int capacity, int memory)
    {
        this.hardwares.Add(new PowerHardware(name, "Power", capacity, memory));
    }

    public void RegisterHeavyHardware(string name, int capacity, int memory)
    {
        this.hardwares.Add(new HeavyHardware(name, "Heavy", capacity, memory));
    }

    public void RegisterExpressSoftwar(string hardwareComponentName, string name, int capacity, int memory)
    {
        Hardware hardware = this.hardwares.FirstOrDefault(a => a.Name == hardwareComponentName);

        if (hardware != null)
        {
            Software software = new ExpressSoftware(name, "Express", capacity, memory);

            if (!(software.CapacityConsumption > hardware.MaximumCapacity || software.MemoryConsumption > hardware.MaximumMemory))
            {
                this.softwares.Add(software);
                hardware.Softwares.Add(name, software);
            }
        }
    }

    public void RegisterLightSoftware(string hardwareComponentName, string name, int capacity, int memory)
    {
        Hardware hardware = this.hardwares.FirstOrDefault(a => a.Name == hardwareComponentName);

        if (hardware != null)
        {
            Software software = new LightSoftware(name, "Light", capacity, memory);

            if (!(software.CapacityConsumption > hardware.MaximumCapacity || software.MemoryConsumption > hardware.MaximumMemory))
            {
                this.softwares.Add(software);
                hardware.Softwares.Add(name, software);
            }
        }
    }

    public void ReleaseSoftwareComponent(string hardwareComponentName, string softwareComponentName)
    {
        Hardware hardware = this.hardwares.FirstOrDefault(a => a.Name == hardwareComponentName);
        Software software = this.softwares.FirstOrDefault(a => a.Name == softwareComponentName);

        if (hardware != null && software != null)
        {
            hardware.Softwares.Remove(software.Name);
        }
    }

    public string Analyze()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("System Analysis");
        sb.AppendLine($"Hardware Components: {this.hardwares.Count}");
        sb.AppendLine($"Software Components: {this.softwares.Count}");
        sb.AppendLine($"Total Operational Memory: {this.softwares.Sum(a => a.MemoryConsumption)} / {this.hardwares.Sum(a => a.MaximumMemory)}");
        sb.AppendLine($"Total Capacity Taken: {this.softwares.Sum(a => a.CapacityConsumption)} / {this.hardwares.Sum(a => a.MaximumCapacity)}");

        return sb.ToString().Trim();
    }

    public string SystemSplit()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var item in this.hardwares)
        {
            sb.AppendLine($"Hardware Component - {item.Name}");
            sb.AppendLine($"Express Software Components - {item.Softwares.Where(a => a.Value.Type == "Express").Count()}");
            sb.AppendLine($"Light Software Components - {item.Softwares.Where(a => a.Value.Type == "Light").Count()}");
            sb.AppendLine($"Memory Usage: {item.Softwares.Sum(a => a.Value.MemoryConsumption)} / {item.MaximumMemory}");
            sb.AppendLine($"Capacity Usage: {item.Softwares.Sum(a => a.Value.CapacityConsumption)} / {item.MaximumCapacity}");
            sb.AppendLine($"Type: {item.Type}");
            if (item.Softwares.Keys.Count != 0)
            {
                sb.AppendLine($"Software Components: {string.Join(", ", item.Softwares.Keys)}");
            }
            else
            {
                sb.AppendLine($"Software Components: None");
            }
        }

        return sb.ToString().Trim();
    }
}