namespace Skeleton.Tests
{
    using Moq;
    using NUnit.Framework;
    using Skeleton.Contracts;

    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void MockDemo()
        {
            Mock<IWeapon> mockWeapon = new Mock<IWeapon>();
            Mock<ITarget> mockTarget = new Mock<ITarget>();

            mockWeapon.Setup(p => p.Attack(mockTarget.Object));

            mockTarget
                .Setup(t => t.GiveExperience())
                .Returns(() => 1);

            var exp = mockTarget.Object.GiveExperience();

            Hero batman = new Hero("Batman", mockWeapon.Object);
        }
    }
}
