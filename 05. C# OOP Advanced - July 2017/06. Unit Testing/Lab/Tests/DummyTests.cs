using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int AxeAttack = 2;
        private const int AxeDurability = 2;
        private const int DummyHealth = 20;
        private const int DummyXP = 20;
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyXP);
        }

        [Test]
        public void DummyLoseHealthOnAttack()
        {
            axe.Attack(dummy);

            Assert.AreEqual(18, dummy.Health);
        }

        [Test]
        public void DeadDummyThrowsExecptionIfAttacked()
        {
            axe.Attack(dummy);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(delegate { throw new InvalidOperationException("Dummy is dead."); });
            Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyGivesExp()
        {
            Axe powerAxe = new Axe(100, 100);
            Hero hero = new Hero("Pesho", powerAxe);

            hero.Attack(dummy);

            Assert.AreEqual(20, hero.Experience);
        }

        [Test]
        public void AliveDummyDoesNotGivesExp()
        {
            Hero hero = new Hero("Pesho", axe);

            hero.Attack(dummy);

            Assert.AreEqual(0, hero.Experience);
        }
    }
}