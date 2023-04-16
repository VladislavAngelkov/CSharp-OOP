using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    [TestFixture]
    public class Tests
    {

        public class RepairsShopTests
        {
            private string name;
            private int mechanicsAvailable;
            private Garage garage;

            [SetUp]
            public void SetUp()
            {
                name = "VladiGarage";
                mechanicsAvailable = 5;
            }

            [Test]
            public void Test_Constructor_ShouldSetNameCorrectly()
            {
                garage = new Garage(name, mechanicsAvailable);

                string expectedName = name;
                string actualName = garage.Name;

                Assert.AreEqual(expectedName, actualName);
            }
            [Test]
            public void Test_Constructor_ShouldSetMechanicsCorrectly()
            {
                garage = new Garage(name, mechanicsAvailable);

                int expectedCount = mechanicsAvailable;
                int actualCount = garage.MechanicsAvailable;

                Assert.AreEqual(expectedCount, actualCount);
            }
            [TestCase(null)]
            [TestCase("")]
            public void Test_Name_ShouldThrowExceptionWhenValueIsNullOrEmpty(string testName)
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    garage = new Garage(testName, mechanicsAvailable);
                }, "Invalid garage name.");
            }
            [TestCase("Valid")]
            [TestCase("  ")]
            [TestCase("1")]
            public void Test_Name_ShouldSetValueCorrectly(string testName)
            {
                garage = new Garage(testName, mechanicsAvailable);

                string expectedName = testName;
                string actualName = garage.Name;

                Assert.AreEqual(expectedName, actualName);
            }
            [TestCase(0)]
            [TestCase(-1)]
            [TestCase(-33)]
            public void Test_MechanicsAvailable_ShouldThrowExceptionWhenValueIsNegativOrEqualToZero(int testCount)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    garage = new Garage(name, testCount);
                }, "At least one mechanic must work in the garage.");
            }
            [TestCase(1)]
            [TestCase(5)]
            [TestCase(100)]
            public void Test_MechanicsAvailable_ShouldSetValueCorrectly(int testCount)
            {
                garage = new Garage(name, testCount);

                int expectedCount = testCount;
                int actualCount = garage.MechanicsAvailable;

                Assert.AreEqual(expectedCount, actualCount);
            }
            [Test]
            public void Test_CarsInGarage_ShouldReturnTheCorrectValue()
            {
                Car carOne = new Car("Opel", 1);
                Car carTwo = new Car("BMW", 3);

                garage = new Garage(name, mechanicsAvailable);
                garage.AddCar(carOne);
                garage.AddCar(carTwo);

                int expectedCount = 2;
                int actualCount = garage.CarsInGarage;

                Assert.AreEqual(expectedCount, actualCount);
            }
            [Test]
            public void Test_AddCar_ShouldThrowExceptionWhenThereAreNotAvailableMechanics()
            {
                garage = new Garage(name, 1);
                Car carOne = new Car("Opel", 1);
                Car carTwo = new Car("BMW", 3);
                garage.AddCar(carOne);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(carTwo);
                }, "No mechanic available.");
            }

            [Test]
            public void Test_AddCar_ShouldWorkCorrectly()
            {
                Car carOne = new Car("Opel", 1);
                Car carTwo = new Car("BMW", 3);

                garage = new Garage(name, mechanicsAvailable);
                garage.AddCar(carOne);
                garage.AddCar(carTwo);

                int expectedCount = 2;
                int actualCount = garage.CarsInGarage;

                Assert.AreEqual(expectedCount, actualCount);
            }
            [Test]
            public void Test_FixCar_ShouldThrowExceptionWhenCarDoesNotExist()
            {
                garage = new Garage(name, mechanicsAvailable);
                Car carOne = new Car("Opel", 1);
                garage.AddCar(carOne);

                string carForFixing = "BMW3";

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar(carForFixing);
                }, $"The car {carForFixing} doesn't exist.");
            }
            [Test]
            public void Test_FixCar_ShouldWorkCorrectly()
            {
                garage = new Garage(name, mechanicsAvailable);
                string carName = "Opel";
                int numOfIssues = 1;
                Car carOne = new Car(carName, numOfIssues);
                garage.AddCar(carOne);

                Car fixedCar = garage.FixCar(carName);

                int expectedNumerOfIssues = 0;
                int actualNumberOfIssues = fixedCar.NumberOfIssues;


                Assert.AreEqual(expectedNumerOfIssues, actualNumberOfIssues);
            }
            [Test]
            public void Test_RemoveFixedCar_ShouldThrowExceptionIfNoFixedCarsAvailable()
            {
                Car carOne = new Car("Opel", 1);
                Car carTwo = new Car("BMW", 3);

                garage = new Garage(name, mechanicsAvailable);
                garage.AddCar(carOne);
                garage.AddCar(carTwo);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                }, "No fixed cars available.");
            }
            [Test]
            public void Test_RemoveFixedCar_ShouldWorkCorrectly()
            {
                Car carOne = new Car("Opel", 1);
                Car carTwo = new Car("BMW", 3);

                garage = new Garage(name, mechanicsAvailable);
                garage.AddCar(carOne);
                garage.AddCar(carTwo);
                garage.FixCar("Opel");
                garage.FixCar("BMW");

                int expectedResult = 2;
                int actualResult = garage.RemoveFixedCar();

                Assert.AreEqual(expectedResult, actualResult);
            }
            [Test]
            public void Test_Report_ShouldWorkCorrectly()
            {
                Car carOne = new Car("Opel", 1);
                Car carTwo = new Car("BMW", 3);

                garage = new Garage(name, mechanicsAvailable);
                garage.AddCar(carOne);
                garage.AddCar(carTwo);

                string expectedMessage = "There are 2 which are not fixed: Opel, BMW.";
                string actualMessage = garage.Report();

                Assert.AreEqual(expectedMessage, actualMessage);
            }
        }
    }
}