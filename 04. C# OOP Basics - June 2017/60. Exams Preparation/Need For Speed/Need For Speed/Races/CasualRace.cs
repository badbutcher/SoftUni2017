namespace Need_For_Speed.Races
{
    using System.Collections.Generic;
    using Need_For_Speed.Cars;

    public class CasualRace : Race
    {
        public CasualRace(int lenght, string route, int prizePool, List<Car> participants)
            : base(lenght, route, prizePool, participants)
        {
        }
    }
}