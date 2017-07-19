namespace _007.Interfaces
{
    public interface ICitizen : IIdentify, IBuyer, IBirthdate
    {
        string Name { get; }

        int Age { get; }
    }
}