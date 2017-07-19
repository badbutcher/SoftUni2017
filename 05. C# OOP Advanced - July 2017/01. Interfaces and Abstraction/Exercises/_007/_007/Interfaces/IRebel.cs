namespace _007.Interfaces
{
    public interface IRebel : IBuyer
    {
        string Name { get; }

        int Age { get; }

        string Group { get; }
    }
}