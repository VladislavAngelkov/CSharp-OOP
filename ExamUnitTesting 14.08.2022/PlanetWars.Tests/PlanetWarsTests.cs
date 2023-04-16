using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private string name = "Earth";
            private double budget = 7;
            private Planet planet;

            [Test]
            public void Test_Constructor_ShouldSetNameCorrectly()
            {
                planet = new Planet(name, budget);
                string expectedName = name;
                string actualName = planet.Name;

                Assert.AreEqual(expectedName, actualName);
                
            }
            [Test]
            public void Test_Constructor_ShouldSetBudgetCorrectly()
            {
                planet = new Planet(name, budget);
                double expectedBudget = budget;
                double actualBudget = planet.Budget;

                Assert.AreEqual(expectedBudget, actualBudget);
            }

            [Test]
            public void Test_ConstructorShouldInitiateWeaponCollection()
            {
                planet = new Planet(name, budget);

                Assert.IsNotNull(planet.Weapons);
            }

            [TestCase(null)]
            [TestCase("")]
            public void Test_Name_ShouldThrowExceptionWhenValueIsNullOrEmpty(string testName)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    planet = new Planet(testName, budget);
                }, "Invalid planet Name");
            }
            [TestCase(" ")]
            [TestCase("0")]
            [TestCase("Mars")]
            public void Test_Name_ShouldSetNameCorrectly(string testName)
            {
                planet= new Planet(testName, budget);
                string expectedName = testName;
                string actualName = planet.Name;

                Assert.AreEqual(expectedName, actualName);
            }
            [TestCase(-0.1)]
            [TestCase(-1)]
            [TestCase(-100)]
            public void Test_Budget_ShouldThrowExceptionWhenValueIsNegative(double testBudget)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    planet = new Planet(name, testBudget);
                }, "Budget cannot drop below Zero!");
            }
            [TestCase(0.1)]
            [TestCase(1)]
            [TestCase(100)]
            public void Test_Budget_ShouldSetValueCorrectly(double testBudget)
            {
                planet = new Planet(name, testBudget);
                double expectedBudget = testBudget;
                double actualBudget = planet.Budget;

                Assert.AreEqual(expectedBudget, actualBudget);
            }
            [Test]
            public void Test_Weapons_ShouldReturnTHeCorrectCollection()
            {
                List<Weapon> weapons = new List<Weapon>()
                {
                    new Weapon("Some", 10, 15),
                    new Weapon("AK 47", 100, 205),
                    new Weapon("Knife", 5, 21)
                };

                planet = new Planet(name, budget);

                foreach (var weapon in weapons)
                {
                    planet.AddWeapon(weapon);
                }

                var expectedCollection = weapons;
                var actualCollection = planet.Weapons;

                CollectionAssert.AreEqual(expectedCollection, actualCollection);
            }
            [Test]
            public void Test_MilitaryPowerRatio_ShouldReturnCorrectValue()
            {
                List<Weapon> weapons = new List<Weapon>()
                {
                    new Weapon("Some", 10, 15),
                    new Weapon("AK 47", 100, 205),
                    new Weapon("Knife", 5, 21)
                };

                planet = new Planet(name, budget);

                foreach (var weapon in weapons)
                {
                    planet.AddWeapon(weapon);
                }

                double expectedResult = weapons.Sum(w => w.DestructionLevel);
                double actualResult = planet.MilitaryPowerRatio;

                Assert.AreEqual(expectedResult, actualResult);
            }
            [TestCase(0)]
            [TestCase(10)]
            [TestCase(100)]
            public void Test_Profit_ShouldIncreaseBudgetCorrectly(double testAmount)
            {
                planet= new Planet(name, budget);
                planet.Profit(testAmount);

                double expectedResult = budget + testAmount;
                double actualResult = planet.Budget;

                Assert.AreEqual(expectedResult, actualResult);
            }
            [Test]
            public void Test_SpendFunds_ShouldThrowExceptionWhenAmountIsMoreThenBudget()
            {
                planet= new Planet(name, budget);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(8);
                }, "Not enough funds to finalize the deal.");
            }
            [Test]
            public void Test_SpendFunds_ShouldDecreaseBudgetCorrectly()
            {
                planet = new Planet(name, budget);
                double spendings = 5;
                planet.SpendFunds(spendings);

                double expectedResult = budget - spendings;
                double actualResult = planet.Budget;

                Assert.AreEqual(expectedResult, actualResult);
            }
            [Test]
            public void Test_AddWeapon_ShouldThrowExceptionWhenWeaponAlreadyExist()
            {
                planet= new Planet(name, budget);
                Weapon weapon = new Weapon("Knife", 10, 5);

                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon);
                }, $"There is already a {weapon.Name} weapon.");
            }
            [Test]
            public void Test_AddWeapon_ShouldWrocCorrectly()
            {
                planet= new Planet(name, budget);
                List<Weapon> weapons = new List<Weapon>();
                Weapon weapon = new Weapon("Knife", 10, 5);
                weapons.Add(weapon);

                planet.AddWeapon(weapon);

                var expectedResult = weapons;
                var actualResult = planet.Weapons;

                CollectionAssert.AreEqual(expectedResult, actualResult);
            }
            [Test]
            public void Test_RemoveWeapon_ShouldNotRemoveWeaponIfSuchDontExist()
            {
                planet= new Planet(name, budget);
                Weapon weapon = new Weapon("Knife", 10, 5);
                planet.AddWeapon(weapon);

                planet.RemoveWeapon("AK47");

                int expectedCount = 1;
                int actualCount = planet.Weapons.Count;

                Assert.AreEqual(expectedCount, actualCount);
            }
            [Test]
            public void Test_RemoveWeapon_ShouldWorkCorrectly()
            {
                planet = new Planet(name, budget);
                Weapon weapon = new Weapon("Knife", 10, 5);
                planet.AddWeapon(weapon);

                planet.RemoveWeapon(weapon.Name);

                int expectedCount = 0;
                int actualCount = planet.Weapons.Count;

                Assert.AreEqual(expectedCount, actualCount);
            }
            [Test]
            public void Test_UpgradeWeapon_ShouldThrowExceptionIfSuchWeaponDontExist()
            {
                planet= new Planet(name, budget);
                string weaponName = "SomeWeapon";

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon(weaponName);
                }, $"{weaponName} does not exist in the weapon repository of {planet.Name}");
            }
            [Test]
            public void Test_UpgradeWeapon_ShouldWorkCorrectly()
            {
                planet = new Planet(name, budget);
                Weapon weapon = new Weapon("Knife", 10, 5);
                int expectedResult = weapon.DestructionLevel + 1;
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(weapon.Name);
                int actualResult = planet.Weapons.FirstOrDefault(w => w.Name == weapon.Name).DestructionLevel;

                Assert.AreEqual(expectedResult, actualResult);
            }
            [Test]
            public void Test_DestructOpponent_ShouldThrowExceptionWhrnOpponentIsStronger()
            {
                planet= new Planet(name, budget);
                Planet opponent = new Planet(name, budget);
                Weapon weapon = new Weapon("Knife", 10, 5);
                opponent.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(opponent);
                }, $"{opponent.Name} is too strong to declare war to!");
            }
            [Test]
            public void Test_DestructOpponent_ShouldWorkCorrectly()
            {
                planet = new Planet(name, budget);
                Planet opponent = new Planet(name, budget);
                Weapon weapon = new Weapon("Knife", 10, 5);
                planet.AddWeapon(weapon);

                string expectedResult = $"{opponent.Name} is destructed!";
                string actualResult = planet.DestructOpponent(opponent);

                Assert.AreEqual(expectedResult, actualResult);
            }
        }
    }
}
