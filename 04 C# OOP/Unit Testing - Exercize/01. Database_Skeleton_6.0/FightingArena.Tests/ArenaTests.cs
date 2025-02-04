namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void ArenaConstructorShouldWorkCorrectly()
        {
            Assert.That(arena, Is.Not.Null);
            Assert.That(arena.Warriors, Is.Not.Null);   
        }

        [Test]
        public void CountPropertyShouldWorkCorrectly()
        {
            int wxpectedCount = 1;
            Warrior warrior = new Warrior("Hulk", 50, 50);
            arena.Enroll(warrior);
            Assert.AreEqual(wxpectedCount, arena.Count);
        }
        [Test]
        public void EnrolMethodShouldWorkCorrectly()
        {
            int wxpectedCount = 1;
            Warrior warrior = new Warrior("Hulk", 50, 50);
            arena.Enroll(warrior);

            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(warrior, arena.Warriors.Single());
        }

        [Test]
        public void EnrollShouldThrowExceptionIfWarriorAlreadyExists()
        {
            Warrior warrior = new Warrior("Hulk", 50, 50);
            Warrior warrior1 = new Warrior("Hulk", 60, 60);

            arena.Enroll(warrior);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                 () => arena.Enroll(warrior1));

            Assert.AreEqual("Warrior is already enrolled for the fights!", ex.Message);
        }

        [Test]
        public void ArenaFightShouldWorkCorrectly()
        {
            Warrior attacker = new("Gosho", 15, 100);
            Warrior defender = new("Pesho", 5, 50);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            int expectedAttackerHp = 95;
            int expectedDefenderHp = 35;

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [Test]
        public void ArenaFightShouldThrowExceptionIfAttackerNotFound()
        {
            Warrior attacker = new("Gosho", 15, 100);
            Warrior defender = new("Pesho", 5, 50);

            arena.Enroll(defender);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
               => arena.Fight(attacker.Name, defender.Name));

            Assert.AreEqual($"There is no fighter with name {attacker.Name} enrolled for the fights!", exception.Message);
        }

        [Test]
        public void ArenaFightShouldThrowExceptionIfDefenderNotFound()
        {
            Warrior attacker = new("Gosho", 15, 100);
            Warrior defender = new("Pesho", 5, 50);

            arena.Enroll(attacker);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
               => arena.Fight(attacker.Name, defender.Name));

            Assert.AreEqual($"There is no fighter with name {defender.Name} enrolled for the fights!", exception.Message);
        }
    }
}

