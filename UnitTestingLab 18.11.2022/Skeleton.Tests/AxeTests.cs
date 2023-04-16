using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
   

    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        private int axeDefaultAttack = 10;
        private int axeDefaultDurability = 15;
        private int dummyDefaultHealth = 20;
        private int dummyDefaultExpirience = 100;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(axeDefaultAttack, axeDefaultDurability);
            dummy = new Dummy(dummyDefaultHealth, dummyDefaultExpirience);
        }

        [Test]
        public void Test_DurabilityShouldDropWhenHitTarget()
        {
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(14), "Axe durability doesnt change after attack");
        }

        [Test]
        public void Test_AttackingWithZeroDurabilityPoints()
        {
            axe = new Axe(10, 0);

            Assert.Throws<InvalidOperationException>(() =>
            axe.Attack(dummy), "Axe is broken."
            );
        }
    }
}