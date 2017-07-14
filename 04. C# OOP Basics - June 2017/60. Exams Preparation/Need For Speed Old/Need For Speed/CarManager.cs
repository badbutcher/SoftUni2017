using System.Collections.Generic;
using System.Linq;

public class CarManager
{
    private Dictionary<int, Car> cars = new Dictionary<int, Car>();
    private Garage garage = new Garage();
    private Dictionary<int, Race> races = new Dictionary<int, Race>();

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        if (type == "Performance")
        {
            cars.Add(id, new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability, new List<string>()));
        }
        else if (type == "Show")
        {
            cars.Add(id, new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability, 0));
        }
    }

    public string Check(int id)
    {
        Car car = cars.FirstOrDefault(a => a.Key == id).Value;

        return car.ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        if (type == "Casual")
        {
            Race race = new CasualRace(length, route, prizePool, new Dictionary<int, Car>());
            races.Add(id, race);
        }
        else if (type == "Drag")
        {
            Race race = new DragRace(length, route, prizePool, new Dictionary<int, Car>());
            races.Add(id, race);
        }
        else if (type == "Drift")
        {
            Race race = new DriftRace(length, route, prizePool, new Dictionary<int, Car>());
            races.Add(id, race);
        }
    }

    public void Participate(int carId, int raceId)
    {
        Car car = cars.FirstOrDefault(a => a.Key == carId).Value;
        Race race = races.FirstOrDefault(a => a.Key == raceId).Value;

        if (car != null)
        {
            race.Participants.Add(carId, car);
        }
    }

    public string Start(int id)
    {
        Race race = races.FirstOrDefault(a => a.Key == id).Value;

        if (race.Participants.Count == 0)
        {
            return "Cannot start the race with zero participants.";
        }

        races.Remove(id);
        return race.ToString();
    }

    public void Park(int id)
    {
        foreach (var item in races)
        {
            if (!item.Value.Participants.ContainsKey(id))
            {
                if (!garage.ParkedCars.Contains(id))
                {
                    garage.ParkedCars.Add(id);
                }
            }
        }
    }

    public void Unpark(int id)
    {
        garage.ParkedCars.Remove(id);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        foreach (var item in garage.ParkedCars)
        {
            cars[item].Tune(tuneIndex, addOn);
        }
    }
}