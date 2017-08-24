public class AutomaticMachine : Ammunition
{
    private const int Multiplayer = 100;
    private const double AmmoWeight = 6.3;

    public AutomaticMachine(string name)
        : base(name, AmmoWeight, AmmoWeight * Multiplayer)
    {
    }
}