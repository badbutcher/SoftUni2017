namespace Need_For_Speed.Races
{
    using System.Collections.Generic;
    using Need_For_Speed.Cars;

    public class DragRace : Race
    {
        public DragRace(int lenght, string route, int prizePool, List<Car> participants)
            : base(lenght, route, prizePool, participants)
        {
        }
    }
}