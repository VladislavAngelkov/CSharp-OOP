using Chainblock.Contracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Chainblock
{
    public class Transaction : ITransaction
    {
        public Transaction(int id, TransactionStatus status, string from, string to, double amount)
        {
            Id = id;
            Status = status;
            From = from;
            To = to;
            Amount = amount;
        }
        public int Id 
        { 
           get
            {
                return Id;
            }
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException();
                }
                Id = value;
            }
        }
        public TransactionStatus Status
        {
            get 
            { 
                return Status; 
            }
            set
            {
                Status = value;
            }
        }
        public string From
        {
            get
            {
                return From;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                From = value;
            }
        }
        public string To
        {
            get
            {
                return To;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                To = value;
            }
        }
        public double Amount
        {
            get
            {
                return Amount;
            }
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException();
                }
                Amount = value;
            }
        }
    }
}
