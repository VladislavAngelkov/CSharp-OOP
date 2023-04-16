namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.PortableExecutable;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;
        private Present presentOne;
        private Present presentTwo;

        [SetUp]
        public void SetUp()
        {
            bag = new Bag();
            presentOne = new Present("Cool", 99);
            presentTwo = new Present("Not so cool", 12);
        }

        [Test]
        public void Constructor_ShouldInitiateCollectionOfPresents()
        {
            Assert.IsNotNull(bag.GetPresents());
        }
        [Test]
        public void Create_ShouldThrowExceptionIfValueIsNull()
        {
            presentOne = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(presentOne);
            }, "Present is null");
        }
        [Test]
        public void Create_ShouldThrowExceeptionWhenPresentAlreadyExist()
        {
            bag.Create(presentOne);
            presentTwo = presentOne;

            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(presentTwo);
            }, "This present already exists!");
        }
        [Test]
        public void Create_ShouldAddThePresentToTheCollection()
        {
            bag.Create(presentOne);
            bag.Create(presentTwo);

            List<Present> expectedResult = new List<Present>()
            {
                presentOne, presentTwo
            };
            IReadOnlyCollection<Present> actualResult = bag.GetPresents();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void Create_ShouldReturnCorectString()
        {
            string expectedResult = $"Successfully added present {presentOne.Name}.";
            string actualResult = bag.Create(presentOne);

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void Remove_ShouldRemoveGivenPresent()
        {
            bag.Create(presentOne);
            bag.Create(presentTwo);
            bag.Remove(presentOne);

            Assert.IsFalse(bag.GetPresents().Contains(presentOne));
        }
        [Test]
        public void Remove_ShouldReturnTrueIfPresentExist()
        {
            bag.Create(presentOne);
            bag.Create(presentTwo);

            Assert.IsTrue(bag.Remove(presentOne));
        }
        [Test]
        public void Remove_ShouldReturnFalseWhenPresentIsNonExisting()
        {
            bag.Create(presentOne);

            Assert.IsFalse(bag.Remove(presentTwo));
        }
        [Test]
        public void GetPresentWithLeastMagic_ShouldWorkCorrectly()
        {
            bag.Create(presentOne);
            bag.Create(presentTwo);

            Present leastMagicPresent = bag.GetPresentWithLeastMagic();

            double expectedResult = presentTwo.Magic;
            double actualResult = leastMagicPresent.Magic;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void GetPresent_ShoudReturnNullIfPresentDoNotExist()
        {
            bag.Create(presentOne);

            Present present = bag.GetPresent("Some present");

            Assert.IsNull(present);
        }
        [Test]
        public void GetPresent_ShouldReturnCorrectPresent()
        {
            bag.Create(presentOne);
            bag.Create(presentTwo);

            Present present = bag.GetPresent("Cool");

            Assert.AreEqual(presentOne, present);
        }
        [Test]
        public void GetPresents_ShouldReturnCorrectCollection()
        {
            bag.Create(presentOne);
            bag.Create(presentTwo);

            List<Present> expectedResult = new List<Present>()
            {
                presentOne, presentTwo
            };
            IReadOnlyCollection<Present> actualResult = bag.GetPresents();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
