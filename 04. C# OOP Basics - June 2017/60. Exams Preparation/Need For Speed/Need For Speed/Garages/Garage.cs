namespace Need_For_Speed.Garages
{
    using System.Collections.Generic;
    using Need_For_Speed.Cars;

    public class Garage
    {
        private List<Car> parkedCars;

        public Garage(List<Car> parkedCars)
        {
            this.ParkedCars = parkedCars;
        }

        public List<Car> ParkedCars
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
}