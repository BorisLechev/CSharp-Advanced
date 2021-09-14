using NUnit.Framework;
using System;

namespace EgnHelper.Tests
{
    [TestFixture]
    public class Tests
    {
        [TestCase("7523169263")]
        [TestCase("7552010005")]
        [TestCase("6101057509")]
        public void IsValid_ShouldReturnTrueForValidEgn(string egn)
        {
            Console.WriteLine("In test");

            // Arrange
            var validate = new EgnValidator();

            // Act
            var result = validate.IsValid(egn);

            // Assert
            Assert.IsTrue(result);
        }

        [TestCase("1111111111", "Only ones")]
        [TestCase("jhdhdvgbhygvbdfygb", "Not digits")]
        [TestCase("", "Empty string")]
        [TestCase("0000000000", "Invalid day of month")]
        [TestCase("7523169262", "Invalid checksum")]
        [TestCase("7523169264", "Invalid checksum")]
        [TestCase("7502300005", "Invalid day")]
        public void IsValid_ShouldReturnFalseForInvalidEgn(string egn, string message)
        {
            Console.WriteLine("In test");

            // Arrange
            var validate = new EgnValidator();

            // Act
            var result = validate.IsValid(egn);

            // Assert
            Assert.IsFalse(result, message);
        }

        [Test]
        public void IsValidMethodShouldThrowAnExceptionWhenTheGivenArgumentIsNull()
        {
            // Arrange
            var validate = new EgnValidator();

            Assert.That(() => validate.IsValid(null), Throws.Exception);

            Assert.Throws<ArgumentNullException>(() => validate.IsValid(null));
        }
    }
}