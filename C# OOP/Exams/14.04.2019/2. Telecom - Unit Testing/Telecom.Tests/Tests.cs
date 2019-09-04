namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        private Phone dummyPhone;

        [SetUp]
        public void SetUp()
        {
            this.dummyPhone = new Phone("Nokia", "A56");
        }

        [Test]
        public void Constructor_Should_Workks_Correctly()
        {
            string make = "Nokia";
            string model = "A56";

            Assert.AreEqual(make, this.dummyPhone.Make);
            Assert.AreEqual(model, this.dummyPhone.Model);
        }

        [Test]
        [TestCase(null, "S5")]
        [TestCase("", "S5")]
        public void Make_If_make_Is_Null_Should_Throw(string make, string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone(make, model);
            });
        }

        [Test]
        [TestCase("S5", null)]
        [TestCase("S5", "")]
        public void Model_If_make_Is_Null_Should_Throw(string make, string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone(make, model);
            });
        }

        [Test]
        public void Count_Initial_Count_Should_Be_Zero()
        {
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, this.dummyPhone.Count);
        }

        [Test]
        [TestCase("Grigor", "08856789")]
        public void AddContact_Should_Return_Correct_Count(string name, string phone)
        {
            this.dummyPhone.AddContact(name, phone);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.dummyPhone.Count);
        }

        [Test]
        [TestCase("Roger", "08856788")]
        public void AddContact_If_Contact_Already_Exists_Should_Throw(string name, string phone)
        {
            this.dummyPhone.AddContact(name, phone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.dummyPhone.AddContact(name, phone);
            });
        }

        [Test]
        [TestCase("Roger", "08856788")]
        public void Call_If_Contact_Exists_Should_Work_Correctly(string name, string phone)
        {
            this.dummyPhone.AddContact(name, phone);

            Assert.That(this.dummyPhone.Call(name), Is.EqualTo($"Calling {name} - {phone}..."));
        }

        [Test]
        [TestCase("Roger", "08856788")]
        public void Call_If_Contact_Does_Not_Exists_Should_Throw(string name, string phone)
        {
            this.dummyPhone.AddContact(name, phone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.dummyPhone.Call("Novak");
            });
        }
    }
}