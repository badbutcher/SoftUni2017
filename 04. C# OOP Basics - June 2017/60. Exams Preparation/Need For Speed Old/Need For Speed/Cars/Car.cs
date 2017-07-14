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
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.HorsePower = horsepower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
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

    public virtual void Tune(int tuneIndex, string addon)
    {
        this.HorsePower += tuneIndex;
        this.Suspension += (tuneIndex * 50) / 100;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{Brand} {Model} {YearOfProduction}");
        sb.AppendLine($"{HorsePower} HP, 100 m/h in {Acceleration} s");
        sb.AppendLine($"{Suspension} Suspension force, {Durability} Durability");

        return sb.ToString();
    }
}