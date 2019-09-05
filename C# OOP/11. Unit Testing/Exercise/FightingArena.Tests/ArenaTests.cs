using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void Test_If_Constructor_Works_Correctly()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void TestEnroll()
        {
            Warrior warrior = new Warrior("Kim", 10, 100);

            this.arena.Enroll(warrior);

            Assert.That(this.arena.Warriors, Has.Member(warrior));
        }

        [Test]
        public void Test_Enrolling_Existing_Warrior()
        {
            Warrior warrior = new Warrior("Pesho", 10, 100);

            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior);
            });
        }

        [Test]
        public void Test_Id_Count_Works_Correctly()
        {
            int expectedCount = 1;

            Warrior warrior = new Warrior("Nino", 10, 100);

            this.arena.Enroll(warrior);

            Assert.AreEqual(expectedCount, this.arena.Count);
        }

        [Test]
        public void Test_If_Fight_Works_Correctly()
        {
            int expectedAttrHP = 95;
            int expectedDefHP = 40;

            Warrior attacker = new Warrior("Kim", 10, 100);
            Warrior defender = new Warrior("Kitoosho", 5, 50);

            this.arena.Enroll(attacker);
            this.arena.Enroll(defender);

            this.arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(expectedAttrHP, attacker.HP);
            Assert.AreEqual(expectedDefHP, defender.HP);
        }

        [Test]
        public void TestFightingMissingWarrior()
        {
            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 50);

            this.arena.Enroll(attacker);
            // Missing enroll on defender

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(attacker.Name, defender.Name);
            });
        }
    }
}
