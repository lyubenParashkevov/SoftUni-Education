namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Threading;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void ConstructorShouldWorkProperly()
        {
            Warrior warrior = new Warrior("Hulk", 100, 50);
            string expectedName = "Hulk";
            int expectedDamage = 100;
            int expectedHp = 50;

            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHp, warrior.HP);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void PropertyNameShouldNotBeNullOrWhiteSpace(string name)
        {
            Warrior warrior;

            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => warrior = new Warrior(name, 100, 50));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-21)]
        public void PropertyDamageShouldNotBeZeroOrNegative(int damage)
        {
            Warrior warrior;

            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => warrior = new Warrior("Hulk", damage, 50));

            Assert.AreEqual("Damage value should be positive!", ex.Message);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        public void PropertyHpShouldNotBeNegative(int hp)
        {
            Warrior warrior;

            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => warrior = new Warrior("Hulk", 100, hp));
            Assert.AreEqual("HP should not be negative!", ex.Message);
        }

        [Test]
        [TestCase(30)]
        [TestCase(20)]
        public void AttackShouldThrowExceptionIfHpIsLessOrEqualMinATtackHp(int hp)
        {
            Warrior warrior = new Warrior("Hulk", 100, hp);
            Warrior enemyWarrior = new Warrior("Hulkov", 5, 90);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => warrior.Attack(enemyWarrior));

            Assert.AreEqual("Your HP is too low in order to attack other warriors!", ex.Message);
        }

        [Test]
        [TestCase(30)]
        [TestCase(20)]
        public void AttackShouldThrowExceptionIfEnemyHpIsLessOrEqualMinATtackHp(int hp)
        {
            Warrior warrior = new Warrior("Hulk", 100, 50);
            Warrior enemyWarrior = new Warrior("Hulkov", 50, hp);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => warrior.Attack(enemyWarrior));

            Assert.AreEqual($"Enemy HP must be greater than {30} in order to attack him!", ex.Message);
        }

        [Test]      
        public void AttackShouldThrowExceptionIfEnemyHpIsLessThanWarriorDamage()
        {
            Warrior warrior = new Warrior("Hulk", 100, 35);
            Warrior enemyWarrior = new Warrior("Hulkov", 45, 100);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => warrior.Attack(enemyWarrior));

            Assert.AreEqual($"You are trying to attack too strong enemy", ex.Message);
        }

        [Test]
        public void AttackShouldWorkKorrectly()
        {
            int expectedAtackerHp = 95;
            int expectedDefenderHp = 80;

            Warrior attacker = new("Pesho", 10, 100);
            Warrior defender = new("Gosho", 5, 90);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAtackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [Test]
        public void EnemyHpShouldBeSetToZeroIfWarriorDamageIsGreaterThanHisHp()
        {
            Warrior attacker = new("Pesho", 50, 100);
            Warrior defender = new("Gosho", 45, 40);

            attacker.Attack(defender);

            int expectedAttackerHp = 55;
            int expectedDefenderHp = 0;

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        
    }


}