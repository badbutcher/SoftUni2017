using System.Collections.Generic;

public abstract class Hardware
{
    private string name;
    private string type;
    private int maximumCapacity;
    private int maximumMemory;
    private Dictionary<string, Software> softwares;

    public Hardware(string name, string type, int maximumCapacity, int maximumMemory)
    {
        this.Name = name;
        this.Type = type;
        this.MaximumCapacity = maximumCapacity;
        this.MaximumMemory = maximumMemory;
        this.Softwares = new Dictionary<string, Software>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public string Type
    {
        get
        {
            return this.type;
        }
        set
        {
            this.type = value;
        }
    }

    public int MaximumCapacity
    {
        get
        {
            return this.maximumCapacity;
        }
        set
        {
            this.maximumCapacity = value;
        }
    }

    public int MaximumMemory
    {
        get
        {
            return this.maximumMemory;
        }
        set
        {
            this.maximumMemory = value;
        }
    }

    public Dictionary<string, Software> Softwares
    {
        get
        {
            return this.softwares;
        }
        set
        {
            this.softwares = value;
        }
    }
}