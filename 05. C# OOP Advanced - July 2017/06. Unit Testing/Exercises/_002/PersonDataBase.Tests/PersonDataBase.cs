namespace PersonDataBaseTests
{
    using System;
    using System.Linq;
    using _002;
    using NUnit.Framework;

    [TestFixture]
    public class TestClass
    {
        [Test]
        public void AddPerson()
        {
            PersonDataBase db = new PersonDataBase();
            Person person = new Person(0, "Pavel");

            db.Add(person);

            Assert.AreEqual(1, db.People.Where(a => a != null).Count());
        }

        [Test]
        public void AddPersonWithTakenId()
        {
            PersonDataBase db = new PersonDataBase();
            Person person = new Person(0, "Pavel");
            Person person2 = new Person(0, "Kamen");

            db.Add(person);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => db.Add(person2));
            Assert.That(ex.Message, Is.EqualTo("The given id is taken."));
        }

        [Test]
        public void AddPersonWithTakenName()
        {
            PersonDataBase db = new PersonDataBase();
            Person person = new Person(0, "Pavel");
            Person person2 = new Person(1, "Pavel");

            db.Add(person);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => db.Add(person2));
            Assert.That(ex.Message, Is.EqualTo("The given name is taken."));
        }

        [Test]
        public void RemovePerson()
        {
            PersonDataBase db = new PersonDataBase();
            Person person = new Person(0, "Pavel");

            db.Add(person);
            db.Remove();

            Assert.AreEqual(0, db.People.Where(a => a != null).Count());
        }

        [Test]
        public void FindPersonByName()
        {
            PersonDataBase db = new PersonDataBase();

            for (int i = 0; i < 4; i++)
            {
                db.Add(new Person(i, $"Pavel{i}"));
            }

            Person person = db.FindByUsername("Pavel2");

            Assert.IsNotNull(person);
        }

        [Test]
        public void FindPersonWithNullName()
        {
            PersonDataBase db = new PersonDataBase();

            for (int i = 0; i < 4; i++)
            {
                db.Add(new Person(i, $"Pavel{i}"));
            }

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => db.FindByUsername(null));
            Assert.That(ex.Message, Is.EqualTo("The given name is empty."));
        }

        [Test]
        public void DontFindPersonNotPresentInDb()
        {
            PersonDataBase db = new PersonDataBase();

            for (int i = 0; i < 4; i++)
            {
                db.Add(new Person(i, $"Pavel{i}"));
            }

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => db.FindByUsername("Gosho"));
            Assert.That(ex.Message, Is.EqualTo("User with Gosho was not found."));
        }

        [Test]
        public void FindPersonById()
        {
            PersonDataBase db = new PersonDataBase();

            for (int i = 0; i < 4; i++)
            {
                db.Add(new Person(i, $"Pavel{i}"));
            }

            Person person = db.FindById(3);

            Assert.IsNotNull(person);
        }

        [Test]
        public void DontFindPersonWithFakeId()
        {
            PersonDataBase db = new PersonDataBase();

            for (int i = 0; i < 4; i++)
            {
                db.Add(new Person(i, $"Pavel{i}"));
            }

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => db.FindById(55));
            Assert.That(ex.Message, Is.EqualTo("User with 55 was not found."));
        }

        [Test]
        public void DontFindPersonWithNegativeId()
        {
            PersonDataBase db = new PersonDataBase();

            for (int i = 0; i < 4; i++)
            {
                db.Add(new Person(i, $"Pavel{i}"));
            }

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => db.FindById(-123));
            Assert.That(ex.Message, Is.EqualTo("The given id is negative."));
        }
    }
}