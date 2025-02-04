using NUnit.Framework;
using System;
using System.Runtime.CompilerServices;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartphone;
        private Shop shop;

        [SetUp]
        public void Setup()
        {
            smartphone = new Smartphone("Nokia", 100);
            shop = new Shop(100);
        }

        [Test]
        public void SmartPhoneConstructorShouldWorkCorrect()
        {
            string expectedName = "Nokia";
            int expectedMaxBatteryCharge = 100;

            Assert.AreEqual(expectedName, smartphone.ModelName);
            Assert.AreEqual(expectedMaxBatteryCharge, smartphone.MaximumBatteryCharge);
        }

        [Test]

        public void ShopConstruktorShouldWorkCorrect()
        {
            int expectedCapacity = 100;
            Assert.AreEqual(expectedCapacity, shop.Capacity);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-18)]
        public void ShopConstructorShouldThrowExceptionIfCapacityIsLessThanZero(int capacity)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => new Shop(capacity));

            Assert.AreEqual("Invalid capacity.", ex.Message);
        }

        [Test]

        public void AddMethodShouldWorkProperly()
        {
            int curentCount = shop.Count;
            shop.Add(smartphone);
            Assert.AreNotEqual(curentCount, shop.Count);
        }

        [Test]


        public void AddMethodShouldThrowExceptionIfSmartphoneIsAdded()
        {
            shop.Add(smartphone);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => shop.Add(smartphone));

            Assert.AreEqual($"The phone model {smartphone.ModelName} already exist.", ex.Message);
        }

        [Test]

        public void AddMethodShouldThrowExceptionIfCountEqualsCapacity()
        {
            shop = new Shop(1);
            Smartphone smartphone1 = new Smartphone("LG", 40);
            shop.Add(smartphone);


            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => shop.Add(smartphone1));

            Assert.AreEqual("The shop is full.", ex.Message);
        }

        [Test]
        public void RemoveMethodShouldWorkProperly()
        {
            
            shop = new Shop(1);
            shop.Add(smartphone);
            int curentCount = shop.Count;   
            shop.Remove(name)


        }
    }
}