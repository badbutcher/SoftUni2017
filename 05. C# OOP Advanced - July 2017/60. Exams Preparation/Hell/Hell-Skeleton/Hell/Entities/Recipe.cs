using System.Collections.Generic;

public class Recipe : IRecipe
{
    public Recipe(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus, IList<string> requiredItems)
    {
        this.Name = name;
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = intelligenceBonus;
        this.HitPointsBonus = hitPointsBonus;
        this.DamageBonus = damageBonus;
        this.RequiredItems = requiredItems;
    }

    public string Name { get; private set; }

    public long StrengthBonus { get; private set; }

    public long AgilityBonus { get; private set; }

    public long IntelligenceBonus { get; private set; }

    public long HitPointsBonus { get; private set; }

    public long DamageBonus { get; private set; }

    public IList<string> RequiredItems { get; private set; }
}