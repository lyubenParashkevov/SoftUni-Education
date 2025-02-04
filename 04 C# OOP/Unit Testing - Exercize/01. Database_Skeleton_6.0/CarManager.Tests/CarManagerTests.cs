namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Ford", "Orion", 2.0, 50.0);
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            string expectedMake = "Ford";
            string expectedModel = "Orion";
            double expectedConsumption = 2;
            double expectedFuelCapacity = 50;

            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedConsumption, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void CarShouldBeCreatedWithZeroFuelAmount()
        {
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void PropertyMakeShouldThrowExceptionIfValueIsNullOrEmpty(string make)
        {

            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => new Car(make, "Orion", 2.0, 50.0));
            Assert.AreEqual("Make cannot be null or empty!", ex.Message);

        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void PropertyModelShouldThrowExceptionIfValueIsNullOrEmpty(string model)
        {

            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => new Car("Ford", model, 2.0, 50.0));
            Assert.AreEqual("Model cannot be null or empty!", ex.Message);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-21)]
        public void PropertyFuelConsumptionlShouldThrowExceptionIfValueIsZeroOrNegative(double
            fuelConsumption)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => new Car("Ford", "Orion", fuelConsumption, 50.0));
            Assert.AreEqual("Fuel consumption cannot be zero or negative!", ex.Message);
        }

        [Test]

        public void PropertyFuelAmountShouldThrowExceptionIfValueIsNegative()
        {
            Assert.Throws<InvalidOperationException>(()
            => car.Drive(12), "Fuel amount cannot be negative!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-21)]
        public void PropertyFuelCapacityShouldThrowExceptionIfValueIsZeroOrNegative(double
            fuelCapacity)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => new Car("Ford", "Orion", 2.0, fuelCapacity));
            Assert.AreEqual("Fuel capacity cannot be zero or negative!", ex.Message);
        }

        [Test]
        public void RefuelMethodShouldWorkProperly()
        {
            car = new Car("Ford", "Orion", 2.0, 50.0);
            car.Refuel(20);
            Assert.AreEqual(20, car.FuelAmount);
        }

        [Test]
        public void CarFuelAmountShouldNotBeMoreThanFuelCapacity()
        {
            double expectedResult = 50;

            car.Refuel(65);
            double actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-15)]
        public void RefuelMethodShouldThrowExceptionIfFuelToRefuelIsZeroOrNegative(double 
            fuelToRefuel)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => car.Refuel(fuelToRefuel));

            Assert.AreEqual("Fuel amount cannot be zero or negative!", ex.Message );
        }

        [Test]
        public void DriveMethodShouldWorkProperly()
        {
            car = new Car("Ford", "Orion", 2.0, 50.0);
            car.Refuel(50.0);

            double fuelNeeded = (500 / 100) * car.FuelConsumption;
            car.Drive(500);
            double expected = 10;
            Assert.AreEqual(expected, fuelNeeded);
            double expectedFuelAmount = 40;
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void DriveMethodShouldThrowExceptionIfFuelAmountIsLessThanFuelNeeded()
        {
            car = new Car("Ford", "Orion", 2.0, 50.0);
            car.Refuel(2.0);

            double fuelNeeded = (500 / 100) * car.FuelConsumption;

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => car.Drive(500));

            Assert.AreEqual("You don't have enough fuel to drive!", ex.Message);
            
        }
    }
}