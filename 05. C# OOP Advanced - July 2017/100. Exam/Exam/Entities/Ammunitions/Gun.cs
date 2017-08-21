public class Gun : Ammunition
{
    private const int Multiplayer = 100;
    private const double AmmoWeight = 1.4;

    public Gun(string name)
        : base(name, AmmoWeight, AmmoWeight * Multiplayer)
    {
    }
}