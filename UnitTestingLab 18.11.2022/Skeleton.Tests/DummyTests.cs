using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private int dummyDefaultHealth = 20;
        private int dummyDefaultExpirience = 100;

        [SetUp]
        public void SetUp()
        {
            dummy = new Dummy(dummyDefaultHealth, dummyDefaultExpirience);
        }

        [Test]
        public void Test_DummyLoosesHealthIfAttacked()
        {
            dummy.TakeAttack(15);
            Assert.AreEqual(5, dummy.Health);
        }

        [Test]
        public void Test_DeadDummyShouldTrowExceptionWhenAttacked()
        {
            dummy = new Dummy(0, 100);
            Assert.Throws<InvalidOperationException>(() =>
            dummy.TakeAttack(20),
            "Dead dummy should thow exception when TakeAttack() method is invoked!"
            );
        }

        [Test]
        public void Test_DeadDummyCanGiveExpirience()
        {
            dummy = new Dummy(0, 100);

            Assert.AreEqual(100, dummy.GiveExperience());
        }

        [Test]
        public void Test_AliveDummyCantGiveExpirience()
        {
            Assert.Throws<InvalidOperationException>(() =>
            dummy.GiveExperience(), "Alive dummy should thow exception when GiveExpirience() method is invoked!");
        }
    }
}