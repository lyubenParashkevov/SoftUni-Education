using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxelLoosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.AreEqual(9, axe.DurabilityPoints, "Axe Durability doesn't change after attack.");          
        }

        [Test]
        public void IfAxeIsBrokenShouldThrowAnException()
        {
            Axe axe = new(10, 10);
            Dummy dummy = new(100,100);

            for (int i = 0; i < 10; i++)
            {
                axe.Attack(dummy);
            }

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => axe.Attack(dummy));

            Assert.AreEqual(ex.Message, "Axe is broken.");
        }
    }
}