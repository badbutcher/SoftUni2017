namespace _003
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        public List<Person> People { get; set; }

        public Family()
        {
            this.People = new List<Person>();
        }

        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
        {
            return People.OrderByDescending(a => a.Age).First();
        }
    }
}