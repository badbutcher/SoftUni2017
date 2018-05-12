namespace FestivalManager.Entities
{
    using Contracts;

    public abstract class Instrument : IInstrument
    {
        private double wear;

        protected Instrument()
        {
            this.Wear = 100;
        }

        public double Wear
        {
            get
            {
                return this.wear;
            }
            private set
            {
                if (value < 0)
                {
                    this.wear = 0;
                }
                else if (value > 100)
                {
                    this.wear = 100;
                }
                else
                {
                    this.wear = value;
                }
            }
        }

        public bool IsBroken => this.Wear <= 0;

        protected abstract int RepairAmount { get; }

        public void Repair()
        {
            this.Wear += this.RepairAmount;
        }

        public void WearDown()
        {
            this.Wear -= this.RepairAmount;
        }

        public override string ToString()
        {
            var instrumentStatus = this.IsBroken ? "broken" : $"{this.Wear}%";

            return $"{this.GetType().Name} [{instrumentStatus}]";
        }
    }
}