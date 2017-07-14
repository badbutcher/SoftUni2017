public abstract class Animal
{
    private string name;
    private int age;
    private bool cleansingStatus;
    private string adoptedAt;

    public Animal(string name, int age, bool cleansingStatus, string adoptedAt)
    {
        this.Name = name;
        this.Age = age;
        this.CleansingStatus = false;
        this.AdoptedAt = adoptedAt;
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

    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            this.age = value;
        }
    }

    public bool CleansingStatus
    {
        get
        {
            return this.cleansingStatus;
        }
        set
        {
            this.cleansingStatus = value;
        }
    }

    public string AdoptedAt
    {
        get
        {
            return this.adoptedAt;
        }
        set
        {
            this.adoptedAt = value;
        }
    }
}