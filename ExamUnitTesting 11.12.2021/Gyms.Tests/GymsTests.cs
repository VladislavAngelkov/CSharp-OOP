namespace Gyms.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class GymsTests
    {
        private string name;
        private int size;
        private Gym gym;

        [SetUp]
        public void SetUp()
        {
            name = "Awesome Gym";
            size = 100;
            gym = new Gym(name, size);
        }

        [Test]
        public void Test_Constructor_ShouldSetNameCorrectly()
        {
            string expectedName = name;
            string actualName = gym.Name;

            Assert.AreEqual(expectedName, actualName);
        }
        [Test]
        public void Test_Constructor_ShouldSetSizeCorrectly()
        {
            int expectedSize = size;
            int actualSize = gym.Capacity;

            Assert.AreEqual(expectedSize, actualSize);
        }
        [Test]
        public void Test_Constructor_ShouldInitiateAthleteCollection()
        {
            int expectedCount = 0;
            int actualCount = gym.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [TestCase(null)]
        [TestCase("")]
        public void Test_Name_ShouldThrowExceptionIfValueIsNullOrEmpty(string testName)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                gym = new Gym(testName, size);
            }, "Invalid gym name.");
        }
        [Test]
        public void Test_Capacity_ShouldThrowExceptionIfValueIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                gym = new Gym(name, -10);
            }, "Invalid gym capacity.");
        }
        [Test]
        public void Test_AddAthlete_ShouldThrowExceptionIfTheGymIsFull()
        {
            gym = new Gym(name, 1);
            Athlete firstAthlete = new Athlete("Pesho");
            Athlete secondAthlete = new Athlete("Gosho");
            gym.AddAthlete(firstAthlete);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(secondAthlete);
            }, "The gym is full.");
        }
        [Test]
        public void Test_AddAthlete_ShouldAddAthleteCorrectly()
        {
            Athlete firstAthlete = new Athlete("Pesho");
            Athlete secondAthlete = new Athlete("Gosho");
            gym.AddAthlete(firstAthlete);
            gym.AddAthlete(secondAthlete);

            int expectedCount = 2;
            int actualCount = gym.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void Test_RemoveAthlete_ShouldThrowExceptionIfValueIsNull()
        {
            Athlete firstAthlete = new Athlete("Pesho");
            gym.AddAthlete(firstAthlete);
            string nonExistingAthleteName = "Gosho";
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete(nonExistingAthleteName);

            }, $"The athlete {nonExistingAthleteName} doesn't exist.");
        }
        [Test]
        public void Test_RemoveAthlete_ShouldWorkCorrectly()
        {
            Athlete firstAthlete = new Athlete("Pesho");
            Athlete secondAthlete = new Athlete("Gosho");
            gym.AddAthlete(firstAthlete);
            gym.AddAthlete(secondAthlete);
            gym.RemoveAthlete("Gosho");
            
            int expectedCount = 1;
            int actualCount = gym.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Test_InjureAthlete_ShouldThrowExceptionIfAthleteDoNotExist()
        {
            Athlete firstAthlete = new Athlete("Pesho");
            Athlete secondAthlete = new Athlete("Gosho");
            gym.AddAthlete(firstAthlete);
            gym.AddAthlete(secondAthlete);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Misho");
            }, $"The athlete Misho doesn't exist.");
        }
        [Test]
        public void Test_InjureAthlete_ShouldWorkCorrectly()
        {
            Athlete firstAthlete = new Athlete("Pesho");
            Athlete secondAthlete = new Athlete("Gosho");
            gym.AddAthlete(firstAthlete);
            gym.AddAthlete(secondAthlete);

            Athlete injuredOne = gym.InjureAthlete("Pesho");

            Assert.IsTrue(injuredOne.IsInjured);
        }
        [Test]
        public void Test_Report_ShouldWorkCorrectly()
        {
            Athlete firstAthlete = new Athlete("Pesho");
            Athlete secondAthlete = new Athlete("Gosho");
            gym.AddAthlete(firstAthlete);
            gym.AddAthlete(secondAthlete);
            gym.InjureAthlete("Pesho");

            string expected = $"Active athletes at {name}: Gosho";
            string actual = gym.Report();

            Assert.AreEqual(expected, actual);
        }
    }
}
