public class Assassin : AbstractHero
{
    private const int StrengthPointsCreate = 25;
    private const int AgilityPointsCreate = 100;
    private const int IntelligencePointsCreate = 15;
    private const int HitPointsCreate = 150;
    private const int DamagePointsCreate = 300;

    public Assassin(string name)
        : base(name, StrengthPointsCreate, AgilityPointsCreate, IntelligencePointsCreate, HitPointsCreate, DamagePointsCreate)
    {
    }
}