using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBank
{
    public class Account
    {
        private static int numberOfAcc;
        private readonly int accountNumber;
        private readonly Customer accountOwner;
        private int maxMinusAllowed;
        public int Balance { get; private set; }
        public int AccountNumber
        {
            get
            {
                return this.accountNumber;
            }
        }

        public Customer AccountOwner
        {
            get
            {
                return accountOwner;
            }
        }

        public int MaxMinusAllowed
        {
            get
            {
                return maxMinusAllowed;
            }
        }

        public Account (Customer c, int monthlyInCome)
        {
            numberOfAcc++;
            accountNumber = numberOfAcc;
            maxMinusAllowed = monthlyInCome * 3;

        }

        public void Add (int amount)
        {
          Balance =  Balance + amount;
        }

        public void subtract (int amount)
        {
            if (this.Balance < this.MaxMinusAllowed)
                throw new BalanceException();
            int check = this.Balance - amount;
            if (check < this.MaxMinusAllowed)
                throw new BalanceException();
            Balance = Balance - amount;
        }

        public static bool operator == (Account a1, Account a2)
        {
            if (a1.AccountNumber == a2.AccountNumber)
                return true;
            return false;
        }

        public static bool operator !=(Account a1, Account a2)
        {
            if (a1.AccountNumber != a2.AccountNumber)
                return true;
            return false;
        }

        public static Account operator +(Account a1, Account a2)
        {
            if (a1.accountOwner != a2.accountOwner)
            {
                throw new NotSameCustomerException();
            }
            else
            {
                Account a3 = new Account(a1.accountOwner, a1.MaxMinusAllowed/3);
                a3.Balance = a1.Balance + a2.Balance;
                a3.maxMinusAllowed = a1.maxMinusAllowed;
                return a3;
            }
        }
        public static int operator +(Account a, int amount)
        {
            a.Add(amount);
            return a.Balance;
        }

        public static int operator -(Account a, int amount)
        {
            a.subtract(amount);
            return a.Balance;
        }



        public override bool Equals(object obj)
        {
            if (obj is Account)
            {
                Account a1 = obj as Account;
                return this == a1;

            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.AccountNumber;
        }

        public override string ToString()
        {
            return $"acc number:{AccountNumber}";
        }
    }
}
