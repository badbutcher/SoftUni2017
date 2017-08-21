public class Helmet : Ammunition
{
    private const int Multiplayer = 100;
    private const double AmmoWeight = 2.3;

    public Helmet(string name)
        : base(name, AmmoWeight, AmmoWeight * Multiplayer)
    {
    }
}