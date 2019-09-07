using Chainblock.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        private int id;

        private string from;

        private string to;

        private double amount;

        public Transaction(int id, TransactionStatus status, string sender, string reciever, double amount)
        {
            this.Id = id;
            this.Status = status;
            this.From = sender;
            this.To = reciever;
            this.Amount = amount;
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Id cannot be zerro or negative.");
                }

                this.id = value;
            }
        }

        public TransactionStatus Status { get; set; }

        public string From
        {
            get
            {
                return this.from;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Sender cannot be empty");
                }
                this.from = value;
            }
        }

        public string To
        {
            get
            {
                return this.to;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Reciever cannot be empty");
                }
                this.to = value;
            }
        }

        public double Amount
        {
            get
            {
                return this.amount;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Amount cannot be zerro or negative.");
                }

                this.amount = value;
            }
        }

        public int CompareTo(ITransaction other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
}
