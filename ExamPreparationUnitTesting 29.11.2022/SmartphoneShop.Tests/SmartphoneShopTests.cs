using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private List<Smartphone> phones;
        private int capacity;
        private Shop shop;

        [SetUp]
        public void SetUp()
        {
            phones = new List<Smartphone>()
            {
                new Smartphone("Nokia", 100),
                new Smartphone("Xiaomi", 5000),
                new Smartphone("Pixel", 4000)
            };

            capacity = 5;
            shop = new Shop(capacity);
        }

        [Test]
        public void Test_Constructor_ShouldSetValuesCorrectly()
        {
            int expectedResult = capacity;
            int actualResult = shop.Capacity;
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestCase(-1)]
        [TestCase(-9)]
        [TestCase(-100)]
        public void Test_Capacity_ShouldThrowExceptionIfValueIsNegative(int testCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                shop = new Shop(testCapacity);
            }, "Invalid capacity.");
        }
        [TestCase(1)]
        [TestCase(9)]
        [TestCase(100)]
        public void Test_Capacity_ShouldSetCorrectValue(int testCapacity)
        {
            shop= new Shop(testCapacity);

            int expectedResult = testCapacity;
            int actualResult = shop.Capacity;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Test_Count_ShouldReturnCorrectValue(int numberOfPhones)
        {
            for (int i = 0; i < numberOfPhones; i++)
            {
                shop.Add(phones[i]);
            }

            int expectedResult = numberOfPhones;
            int actualResult = shop.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test_Add_ShouldThrowExceptionIfThePhoneAlreadyExist()
        {
            var phone = new Smartphone("Samsung", 3000);
            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(phone);
            }, $"The phone model {phone.ModelName} already exist.");
        }
        [Test]
        public void Test_Add_ShouldThrowExceptionIfCapacityIsFull()
        {
            shop = new Shop(1);
            var firstPhone = new Smartphone("Samsung", 3000);
            shop.Add(firstPhone);

            var secondPhone = new Smartphone("Mondragno", 3000);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(secondPhone);
            }, "The shop is full.");
        }
        [Test]
        public void Test_Remove_ShouldThrowExceptionIfPhoneDoesNotExist()
        {
            var phone = new Smartphone("Nokia", 2000);
            shop.Add(phone);

            string modelName = "HTC";

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove(modelName);
            }, $"The phone model {modelName} doesn't exist.");
        }
        [Test]
        public void Test_Remove_ShouldWorkCorrectly()
        {
            var phone = new Smartphone("Nokia", 2000);
            shop.Add(phone);
            shop.Remove("Nokia");

            int expectedResult = 0;
            int actualResult = shop.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void Test_TestPhone_ShouldThrowExceptionIfPhoneDoesNotExist()
        {
            var phone = new Smartphone("Nokia", 2000);
            shop.Add(phone);
            string modelName = "HTC";
            int batteryUssage = 2000;
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(modelName, batteryUssage);
            }, $"The phone model {modelName} doesn't exist.");
        }
        [Test]
        public void Test_TestPhone_ShouldThrowExceptionIfBatteryUssageIsBiggerThenBatteryCharge()
        {
            var phone = new Smartphone("Nokia", 2000);
            shop.Add(phone);
            string modelName = "Nokia";
            int batteryUssage = 3000;
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(modelName, batteryUssage);
            }, $"The phone model {phone.ModelName} is low on batery.");
        }
        [Test]
        public void Test_TestPhone_ShouldDecreaseBatteryChargeCorrectly()
        {
            var phone = new Smartphone("Nokia", 2000);
            shop.Add(phone);
            string modelName = "Nokia";
            int batteryUssage = 500;

            shop.TestPhone(modelName, batteryUssage);


            int expectedResut = 1500;
            int actualResult = phone.CurrentBateryCharge;

            Assert.AreEqual(expectedResut, actualResult);
        }
        [Test]
        public void Test_ChargePhone_ShouldThrowExceptionIfPhoneDoesNotExist()
        {
            var phone = new Smartphone("Nokia", 2000);
            shop.Add(phone);
            string modelName = "HTC";
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone(modelName);
            }, $"The phone model {modelName} doesn't exist.");
        }
        [Test]
        public void Test_ChargePhone_ShouldWorkCorrectly()
        {
            var phone = new Smartphone("Nokia", 2000);
            shop.Add(phone);
            string modelName = "Nokia";
            int batteryUssage = 500;

            shop.TestPhone(modelName, batteryUssage);

            shop.ChargePhone(modelName);

            int expectedResult = 2000;
            int actualResult = phone.CurrentBateryCharge;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}