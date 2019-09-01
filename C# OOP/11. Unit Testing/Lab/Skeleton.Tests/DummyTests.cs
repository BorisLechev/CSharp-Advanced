namespace Skeleton.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DummyTests
    {
        // Изпълнява се преди всеки път
        [SetUp]
        public void SetUp()
        {

        }

        // след всеки тест
        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void LoseHealth()
        {
            // Arrange
            Dummy dummy = new Dummy(10, 10);

            // Act
            dummy.TakeAttack(5);

            // Assert
            dummy.Health.Should().Be(5);
        }

        [Test]
        public void Dead_Dummy_Should_Throw_When_Attacked()
        {
            // Arrange
            Dummy dummy = new Dummy(0, 10);

            // Act
            // Assert
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(2));
        }


        [Test]
        public void Dummy_Give_Experience_When_Dies()
        {
            // Arrange
            Dummy dummy = new Dummy(0, 10);

            // Act
            int experience = dummy.GiveExperience();

            // Assert
            experience.Should().Be(10);
        }

        [Test]
        public void CanGiveExperience()
        {
            // Arrange
            Dummy dummy = new Dummy(0, 10);


            // Act
            // Assert
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}
