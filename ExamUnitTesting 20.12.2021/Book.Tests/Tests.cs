namespace Book.Tests
{
    using System;

    using NUnit.Framework;
    using static System.Net.Mime.MediaTypeNames;

    [TestFixture]
    public class Tests
    {
        private string name;
        private string author;
        private Book book;

        [SetUp]
        public void SetUp()
        {
            name = "Strange Book";
            author = "Infamous";
            book = new Book(name, author);
        }
        [Test]
        public void Test_Constuctor_ShouldSetNameCorrectly()
        {
            string expectedName = name;
            string actualName = book.BookName;
            
            Assert.AreEqual(expectedName, actualName);
        }
        [Test]
        public void Test_Constructor_ShouldSetAuthorCorrectly()
        {
            string expectedAuthor = author;
            string actualAuthor = book.Author;

            Assert.AreEqual(expectedAuthor, actualAuthor);
        }
        [Test]
        public void Test_Constructor_ShouldInitiateFootnoteCollection()
        {
            int expectedCount = 0;
            int actualCount = book.FootnoteCount;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [TestCase(null)]
        [TestCase("")]
        public void Test_BookName_ShouldThrowExceptionIfValueIsNullOrEmpty(string testName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book(testName, author);
            }, $"Invalid {nameof(book.BookName)}!");
        }
        [TestCase(null)]
        [TestCase("")]
        public void Test_Author_ShouldThrowExceptionIfValueIsNullOrEmpty(string testAuthor)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                book = new Book(name, testAuthor);
            }, $"Invalid {nameof(book.Author)}!");
        }
        [Test]
        public void Test_AddFootnote_ShouldThrowExceptionIfFootNotesAlreadyContainsFootnoteWithTheSameNumber()
        {
            string footnoteOne = "Some footnote";
            string footnoteTwo = "Other footnote";

            book.AddFootnote(1, footnoteOne);

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(1, footnoteTwo);
            }, "Footnote already exists!");
        }
        [Test]
        public void Test_AddFootnote_ShouldAddFootnote()
        {
            string footnoteOne = "Some footnote";
            string footnoteTwo = "Other footnote";

            book.AddFootnote(1, footnoteOne);
            book.AddFootnote(2, footnoteTwo);

            int expectedCount = 2;
            int actualCount = book.FootnoteCount;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void Test_FindFootnote_ShouldThrowExceptionIfNumberDoNotExist()
        {
            string footnoteOne = "Some footnote";
            string footnoteTwo = "Other footnote";

            book.AddFootnote(1, footnoteOne);
            book.AddFootnote(2, footnoteTwo);

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(3);
            }, "Footnote doesn't exists!");
        }
        [Test]
        public void Test_FindFootnote_ShouldReturnCorrectFootnote()
        {
            string footnoteOne = "Some footnote";
            string footnoteTwo = "Other footnote";

            book.AddFootnote(1, footnoteOne);
            book.AddFootnote(2, footnoteTwo);

            string expectedFootnote = $"Footnote #{1}: {footnoteOne}";
            string actualFootnote = book.FindFootnote(1);

            Assert.AreEqual(@expectedFootnote, actualFootnote);
        }
        [Test]
        public void Test_AlterFootnote_ShouldThrowExceptionIfNumberIsNotExisting()
        {
            string footnoteOne = "Some footnote";
            string footnoteTwo = "Other footnote";

            book.AddFootnote(1, footnoteOne);
            book.AddFootnote(2, footnoteTwo);

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(3, "Some text");
            }, "Footnote does not exists!");
        }
        [Test]
        public void Test_AlterFootnote_ShouldWorkCorrectly()
        {
            string footnoteOne = "Some footnote";
            string footnoteTwo = "Other footnote";

            book.AddFootnote(1, footnoteOne);
            book.AlterFootnote(1, footnoteTwo);

            string expectedFootnote = $"Footnote #{1}: {footnoteTwo}";
            string actualFootnote = book.FindFootnote(1);
        }
       
    }
}