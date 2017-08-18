public class Wizard : AbstractHero
{
    private const int StrengthPointsCreate = 25;
    private const int AgilityPointsCreate = 25;
    private const int IntelligencePointsCreate = 100;
    private const int HitPointsCreate = 100;
    private const int DamagePointsCreate = 250;
    public Wizard(string name)
        : base(name, StrengthPointsCreate, AgilityPointsCreate, IntelligencePointsCreate, HitPointsCreate, DamagePointsCreate)
    {
    }
}