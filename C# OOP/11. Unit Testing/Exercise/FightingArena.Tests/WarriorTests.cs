using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_If_Constructor_Works_Correctly()
        {
            Warrior warrior = new Warrior("Frederic", 15, 100);

            Assert.AreEqual("Frederic", warrior.Name);
            Assert.AreEqual(15, warrior.Damage);
            Assert.AreEqual(100, warrior.HP);
        }

        [Test]
        public void Throw_Exception_If_Name_Is_Empty()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("", 15, 100));
        }

        [Test]
        public void Throw_Exception_If_Name_Is_Whitespace()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("  ", 15, 100));
        }

        [Test]
        public void Test_With_Correctly_Entered_Name()
        {
            Warrior warrior = new Warrior("Malle", 12, 90);

            Assert.AreEqual("Malle", warrior.Name);
        }

        [Test]
        public void Test_With_Zero_Damage()
        {
            Assert.Throws<ArgumentException>(() => 
            {
                Warrior warrior = new Warrior("Malle", 0, 90);
            });
        }

        [Test]
        public void Throw_Exception_If_Damage_Is_Negative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Malle", -45, 90);
            });
        }

        [Test]
        public void Test_If_Set_Correctly_Damage()
        {
            Warrior warrior = new Warrior("Malle", 45, 90);

            Assert.AreEqual(45, warrior.Damage);
        }

        [Test]
        public void Throw_Exception_If_HP_Is_Negative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Malle", 45, -90);
            });
        }

        [Test]
        public void Test_If_HP_Works_Correctly()
        {
            Warrior warrior = new Warrior("Malle", 55, 90);

            Assert.AreEqual(90, warrior.HP);
        }

        [Test]
        public void Test_If_Attack_Works_Correctly()
        {
            int expectedAttHP = 95;
            int expectedDefHP = 80;

            Warrior attacker = new Warrior("Jeremy", 10, 100);
            Warrior defender = new Warrior("Paul", 5, 90);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttHP, attacker.HP);
            Assert.AreEqual(expectedDefHP, defender.HP);
        }

        [Test]
        public void Test_If_Attacking_With_Lower_HP()
        {
            Warrior attacker = new Warrior("Jeremy", 10, 25);
            Warrior defender = new Warrior("Paul", 5, 45);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void Test_If_Attacking_Enemy_With_Lower_HP()
        {
            Warrior attacker = new Warrior("Jeremy", 10, 45);
            Warrior defender = new Warrior("Paul", 5, 25);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void Test_If_I_Attack_Too_Strong_Enemy()
        {
            int expectedAttrHP = 55;
            int expectedDefHP = 0;

            Warrior attacker = new Warrior("Jeremy", 50, 100);
            Warrior defender = new Warrior("Paul", 45, 40);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttrHP, attacker.HP);
            Assert.AreEqual(expectedDefHP, defender.HP);
        }
    }
}