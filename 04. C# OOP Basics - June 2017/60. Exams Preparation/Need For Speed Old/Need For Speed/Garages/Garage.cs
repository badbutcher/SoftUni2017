using System.Collections.Generic;

public class Garage
{
    private List<int> parkedCars;

    public Garage()
    {
        this.ParkedCars = new List<int>();
    }

    public List<int> ParkedCars
    {
        get
        {
            return this.parkedCars;
        }
        set
        {
            this.parkedCars = value;
        }
    }
}