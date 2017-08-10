namespace _002
{
    using System;
    using System.Linq;

    public class PersonDataBase
    {
        public PersonDataBase()
        {
            this.Index = 0;
            this.People = new Person[15];
        }

        public int Index { get; set; }

        public Person[] People { get; set; }

        public void Add(Person person)
        {
            if (this.Index >= 15)
            {
                throw new InvalidOperationException("Array is bigger than 16.");
            }

            var currentPeople = this.People.Where(a => a != null);

            if (currentPeople.Any(a => a.Id == person.Id))
            {
                throw new InvalidOperationException("The given id is taken.");
            }

            if (currentPeople.Any(a => a.Name == person.Name))
            {
                throw new InvalidOperationException("The given name is taken.");
            }

            this.People[this.Index] = person;
            this.Index++;
        }

        public void Remove()
        {
            if (this.Index <= 0)
            {
                throw new InvalidOperationException("Index is less than 0.");
            }

            this.Index--;
            this.People[this.Index] = null;
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new InvalidOperationException("The given id is negative.");
            }

            bool found = this.People.Where(x => x != null).Any(p => p.Id == id);

            if (!found)
            {
                throw new InvalidOperationException($"User with {id} was not found.");
            }

            return People.First(a => a.Id == id);
        }

        public Person FindByUsername(string username)
        {
            if (username == null)
            {
                throw new InvalidOperationException("The given name is empty.");
            }

            bool found = this.People.Where(x => x != null).Any(p => p.Name == username);

            if (!found)
            {
                throw new InvalidOperationException($"User with {username} was not found.");
            }

            return People.First(a => a.Name == username);
        }
    }
}