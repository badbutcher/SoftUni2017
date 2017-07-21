namespace _012
{
    public class Threeuple<T, F, G>
    {
        public Threeuple(T itemOne, F itemTwo, G itemThree)
        {
            this.ItemOne = itemOne;
            this.ItemTwo = itemTwo;
            this.ItemThree = itemThree;
        }

        public T ItemOne { get; private set; }

        public F ItemTwo { get; private set; }

        public G ItemThree { get; private set; }

        public override string ToString()
        {
            return $"{this.ItemOne} -> {this.ItemTwo} -> {this.ItemThree}";
        }
    }
}