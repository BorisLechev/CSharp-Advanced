namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SoftParkTest
    {
        private SoftPark softPark;

        private Car dummyCar;

        [SetUp]
        public void Setup()
        {
            this.softPark = new SoftPark();
            this.dummyCar = new Car("VW", "V1367SS");
        }

        [Test]
        public void Constructor_Should_Initialize_All_Parking_Spots()
        {
            int expectedCount = 12;
            int actualCount = this.softPark.Parking.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ParkCar_Should_Park_Car_Successfully()
        {
            Car car = new Car("Mercedes", "SA1212SS");

            Assert.That(this.softPark.ParkCar("A1", car), Is.EqualTo("Car:SA1212SS parked successfully!"));
        }

        [Test]
        [TestCase("A0", null)]
        public void ParkCar_Try_Park_On_Invalid_Park_Spot_Should_Throw(string parkSpot, Car car)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.ParkCar(parkSpot, car);
            });
        }

        [Test]
        public void ParkCar_Try_Park_On_Taken_Spot_Should_Throw()
        {
            this.softPark.ParkCar("A4", this.dummyCar);

            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.ParkCar("A4", this.dummyCar);
            });
        }

        [Test]
        public void ParkCar_Try_Park_A_Car_That_Already_Exists_Should_Throw()
        {
            this.softPark.ParkCar("A4", this.dummyCar);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.softPark.ParkCar("A3", this.dummyCar);
            });
        }

        [Test]
        public void RemoveCar_Should_Remove_Car_Successfully()
        {
            Car car = new Car("Mercedes", "SA1212SS");
            this.softPark.ParkCar("A1", car);

            Assert.That(this.softPark.RemoveCar("A1", car), Is.EqualTo("Remove car:SA1212SS successfully!"));
        }

        [Test]
        public void RemoveCar_Try_To_Remove_Invalid_Park_Spot_Should_Throw()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.RemoveCar("A0", null);
            });
        }

        [Test]
        public void RemoveCar_Try_To_Remove_Non_Existing_Car_Should_Throw()
        {
            this.softPark.ParkCar("A4", this.dummyCar);
            this.softPark.RemoveCar("A4", this.dummyCar);

            Assert.Throws<ArgumentException>(() =>
            {
                this.softPark.RemoveCar("A4", this.dummyCar);
            });
        }
    }
}