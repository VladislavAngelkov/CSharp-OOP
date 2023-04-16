namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class CarManagerTests
    {
        private string make;
        private string model;
        private double fuelConsumption;
        private double fuelCapacity;
        private Car car;

        [SetUp]
        public void SetUp()
        {
            make = "Audi";
            model = "A4";
            fuelConsumption = 10.0;
            fuelCapacity = 40.0;

            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }
        [Test]
        public void Test_ConstructorShoildSetFuelAmountToZero()
        {
            double expectedFuelAmount = 0;
            double actualFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }
        [Test]
        public void Test_ConstructorShoildSetMakeCorrectly()
        {
            string expectedMake = make;
            string actualMake = car.Make;

            Assert.AreEqual(expectedMake, actualMake);
        }
        [Test]
        public void Test_ConstructorShoildSetModelCorrectly()
        {
            string expectedModel = model;
            string actualModel = car.Model;

            Assert.AreEqual(expectedModel, actualModel);
        }
        [Test]
        public void Test_ConstructorShoildSetFuelConsumptionCorrectly()
        {
            double expectedFuelConsumption = fuelConsumption;
            double actualFuelConsumption = car.FuelConsumption;

            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
        }
        [Test]
        public void Test_ConstructorShoildSetFuelCapacityCorrectly()
        {
            double expectedFuelCapacity = fuelCapacity;
            double actualFuelCapacity = car.FuelCapacity;

            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_MakeShouldThrowExceptionWhenGivenStringIsNullOrEmpty(string wrongMake)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(wrongMake, model, fuelConsumption, fuelCapacity);

            }, "Make cannot be null or empty!");
        }
        [TestCase(" ")]
        [TestCase("1")]
        [TestCase("BMW")]
        public void Test_MakeShouldWorkCorrectly(string wrightMake)
        {
            car = new Car(wrightMake, model, fuelConsumption, fuelCapacity);
            string expectedMake = wrightMake;
            string actualMake = car.Make;

            Assert.AreEqual(expectedMake, actualMake);
        }
        [TestCase(null)]
        [TestCase("")]
        public void Test_ModelShouldThrowExceptionWhenGivenStringIsNullOrEmpty(string wrongModel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(make, wrongModel, fuelConsumption, fuelCapacity);

            }, "Make cannot be null or empty!");
        }
        [TestCase(" ")]
        [TestCase("1")]
        [TestCase("BMW")]
        public void Test_ModelShouldWorkCorrectly(string wrightModel)
        {
            car = new Car(make, wrightModel, fuelConsumption, fuelCapacity);
            string expectedModel = wrightModel;
            string actualModel = car.Model;

            Assert.AreEqual(expectedModel, actualModel);
        }
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-33)]
        public void Test_FuelConsumptionShouldThrowExceptionIfGivenValueIsLessOrEqualToZero(double testedFuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(make, model, testedFuelConsumption, fuelCapacity);

            }, "Fuel consumption cannot be zero or negative!");
        }
        [TestCase(0.1)]
        [TestCase(1)]
        [TestCase(100)]
        public void Test_FuelConsumptionShouldSetValueCorrectly(double testedFuelConsumption)
        {
            car = new Car(make, model, testedFuelConsumption, fuelCapacity);
            double expecterFuelConsumption = testedFuelConsumption;
            double actualFuelConsumption = car.FuelConsumption;

            Assert.AreEqual(expecterFuelConsumption, actualFuelConsumption);
        }
        [TestCase(-1)]
        [TestCase(-33)]
        [TestCase(-0.1)]
        public void Test_FuelAmountShoudThrowExceptionIfValueIsLessThenZero(double testFuelAmount)
        {
            Type type = typeof(Car);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            PropertyInfo propFuelAmount = properties.FirstOrDefault(p => p.Name == "FuelAmount");

            var ex =Assert.Throws<TargetInvocationException>(() =>
            {
                propFuelAmount.SetValue(car, testFuelAmount);
            }, "Fuel amount cannot be negative!");

            Assert.That(ex.InnerException, Is.TypeOf<ArgumentException>());
            Assert.AreEqual(ex.InnerException.Message, "Fuel amount cannot be negative!");
        }
        [TestCase(0)]
        [TestCase(-0.1)]
        [TestCase(-1)]
        [TestCase(-33)]
        public void Test_FuelCapacityShouldThrowExceptionIfValueIsLessOrEqualToZero(double testFuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(make, model, fuelConsumption, testFuelCapacity);
            }, "Fuel capacity cannot be zero or negative!");
        }
        [TestCase(0)]
        [TestCase(-0.1)]
        [TestCase(-33)]
        public void Test_RefuelMethodShouldThrowExceptionIfValueIsLessOrEqualToZero(double testRefuelingAmount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(testRefuelingAmount);
            }, "Fuel amount cannot be zero or negative!");
        }
        [TestCase(40.1)]
        [TestCase(41)]
        [TestCase(100)]
        public void Test_RefuelMethodShouldNotOvertopFuelCapacity(double testRefuelingAmount)
        {

            car.Refuel(testRefuelingAmount);

            double expectedAmount = fuelCapacity;
            double actualAmount = car.FuelAmount;

            Assert.AreEqual(expectedAmount, actualAmount);
        }
        [TestCase(0.1)]
        [TestCase(1)]
        [TestCase(31)]
        public void Test_RefuelMethodShouldChangeFuelAmountCorrectly(double testRefuelingAmount)
        {
            car.Refuel(testRefuelingAmount);
            double expectedAmount = testRefuelingAmount;
            double actualAmount = car.FuelAmount;

            Assert.AreEqual(expectedAmount, actualAmount);  
        }
        [TestCase(0.1)]
        [TestCase(1)]
        [TestCase(100)]
        public void Test_DriveMethodShouldThrowExceptionIfThereIsNotEnoughtFuel(double distance)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            }, "You don't have enough fuel to drive!");
        }
        [TestCase(0.1)]
        [TestCase(1)]
        [TestCase(100)]
        public void Test_DriveMEthodShouldDecreaseFuelAmountCorrectly(double distance)
        {
            car.Refuel(fuelCapacity);
            car.Drive(distance);
            double expectedAmount = fuelCapacity - ((fuelConsumption * distance) / 100);
            double actualAmount = car.FuelAmount;

            Assert.AreEqual(expectedAmount, actualAmount);
        }
    }
}