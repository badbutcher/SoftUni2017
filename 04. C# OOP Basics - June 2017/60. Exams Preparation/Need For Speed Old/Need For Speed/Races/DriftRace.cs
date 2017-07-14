using System;
using System.Collections.Generic;
using System.Linq;

public class DriftRace : Race
{
    public DriftRace(int lenght, string route, int prizePool, Dictionary<int, Car> participants)
        : base(lenght, route, prizePool, participants)
    {
    }

    public override int GetPP(int carId)
    {
        Car car = Participants.FirstOrDefault(a => a.Key == carId).Value;

        return (car.Suspension + car.Durability);
    }
}