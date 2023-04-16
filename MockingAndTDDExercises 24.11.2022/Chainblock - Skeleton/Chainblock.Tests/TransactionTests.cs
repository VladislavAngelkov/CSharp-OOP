using Chainblock.Contracts;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        private ITransaction transaction;
        private int id;
        private TransactionStatus status;
        private string from;
        private string to;
        private double amount;

        [SetUp]
        public void SetUp()
        {
            id = 1;
            status = TransactionStatus.Successfull;
            from = "Pesho";
            to = "Gosho";
            amount = 100;
            transaction = new Transaction(id, status, from, to, amount);
        }
        [Test]
        public void Test_Constuctor_ShouldSetIdCorrectly()
        {
            int expectedId = id;
            int actualId = transaction.Id;

            Assert.AreEqual(expectedId, actualId);
        }
        [Test]
        public void Test_Constructor_ShouldSetTransactionStatusCorrectly()
        {
            TransactionStatus expectedStatus = status;
            TransactionStatus actualStatus = transaction.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }
        [Test]
        public void Test_Constructor_ShouldSetSenderCorrectly()
        {
            string expectedSender = from;
            string actualSender = transaction.From;

            Assert.AreEqual(expectedSender, actualSender);
        }
        [Test]
        public void Test_Constructor_ShouldSetRecReceiverCorrectly()
        {
            string expectedRecReceiver = to;
            string actualRecReceiver = transaction.To;

            Assert.AreEqual(expectedRecReceiver, actualRecReceiver);
        }
        [Test]
        public void Test_Constructor_ShouldSetAmountCorrectly()
        {
            double expectedAmount = amount;
            double actualAmount = transaction.Amount;

            Assert.AreEqual(expectedAmount, actualAmount);
        }
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-33)]
        public void Test_Id_ShouldThrowExceptionIfGivenValueIsLessThenOrEqualToZero(int testId)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                transaction.Id = testId;
            });
        }
        [TestCase(1)]
        [TestCase(7)]
        [TestCase(33)]
        public void Test_Id_ShouldSetCorrectValue(int testId)
        {
            transaction.Id = testId;

            int expectedId = testId;
            int actualId = transaction.Id;

            Assert.AreEqual(expectedId, actualId);
        }
        [TestCase("Failed")]
        [TestCase("Successfull")]
        [TestCase("Aborted")]
        [TestCase("Unauthorized")]
        public void Test_Status_ShouldSetCorrectValue(string transactionStatus)
        {
            TransactionStatus testStatus = Enum.Parse<TransactionStatus>(transactionStatus);
            transaction.Status = testStatus;

            TransactionStatus expectedStatus = testStatus;
            TransactionStatus actualStatus = transaction.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }
        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void Test_From_ShouldThrowExceptionIfSenderIsNullOrWhitespace(string testFrom)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                transaction.From = testFrom;
            });
        }
        [TestCase("TestText")]
        [TestCase("Test Text")]
        [TestCase("Big Test Text With Numbers 1234567890 And Some Punctuation Marks ,.!? And So On...")]
        public void Test_From_ShouldSetCorrectValue(string testFrom)
        {
            transaction.From = testFrom;

            string expectedFrom = testFrom;
            string actualFrom = transaction.From;

            Assert.AreEqual(expectedFrom, actualFrom);
        }
        public void Test_To_ShouldThrowExceptionIfSenderIsNullOrWhitespace(string testTo)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                transaction.To = testTo;
            });
        }
        [TestCase("TestText")]
        [TestCase("Test Text")]
        [TestCase("Big Test Text With Numbers 1234567890 And Some Punctuation Marks ,.!? And So On...")]
        public void Test_To_ShouldSetCorrectValue(string testTo)
        {
            transaction.To = testTo;

            string expectedTo = testTo;
            string actualTo = transaction.To;

            Assert.AreEqual(expectedTo, actualTo);
        }
        [TestCase(0)]
        [TestCase(-0.1)]
        [TestCase(-100)]
        public void Test_Amount_ShouldThrowExceptionWhenGivenValueIsLessThenOrEqualToZero(double testAmount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                transaction.Amount = testAmount;
            });
        }
        [TestCase(0.1)]
        [TestCase(7)]
        [TestCase(100000)]
        public void Test_Amount_ShouldSetCorrectValue(double testAmount)
        {
            transaction.Amount = testAmount;

            double expectedAmount = testAmount;
            double actualAmount = transaction.Amount;

            Assert.AreEqual(expectedAmount, actualAmount);
        }

    }
}
