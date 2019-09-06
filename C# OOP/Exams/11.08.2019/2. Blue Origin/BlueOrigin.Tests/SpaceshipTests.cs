namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class SpaceshipTests
    {
        private Astronaut dummyAstronaut;

        private Spaceship dummySpaceship;

        [SetUp]
        public void SetUp()
        {
            this.dummyAstronaut = new Astronaut("Grigor", 26.97);
            this.dummySpaceship = new Spaceship("Baby Federer", 500);
        }

       [Test]
       public void Constructor_Astronaut_Should_Works_Correctly()
       {
            string expectedName = "Grigor";
            double expectedOxygenPercentage = 26.97;

            Assert.AreEqual(expectedName, this.dummyAstronaut.Name);
            Assert.AreEqual(expectedOxygenPercentage, this.dummyAstronaut.OxygenInPercentage);
       }

        [Test]
        public void Constructor_Spaceship_Should_Works_Correctly()
        {
            string expectedName = "Baby Federer";
            int expectedCapacity = 500;

            Assert.AreEqual(expectedName, this.dummySpaceship.Name);
            Assert.AreEqual(expectedCapacity, this.dummySpaceship.Capacity);
        }

        [Test]
        public void Count_Should_Return_Correct_Count_Of_Astronauts()
        {
            this.dummySpaceship.Add(this.dummyAstronaut);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.dummySpaceship.Count);
        }

        [Test]
        [TestCase(null, 432)]
        public void Name_If_Name_Is_Null_Should_Throw(string name, int capacity)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Spaceship spaceship = new Spaceship(name, capacity);
            });
        }

        [Test]
        [TestCase("", 432)]
        public void Name_If_Name_Is_Empty_String_Should_Throw(string name, int capacity)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Spaceship spaceship = new Spaceship(name, capacity);
            });
        }

        [Test]
        [TestCase("Roger", -1)]
        [TestCase("Roger", -10)]
        public void Capacity_If_Capacity_Is_Negative_Should_Throw(string name, int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Spaceship spaceship = new Spaceship(name, capacity);
            });
        }

        [Test]
        public void Add_Should_Works_Correctly()
        {
            Spaceship spaceship = new Spaceship("Ship", 200);

            spaceship.Add(this.dummyAstronaut);

            Astronaut astronaut = new Astronaut("Daniil", 21.32);

            spaceship.Add(astronaut);

            int expectedCount = 2;

            Assert.AreEqual(expectedCount, spaceship.Count);
        }

        [Test]
        public void Add_Should_Throw_When_Reach_Capacity()
        {
            Spaceship spaceship = new Spaceship("Ship", 0);

            Astronaut astronaut = new Astronaut("Daniil", 21.32);

            Assert.Throws<InvalidOperationException>(() =>
            {
                spaceship.Add(this.dummyAstronaut);
                spaceship.Add(astronaut);
            });
        }

        [Test]
        public void Add_Should_Throw_For_Existing_Astronaut()
        {
            Spaceship spaceship = new Spaceship("Ship", 5);

            spaceship.Add(this.dummyAstronaut);

            Assert.Throws<InvalidOperationException>(() =>
            {
                spaceship.Add(this.dummyAstronaut);
            });
        }

        [Test]
        public void Remove_Should_Works_Correctly()
        {
            Spaceship spaceship = new Spaceship("Ship", 200);

            spaceship.Add(this.dummyAstronaut);

            spaceship.Remove("Grigor");

            int expectedCount = 0;

            Assert.AreEqual(expectedCount, spaceship.Count);
        }
    }
}