//namespace _001
//{
public class Person
{
    private string firstName;
    private string lastName;
    private int age;

    public Person(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        private set
        {
            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        private set
        {
            this.lastName = value;
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        private set
        {
            this.age = value;
        }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
    }
}

//}