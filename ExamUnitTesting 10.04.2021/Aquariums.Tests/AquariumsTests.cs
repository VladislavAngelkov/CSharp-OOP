namespace Aquariums.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    [TestFixture]
    public class AquariumsTests
    {
        private string name;
        private int capacity;
        private Aquarium aquarium;
        private Fish fishOne;
        private Fish fishTwo;

        [SetUp]
        public void SetUp()
        {
            name = "BlackSea";
            capacity = 3;
            aquarium = new Aquarium(name, capacity);
            fishOne = new Fish("Pesho");
            fishTwo = new Fish("Gosho");
        }

        [Test]
        public void Cosntructor_ShouldSetNameCorrectly()
        {
            string epectedResult = name;
            string actualResult = aquarium.Name;

            Assert.AreEqual(epectedResult, actualResult);
        }
        [Test]
        public void Constructor_ShouldSetCapacityCorrectly()
        {
            int expectedResult = capacity;
            int actualResult = aquarium.Capacity;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void Constructor_ShouldInitiateCollectionOfFish()
        {
            Type type = typeof(Aquarium);
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var collectionField = fields.FirstOrDefault(f => f.Name == "fish");

            var collection = collectionField.GetValue(aquarium);

            Assert.IsNotNull(collection);
        }
        [TestCase(null)]
        [TestCase("")]
        public void Name_ShouldThrowExceptionWhenValueIsNullOrEmpty(string testName)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                aquarium = new Aquarium(testName, capacity);
            }, "Invalid aquarium name!");
        }
        [TestCase(-1)]
        [TestCase(-100)]
        public void Capacity_ShouldThrowExceptionWhenValueIsNegative(int testCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                aquarium = new Aquarium(name, testCapacity);
            }, "Invalid aquarium capacity!");
        }
        [Test]
        public void Capacity_ShouldSetCorrectValue()
        {
            int expectedResult = capacity;
            int actualResult = aquarium.Capacity;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void Count_ShouldReturnCorrectCount()
        {
            aquarium.Add(fishOne);
            aquarium.Add(fishTwo);

            int expectedResult = 2;
            int actualResult = aquarium.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void Add_ShouldThrowExceptionWhenCapacityIsFull()
        {
            aquarium.Add(fishOne);
            aquarium.Add(fishTwo); 
            aquarium.Add(fishOne);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fishTwo);
            }, "Aquarium is full!");
        }
        [Test]
        public void Add_ShouldWorkCorrectly()
        {
            aquarium.Add(fishOne);
            aquarium.Add(fishTwo);

            List<Fish> expectedCollection = new List<Fish>()
            {
                fishOne,
                fishTwo
            };
            Type type = typeof(Aquarium);
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var collectionField = fields.FirstOrDefault(f => f.Name == "fish");

            var actualCollection = collectionField.GetValue(aquarium) as ICollection<Fish>;

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }
        [Test]
        public void Remove_ShouldThrowExceptionWhenFishIsNonExisting()
        {
            aquarium.Add(fishOne);
            aquarium.Add(fishTwo);
            string fishName = "Misho";
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish(fishName);
            }, $"Fish with the name {fishName} doesn't exist!");
        }
        [Test]
        public void Remove_ShouldWorkCorrectly() 
        {
            aquarium.Add(fishOne);
            aquarium.Add(fishTwo);

            aquarium.RemoveFish(fishOne.Name);

            List<Fish> expectedCollection = new List<Fish>()
            {
                fishTwo
            };
            Type type = typeof(Aquarium);
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var collectionField = fields.FirstOrDefault(f => f.Name == "fish");

            var actualCollection = collectionField.GetValue(aquarium) as ICollection<Fish>;

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }
        [Test]
        public void SellFish_ShouldThrowExceptionWhenFishIsNonExisting()
        {
            aquarium.Add(fishOne);
            aquarium.Add(fishTwo);
            string fishName = "Misho";

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish(fishName);
            }, $"Fish with the name {fishName} doesn't exist!");
        }
        [Test]
        public void SellFish_ShouldReturnCorrectFish()
        {
            aquarium.Add(fishOne);
            aquarium.Add(fishTwo);

            var expectedFish = fishOne;
            var actualFish = aquarium.SellFish(fishOne.Name);

            Assert.AreEqual(expectedFish, actualFish);
        }
        [Test]
        public void SellFish_ShouldSetFishAvailableToFalse()
        {
            aquarium.Add(fishOne);
            aquarium.Add(fishTwo);

            var fish = aquarium.SellFish(fishOne.Name);

            Assert.IsFalse(fish.Available);
        }
        [Test]
        public void Report_ShouldReturnCorrectString()
        {
            aquarium.Add(fishOne);
            aquarium.Add(fishTwo);

            string expectedString = $"Fish available at {aquarium.Name}: Pesho, Gosho";

            string actualString = aquarium.Report();

            Assert.AreEqual(expectedString, actualString);
        }
    }
}
