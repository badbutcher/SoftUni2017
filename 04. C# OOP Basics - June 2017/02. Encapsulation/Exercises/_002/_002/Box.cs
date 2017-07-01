namespace _002
{
    using System;

    public class Box
    {
        private decimal length;
        private decimal width;
        private decimal height;

        public Box(decimal length, decimal width, decimal height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public decimal GetVolume()
        {
            return this.Length * this.Width * this.Height;
        }

        public decimal GetLateralSurfaceArea()
        {
            return this.Length * this.Height * 2 + this.Width * this.Height * 2;
        }

        public decimal GetSurfaceArea()
        {
            return 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }
    }
}