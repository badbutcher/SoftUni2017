namespace _005.Interfaces
{
    public interface IHuman : ICitizen
    {
        string Name { get; }

        int Age { get; }
    }
}