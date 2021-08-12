using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;

        [SetUp]
        public void Setup()
        {
            this.bankVault = new BankVault();
        }

        [Test]
        public void Constructor_Should_Set_Values_Correctly()
        {
            Assert.IsNotNull(this.bankVault);
            Assert.That(this.bankVault.VaultCells.Count, Is.EqualTo(12));
        }

        [Test]
        public void AddItem_Should_Throw_An_Exception_If_Cell_Is_Not_Existing()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.AddItem("90", new Item("Petar", "5"));
            });
        }

        [Test]
        public void AddItem_Should_Throw_An_Exception_If_Cell_Is_Taken()
        {
            this.bankVault.AddItem("A1", new Item("Petar", "5"));

            Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.AddItem("A1", new Item("Goshi", "5"));
            });
        }

        [Test]
        public void AddItem_Should_Throw_An_Exception_If_Cell_Has_Already_An_Item()
        {
            var item = new Item("Petar", "5");

            this.bankVault.AddItem("A1", item);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.bankVault.AddItem("A2", item);
            });
        }

        [Test]
        public void RemoveItem_Should_Throw_An_Exception_If_Cell_Has_Already_An_Item()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.RemoveItem("90", new Item("Petar", "5"));
            });
        }

        [Test]
        public void RemoveItem_Should_Throw_An_Exception_If_Item_In_That_Cell_Is_Not_Existing()
        {
            var item = new Item("Petar", "5");

            this.bankVault.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() =>
            {
                this.bankVault.RemoveItem("A1", new Item("Goshi", "5"));
            });
        }

        [Test]
        public void RemoveItem_Should_Remove_Item_Correctly()
        {
            var item = new Item("Pesho", "5");

            this.bankVault.AddItem("A1", item);

            var removedItem = bankVault.RemoveItem("A1", item);

            Assert.That(removedItem, Is.EqualTo($"Remove item:{item.ItemId} successfully!"));
            Assert.That(bankVault.VaultCells["A1"], Is.EqualTo(null));
        }
    }
}