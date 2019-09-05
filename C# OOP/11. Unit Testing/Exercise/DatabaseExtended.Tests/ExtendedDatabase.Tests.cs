namespace Tests
{
    using NUnit.Framework;
    using ExtendedDatabase;
    using System;

    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;

        private static Person[] people;

        [SetUp]
        public void Setup()
        {
            people = new Person[] { new Person(0, "John"), new Person(1, "Radko") };
            this.database = new ExtendedDatabase(people);
        }

        [Test]
        public void Test_Constructor_Works_Correctly()
        {
            Assert.AreEqual(2, this.database.Count);
        }

        [Test]
        public void Add_Person_Correctly()
        {
            Person person = new Person(2, "Jivko");

            this.database.Add(person);

            Assert.AreEqual(3, this.database.Count);
        }

        [Test]
        public void Add_Database_Is_Full()
        {
            this.database.Add(new Person(2, "Jivko"));
            this.database.Add(new Person(3, "Jeremy"));
            this.database.Add(new Person(4, "Sebastian"));
            this.database.Add(new Person(5, "Thierry"));
            this.database.Add(new Person(6, "Alberto"));
            this.database.Add(new Person(7, "Frederic"));
            this.database.Add(new Person(8, "Francis"));
            this.database.Add(new Person(9, "Sam"));
            this.database.Add(new Person(10, "Daniella"));
            this.database.Add(new Person(11, "Olivier"));
            this.database.Add(new Person(12, "Dominic"));
            this.database.Add(new Person(13, "David"));
            this.database.Add(new Person(14, "Boris"));
            this.database.Add(new Person(15, "Tammy"));

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(new Person(16, "Kim"));
            });
        }

        [Test]
        public void Add_Two_People_With_Same_Usernames()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(new Person(3, "Radko"));
            });
        }

        [Test]
        public void Add_Two_People_With_Same_Id()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(new Person(1, "Guro"));
            });
        }

        [Test]
        public void Remove_Person_Correctly()
        {
            int expectedLength = this.database.Count - 1;

            this.database.Remove();

            Assert.AreEqual(expectedLength, this.database.Count);
        }

        [Test]
        public void Find_Person_By_Username_Correctly()
        {
            Person expectedPerson = this.database.People[0];

            Person actualPerson = this.database.FindByUsername("John");

            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [Test]
        public void Throw_Exception_If_Username_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(null));
        }

        [Test]
        public void Throw_Exception_If_Person_With_Such_Username_Does_Not_Exist_In_The_Database()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername("Nedko"));
        }

        [Test]
        public void Find_Person_By_Id_Correctly()
        {
            Person expectedPerson = this.database.People[0];

            Person actualPerson = this.database.FindById(0);

            Assert.AreEqual(expectedPerson.Username, actualPerson.Username);
        }

        [Test]
        public void Throw_Exception_If_Id_Is_Negative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(-1));
        }

        [Test]
        public void Throw_Exception_If_Person_With_Such_Id_Does_Not_Exist_In_The_Database()
        {
            Assert.Throws<InvalidOperationException>(() => this.database.FindById(9999));
        }
    }
}