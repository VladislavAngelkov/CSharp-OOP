using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;

namespace FootballTeam.Tests
{
    [TestFixture]
    public class Tests
    {
        private string name;
        private int capacity;
        private FootballPlayer playerOne;
        private FootballPlayer playerTwo;
        private FootballTeam team;

        [SetUp]
        public void Setup()
        {
            name = "Barsa";
            capacity = 20;
            team = new FootballTeam(name, capacity);
            playerOne = new FootballPlayer("Messi", 9, "Forward");
            playerTwo = new FootballPlayer("Ronaldo", 8, "Forward");
        }

        [Test]
        public void Constructor_ShouldSetNameCorrectly()
        {
            string expectedName = name;
            string actualName = team.Name;

            Assert.AreEqual(expectedName, actualName);
        }
        [Test]
        public void Constructor_ShouldSetCapacityCorrectly()
        {
            int expectedCapacity = capacity;
            int actualCapacity = team.Capacity;

            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        [Test]
        public void Constructor_ShouldInitiatePlayersCollection()
        {
            Type type = typeof(FootballTeam);
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var playersField = fields.FirstOrDefault(f => f.Name == "players");

            Assert.IsNotNull(playersField);
        }
        [TestCase(null)]
        [TestCase("")]
        public void Name_ShouldThrowExceptionIfValueIsNullOrEmpty(string testName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                team = new FootballTeam(testName, capacity);
            }, "Name cannot be null or empty!");
        }
        [Test]
        public void Name_ShouldSetNameCorrectly()
        {
            string newName = "Real";
            team.Name = newName;

            string expectedName = newName;
            string actualName = team.Name;

            Assert.AreEqual(expectedName, actualName);
        }
        [Test]
        public void Capacity_ShouldThrowExceptionIfValueIsLessThen15()
        {
            int testCapacity = 10;
            Assert.Throws<ArgumentException>(() =>
            {
                team = new FootballTeam(name, testCapacity);
            }, "Capacity min value = 15");
        }
        [Test]
        public void Capacity_ShouldSetCapacityCorrectly() 
        {
            int testCapacity = 16;
            team.Capacity = testCapacity;

            int expectedCapacity = testCapacity;
            int actualCapacity = team.Capacity;

            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        [Test]
        public void Players_ShouldReturnCorrectCollection()
        {
            team.AddNewPlayer(playerOne);
            team.AddNewPlayer(playerTwo);

            List<FootballPlayer> expectedResult = new List<FootballPlayer>()
            {
                playerOne, playerTwo
            };

            var actualResult = team.Players;

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void AddNewPlayer_ShouldreturnCorrectMessageIfCapacityIsFull()
        {
            for (int i = 0; i < team.Capacity; i++)
            {
                team.AddNewPlayer(playerOne);
            }

            string expectedMessage = "No more positions available!";
            string actualMessage = team.AddNewPlayer(playerOne);

            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [Test]
        public void AddNewPlayer_ShouldReturnCorrectMessageIfPlayerAdded()
        {
            string expectedMessage = $"Added player {playerOne.Name} in position {playerOne.Position} with number {playerOne.PlayerNumber}";
            string actualMessage = team.AddNewPlayer(playerOne);

            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [Test]
        public void AddNewPlayer_ShouldAddThePlayer()
        {
            team.AddNewPlayer(playerOne);
            team.AddNewPlayer(playerTwo);

            Assert.IsTrue(team.Players.Contains(playerOne));
            Assert.IsTrue(team.Players.Contains(playerTwo));
        }
        [Test]
        public void PickPlayer_ShouldReturnCorrectPlayer()
        {
            team.AddNewPlayer(playerOne);
            team.AddNewPlayer(playerTwo);

            var actualPlayer = team.PickPlayer(playerOne.Name);

            Assert.AreEqual(playerOne, actualPlayer);
        }
        [Test]
        public void PlayerScore_ShouldIncreasePlayersScoredGoals()
        {
            team.AddNewPlayer(playerOne);
            team.AddNewPlayer(playerTwo);

            team.PlayerScore(playerOne.PlayerNumber);

            int expectedResult = 1;
            int actualResult = team.PickPlayer(playerOne.Name).ScoredGoals;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void PlayerScore_ShouldReturnCorrectMessage()
        {
            team.AddNewPlayer(playerOne);
            team.AddNewPlayer(playerTwo);

            string actualMessage = team.PlayerScore(playerOne.PlayerNumber);
            string expectedMessage = $"{playerOne.Name} scored and now has {playerOne.ScoredGoals} for this season!";

            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}