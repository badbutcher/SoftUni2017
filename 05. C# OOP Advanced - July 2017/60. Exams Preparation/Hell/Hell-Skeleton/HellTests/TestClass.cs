using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace HellTests
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            HeroInventory inv = new HeroInventory();
            CommonItem item = new CommonItem("Laptop", 50, 50, 50, 50, 50);
            inv.AddCommonItem(item);

            Type type = typeof(HeroInventory);
            HeroInventory testInstance = (HeroInventory)Activator.CreateInstance(type);
            testInstance.AddCommonItem(item);
            FieldInfo filed = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic).FirstOrDefault(a => a.Name == "commonItems");

            Dictionary<string, IItem> asdasd = (Dictionary<string, IItem>)filed.GetValue(testInstance);

            Assert.AreEqual(1, asdasd.Count);
        }

        [Test]
        public void TestMethod2()
        {
            HeroInventory inv = new HeroInventory();
            CommonItem item = new CommonItem("Laptop", 50, 50, 50, 50, 50);
            inv.AddCommonItem(item);

            //Type type = typeof(HeroInventory);
            //HeroInventory testInstance = (HeroInventory)Activator.CreateInstance(type);
            //testInstance.AddCommonItem(item);
            //FieldInfo filed = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic).FirstOrDefault(a => a.Name == "commonItems");

            //Dictionary<string, IItem> asdasd = (Dictionary<string, IItem>)filed.GetValue(testInstance);

            ArgumentException ex = Assert.Throws<ArgumentException>(() => inv.AddCommonItem(item));

            Assert.That(ex.Message, Is.EqualTo("An item with the same key has already been added."));
        }

        [Test]
        public void TestMethod3()
        {
            //Arrange
            HeroInventory inv = new HeroInventory();
            CommonItem item = new CommonItem("Laptop", 50, 50, 50, 50, 50);
            CommonItem item2 = new CommonItem("Laptop2", 50, 22, 50, 50, 50);
            IRecipe recipe = new Recipe("FullLaptop", 100, 100, 100, 100, 100, new List<string>() { "Laptop", "Laptop1" });

            //Act
            inv.AddRecipeItem(recipe);
            inv.AddCommonItem(item);
            inv.AddCommonItem(item2);

            Type type = typeof(HeroInventory);
            HeroInventory testInstance = (HeroInventory)Activator.CreateInstance(type);
            MethodInfo method = type.GetMethod("CheckRecipes", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            method.Invoke(testInstance, new object[] { });

            //Dictionary<string, IItem> asdasd = (Dictionary<string, IItem>)filed.getv(testInstance);

            FieldInfo filed = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic).FirstOrDefault(a => a.Name == "commonItems");

            Dictionary<string, IItem> asdasd = (Dictionary<string, IItem>)filed.GetValue(testInstance);

            Assert.AreEqual(0, asdasd.Count);
        }
    }
}