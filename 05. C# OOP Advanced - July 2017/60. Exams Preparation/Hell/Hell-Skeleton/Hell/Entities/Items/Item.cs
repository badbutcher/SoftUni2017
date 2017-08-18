public abstract class Item : IItem
{
    protected Item(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus)
    {
        this.Name = name;
        this.StrengthBonus = strengthBonus;
        this.AgilityBonus = agilityBonus;
        this.IntelligenceBonus = intelligenceBonus;
        this.HitPointsBonus = hitPointsBonus;
        this.DamageBonus = damageBonus;
    }

    public string Name { get; private set; }

    public long StrengthBonus { get; private set; }

    public long AgilityBonus { get; private set; }

    public long IntelligenceBonus { get; private set; }

    public long HitPointsBonus { get; private set; }

    public long DamageBonus { get; private set; }
}