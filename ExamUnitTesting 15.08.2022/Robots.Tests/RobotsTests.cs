namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class RobotsTests
    {
        private int capacity;
        private Robot robotOne;
        private Robot robotTwo;
        private RobotManager manager;

        [SetUp]
        public void SetUp()
        {
            capacity = 10;
            manager = new RobotManager(capacity);
            robotOne = new Robot("Pesho", 10);
            robotTwo = new Robot("Gosho", 20);
        }
        [Test]
        public void Test_Constuctor_ShouldSetCapacityCorrectly()
        {
            int expectedResult = capacity;
            int actualResult = manager.Capacity;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void Test_Constructor_ShouldInitiate_RobotsCollection()
        {
            int expectedResult = 0;
            int actualResult = manager.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-101)]
        public void Test_Capacity_ShouldThrowExceptionIfValueIsNegative(int testCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                manager = new RobotManager(testCapacity);
            }, "Invalid capacity!");
        }
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(101)]
        public void Test_Capacity_ShouldSetCorrectValue(int testCapacity)
        {
            manager= new RobotManager(testCapacity);

            int expectedCapacity = testCapacity;
            int actualCapacity = manager.Capacity;

            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        [Test]
        public void Test_Count_ShouldReturnCorrectValue()
        {
            manager.Add(robotOne);
            manager.Add(robotTwo);

            int expectedCount = 2;
            int actualCount = manager.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void Test_Add_ShouldThrowExceptionIfRobotWithTHeSameNameAlreadyExist()
        {
            manager.Add(robotOne);
            robotTwo = new Robot(robotOne.Name, 40);

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Add(robotTwo);
            }, $"There is already a robot with name {robotTwo.Name}!");
        }
        [Test]
        public void Test_Add_ShouldThrowExceptionWhenCapacityIsFull()
        {
            manager = new RobotManager(1);
            manager.Add(robotOne);

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Add(robotTwo);
            }, "Not enough capacity!");
        }
        [Test]
        public void Test_Add_ShouldWorkCorrectly()
        {
            manager.Add(robotOne);
            manager.Add(robotTwo);

            List<Robot> expectedResult = new List<Robot>()
            {
                robotOne,
                robotTwo
            };

            Type type = typeof(RobotManager);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo robots = fields.FirstOrDefault(f => f.Name == "robots");

            List<Robot> actualResult = robots.GetValue(manager) as List<Robot>;

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void Test_Remove_ShouldThrowExceptionWhenRobotWithGivenNameDoNotExist()
        {
            manager.Add(robotOne);
            manager.Add(robotTwo);
            string name = "Misho";
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Remove(name);
            }, $"Robot with the name {name} doesn't exist!");
        }
        [Test]
        public void Test_Remove_ShouldWorkCorrect()
        {
            manager.Add(robotOne);
            manager.Add(robotTwo);

            string name = robotOne.Name;
            manager.Remove(name);

            int expectedResult = 1;
            int actualResult = manager.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void Test_Work_ShouldThrowExceptionWhenRobotWithGivenNameDoNotExist()
        {
            manager.Add(robotOne);
            manager.Add(robotTwo);
            string name = "Misho";
            string job = "Cleaning";
            int batteryUsage = 5;
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work(name, job, batteryUsage);
            }, $"Robot with the name {name} doesn't exist!");
        }
        [Test]
        public void Test_Work_ShouldThrowExceptionWhenRobotDoesNotHaveEnoughtBattery()
        {
            manager.Add(robotOne);
            manager.Add(robotTwo);
            string name = robotOne.Name;
            string job = "Cleaning";
            int batteryUsage = 50;
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work(name, job, batteryUsage);
            }, $"{name} doesn't have enough battery!");
        }
        [Test]
        public void Test_Work_ShouldDecreaseBatteryCorrectly()
        {
            manager.Add(robotOne);
            manager.Add(robotTwo);
            string name = robotOne.Name;
            string job = "Cleaning";
            int batteryUsage = 5;
            manager.Work(name, job, batteryUsage);

            int expectedResult = 5;
            int actualResult = robotOne.Battery;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void Test_Charge_ShouldThrowExceptionWhenRobotWithGivenNameDoNotExist()
        {
            manager.Add(robotOne);
            manager.Add(robotTwo);
            string name = "Misho";

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Charge(name);
            }, $"Robot with the name {name} doesn't exist!");
        }
        [Test]
        public void Test_Charge_ShouldWorkCorrect()
        {
            manager.Add(robotOne);
            manager.Add(robotTwo);
            string name = robotOne.Name;
            string job = "Cleaning";
            int batteryUsage = 5;
            manager.Work(name, job, batteryUsage);
            manager.Charge(name);

            int expectedResult = 10;
            int actualResult = robotOne.Battery;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
