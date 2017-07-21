namespace _001
{
    public class Box<T>
    {
        private T value;

        public Box(T value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return $"{this.GetType().FullName}: {this.value}";
        }
    }
}