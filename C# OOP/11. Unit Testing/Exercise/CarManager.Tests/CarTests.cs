namespace Tests
{
    using CarManager;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Constructor_Works_Correctly()
        {
            Car car = new Car("Audi", "A3", 7, 50);

            Assert.AreEqual("Audi", car.Make);
            Assert.AreEqual("A3", car.Model);
            Assert.AreEqual(7, car.FuelConsumption);
            Assert.AreEqual(50, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void Test_If_MakeProp_Throws_Exception_If_Argument_Is_Null()
        {
            Car car = null;

            Assert.Throws<ArgumentException>(() => car = new Car(null, "A4", 7, 60));
        }

        [Test]
        public void Test_If_ModelProp_Throws_Exception_If_Argument_Is_Null()
        {
            Car car = null;

            Assert.Throws<ArgumentException>(() => car = new Car("Audi", null, 7, 60));
        }

        [Test]
        public void Test_If_FuelConsumptionProp_Throws_Exception_If_Argument_Is_Negative_Number()
        {
            Car car = null;

            Assert.Throws<ArgumentException>(() => car = new Car("Audi", "A3", -7, 60));
        }

        [Test]
        public void Test_If_FuelConsumptionProp_Throws_Exception_If_Argument_Is_Zero()
        {
            Car car = null;

            Assert.Throws<ArgumentException>(() => car = new Car("Audi", "A3", 0, 60));
        }

        [Test]
        public void Test_If_FuelCapacityProp_Throws_Exception_If_Argument_Is_Negative_Number()
        {
            Car car = null;

            Assert.Throws<ArgumentException>(() => car = new Car("Audi", "A3", 7, -60));
        }

        [Test]
        public void Test_Refuel_Works_Correctly()
        {
            Car car = new Car("Audi", "A3", 7, 60);

            car.Refuel(20);

            int expectedFuelAmount = 20;

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void Test_Refuel_Works_Correctly_With_Over_Refuel()
        {
            Car car = new Car("Audi", "A3", 7, 60);

            car.Refuel(20);
            car.Refuel(2000);

            int expectedFuelAmount = 60;

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void Test_Refuel_Throws_Error_In_Case_Of_AmountToRefill_Is_Negative()
        {
            Car car = new Car("Audi", "A3", 7, 60);

            Assert.Throws<ArgumentException>(() => car.Refuel(-20));
        }

        [Test]
        public void Test_If_Drive_Method_Works_Correctly()
        {
            double expectedFuelAmount = 28.6;

            Car car = new Car("Audi", "A3", 7, 60);

            car.Refuel(30);

            car.Drive(20);

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void TestIfDriveMethodThrowsException_If_FuelNeeded_Is_Bigger_Than_FuelAmount()
        {
            Car car = new Car("Audi", "A4", 7, 60);

            Assert.Throws<InvalidOperationException>(() => car.Drive(20));
        }
    }
}