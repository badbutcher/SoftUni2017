namespace Need_For_Speed
{
    using System.Collections.Generic;
    using System.Linq;
    using Need_For_Speed.Cars;
    using Need_For_Speed.Races;

    public class CarManager
    {
        private Dictionary<int, Car> cars = new Dictionary<int, Car>();
        private Dictionary<int, Car> parkedCars = new Dictionary<int, Car>();
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

            return "CAR DATA";
        }

        public void Open(int id, string type, int length, string route, int prizePool)
        {
            if (type == "Casual")
            {
                Race race = new CasualRace(length, route, prizePool, new List<Car>());
                races.Add(id, race);
            }
            else if (type == "Drag")
            {
                Race race = new DragRace(length, route, prizePool, new List<Car>());
                races.Add(id, race);
            }
            else if (type == "Drift")
            {
                Race race = new DriftRace(length, route, prizePool, new List<Car>());
                races.Add(id, race);
            }
        }

        public void Participate(int carId, int raceId)
        {
            Car car = cars.FirstOrDefault(a => a.Key == carId).Value;
            Race race = races.FirstOrDefault(a => a.Key == raceId).Value;

            race.Participants.Add(car);
        }

        public string Start(int id)
        {
            return "START RACE";
        }

        public void Park(int id)
        {
            Car car = cars.FirstOrDefault(a => a.Key == id).Value;
            parkedCars.Add(id, car);
            cars.Remove(id);
        }

        public void Unpark(int id)
        {
            Car car = parkedCars.FirstOrDefault(a => a.Key == id).Value;
            cars.Add(id, car);
            parkedCars.Remove(id);
        }

        public void Tune(int tuneIndex, string addOn)
        {
            foreach (var car in parkedCars)
            {
                car.Value.Horsepower += tuneIndex / 2;
                car.Value.Suspension += tuneIndex / 2;

                if (car.Value.GetType().Name == "ShowCar")
                {
                    ShowCar showCar = (ShowCar)car.Value;
                    showCar.Stars += tuneIndex;
                }
                else if (car.Value.GetType().Name == "PerformanceCar")
                {
                    PerformanceCar performanceCar = (PerformanceCar)car.Value;
                    performanceCar.AddOns.Add(addOn);
                }
            }
        }
    }
}