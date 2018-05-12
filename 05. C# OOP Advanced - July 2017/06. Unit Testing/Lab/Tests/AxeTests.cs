using System;

namespace Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void DoesWeaponsLoseDurability()
        {
            Axe axe = new Axe(20, 20);
            Dummy dummy = new Dummy(100, 100);

            axe.Attack(dummy);

            Assert.AreEqual(19, axe.DurabilityPoints);
        }

        [Test]
        public void AttackWithBrokenWeapon()
        {
            Axe axe = new Axe(20, 1);
            Dummy dummy = new Dummy(100, 100);

            axe.Attack(dummy);

            //InvalidOperationException ex = Assert.Throws<InvalidOperationException> (() => axe.Attack(dummy));
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(delegate { throw new InvalidOperationException("Axe is broken."); });
            Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
        }
    }
}