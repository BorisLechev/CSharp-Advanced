namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ProductStockTests
    {
        private IProductStock productStock;
        private IProduct dummyProduct;

        [SetUp]
        public void SetUp()
        {
            this.productStock = new ProductStock();
            this.dummyProduct = new Product("SSD", 123.99m, 4); 
        }

        [Test]
        public void Constructor_Should_Initialize_The_Array()
        {
            int expected = 4;
            int actual = this.productStock.Capacity;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_Should_Increase_Quantity_For_Products_With_Same_Label()
        {
            string label = "SSD";
            decimal price = 123.99m;
            int quantity = 2;

            IProduct dummyProduct1 = new Product(label, price, quantity);
            IProduct dummyProduct2 = new Product(label, price, quantity);

            this.productStock.Add(dummyProduct1);
            this.productStock.Add(dummyProduct2);

            int expectedCount = 1;
            int actualCount = this.productStock.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Add_Should_Add_Successfully()
        {
            string label = "SSD";
            decimal price = 123.99m;
            int quantity = 2;

            IProduct dummyProduct1 = new Product(label, price, quantity);

            this.productStock.Add(dummyProduct1);

            int expectedCount = 1;
            int actualCount = this.productStock.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Add_Should_Resize_When_Count_Is_Equal_To_Array_Length()
        {
            IProduct[] products = new []
            {
                new Product("Test1", 67.99m, 12),
                new Product("Test2", 67.99m, 12),
                new Product("Test3", 67.99m, 12),
                new Product("Test4", 67.99m, 12),
                new Product("Test5", 67.99m, 12),
            };

            foreach (IProduct product in products)
            {
                this.productStock.Add(product);
            }

            int expectedCount = 8;
            int actualArraySize = this.productStock.Capacity;

            Assert.AreEqual(expectedCount, actualArraySize);
        }

        [Test]
        public void Add_Should_throw_InvalidOperationException_When_NULL_Is_Passed()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.productStock.Add(null);
            });
        }

        [Test]
        public void Set_Invalid_Index_Should_Return_OutOfRangeException()
        {
            IProduct product = new Product("DummyLabel", 1, 2);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                this.productStock[this.productStock.Capacity + 5] = product;
            });
        }

        [Test]
        public void Set_ValidInvalid_Successfully()
        {
            IProduct product = new Product("HDD", 54.99m, 2);
            this.productStock[0] = product;

            IProduct actualProduct = this.productStock[0];

            Assert.AreSame(product, actualProduct);
        }

        [Test]
        public void Get_Valid_Index_Should_Return_Value()
        {
            this.productStock.Add(this.dummyProduct);

            IProduct actualproduct = this.productStock[0];

            Assert.AreSame(this.dummyProduct, actualproduct);
        }

        [Test]
        public void Get_Invalid_Index_Should_Return_OutOfRangeException()
        {
            this.productStock.Add(this.dummyProduct);

            IProduct product = null;

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                product = this.productStock[2];
            });
        }

        [Test]
        public void Remove_Should_Remove_Successfully_Product()
        {
            this.productStock.Add(this.dummyProduct);

            this.productStock.Remove(this.dummyProduct);

            int expectedValue = 0;
            int actualValue = this.productStock.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Remove_Should_Reorder_Correctly()
        {
            IProduct[] products = new[]
            {
                new Product("Test1", 67.99m, 12),
                new Product("Test2", 67.99m, 12),
                new Product("FailProduct", 67.99m, 12),
                new Product("Test3", 67.99m, 12),
                new Product("Test4", 67.99m, 12),
                new Product("Test5", 67.99m, 12),
                new Product("Test6", 67.99m, 12),
                new Product("Test7", 67.99m, 12),
            };

            foreach (IProduct product in products)
            {
                this.productStock.Add(product);
            }

            this.productStock.Remove(products[2]);

            for (int i = 2; i < this.productStock.Count; i++)
            {
                Assert.AreEqual(products[i + 1], this.productStock[i]);
            }
        }

        [Test]
        public void Remove_Should_Shrink_When_The_Length_Is_Half_Empty()
        {
            IProduct[] products = new[]
    {
                new Product("Test1", 67.99m, 12),
                new Product("Test2", 67.99m, 12),
                new Product("Test3", 67.99m, 12),
                new Product("Test4", 67.99m, 12),
                new Product("Test5", 67.99m, 12)
            };

            foreach (IProduct product in products)
            {
                this.productStock.Add(product);
            }

            this.productStock.Remove(products[3]);

            int expectedValue = 4;
            int actualValue = this.productStock.Capacity;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Remove_Should_return_False_When_Product_Was_Not_Found()
        {
            var actualResult = this.productStock.Remove(this.dummyProduct);

            Assert.That(() => actualResult, Is.False);
        }

        [Test]
        public void Find_Return_Product_Successfully()
        {
            this.productStock.Add(this.dummyProduct);

            var expectedProduct = this.productStock.Find(0);
            var actualProduct = this.dummyProduct;

            Assert.AreSame(expectedProduct, actualProduct);
        }

        [Test]
        [TestCase(69)]
        [TestCase(-5)]
        [TestCase(1)]
        public void Find_Should_Return_IndexOutOfRangeException_When_Invalid_Index_Is_Passed(int index)
        {
            this.productStock.Add(this.dummyProduct);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                this.productStock.Find(index);
            });
        }

        [Test]
        public void Contains_Should_Return_True_If_Existing_Product_Is_Passed()
        {
            this.productStock.Add(this.dummyProduct);

            bool expectedResult = true;
            bool actualResult = this.productStock.Contains(this.dummyProduct);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Contains_Should_Return_False_If_Product_Does_Not_Exist()
        {
            bool expectedResult = false;
            bool actualResult = this.productStock.Contains(this.dummyProduct);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Contains_Should_Throw_ArgumentNULLException_When_NULL_Is_Passed()
        {
            this.productStock.Add(this.dummyProduct);

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.productStock.Contains(null);
            });
        }

        [Test]
        public void FindByLabel_Should_Return_Correct_Product_Successfully()
        {
            this.productStock.Add(this.dummyProduct);

            IProduct expectedProduct = this.dummyProduct;
            IProduct actualProduct =  this.productStock.FindByLabel("SSD");

            Assert.AreSame(expectedProduct, actualProduct);
        }

        [Test]
        public void FindByLabel_Should_Throw_ArgumentNullException_If_Such_Product_Does_Not_Exist()
        {
            this.productStock.Add(this.dummyProduct);

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.productStock.FindByLabel("HDD");
            });
        }

        [Test]
        public void FindMostExpensiveProduct_Successfully()
        {
            this.productStock.Add(this.dummyProduct);

            IProduct secondProduct = new Product("PC", 201.99m, 1);

            this.productStock.Add(secondProduct);

            IProduct expectedProduct = secondProduct;
            IProduct actualProduct = this.productStock.FindMostExpensiveProduct();

            Assert.AreSame(expectedProduct, actualProduct);
        }
    }
}
