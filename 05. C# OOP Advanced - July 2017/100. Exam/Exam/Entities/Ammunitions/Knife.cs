public class Knife : Ammunition
{
    private const int Multiplayer = 100;
    private const double AmmoWeight = 0.4;

    public Knife(string name)
        : base(name, AmmoWeight, AmmoWeight * Multiplayer)
    {
    }
}