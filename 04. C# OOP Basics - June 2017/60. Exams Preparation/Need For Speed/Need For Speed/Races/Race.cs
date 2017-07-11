namespace Need_For_Speed.Races
{
    using System.Collections.Generic;
    using Need_For_Speed.Cars;

    public abstract class Race
    {
        private int lenght;
        private string route;
        private int prizePool;
        private List<Car> participants;

        public Race(int lenght, string route, int prizePool, List<Car> participants)
        {
            this.Lenght = lenght;
            this.Route = route;
            this.PrizePool = prizePool;
            this.Participants = participants;
        }

        public int Lenght
        {
            get
            {
                return this.lenght;
            }
            set
            {
                this.lenght = value;
            }
        }

        public string Route
        {
            get
            {
                return this.route;
            }
            set
            {
                this.route = value;
            }
        }

        public int PrizePool
        {
            get
            {
                return this.prizePool;
            }
            set
            {
                this.prizePool = value;
            }
        }

        public List<Car> Participants
        {
            get
            {
                return this.participants;
            }
            set
            {
                this.participants = value;
            }
        }
    }
}