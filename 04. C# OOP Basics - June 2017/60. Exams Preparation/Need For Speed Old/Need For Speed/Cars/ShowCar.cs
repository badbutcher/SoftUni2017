public class ShowCar : Car
{
    private int stars;

    public ShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability, int stars)
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.Stars = stars;
    }

    public int Stars
    {
        get
        {
            return this.stars;
        }
        set
        {
            this.stars = value;
        }
    }

    public override void Tune(int tuneIndex, string addon)
    {
        base.Tune(tuneIndex, addon);
        this.Stars += tuneIndex;
    }

    public override string ToString()
    {
        return base.ToString() + $"{Stars} *";
    }
}