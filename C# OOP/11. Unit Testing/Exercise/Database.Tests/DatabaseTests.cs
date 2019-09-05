namespace Tests
{
    using Database;
    using FluentAssertions;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        private readonly int[] data = new int[] { 16, 43, 34, 87, 12, 98, 88, 1, 8, 77, 51, 13, 16, 90, 12, 69 };

        [SetUp]
        public void Setup()
        {
            this.database = new Database(data);
        }

        [Test]
        public void Throws_Exception_When_Create_Object_Without_Parameters_Or_Params_More_Than_Capacity()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.Add(72));
        }

        [Test]
        public void Return_Count_Of_The_Collection()
        {
            Assert.AreEqual(16, this.database.Count);
        }

        [Test]
        public void Add_Element_In_The_Collection_Correctly()
        {
            this.database.Remove();
            this.database.Add(3);

            database.Count.Should().Be(16);
        }

        [Test]
        [TestCase(16, 43, 34, 87, 12, 98, 88, 1, 8, 77, 51, 13, 16, 90, 12, 69)]
        public void Throw_Exception_When_Add_Element(params int[] numbers)
        {
            Database database = new Database(numbers);

            Assert.Throws<InvalidOperationException>(() => database.Add(3));
        }

        [Test]
        public void Remove_Element_From_Empty_Database()
        {
            Database database = new Database()
;
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Test_Fetch_Works_Correctly()
        {
            CollectionAssert.AreEqual(this.data, this.database.Fetch());
        }
    }
}