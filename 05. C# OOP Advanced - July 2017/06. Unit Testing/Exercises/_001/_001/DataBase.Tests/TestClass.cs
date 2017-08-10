namespace DataBase.Tests
{
    using System;
    using System.Linq;
    using _001;
    using NUnit.Framework;

    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestAddCommand()
        {
            DataBaseClass db = new DataBaseClass();

            db.Add(1);

            Assert.AreEqual(1, db.Items.Where(a => a != 0).Count());
        }

        [Test]
        public void TestAddCommandOverflow()
        {
            DataBaseClass db = new DataBaseClass();

            for (int i = 0; i < 15; i++)
            {
                db.Add(1);
            }

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => db.Add(1));

            Assert.That(ex.Message, Is.EqualTo("Array is bigger than 16."));
        }

        [Test]
        public void TestRemoveCommand()
        {
            DataBaseClass db = new DataBaseClass();

            db.Add(1);
            db.Remove();

            Assert.AreEqual(0, db.Items.Where(a => a != 0).Count());
        }

        [Test]
        public void TestRemoveFromEmptyArray()
        {
            DataBaseClass db = new DataBaseClass();
            
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => db.Remove());

            Assert.That(ex.Message, Is.EqualTo("Index is less than 0."));
        }

        [Test]
        public void FetchAllCommand()
        {
            DataBaseClass db = new DataBaseClass();

            for (int i = 0; i < 3; i++)
            {
                db.Add(1);
            }

            int[] dbItems = db.FetchAll();

            Assert.AreEqual(3, dbItems.Where(a => a != 0).Count());
        }
    }
}