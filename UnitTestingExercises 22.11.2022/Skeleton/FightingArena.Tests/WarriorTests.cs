namespace FightingArena.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;
        private string name;
        private int damage;
        private int hp;
        private Warrior warrior;

        [SetUp]
        public void SetUp()
        {

            name = "Pesho";
            damage = 10;
            hp = 100;
            warrior = new Warrior(name, damage, hp);
        }

        [Test]
        public void Test_ConstructorShouldSetNameCorrectly()
        {
            string expectedName = name;
            string actualName = warrior.Name;

            Assert.AreEqual(expectedName, actualName);
        }
        [Test]
        public void Test_ConstructorShouldSetDamageCorrectly()
        {
            int expectedDemage = damage;
            int actualDemage = warrior.Damage;

            Assert.AreEqual(expectedDemage, actualDemage);
        }
        [Test]
        public void Test_ConstructorShouldSetHpCorrectly()
        {
            int expectedHp = hp;
            int actualHp = warrior.HP;

            Assert.AreEqual(expectedHp, actualHp);
        }
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Test_NameShoudThrowExceptionIfGivenValueIsNullOrWhitespace(string testName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(testName, damage, hp);

            }, "Name should not be empty or whitespace!");
        }
        [TestCase("12345")]
        [TestCase("Vladi")]
        [TestCase("   1213   ")]
        [TestCase("Some Words And Some Digits 12345 And Some Punctuation Marks . , !  @  $ % - ")]
        public void Test_NameShoudSetCorrectValue(string testName)
        {
            warrior = new Warrior(testName, damage, hp);

            string expectedName = testName;
            string actualName = warrior.Name;
            Assert.AreEqual(expectedName, actualName);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-33)]
        public void Test_DamageShouldThrowExceptionIfGivenValueIsLessThenOrEqualToZero(int testDamage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(name, testDamage, hp);
            }, "Damage value should be positive!");
        }

        [TestCase(1)]
        [TestCase(33)]
        [TestCase(1000000)]
        public void Test_DamageShouldSetCorrectValue(int testDamage)
        {
            warrior = new Warrior(name, testDamage, hp);

            int expectedDamage = testDamage;
            int actualDamage = warrior.Damage;

            Assert.AreEqual(expectedDamage, actualDamage);
        }
        [TestCase(-1)]
        [TestCase(-33)]
        public void Test_HpSouldThrowExceptionIfGivenValueIsLessThenZero(int testHp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(name, damage, testHp);
            }, "HP should not be negative!");
        }
        [TestCase(1)]
        [TestCase(33)]
        public void Test_HpSouldSetCorrectValue(int testHp)
        {
            warrior = new Warrior(name, damage, testHp);

            int expectedHp = testHp;
            int actualHp = warrior.HP;

            Assert.AreEqual(expectedHp, actualHp);
        }
        [TestCase(30)]
        [TestCase(29)]
        [TestCase(0)]
        public void Test_AttackMethodShouldThrowExceptionIfAttackerHpIsBellowOrEqualToMinHpForAttack(int testHp)
        {
            warrior = new Warrior(name, damage, testHp);
            Warrior attackedWarrior = new Warrior("Gosho", 50, 100);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(attackedWarrior);
            }, "Your HP is too low in order to attack other warriors!");
        }
        [TestCase(30)]
        [TestCase(29)]
        [TestCase(0)]
        public void Test_AttackMethodShouldThrowExceptionIfAttackedHpIsBellowOrEqualToMinHpForAttack(int testHp)
        {
            Warrior attackedWarrior = new Warrior("Gosho", 50, testHp);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(attackedWarrior);
            }, "Your HP is too low in order to attack other warriors!");
        }
        [TestCase(101)]
        [TestCase(150)]
        [TestCase(100000)]
        public void Test_AttackMethodShouldThrowExceptionIfAttackerHpIsLowerThenAttackedDamage(int attackedDamage)
        {
            Warrior attackedWarrior = new Warrior("Gosho", attackedDamage, 100);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(attackedWarrior);
            }, "You are trying to attack too strong enemy");
        }
        [Test]
        public void Test_AttackMethodShouldDecreaseAttackerHpCorrectly()
        {
            Warrior attackedWarrior = new Warrior("Gosho", 10, 100);
            warrior.Attack(attackedWarrior);

            int expectedHp = hp - attackedWarrior.Damage;
            int actualHp = warrior.HP;

            Assert.AreEqual(expectedHp, actualHp);
        }
        [Test]
        public void Test_AttackMethodShouldDecreaseAttackedHpCorrectly()
        {
            Warrior attackedWarrior = new Warrior("Gosho", 10, 100);
            warrior.Attack(attackedWarrior);

            int expectedHp = 100 - warrior.Damage;
            int actualHp = attackedWarrior.HP;

            Assert.AreEqual(expectedHp, actualHp);
        }
        [TestCase(100)]
        [TestCase(101)]
        [TestCase(1000)]
        public void Test_AttackMethodShouldSetAttackedHpToZero(int testDamage)
        {
            warrior = new Warrior(name, testDamage, hp);
            Warrior attackedWarrior = new Warrior("Gosho", 10, 100);
            warrior.Attack(attackedWarrior);
           
            int actualHp = attackedWarrior.HP;

            Assert.AreEqual(0, actualHp);
        }

    }
}