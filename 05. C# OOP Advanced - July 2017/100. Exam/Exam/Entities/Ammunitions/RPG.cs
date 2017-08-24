public class RPG : Ammunition
{
    private const int Multiplayer = 100;
    private const double AmmoWeight = 17.1;

    public RPG(string name)
        : base(name, AmmoWeight, AmmoWeight * Multiplayer)
    {
    }
}