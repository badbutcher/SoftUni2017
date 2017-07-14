using System.Collections.Generic;

public abstract class Center
{
    private string name;
    private List<Animal> storedAnimals;

    public Center(string name, List<Animal> storedAnimals)
    {
        this.Name = name;
        this.StoredAnimals = storedAnimals;
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

    public List<Animal> StoredAnimals
    {
        get
        {
            return this.storedAnimals;
        }
        set
        {
            this.storedAnimals = value;
        }
    }
}