using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;

namespace HellTests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void AddItemToHeroInventory()
        {
            HeroInventory inv = new HeroInventory();
            CommonItem item = new CommonItem("Laptop", 50, 50, 50, 50, 50);
            inv.AddCommonItem(item);

            Type type = typeof(HeroInventory);
            HeroInventory heroInstance = (HeroInventory)Activator.CreateInstance(type);
            heroInstance.AddCommonItem(item);
            FieldInfo filed = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic).FirstOrDefault(a => a.Name == "commonItems");

            Dictionary<string, IItem> listOfItems = (Dictionary<string, IItem>)filed.GetValue(heroInstance);

            Assert.AreEqual(1, listOfItems.Count);
        }

        [Test]
        public void AddDuplicateItemToHeroInventory()
        {
            HeroInventory inv = new HeroInventory();
            CommonItem item = new CommonItem("Laptop", 50, 50, 50, 50, 50);

            inv.AddCommonItem(item);

            ArgumentException ex = Assert.Throws<ArgumentException>(() => inv.AddCommonItem(item));
            Assert.That(ex.Message, Is.EqualTo("An item with the same key has already been added."));
        }

        [Test]
        public void AddNewHero()
        {
            List<string> barbarian = new List<string>() { "Pavel", "Barbarian" };
            Type type = typeof(HeroManager);
            HeroManager heroManagerInstantce = (HeroManager)Activator.CreateInstance(type);
            FieldInfo filed = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic).FirstOrDefault(a => a.Name == "heroes");
            IDictionary<string, IHero> listOfHeroes = (IDictionary<string, IHero>)filed.GetValue(heroManagerInstantce);

            Assert.AreEqual("Created Barbarian - Pavel", heroManagerInstantce.AddHero(barbarian));
        }

        //[Test]
        //public void InspectHero()
        //{
        //    List<string> barbarian = new List<string>() { "Pavel", "Barbarian" };
        //    Type type = typeof(HeroManager);
        //    HeroManager heroManagerInstantce = (HeroManager)Activator.CreateInstance(type);
        //    FieldInfo filed = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic).FirstOrDefault(a => a.Name == "heroes");
        //    IDictionary<string, IHero> listOfHeroes = (IDictionary<string, IHero>)filed.GetValue(heroManagerInstantce);

        //    heroManagerInstantce.AddHero(barbarian);
        //    var myHero = listOfHeroes.FirstOrDefault(a => a.Value.Name == "Pavel");

        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("[Barbarian, Hero: Pavel, Class: Barbarian");
        //    sb.AppendLine("HitPoints: 350, Damage: 150");
        //    sb.AppendLine("Strength: 90");
        //    sb.AppendLine("Agility: 25");
        //    sb.AppendLine("Intelligence: 10");
        //    sb.AppendLine("Items: None\r\n]");

        //    var aasd = heroManagerInstantce.Inspect(barbarian);

        //    Assert.AreEqual(sb.ToString().Trim(), heroManagerInstantce.Inspect(barbarian));
        //}

        [Test]
        public void TestStrenghtBonus()
        {
            HeroInventory inv = new HeroInventory();
            CommonItem item = new CommonItem("Sword", 10, 10, 10, 10, 10);

            inv.AddCommonItem(item);

            Assert.AreEqual(10, inv.TotalStrengthBonus);
        }

        [Test]
        public void TestAgilityBonus()
        {
            HeroInventory inv = new HeroInventory();
            CommonItem item = new CommonItem("Sword", 10, 10, 10, 10, 10);

            inv.AddCommonItem(item);

            Assert.AreEqual(10, inv.TotalAgilityBonus);
        }

        [Test]
        public void TestIntelligenceBonus()
        {
            HeroInventory inv = new HeroInventory();
            CommonItem item = new CommonItem("Sword", 10, 10, 10, 10, 10);

            inv.AddCommonItem(item);

            Assert.AreEqual(10, inv.TotalIntelligenceBonus);
        }

        [Test]
        public void TestIHitPointsBonus()
        {
            HeroInventory inv = new HeroInventory();
            CommonItem item = new CommonItem("Sword", 10, 10, 10, 10, 10);

            inv.AddCommonItem(item);

            Assert.AreEqual(10, inv.TotalHitPointsBonus);
        }

        [Test]
        public void TestDamageBonus()
        {
            HeroInventory inv = new HeroInventory();
            CommonItem item = new CommonItem("Sword", 10, 10, 10, 10, 10);

            inv.AddCommonItem(item);

            Assert.AreEqual(10, inv.TotalDamageBonus);
        }
    }
}