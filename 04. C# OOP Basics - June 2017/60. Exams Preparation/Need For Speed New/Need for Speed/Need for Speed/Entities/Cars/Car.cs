using System.Text;

public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsepower;
    private int acceleration;
    private int suspension;
    private int durability;

    public Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        this.brand = brand;
        this.model = model;
        this.yearOfProduction = yearOfProduction;
        this.horsepower = horsepower;
        this.acceleration = acceleration;
        this.suspension = suspension;
        this.durability = durability;
    }

    public string Brand
    {
        get
        {
            return this.brand;
        }
        set
        {
            this.brand = value;
        }
    }

    public string Model
    {
        get
        {
            return this.model;
        }
        set
        {
            this.model = value;
        }
    }

    public int YearOfProduction
    {
        get
        {
            return this.yearOfProduction;
        }
        set
        {
            this.yearOfProduction = value;
        }
    }

    public int HorsePower
    {
        get
        {
            return this.horsepower;
        }
        set
        {
            this.horsepower = value;
        }
    }

    public int Acceleration
    {
        get
        {
            return this.acceleration;
        }
        set
        {
            this.acceleration = value;
        }
    }

    public int Suspension
    {
        get
        {
            return this.suspension;
        }
        set
        {
            this.suspension = value;
        }
    }

    public int Durability
    {
        get
        {
            return this.durability;
        }
        set
        {
            this.durability = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{brand} {model} {yearOfProduction}");
        sb.AppendLine($"{horsepower} HP, 100 m/h in {acceleration} s");
        sb.AppendLine($"{suspension} Suspension force, {durability} Durability");

        return sb.ToString();
    }

    public virtual void Tune(int tuneIndex, string addon)
    {
        this.HorsePower += tuneIndex;
        this.Suspension += tuneIndex * 50 / 100;
    }
}