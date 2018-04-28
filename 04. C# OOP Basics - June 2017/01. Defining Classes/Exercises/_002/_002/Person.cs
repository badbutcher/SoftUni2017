//namespace _002
//{
public class Person
{
    public string Name { get; set; }

    public int Age { get; set; }

    public Person()
    {
        this.Name = "No name";
        this.Age = 1;
    }

    public Person(int age)
    {
        this.Name = "No name";
        this.Age = age;
    }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
}

//}