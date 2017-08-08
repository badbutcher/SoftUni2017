using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using _001;

namespace Database.Tests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestAddCommand()
        {
            DatabaseClass db = new DatabaseClass();

            db.Add(1);

            Assert.AreEqual(1, db.Items[0]);
        }

        [Test]
        public void TestAddOverflow()
        {
            DatabaseClass db = new DatabaseClass();

            for (int i = 0; i < 16; i++)
            {
                db.Add(i);
            }

            InvalidOperationException ex = Assert.Throws<InvalidOperationException> (() => db.Add(17));

            Assert.That(ex.Message, Is.EqualTo("Database size is bigger than 16"));
        }

        [Test]
        public void TestRemoveCommand()
        {
            DatabaseClass db = new DatabaseClass();

            db.Add(10);
            db.Remove();

            Assert.AreEqual(0, db.Items[0]);
        }

        [Test]
        public void TestRemoveEmptyArray()
        {
            DatabaseClass db = new DatabaseClass();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => db.Remove());

            Assert.That(ex.Message, Is.EqualTo("Database is empty"));
        }

        [Test]
        public void TestFetchAllCommand()
        {
            DatabaseClass db = new DatabaseClass();

            for (int i = 0; i <= 8; i++)
            {
                db.Add(i);
            }

            int[] items = db.FetchAll();
            Assert.AreEqual(8, items.Length);
        }
    }
}
