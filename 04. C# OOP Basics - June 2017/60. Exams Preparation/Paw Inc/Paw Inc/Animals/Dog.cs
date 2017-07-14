public class Dog : Animal
{
    private int commandsLearned;

    public Dog(string name, int age, bool cleansingStatus, int commandsLearned, string adoptedAt)
        : base(name, age, cleansingStatus, adoptedAt)
    {
        this.CommandsLearned = commandsLearned;
    }

    public int CommandsLearned
    {
        get
        {
            return this.commandsLearned;
        }
        set
        {
            this.commandsLearned = value;
        }
    }
}