public class Cat : Animal
{
    private int intelligenceCoefficient;

    public Cat(string name, int age, bool cleansingStatus, int intelligenceCoefficient, string adoptedAt)
        : base(name, age, cleansingStatus, adoptedAt)
    {
        this.IntelligenceCoefficient = intelligenceCoefficient;
    }

    public int IntelligenceCoefficient
    {
        get
        {
            return this.intelligenceCoefficient;
        }
        set
        {
            this.intelligenceCoefficient = value;
        }
    }
}