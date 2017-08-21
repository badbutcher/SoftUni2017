public class NightVision : Ammunition
{
    private const int Multiplayer = 100;
    private const double AmmoWeight = 0.8;

    public NightVision(string name)
        : base(name, AmmoWeight, AmmoWeight * Multiplayer)
    {
    }
}