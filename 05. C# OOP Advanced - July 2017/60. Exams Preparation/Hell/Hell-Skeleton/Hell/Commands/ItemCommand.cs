using System;

public class ItemCommand : Command
{
    public ItemCommand(string name, string heroName, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitpointsBonus, int damageBonus)
    {
        Name = name;
        HeroName = heroName;
        StrengthBonus = strengthBonus;
        AgilityBonus = agilityBonus;
        IntelligenceBonus = intelligenceBonus;
        HitpointsBonus = hitpointsBonus;
        DamageBonus = damageBonus;
    }

    public string Name { get; private set; }
    public string HeroName { get; private set; }
    public int StrengthBonus { get; private set; }
    public int AgilityBonus { get; private set; }
    public int IntelligenceBonus { get; private set; }
    public int HitpointsBonus { get; private set; }
    public int DamageBonus { get; private set; }

    public override string Execute()
    {
        throw new System.NotImplementedException();
    }
}