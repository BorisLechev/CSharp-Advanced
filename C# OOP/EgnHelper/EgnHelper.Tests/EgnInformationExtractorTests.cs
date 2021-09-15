using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgnHelper.Tests
{
    [TestFixture]
    public class EgnInformationExtractorTests
    {
        // 6101057509
        // ЕГН на мъж, роден на 5 януари 1961 г. в регион София - окръг
        [Test]
        public void ExtractInformationShouldWorkCorrectlyFor6101057509()
        {
            var informationExtractor = new EgnInformationExtractor();

            var information = informationExtractor.Extract("6101057509");

            Assert.That(information.PlaceOfBirth, Is.EqualTo("София - окръг"));
            Assert.That(information.DateOfBirth, Is.EqualTo(new DateTime(1961, 1, 5)));
            Assert.That(information.Sex, Is.EqualTo(Sex.Male));
            Assert.That(information.ToString(), Is.EqualTo("ЕГН на мъж, роден на 5 януари 1961 г. в регион София - окръг"));
        }

        // 8032056031 
        // ЕГН: 8032056031 е ЕГН на жена, родена на 5 декември 1880 г. в регион Смолян
        [Test]
        public void ExtractInformationShouldWorkCorrectlyFor8032056031()
        {
            var informationExtractor = new EgnInformationExtractor();

            var information = informationExtractor.Extract("8032056031");

            Assert.That(information.PlaceOfBirth, Is.EqualTo("Смолян"));
            Assert.That(information.DateOfBirth, Is.EqualTo(new DateTime(1880, 12, 5)));
            Assert.That(information.Sex, Is.EqualTo(Sex.Female));
            Assert.That(information.ToString(), Is.EqualTo("ЕГН на жена, родена на 5 декември 1880 г. в регион Смолян"));
        }

        // 7552010005 
        // ЕГН на мъж, роден на 1 декември 2075 г. в регион Благоевград
        [Test]
        public void ExtractInformationShouldWorkCorrectlyFor7552010005()
        {
            var informationExtractor = new EgnInformationExtractor();

            EgnInformation information = informationExtractor.Extract("7552010005");

            Assert.That(information.PlaceOfBirth, Is.EqualTo("Благоевград"));
            Assert.That(information.DateOfBirth, Is.EqualTo(new DateTime(2075, 12, 1)));
            Assert.That(information.Sex, Is.EqualTo(Sex.Male));
            Assert.That(information.ToString(), Is.EqualTo("ЕГН на мъж, роден на 1 декември 2075 г. в регион Благоевград"));
        }

        [Test]
        public void ExtractInformationShoulThrowArgumentNullException()
        {
            var informationExtractor = new EgnInformationExtractor();

            Assert.Throws<ArgumentNullException>(() => informationExtractor.Extract(null));
        }

        // 0248079651 
        // ЕГН на жена, родена на 7 август 2002 г. в регион Друг/Неизвестен
        [Test]
        public void ExtractInformationShouldWorkCorrectlyForOtherRegion()
        {
            var informationExtractor = new EgnInformationExtractor();

            EgnInformation information = informationExtractor.Extract("0248079651 ");

            Assert.That(information.PlaceOfBirth, Is.EqualTo("Друг/Неизвестен"));
            Assert.That(information.DateOfBirth, Is.EqualTo(new DateTime(2002, 8, 7)));
            Assert.That(information.Sex, Is.EqualTo(Sex.Female));
            Assert.That(information.ToString(), Is.EqualTo("ЕГН на жена, родена на 7 август 2002 г. в регион Друг/Неизвестен"));
        }
    }
}
