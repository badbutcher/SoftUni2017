using System.Collections.Generic;
using System.Linq;

public class DragRace : Race
{
    public DragRace(int lenght, string route, int prizePool, Dictionary<int, Car> participants)
        : base(lenght, route, prizePool, participants)
    {
    }

    public override int GetPP(int carId)
    {
        Car car = Participants.FirstOrDefault(a => a.Key == carId).Value;

        return (car.HorsePower / car.Acceleration);
    }
}