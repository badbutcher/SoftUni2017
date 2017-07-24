namespace _001
{
    public class Box<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().FullName}: {this.Value}";
        }
    }
}