namespace INStock.Tests
{
    using INStock.Contracts;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class ProductStockTests
    {
        private ProductStock productStock;
        [SetUp]
        public void SetUp()
        {
            productStock = new ProductStock();
        }
        [Test]
        public void Test_Constructor_ShouldInitiateProductsHashSet()
        {
            Type type = typeof(ProductStock);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo field = fields.FirstOrDefault(f => f.Name == "products");
            var productCollection = field.GetValue(productStock);

            Assert.IsNotNull(productCollection);
        }
        [Test]
        public void Test_Add_ShouldIncreaseProductsCountIfProductIsntAlreadyInTheStock()
        {
            Mock<Product> productMock = new Mock<Product>();
            var product = productMock.Object;
            productStock.Add(product);

            int expextedCount = 1;
            int actualCount = productStock.Count();

            Assert.AreEqual(expextedCount, actualCount);
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(10)]
        public void Test_Count_ShouldReturnCorrectValue(int timesAdded)
        {
            Mock<Product> productMock = new Mock<Product>();
            var product = productMock.Object;
            for (int i = 0; i < timesAdded; i++)
            {
                productStock.Add(product);
            }

            int expectedCount = timesAdded;
            int actualCount = productStock.Count();

            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void Test_Contains_ShouldReturnTrue()
        {
            string label = "TestProduct";
            Mock<Product> productMock = new Mock<Product>();
            productMock.Setup(p => p.Label).Returns(label);
            var product = productMock.Object;
            productStock.Add(product);
            Assert.IsTrue(productStock.Contains(product));
        }
        [Test]
        public void Test_Contains_ShouldReturnFalse()
        {
            string label = "TestProduct";
            Mock<Product> productMock = new Mock<Product>();
            productMock.Setup(p => p.Label).Returns(label);
            var product = productMock.Object;
            productStock.Add(product);

            Mock<Product> desiredProduct = new Mock<Product>();
            desiredProduct.Setup(p => p.Label).Returns("");

            Assert.IsTrue(productStock.Contains(desiredProduct.Object));
        }
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(10)]
        public void Test_Find_ShouldThrowExceptionIfProductDoesntExistAtGivenIndex(int index)
        {
            Mock<Product> productMock = new Mock<Product>();
            var product = productMock.Object;
            productStock.Add(product);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                productStock.Find(index);
            });
        }
        [Test]
        public void Test_Find_ShouldReturnProductIfSuchExist()
        {
            Mock<Product> productMock = new Mock<Product>();
            var product = productMock.Object;
            productStock.Add(product);

            var returnedProduct = productStock.Find(0);

            Assert.IsNotNull(returnedProduct);
        }
        [Test]
        public void Test_FindAllByPrice_ShouldReturnAllProductsWithThatPrice()
        {
            Mock<Product> productOneMock = new Mock<Product>();
            productOneMock.Setup(p => p.Price).Returns(10);
            var productOne = productOneMock.Object;

            Mock<Product> productTwoMock = new Mock<Product>();
            productTwoMock.Setup(p => p.Price).Returns(10);
            var productTwo = productTwoMock.Object;

            Mock<Product> productThreeMock = new Mock<Product>();
            productThreeMock.Setup(p => p.Price).Returns(20);
            var productThree = productThreeMock.Object;

            productStock.Add(productOne);
            productStock.Add(productTwo);
            productStock.Add(productThree);

            var products = productStock.FindAllByPrice(10);

            Assert.AreEqual(2, products.Count());
        }
        [Test]
        public void Test_FindByQuantity_ShouldReturnProductsWithGivenQuantity()
        {
            Mock<Product> productOneMock = new Mock<Product>();
            productOneMock.Setup(p => p.Quantity).Returns(10);
            var productOne = productOneMock.Object;

            Mock<Product> productTwoMock = new Mock<Product>();
            productTwoMock.Setup(p => p.Quantity).Returns(10);
            var productTwo = productTwoMock.Object;

            Mock<Product> productThreeMock = new Mock<Product>();
            productThreeMock.Setup(p => p.Quantity).Returns(20);
            var productThree = productThreeMock.Object;

            productStock.Add(productOne);
            productStock.Add(productTwo);
            productStock.Add(productThree);

            var products = productStock.FindAllByQuantity(10);

            Assert.AreEqual(2, products.Count());
        }
        [Test]
        public void Test_FindAllInRange_ShouldReturnProductsWithPricesInThatRange()
        {
            Mock<Product> productOneMock = new Mock<Product>();
            productOneMock.Setup(p => p.Price).Returns(10);
            var productOne = productOneMock.Object;

            Mock<Product> productTwoMock = new Mock<Product>();
            productTwoMock.Setup(p => p.Price).Returns(20);
            var productTwo = productTwoMock.Object;

            Mock<Product> productThreeMock = new Mock<Product>();
            productThreeMock.Setup(p => p.Price).Returns(30);
            var productThree = productThreeMock.Object;

            productStock.Add(productOne);
            productStock.Add(productTwo);
            productStock.Add(productThree);

            var products = productStock.FindAllInRange(15, 25);

            Assert.AreEqual(1, products.Count());
        }
        [Test]
        public void Test_FindByLabel_ShouldReturnProductWithGivenLabel()
        {
            string desiredLabel = "TestProduct";

            Mock<Product> productOneMock = new Mock<Product>();
            productOneMock.Setup(p => p.Label).Returns(desiredLabel);
            var productOne = productOneMock.Object;

            Mock<Product> productTwoMock = new Mock<Product>();
            productTwoMock.Setup(p => p.Label).Returns("NotCorrectTestProduct");
            var productTwo = productTwoMock.Object;

            Mock<Product> productThreeMock = new Mock<Product>();
            productThreeMock.Setup(p => p.Label).Returns("NotCorrectTestProductEither");
            var productThree = productThreeMock.Object;

            productStock.Add(productOne);
            productStock.Add(productTwo);
            productStock.Add(productThree);

            var product = productStock.FindByLabel(desiredLabel);

            Assert.IsNotNull(product);
        }
        [Test]
        public void Test_FindByLabel_ShouldReturnNull()
        {
            string desiredLabel = "TestProduct";

            Mock<Product> productOneMock = new Mock<Product>();
            productOneMock.Setup(p => p.Label).Returns("SomethingElse");
            var productOne = productOneMock.Object;

            Mock<Product> productTwoMock = new Mock<Product>();
            productTwoMock.Setup(p => p.Label).Returns("NotCorrectTestProduct");
            var productTwo = productTwoMock.Object;

            Mock<Product> productThreeMock = new Mock<Product>();
            productThreeMock.Setup(p => p.Label).Returns("NotCorrectTestProductEither");
            var productThree = productThreeMock.Object;

            productStock.Add(productOne);
            productStock.Add(productTwo);
            productStock.Add(productThree);

            var product = productStock.FindByLabel(desiredLabel);

            Assert.IsNull(product);
        }
        [Test]
        public void Test_FindMostExpensiveProduct_ShouldReturnTheProductWithTheHighestPrice()
        {
            Mock<Product> productOneMock = new Mock<Product>();
            productOneMock.Setup(p => p.Price).Returns(10);
            var productOne = productOneMock.Object;

            Mock<Product> productTwoMock = new Mock<Product>();
            productTwoMock.Setup(p => p.Price).Returns(20);
            var productTwo = productTwoMock.Object;

            Mock<Product> productThreeMock = new Mock<Product>();
            productThreeMock.Setup(p => p.Price).Returns(30);
            var productThree = productThreeMock.Object;

            productStock.Add(productOne);
            productStock.Add(productTwo);
            productStock.Add(productThree);

            var product = productStock.FindMostExpensiveProduct();

            Assert.AreEqual(productThree.Price, product.Price);
        }
        [Test]
        public void Test_GetEnumerator_ShouldReturnIEnumerator()
        {
            Type type = productStock.GetType();
            MethodInfo[] methods = type.GetMethods();
            MethodInfo method = methods.FirstOrDefault(m=>m.Name == "GetEnumerator");

            var enumerator = method.Invoke(productStock, new object[] { });
           
            Assert.IsTrue(typeof(IEnumerator<Product>).IsAssignableFrom(enumerator.GetType()));
        }
        [Test]
        public void Test_Remove_ShouldRemoveGivenElement()
        {
            Mock<Product> productOneMock = new Mock<Product>();
            productOneMock.Setup(p => p.Label).Returns("TestProductOne");
            var productOne = productOneMock.Object;

            Mock<Product> productTwoMock = new Mock<Product>();
            productTwoMock.Setup(p => p.Label).Returns("TestProductTwo");
            var productTwo = productTwoMock.Object;

            Mock<Product> productThreeMock = new Mock<Product>();
            productThreeMock.Setup(p => p.Label).Returns("TestProductThree");
            var productThree = productThreeMock.Object;

            productStock.Add(productOne);
            productStock.Add(productTwo);
            productStock.Add(productThree);

            var product = productStock.Remove(productOne);

            Assert.AreEqual(2, productStock.Count);
        }
        [Test]
        public void Test_IEnumerableGetEnumerator_houldReturnIEnumerator()
        {
            Type type = productStock.GetType();
            MethodInfo[] methods = type.GetMethods();
            MethodInfo method = methods.FirstOrDefault(m => m.Name == "IEnumerable.GetEnumerator");

            var enumerator = method.Invoke(productStock, new object[] { });

            Assert.IsTrue(typeof(IEnumerator<Product>).IsAssignableFrom(enumerator.GetType()));
        }
    }
}
