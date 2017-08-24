public class MachineGun : Ammunition
{
    private const int Multiplayer = 100;
    private const double AmmoWeight = 10.6;

    public MachineGun(string name)
        : base(name, AmmoWeight, AmmoWeight * Multiplayer)
    {
    }
}