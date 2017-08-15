namespace BashSoftTesting
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using BashSoft.Contracts;
    using BashSoft.DataStructures;

    [TestFixture]
    public class OrderedDataStructureTester
    {
        private ISimpleOrderedBag<string> names;

        [SetUp]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [Test]
        public void TestEmptyCtor()
        {
            this.names = new SimpleSortedList<string>();
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestCtorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);
            Assert.AreEqual(this.names.Capacity, 20);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);
            Assert.AreEqual(this.names.Capacity, 30);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestCtorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestAddIncreasesSize()
        {
            this.names.Add("Nasko");
            Assert.AreEqual(1, this.names.Size);
        }

        [Test]
        public void TestAddNullThrowsExeption()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => this.names.Add(null));
            Assert.That(ex.Message, Is.EqualTo("Cant add nulls"));
        }

        [Test]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");

            string[] sortedNames = new string[3] { "Balkan", "Georgi", "Rosen" };

            Assert.AreEqual(sortedNames, this.names);
        }

        [Test]
        public void TestAddingMoreThanInitialCapacity()
        {
            for (int i = 0; i < 17; i++)
            {
                this.names.Add("Pavel" + i);
            }
            
            Assert.AreEqual(17, this.names.Size);
        }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            List<string> list = new List<string>();

            list.Add("Rosen");
            list.Add("Georgi");
            this.names.AddAll(list);

            Assert.AreEqual(2, this.names.Size);
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            List<string> list = new List<string>();

            list.Add("Rosen");
            list.Add("Georgi");
            list.Add(null);
          
            ArgumentException ex = Assert.Throws<ArgumentException>(() => this.names.AddAll(list));
            Assert.That(ex.Message, Is.EqualTo("Cant add nulls"));
        }

        [Test]
        public void TestAddAllKeepsSorted()
        {
            List<string> list = new List<string>();

            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");
            this.names.AddAll(list);
            string[] sortedNames = new string[3] { "Balkan", "Georgi", "Rosen" };
           
            Assert.AreEqual(sortedNames, this.names);
        }

        [Test]
        public void TestRemoveValidElementDecreasesSize()
        {
            this.names.Add("Rosen");
            this.names.Remove("Rosen");

            Assert.AreEqual(0, this.names.Size);
        }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            this.names.Add("ivan");
            this.names.Add("nasko");
            this.names.Remove("ivan");

            Assert.AreEqual(1, this.names.Size);
        }

        [Test]
        public void TestRemovingNullThrowsException()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => this.names.Remove(null));
            Assert.That(ex.Message, Is.EqualTo("Cant remove nulls"));
        }

        [Test]
        public void TestJoinWithNull()
        {
            this.names.Add("ivan");
            this.names.Add("nasko");
            ArgumentException ex = Assert.Throws<ArgumentException>(() => this.names.JoinWith(null));
            Assert.That(ex.Message, Is.EqualTo("Cant join with null"));
        }

        [Test]
        public void TestJoinWorksFine()
        {
            this.names.Add("ivan");
            this.names.Add("nasko");
            string joined = this.names.JoinWith(", ");

            string result = "ivan, nasko";
            Assert.AreEqual(result, joined);
        }
    }
}
