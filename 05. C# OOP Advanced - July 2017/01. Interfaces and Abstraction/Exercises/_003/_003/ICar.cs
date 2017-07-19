namespace _003
{
    public interface ICar
    {
        string Model { get; }

        string Driver { get; }

        string Break();

        string Start();
    }
}