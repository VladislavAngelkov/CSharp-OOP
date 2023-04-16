namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person[] persons16;
        private Person[] persons1;
        private Person[] persons3;

        [SetUp]
        public void SetUp()
        {
            persons16 = new Person[]
            {
                new Person(1, "Name1"),
                new Person(2, "Name2"),
                new Person(3, "Name3"),
                new Person(4, "Name4"),
                new Person(5, "Name5"),
                new Person(6, "Name6"),
                new Person(7, "Name7"),
                new Person(8, "Name8"),
                new Person(9, "Name9"),
                new Person(10, "Name10"),
                new Person(11, "Name11"),
                new Person(12, "Name12"),
                new Person(13, "Name13"),
                new Person(14, "Name14"),
                new Person(15, "Name15"),
                new Person(16, "Name16")
            };
            persons3 = new Person[]
            {
                new Person(1, "Name1"),
                new Person(2, "Name2"),
                new Person(3, "Name3"),
            };
            persons1 = new Person[]
            {
                new Person(1, "Name1")
            };
        }

        [Test]
        public void Test_ConstructorShouldCreateArrayWithCount16()
        {


            Database database = new Database(persons16);

            int expectedCount = persons16.Length;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Test_ConstructorShouldCreateArrayWithCount1()
        {
            Person[] persons = new Person[]
            {
                new Person(1, "Name")
            };

            Database database = new Database(persons);

            int expectedCount = persons.Length;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Test_ConstructorShouldCreateArrayWithCount0()
        {
            Person[] persons = new Person[0];


            Database database = new Database(persons);

            int expectedCount = persons.Length;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Test_AddMethodShouldThrowExceptionIfArrayIsFull()
        {
            Database database = new Database(persons16);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(33, "Gosho"));
            }, "Array's capacity must be exactly 16 integers!");
        }
        [Test]
        public void Test_AddMethodShouldThrowExeptionIfUserWithTheSameNameAlreadyExist()
        {
            Person userToAdd = new Person(33, "Name1");
            Database database = new Database(persons3);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(userToAdd);
            }, "There is already user with this username!");
        }
        [Test]
        public void Test_AddMethodShouldThrowExeptionIfUserWithTheSameIdAlreadyExist()
        {
            Person userToAdd = new Person(1, "Name33");
            Database database = new Database(persons3);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(userToAdd);
            }, "There is already user with this Id!");
        }
        [Test]
        public void Test_AddMethodShouldIncreaseCountWhenUserAdded()
        {
            Person userToAdd = new Person(33, "Name33");
            Database database = new Database(persons3);

            int expectedCount = persons3.Length + 1;

            database.Add(userToAdd);
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void Test_RemoveMethodShouldThrowExceptionIfArrayCountIsZero()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }
        [Test]
        public void Test_RemoveMethodShouldLowerCount()
        {
            Database database = new Database(persons3);
            database.Remove();

            int actualCount = database.Count;
            int expectedCount = 2;

            Assert.AreEqual(expectedCount, actualCount);
        }
        [TestCase("")]
        [TestCase(null)]
        public void Test_FindByUsernameMethodShouldThrowExceptionIfGivenNameIsNullOrEmpty(string name)
        {
            Database database = new Database(persons3);

            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(name);
            }, "Username parameter is null!");
        }
        [Test]
        public void Test_FindByUsernameMethodShouldThrowExceptionIfThereIsNoUserWithThatName()
        {
            Database database = new Database(persons3);
            string name = "Pesho";

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername(name);
            }, "No user is present by this username!");
        }
        [Test]
        public void Test_FindByUsernameMethodShouldReturnCorrectUser()
        {
            Database database = new Database(persons3);
            string name = "Name1";
            Person person = database.FindByUsername(name);

            string expectedName = name;
            int expectedId = 1;
            string actualName = person.UserName;
            long actualId = person.Id;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedId, actualId);
        }
        [TestCase(-1)]
        [TestCase(-33)]
        public void Test_FindByIdMethodShouldThrowExceptionIfGivenIdIsLessThenZero(long id)
        {
            Database database = new Database(persons3);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(id);
            }, "Id should be a positive number!");
        }
        [Test]
        public void Test_FindByIdMethodShouldThrowExceptionIfThereIsNoUserWithThatId()
        {
            Database database = new Database(persons3);
            long id = 33;

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(id);
            }, "No user is present by this ID!");
        }
        [Test]
        public void Test_FindByIdMethodShouldReturnCorrectUser()
        {
            Database database = new Database(persons3);
            long id = 1;
            Person person = database.FindById(id);

            string expectedName = "Name1";
            long expectedId = id;
            string actualName = person.UserName;
            long actualId = person.Id;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedId, actualId);
        }
    }
}

