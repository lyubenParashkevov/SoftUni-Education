using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        [SetUp]
        public void Setup()
        {
            dummy = new Dummy(10, 10);
        } 
        [Test]
        public void TakeAttackShouldLoosePointsAfterAttacked()
        {
            //Dummy dummy = new Dummy(10, 10);
            dummy.TakeAttack(3);

            Assert.AreEqual(7, dummy.Health);
        }

        [Test]
        public void TakeAttackShouldThrowAnExceptionWhenDummyIsDeath()
        {
            //Dummy dummy = new Dummy(10, 10);
            dummy.TakeAttack(9);
            dummy.TakeAttack(1);


            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => dummy.TakeAttack(2));
            Assert.AreEqual("Dummy is dead.", ex.Message);
        }

        [TestCase(0)]
        [TestCase(-2)]
        public void GiveExperienceShouldWorkProperly(int health)
        {
            dummy = new Dummy(health , 20);

            Assert.AreEqual(20, dummy.GiveExperience());

        }

        [TestCase(1)]
        [TestCase(30)]
        public void GiveExperienceShouldThrowExceptionWhenDummyIsAlive(int health)
        {
            dummy = new Dummy(health, 20);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => dummy.GiveExperience());

            Assert.AreEqual("Target is not dead.", ex.Message);

        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            dummy = new Dummy(0, 10);

            Assert.IsNotNull(dummy);
            Assert.AreEqual(10, dummy.GiveExperience());
            Assert.AreEqual(0, dummy.Health);
        }

    }
}