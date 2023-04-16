namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Tests
    {
        private UniversityLibrary library;
        private TextBook firstBook;
        private TextBook secondBook;

        [SetUp]
        public void Setup()
        {
            library = new UniversityLibrary();

            string firstBookTitle = "Roben Bukvar";
            string firstBookAuthor = "Dr. Petar Beron";
            string firstBookCategory = "Education";
            firstBook = new TextBook(firstBookTitle, firstBookAuthor, firstBookCategory);

            string secondBookTitle = "It";
            string secondBookAuthor = "Stephen King";
            string secondBookCategory = "Horror";
            secondBook = new TextBook(secondBookTitle, secondBookAuthor, secondBookCategory);
        }

        [Test]
        public void ConstructorShouldInitateBookCollection()
        {
           Type type = library.GetType();

            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            var booksField = fields.FirstOrDefault(f => f.Name == "textBooks");

            var fieldValue = booksField.GetValue(library);

            Assert.IsNotNull(fieldValue);
        }
        [Test]
        public void Catalogue_ShouldReturnCorectCollection()
        {
            library.AddTextBookToLibrary(firstBook);
            library.AddTextBookToLibrary(secondBook);

            var expectedResult = new List<TextBook>()
            {
                firstBook, secondBook
            };

            var actualResult = library.Catalogue;

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void AddTextBookToLibrary_ShouldIncreaseBookCount()
        {
            library.AddTextBookToLibrary(firstBook);
            library.AddTextBookToLibrary(secondBook);

            int expectedCount = 2;
            int actualCount = library.Catalogue.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void AddTextBookToLibrary_ShouldGiveCorrectInventoryNumber()
        {
            library.AddTextBookToLibrary(firstBook);
            int expectedResult = 1;
            int actualResult = firstBook.InventoryNumber;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void AddTextBookToLibrary_ShouldReturnCorrectMessage()
        {
            string actualResult = library.AddTextBookToLibrary(firstBook);

            string expectedResult = firstBook.ToString();

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void LoanTextBook_ShouldReturnCorrectMessageWhenStudnetHasAlreadyLoanedTheBook()
        {
            string studentName = "Vladi";
            library.AddTextBookToLibrary(firstBook);
            library.LoanTextBook(1, studentName);

            string expectedResult = $"{studentName} still hasn't returned {firstBook.Title}!";
            string actualResult = library.LoanTextBook(1, studentName);

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void LoanTextBook_ShouldReturnCorrectMessageWhenOperationIsSuccessful()
        {
            library.AddTextBookToLibrary(firstBook);

            string studentName = "Vladi";

            string expectedResult = $"{firstBook.Title} loaned to {studentName}.";

            string actualResult = library.LoanTextBook(1, studentName);

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void ReturnTextBook_ShouldSetHolderToEmptyString()
        {
            library.AddTextBookToLibrary(firstBook);
            string studentName = "Vladi";
            library.LoanTextBook(1, studentName);

            library.ReturnTextBook(1);

            string holder = firstBook.Holder;

            Assert.IsTrue(string.IsNullOrEmpty(holder));
        }
        [Test]
        public void ReturnTextBook_ShouldReturnCorrectMessage()
        {
            library.AddTextBookToLibrary(firstBook);
            string studentName = "Vladi";
            library.LoanTextBook(1, studentName);

            string expectedMessage = $"{firstBook.Title} is returned to the library.";
            string actualMessage = library.ReturnTextBook(1);

            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}