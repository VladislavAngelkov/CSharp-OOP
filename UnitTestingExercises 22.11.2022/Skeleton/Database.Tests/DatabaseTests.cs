namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_ConstuctorShouldSetCountCorrectly(int[] data)
        {
            Database database = new Database(data);
            int expectedCount = data.Length;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_ConstructorShouldSetCorrectIntegerArray(int[] data)
        {
            Database database = new Database(data);
            int[] settedArray = database.Fetch();

            CollectionAssert.AreEqual(data, settedArray);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27 })]
        public void Test_ConstructorShouldThrowExceptionIfArrayLenghtIsBiggerThen16(int[] data)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(data);
            });
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void Test_AddMethodShouldAddElement(int[] data)
        {
            int elementToAdd = 33;
            Database database = new Database(data);
            database.Add(elementToAdd);
            int expectedCount = data.Length + 1;
            int actualCount = database.Fetch().Length;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void Test_AddMethodShouldAddElementAtLastPosition(int[] data)
        {
            int expectedElementToAdd = 33;
            Database database = new Database(data);
            database.Add(expectedElementToAdd);
            int actualAddedElement = database.Fetch()[database.Fetch().Length - 1];

            Assert.AreEqual(expectedElementToAdd, actualAddedElement);
        }

        [Test]
        public void Test_AddMethodShouldThrowExceptionWhenTryingToAddElementToFullArray()
        {
            Database database = new Database();
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 17; i++)
                {
                    database.Add(i);
                }
            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_RemoveMethodShouldRemoveElement(int[] data)
        {
            Database database = new Database(data);
            database.Remove();

            int expectedCount = data.Length - 1;
            int actualCount = database.Fetch().Length;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_RemoveMethodShouldSetCountCorrectly(int[] data)
        {
            Database database = new Database(data);
            database.Remove();

            int expectedCount = data.Length - 1;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_RemoveMethodShouldRemoveElementAtLastIndex(int[] data)
        {
            Database database = new Database(data);
            int lastElementBeforeRemove = database.Fetch()[database.Fetch().Length - 1];
            database.Remove();
            int lastElementAfterRemove = database.Fetch()[database.Fetch().Length - 1];

            Assert.AreNotEqual(lastElementBeforeRemove, lastElementAfterRemove);
        }

        [Test]
        public void Test_RemoveMethodShouldThrowExceptionIfArrayIsEmpty()
        {
            Database database = new Database();
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            }, "The collection is empty!");
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_CountShouldWorkCorrectly(int[] data)
        {
            Database database = new Database(data);
            int expectedCount = data.Length;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]

        public void Test_FetchMethodShouldReturnCorrectArray(int[] data)
        {
            Database database = new Database(data);
            int[] actualArray = database.Fetch();

            CollectionAssert.AreEqual(actualArray, data);
        }
    }
}
