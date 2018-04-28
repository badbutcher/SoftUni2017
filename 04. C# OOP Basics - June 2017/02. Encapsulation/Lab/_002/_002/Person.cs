//namespace _002
//{
public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private double salary;

    public Person(string firstName, string lastName, int age, double salary)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.salary = salary;
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

    public double Salary
    {
        get
        {
            return this.salary;
        }
        private set
        {
            this.salary = value;
        }
    }

    public void IncreaseSalary(double bonus)
    {
        if (this.age > 30)
        {
            this.salary += this.salary * bonus / 100;
        }
        else
        {
            this.salary += this.salary * bonus / 200;
        }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
    }
}

//}