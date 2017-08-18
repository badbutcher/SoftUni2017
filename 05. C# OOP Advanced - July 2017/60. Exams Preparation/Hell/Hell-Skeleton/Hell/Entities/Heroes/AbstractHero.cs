using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public abstract class AbstractHero : IHero, IComparable<AbstractHero>
{
    private IInventory inventory;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;

    protected AbstractHero(string name)
    {
        this.Name = name;
    }

    protected AbstractHero(string name, long strength, long agility, long intelligence, long hitPoints, long damage)
    {
        this.Name = name;
        this.Strength = strength;
        this.Agility = agility;
        this.Intelligence = intelligence;
        this.HitPoints = hitPoints;
        this.Damage = damage;
        this.inventory = new HeroInventory();
    }

    public string Name { get; private set; }

    public long Strength
    {
        get { return this.strength + this.inventory.TotalStrengthBonus; }
        private set { this.strength = value; }
    }

    public long Agility
    {
        get { return this.agility + this.inventory.TotalAgilityBonus; }
        private set { this.agility = value; }
    }

    public long Intelligence
    {
        get { return this.intelligence + this.inventory.TotalIntelligenceBonus; }
        private set { this.intelligence = value; }
    }

    public long HitPoints
    {
        get { return this.hitPoints + this.inventory.TotalHitPointsBonus; }
        private set { this.hitPoints = value; }
    }

    public long Damage
    {
        get { return this.damage + this.inventory.TotalDamageBonus; }
        private set { this.damage = value; }
    }

    public long PrimaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    public long SecondaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    // REFLECTION
    public ICollection<IItem> Items
    {
        //get
        //{
        //    Type inventoryType = inventory.GetType();
        //    FieldInfo fieldInfo = inventoryType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(a => Attribute.IsDefined(a, typeof(ItemAttribute)));

        //    Dictionary<string, IItem> commandItems = (Dictionary<string, IItem>)fieldInfo.GetValue(this.inventory);

        //    return commandItems.Values;
        //}

        //get
        //{
        //    FieldInfo[] inventoryFieldsInfo = this.inventory.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        //    foreach (FieldInfo fi in inventoryFieldsInfo)
        //    {
        //        ItemAttribute itemAttribute = (ItemAttribute)fi.GetCustomAttributes(typeof(ItemAttribute), true).FirstOrDefault();

        //        if (itemAttribute != null)
        //        {
        //            Dictionary<string, IItem> itemRaw = (Dictionary<string, IItem>)fi.GetValue(this.inventory);

        //            return itemRaw.Select(a => a.Value).ToList();
        //        }
        //    }

        //    throw new InvalidOperationException("Hero has no items");
        //}

        get
        {
            Type typeOfInventory = typeof(HeroInventory);
            FieldInfo[] fieldInfo = typeOfInventory.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo commandItemsStorage = fieldInfo.FirstOrDefault(a => a.GetCustomAttribute<ItemAttribute>() != null);

            IDictionary dictinary = (IDictionary)commandItemsStorage.GetValue(this.inventory);

            Dictionary<string, IItem> newDictinary = CastDict(dictinary).ToDictionary(a => (string)a.Key, a => (IItem)a.Value);

            var sortedItmes = new IItem[newDictinary.Values.Count];
            var counter = 0;

            foreach (var item in newDictinary.Values)
            {
                sortedItmes[counter++] = item;
            }

            return sortedItmes;
        }
    }

    private IEnumerable<DictionaryEntry> CastDict(IDictionary dictinary)
    {
        foreach (DictionaryEntry entry in dictinary)
        {
            yield return entry;
        }
    }

    public void AddRecipe(Recipe recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }

    public int CompareTo(AbstractHero other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (ReferenceEquals(null, other))
        {
            return 1;
        }

        var primary = this.PrimaryStats.CompareTo(other.PrimaryStats);
        if (primary != 0)
        {
            return primary;
        }

        return this.SecondaryStats.CompareTo(other.SecondaryStats);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Hero: {this.Name}, Class: {GetType().Name}");
        sb.AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}");
        sb.AppendLine($"Strength: {this.Strength}");
        sb.AppendLine($"Agility: {this.Agility}");
        sb.AppendLine($"Intelligence: {this.Intelligence}");
        if (this.Items.Count > 0)
        {
            sb.AppendLine($"Items:");
            foreach (var item in this.Items)
            {
                sb.AppendLine(item.ToString());
            }
        }
        else
        {
            sb.AppendLine($"Items: None");
        }

        return sb.ToString();
    }
}