namespace _011
{
    public class Tuple<T, F>
    {
        public Tuple(T itemOne, F itemTwo)
        {
            this.ItemOne = itemOne;
            this.ItemTwo = itemTwo;
        }

        public T ItemOne { get; private set; }

        public F ItemTwo { get; private set; }

        public override string ToString()
        {
            return $"{this.ItemOne} -> {this.ItemTwo}";
        }
    }
}