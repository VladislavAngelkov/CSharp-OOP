namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Transactions;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void SetUp()
        {
            arena= new Arena();
        }

        [Test]
        public void Test_ConstructorShouldInitiateWarriorsCollection() 
        {
            var warriors = arena.Warriors;
            
            Assert.IsNotNull(warriors);
        }
        [Test]
        public void Test_WarriorsShouldReturnIReadOnlyCollection()
        {
            var warriors = arena.Warriors;
            Type type = warriors.GetType();
            Type[] types = type.GetInterfaces();
            Assert.IsTrue(types.Any(t => t.IsAssignableFrom(typeof(IReadOnlyCollection<Warrior>))));
        }
        [Test]
        public void Test_CountShouldReturnCorrectValue()
        {
            arena.Enroll(new Warrior("Pesho", 10, 100));
            arena.Enroll(new Warrior("Gosho", 20, 200));
            arena.Enroll(new Warrior("Misho", 30, 300));

            int expectedCount = 3;
            int actualCount = arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void Test_EnrollShouldThrowExceptionIfTheNameAlreadyExist()
        {
            Warrior firstWarrior = new Warrior("Pesho", 10, 100);
            Warrior secondWarrior = new Warrior("Pesho", 20, 200);
            arena.Enroll(firstWarrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(secondWarrior);
            }, "Warrior is already enrolled for the fights!");
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(10)]
        public void Test_EnrollShouldChangeCountCorrectly(int timesAdded)
        {
            for (int i = 0; i < timesAdded; i++)
            {
                Warrior warrior = new Warrior($"Name{i}", 10, 100);
                arena.Enroll(warrior);
            }

            int expectedCount = timesAdded;
            int actualCount = arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void Test_FightMethodShouldThrowExceptionIfAttakerIsNotExisting()
        {
            arena.Enroll(new Warrior("Pesho", 10, 100));
            string missingName = "NotThere";

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(missingName, "Pesho");
            }, $"There is no fighter with name {missingName} enrolled for the fights!");
        }
        [Test]
        public void Test_FightMethodShouldThrowExceptionIfAttakedIsNotExisting()
        {
            arena.Enroll(new Warrior("Pesho", 10, 100));
            string missingName = "NotThere";

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Pesho", missingName);
            }, $"There is no fighter with name {missingName} enrolled for the fights!");
        }

        [Test]
        public void Test_FightMethodShouldDecreaseBothFightersHpByWrightAmount()
        {
            string firstFighterName = "Pesho";
            int firstFighterDamage = 10;
            int firstFighterHp = 100;
            Warrior firstFighter = new Warrior(firstFighterName, firstFighterDamage, firstFighterHp);
            arena.Enroll(firstFighter);

            string secondFighterName = "Gosho";
            int secondFighterDamage = 20;
            int secondFighterHp = 200;
            Warrior secondFighter = new Warrior(secondFighterName, secondFighterDamage, secondFighterHp);
            arena.Enroll(secondFighter);

            arena.Fight(firstFighterName, secondFighterName);

            int firstFighterExpectedHp = firstFighterHp - secondFighterDamage;
            int secondFighterExpectedHp = secondFighterHp - firstFighterDamage;
            int firstFighterActualHp = firstFighter.HP;
            int secondFighterActualHp = secondFighter.HP;

            Assert.AreEqual(firstFighterExpectedHp, firstFighterActualHp);
            Assert.AreEqual(secondFighterExpectedHp, secondFighterActualHp);
        }
    }
}
