namespace Chainblock.Tests
{
    using Chainblock.Contracts;
    using Chainblock.Models;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ChainBlockTests
    {
        private Chainblock chainblock;

        private ITransaction dummyTransaction;

        [SetUp]
        public void SetUp()
        {
            this.chainblock = new Chainblock();
            this.dummyTransaction = new Transaction(1, TransactionStatus.Failed, "Jeremy", "Alberto", 15000);
        }

        [Test]
        public void Add_Should_Works_Correctly()
        {
            this.chainblock.Add(this.dummyTransaction);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void Add_Should_Throw_Exception_If_I_Try_To_Add_Same_Transaction_Twice()
        {
            this.chainblock.Add(this.dummyTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.Add(this.dummyTransaction);
            });
        }

        [Test]
        public void Contains_Should_Return_True_If_Existing_Incollection_Transaction_Is_Passed()
        {
            this.chainblock.Add(this.dummyTransaction);

            bool actualResult = this.chainblock.Contains(this.dummyTransaction);

            Assert.IsTrue(actualResult);
        }

        [Test]
        public void Contains_Should_Return_False_If_NonExisting_Transaction_Is_Passed()
        {
            this.chainblock.Add(this.dummyTransaction);
            ITransaction nonExistingTransaction = new Transaction(56, TransactionStatus.Successfull, "hahahaha", "uuuu", 2);

            bool actualResult = this.chainblock.Contains(nonExistingTransaction);

            Assert.IsFalse(actualResult);
        }

        [Test]
        public void ChangeTransactionStatus_Should_Change_Status_Successfully_If_Transaction_Exists_In_The_Collection()
        {
            this.chainblock.Add(this.dummyTransaction);

            this.chainblock.ChangeTransactionStatus(1, TransactionStatus.Successfull);

            TransactionStatus expectedStatus = TransactionStatus.Successfull;
            TransactionStatus actualStatus = this.dummyTransaction.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Test]
        public void ChangeTransactionStatus_Should_Throws_ArgumentException_If_Transaction_Do_Not_Exists_In_Collection()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.chainblock.ChangeTransactionStatus(1, TransactionStatus.Successfull);
            });
        }

        [Test]
        public void RemoveTransactionById_Successfully_When_Id_Exist_In_The_Collection()
        {
            this.chainblock.Add(this.dummyTransaction);

            this.chainblock.RemoveTransactionById(1);

            int expectedCount = 0;
            int actualCount = this.chainblock.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(2)]
        public void RemoveTransactionById_Throw_InvalidOperationExpection_When_Id_Does_Not_Exists_In_The_Collection(int id)
        {
            this.chainblock.Add(this.dummyTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.RemoveTransactionById(id);
            });
        }

        [Test]
        public void GetById_Should_Return_Transaction_Successfully()
        {
            this.chainblock.Add(this.dummyTransaction);

            ITransaction expectedTransaction = this.dummyTransaction;
            ITransaction actualTransaction = this.chainblock.GetById(1);

            Assert.AreSame(expectedTransaction, actualTransaction);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(2)]
        public void GetById_Should_Throw_InvalidOperationException_If_Such_Transaction_Does_Not_Exist(int id)
        {
            this.chainblock.Add(this.dummyTransaction);

            ITransaction expectedTransaction = this.dummyTransaction;
            ITransaction actualTransaction = this.chainblock.GetById(1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetById(id);
            });
        }

        [Test]
        public void GetByTransactionStatus_Should_Return_Transaction_Successfully_Ordered_By_Amount_In_Descending_Order()
        {
            this.chainblock.Add(this.dummyTransaction);

            ITransaction secondTransaction = new Transaction(2, TransactionStatus.Successfull, "Thierry", "Dominique", 15567);

            this.chainblock.Add(secondTransaction);

            ITransaction thirdTransaction = new Transaction(3, TransactionStatus.Failed, "Frederic", "Sebastian", 105);

            this.chainblock.Add(thirdTransaction);

            IEnumerable<ITransaction> transactions = new List<ITransaction>()
            {
                this.dummyTransaction,
                thirdTransaction
            };

            var actualResult = this.chainblock.GetByTransactionStatus(TransactionStatus.Failed);

            CollectionAssert.AreEqual(transactions, actualResult);
        }

        [Test]
        public void GetByTransactionStatus_Throw_InvalidOperationException_Transactions_With_Such_Status_Do_Not_Exist()
        {
            this.chainblock.Add(this.dummyTransaction);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetByTransactionStatus(TransactionStatus.Aborted);
            });
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_Returns_All_Senders_Which_Have_Transactions_With_Given_Status_OrderedBy_Transactions()
        {
            this.chainblock.Add(this.dummyTransaction);

            ITransaction secondTransaction = new Transaction(2, TransactionStatus.Failed, "Mimi", "Goshi", 23.99);
            this.chainblock.Add(secondTransaction);

            ITransaction thirdTransaction = new Transaction(3, TransactionStatus.Successfull, "Yani", "Toshi", 98.99);
            this.chainblock.Add(thirdTransaction);

            IEnumerable<string> transactions = new List<string>()
            {
                "Yani"
            };

            var actualSenders = this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);

            CollectionAssert.AreEqual(transactions, actualSenders);
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_Should_Throw_InvalidOperationException_If_No_Transactions_Exist()
        {
            this.chainblock.Add(this.dummyTransaction);

            IEnumerable<string> transactionsWithEqualStatus = null;

            Assert.Throws<InvalidOperationException>(() =>
            {
                transactionsWithEqualStatus = this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Aborted);
            });
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_Returns_All_Receivers_Which_Have_Transactions_With_Given_Status_OrderedBy_Transactions()
        {
            this.chainblock.Add(this.dummyTransaction);

            ITransaction secondTransaction = new Transaction(2, TransactionStatus.Failed, "Mimi", "Goshi", 23.99);
            this.chainblock.Add(secondTransaction);

            ITransaction thirdTransaction = new Transaction(3, TransactionStatus.Successfull, "Yani", "Toshi", 98.99);
            this.chainblock.Add(thirdTransaction);

            IEnumerable<string> transactions = new List<string>()
            {
                "Toshi"
            };

            var actualReceivers = this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);

            CollectionAssert.AreEqual(transactions, actualReceivers);
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_Should_Throw_InvalidOperationException_If_No_Transactions_Exist()
        {
            this.chainblock.Add(this.dummyTransaction);

            IEnumerable<string> transactionsWithEqualStatus = null;

            Assert.Throws<InvalidOperationException>(() =>
            {
                transactionsWithEqualStatus = this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Aborted);
            });
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_Should_Return_All_Transactions_OrderedDescending_By_Amount_And_By_Id()
        {
            this.chainblock.Add(this.dummyTransaction);

            ITransaction secondTransaction = new Transaction(2, TransactionStatus.Failed, "Grisho", "Roger", 23.99);
            this.chainblock.Add(secondTransaction);

            ITransaction thirdTransaction = new Transaction(3, TransactionStatus.Successfull, "Novak", "Rafael", 98.99);
            this.chainblock.Add(thirdTransaction);

            IEnumerable<ITransaction> transactions = new List<ITransaction>()
            {
                this.dummyTransaction,
                secondTransaction,
                thirdTransaction
            };

            var actualTransactions = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.AreEquivalent(transactions, actualTransactions);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_Should_Return_All_Transactions_With_Passed_Sender_Correctly()
        {
            this.chainblock.Add(this.dummyTransaction);

            ITransaction secondTransaction = new Transaction(2, TransactionStatus.Failed, "Ursula", "John", 23.99);
            this.chainblock.Add(secondTransaction);

            ITransaction thirdTransaction = new Transaction(3, TransactionStatus.Successfull, "Ursula", "Jack", 98.99);
            this.chainblock.Add(thirdTransaction);

            IEnumerable<ITransaction> transactions = new List<ITransaction>()
            {
                secondTransaction,
                thirdTransaction
            };

            var actualTransactions = this.chainblock.GetBySenderOrderedByAmountDescending("Ursula");

            CollectionAssert.AreEquivalent(transactions, actualTransactions);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_Should_Throw_InvalidOperationException_If_There_Are_No_Such_Transactions()
        {
            this.chainblock.Add(this.dummyTransaction);

            IEnumerable<ITransaction> transactions = null;

            Assert.Throws<InvalidOperationException>(() =>
            {
                transactions = this.chainblock.GetBySenderOrderedByAmountDescending("Masimiliano");
            });
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_Should_Return_All_Transactions_With_Passed_Receiver_Correctly()
        {
            this.chainblock.Add(this.dummyTransaction);

            ITransaction secondTransaction = new Transaction(2, TransactionStatus.Failed, "Ursula", "John", 23.99);
            this.chainblock.Add(secondTransaction);

            ITransaction thirdTransaction = new Transaction(3, TransactionStatus.Successfull, "Ursula", "John", 98.99);
            this.chainblock.Add(thirdTransaction);

            IEnumerable<ITransaction> transactions = new List<ITransaction>()
            {
                secondTransaction,
                thirdTransaction
            };

            var actualTransactions = this.chainblock.GetByReceiverOrderedByAmountThenById("John");

            CollectionAssert.AreEquivalent(transactions, actualTransactions);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_Should_Throw_InvalidOperationException_If_There_Are_No_Such_Transactions()
        {
            this.chainblock.Add(this.dummyTransaction);

            IEnumerable<ITransaction> transactions = null;

            Assert.Throws<InvalidOperationException>(() =>
            {
                transactions = this.chainblock.GetByReceiverOrderedByAmountThenById("Masimiliano");
            });
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_Should_Return_Correct_Collection_Successfully()
        {
            this.chainblock.Add(this.dummyTransaction);

            ITransaction secondTransaction = new Transaction(2, TransactionStatus.Failed, "Ursula", "John", 23.99);
            this.chainblock.Add(secondTransaction);

            ITransaction thirdTransaction = new Transaction(3, TransactionStatus.Successfull, "Ursula", "John", 98.99);
            this.chainblock.Add(thirdTransaction);

            IEnumerable<ITransaction> transactions = new List<ITransaction>()
            {
                secondTransaction
            };

            var actualTransactions = this.chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Failed, 100);

            CollectionAssert.AreEqual(transactions, actualTransactions);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_Should_Return_Empty_Collection_If_No_Such_Transactions_Were_Found()
        {
            this.chainblock.Add(this.dummyTransaction);

            var amountCheckCollection =
                this.chainblock
                .GetByTransactionStatusAndMaximumAmount(TransactionStatus.Failed, 200);

            var statusCheckCollection =
                this.chainblock
                .GetByTransactionStatusAndMaximumAmount(TransactionStatus.Aborted, 200);

            int expectedCount = 0;
            int actualAmountCheckCollectionCount = amountCheckCollection.ToArray().Length;
            int actualStatusCheckCollectionCount = statusCheckCollection.ToArray().Length;

            Assert.AreEqual(expectedCount, actualAmountCheckCollectionCount);
            Assert.AreEqual(expectedCount, actualStatusCheckCollectionCount);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_Return_All_Transactions_With_Given_Sender_And_Amount_Bigger_Than_Given_Amount_Successfully()
        {
            this.chainblock.Add(this.dummyTransaction);

            ITransaction secondTransaction = new Transaction(2, TransactionStatus.Failed, "Ursula", "John", 23.99);
            this.chainblock.Add(secondTransaction);

            ITransaction thirdTransaction = new Transaction(3, TransactionStatus.Successfull, "Ursula", "John", 98.99);
            this.chainblock.Add(thirdTransaction);

            IEnumerable<ITransaction> transactions = new List<ITransaction>()
            {
                thirdTransaction
            };

            var actualTransactions = this.chainblock.GetBySenderAndMinimumAmountDescending("Ursula", 50);

            CollectionAssert.AreEqual(transactions, actualTransactions);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_Throw_InvalidOperationException_If_There_Are_No_Such_Transactions()
        {
            this.chainblock.Add(this.dummyTransaction);

            IEnumerable<ITransaction> transactions = null;

            Assert.Throws<InvalidOperationException>(() =>
            {
                transactions = this.chainblock.GetBySenderAndMinimumAmountDescending("Jeremy", 100000);
            });
        }

        [Test]
        public void GetByReceiverAndAmountRange_Should_Return_All_Transactions_With_Given_Amount_Within_Given_Range_Successfully()
        {
            this.chainblock.Add(this.dummyTransaction);

            ITransaction secondTransaction = new Transaction(2, TransactionStatus.Failed, "Ursula", "John", 23.99);
            this.chainblock.Add(secondTransaction);

            ITransaction thirdTransaction = new Transaction(3, TransactionStatus.Successfull, "Ursula", "John", 98.99);
            this.chainblock.Add(thirdTransaction);

            IEnumerable<ITransaction> transactions = new List<ITransaction>()
            {
                secondTransaction,
                thirdTransaction
            };

            var actualTransactions = this.chainblock.GetByReceiverAndAmountRange("John", 20, 99);

            CollectionAssert.AreEquivalent(transactions, actualTransactions);
        }

        [Test]
        public void GetByReceiverAndAmountRange_Should_Throw_InvalidOperationexception_If_There_Are_Not_Such_Transactions_With_Given_Receiver_With_Given_Amount_Within_Given_Range()
        {
            this.chainblock.Add(this.dummyTransaction);

            IEnumerable<ITransaction> transactions = null;

            Assert.Throws<InvalidOperationException>(() =>
            {
                transactions = this.chainblock.GetByReceiverAndAmountRange("Jeremy", 20000, 25000);
            });
        }

        [Test]
        public void GetAllInAmountRange_Should_Return_All_Transactions_Within_A_Range_Successfully()
        {
            this.chainblock.Add(this.dummyTransaction);

            ITransaction secondTransaction = new Transaction(2, TransactionStatus.Failed, "Ursula", "John", 23.99);
            this.chainblock.Add(secondTransaction);

            ITransaction thirdTransaction = new Transaction(3, TransactionStatus.Successfull, "Ursula", "John", 98.99);
            this.chainblock.Add(thirdTransaction);

            IEnumerable<ITransaction> transactions = new List<ITransaction>()
            {
                this.dummyTransaction,
                secondTransaction,
                thirdTransaction
            };

            var actualTransactions = this.chainblock.GetAllInAmountRange(1, 20000);

            CollectionAssert.AreEqual(transactions, actualTransactions);
        }

        [Test]
        public void GetAllInAmountRange_Should_Return_All_Transactions_With_Amount_Within_Given_Range_Successfully()
        {
            var allTransactionsWithAmountWithinRange = this.chainblock.GetAllInAmountRange(1, 10);
            int expectedCount = 0;
            var actualCount = allTransactionsWithAmountWithinRange.ToArray().Length;

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
