namespace Skeleton.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using System;

    [TestFixture] // za da znae kompilatora, che e palen s testove
    public class AxeTests
    {
        [Test]
        public void FirstTest()
        {
            Axe axe = new Axe(10, 10);

            // rabotat li get; set;
            //Assert.AreEqual(10, axe.AttackPoints);
            //Assert.AreEqual(10, axe.DurabilityPoints);

            // sintaksis na Fluent Assertions -> Documentation !!!
            axe.AttackPoints.Should().Be(10);
            axe.DurabilityPoints.Should().Be(10);
        }

        [Test]
        public void Axe_Attack_Should_Drop_Durability_By_One()
        {
            // AAA Pattern

            // Arrange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            // Act (1 row)
            axe.Attack(dummy);

            // Assert (1 row or 3 max)
            // ot -> this.durabilityPoints -= 1;
            axe.DurabilityPoints.Should().Be(9);
        }
    }
}
