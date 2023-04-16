using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    [TestFixture]
    internal class HeroTests
    {
        private Hero hero;
        private IWeapon weapon;
        private ITarget target;
        private string name;

        [SetUp]
        public void SetUp()
        {
            Mock<IWeapon> weaponMock = new Mock<IWeapon>();
            weaponMock.Setup(x => x.AttackPoints).Returns(100);
            weapon = weaponMock.Object;

            name = "Vladi";
            hero = new Hero(name, weapon);

            Mock<ITarget> targetMock = new Mock<ITarget>();
            targetMock.Setup(t=>t.IsDead()).Returns(true);
            targetMock.Setup(t=>t.GiveExperience()).Returns(50);
            target = targetMock.Object;
        }

        [Test]
        public void Test_Attack_ShouldGiveExperienceWhenTargetIsDead()
        {
            hero.Attack(target);

            int expectedExperience = 50;
            int actualExperience = hero.Experience;

            Assert.AreEqual(expectedExperience, actualExperience);
        }
    }
}
