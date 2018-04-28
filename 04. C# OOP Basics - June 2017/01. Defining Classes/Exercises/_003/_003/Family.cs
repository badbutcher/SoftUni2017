namespace _003
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        public List<Person> People { get; set; } = new List<Person>();

        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.People.OrderByDescending(a => a.Age).First();
        }
    }
}