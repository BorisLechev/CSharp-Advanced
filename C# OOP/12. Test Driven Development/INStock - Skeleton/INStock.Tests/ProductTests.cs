namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void Constructor_Should_Initialize_CorrectValues()
        {
            string label = "SSD";
            decimal price = 154.99m;
            int quantity = 3;

            IProduct product = new Product(label, price, quantity);

            Assert.AreEqual(label, product.Label);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(quantity, product.Quantity);
        }

        [Test]
        public void Constructor_Invalid_Label_Should_Throw_ArgumentNullException()
        {
            string invalidLabel = null;
            decimal price = 154.99m;
            int quantity = 3;

            Assert.Throws<ArgumentNullException>(() => 
            {
                new Product(invalidLabel, price, quantity);
            });
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(-500)]
        public void Constructor_InvalidPrice_Should_Throw_ArgumentException(decimal price)
        {
            string label = "SSD";
            int quantity = 3;

            Assert.Throws<ArgumentException>(() =>
            {
                new Product(label, price, quantity);
            });
        }

        [Test]
        public void Constructor_InvalidQuantity_Should_Throw_ArgumentException()
        {
            string label = "SSD";
            decimal price = 78.99m;
            int invalidQuantity = -3;

            Assert.Throws<ArgumentException>(() =>
            {
                new Product(label, price, invalidQuantity);
            });
        }

        [Test]
        public void CompareTo_Should_Return_Label_With_Greater_ASCII_Code()
        {
            string greaterProductLabel = "Camera";
            decimal greaterProductPrice = 799.99m;
            int greaterProductQuantity = 1;

            string smallerproductLabel = "Camcorder";
            decimal smallerProductPrice = 1299.99m;
            int smallerProductQuantity = 1;

            IProduct greaterProduct = new Product(greaterProductLabel, greaterProductPrice, greaterProductQuantity);
            IProduct smallerProduct = new Product(smallerproductLabel, smallerProductPrice, smallerProductQuantity);

            int actualResult = greaterProduct.CompareTo(smallerProduct);
            int expectedResult = 1;

            // Assert.That(() => actualResult, Is.EqualTo(1));
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}