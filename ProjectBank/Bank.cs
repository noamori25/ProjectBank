using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBank
{
    class Bank : Ibank
    {
        private List<Account> ListOfAccount = new List<Account>();
        private List<Customer> ListOfCustomer = new List<Customer>();
        private Dictionary<int, Customer> DByCustomerId = new Dictionary<int, Customer>();
        private Dictionary<int, Customer> DByCustomerNum = new Dictionary<int, Customer>();
        private Dictionary<int, Account> DByAccountNum = new Dictionary<int, Account>();
        private Dictionary<Customer, List<Account>> DByCustomer = new Dictionary<Customer, List<Account>>();
        private int totalMoneyInBank;
        private int profits;
        internal Bank()
        {

        }
        public string Name { get; }

        public string Address { get;}

        public int CustomerCount
        {
            get
            {
                return ListOfCustomer.Count();
            }
        }
        internal Customer GetCustomerById (int customerId)
        {
           if(DByCustomerId.TryGetValue(customerId, out Customer c))
               return c;
            throw new CustomerNotFountException();
        }

        internal Customer GetCustomerByNumber (int customerNumber)
        {
            if (DByCustomerNum.TryGetValue(customerNumber, out Customer c))
                return c;
            throw new CustomerNotFountException();
        }

        internal Account GetAccountByNumber(int accountNumber)
        {
            if (DByAccountNum.TryGetValue(accountNumber, out Account a))
                return a;
            throw new AccountNotFoundException();
        }

        internal List<Account> GetAccountByCustomer (Customer c)
        {
            if (DByCustomer.TryGetValue(c, out List<Account> a))
                return a;
            throw new CustomerNotFountException();
               
        }
        internal void AddNewCustomer (Customer c)
        {
            if (c == null)
            {
                throw new CustomerNullException();
            }

            if (ListOfCustomer.Contains(c))
            {
                    throw new CustomerAlreadyExistException();
            }
            else
            {
                ListOfCustomer.Add(c);
                DByCustomerId.Add(c.CustomerId, c);
                DByCustomerNum.Add(c.CustomerNumber, c);
              
               
            }

        }

        internal void OpenNewAccount (Customer c, Account a)
        {
            if (ListOfAccount.Contains(a))
            {
                throw new AccountAlreadyExistException();
            }
            else
            {
                ListOfAccount.Add(a);
                DByAccountNum.Add(a.AccountNumber, a);
                List<Account> aList = new List<Account>();
                aList.Add(a);
                DByCustomer.Add(c, aList);
                totalMoneyInBank = totalMoneyInBank + a.Balance;
            }

        }

        internal int Deposit (Account a, int amount)
        {
            if (ListOfAccount.Contains(a))
            {
                a.Add(amount);
                totalMoneyInBank = totalMoneyInBank + amount;
                return a.Balance;
            }
            else
            {
                throw new AccountNotFoundException();
            }
        }

        internal int Withdraw (Account a, int amount)
        {
            if (ListOfAccount.Contains(a))
            {
                a.subtract(amount);
                totalMoneyInBank = totalMoneyInBank - amount;
                return a.Balance;
            }
            else
            {
                throw new AccountNotFoundException();
            }
        }

        internal int GetCustomerTotalBalance (Customer c)
        {
            int sum = 0;
            DByCustomer.TryGetValue(c, out List<Account> listc);
            foreach (Account a in listc)
            {
                sum = sum + a.Balance;
            }
            return sum;
        }

        internal void CloseAccount (Account a, Customer c)
        {
            if (ListOfAccount.Contains(a) && ListOfCustomer.Contains(c))
            {
                if (a.Balance < 0)
                    throw new CustomerNotAllowedToCloseAccountException();
                ListOfAccount.Remove(a);
                DByAccountNum.Remove(a.AccountNumber);
                ListOfCustomer.Remove(c);
                DByCustomer.Remove(c);
                DByCustomerId.Remove(c.CustomerId);
                DByCustomerNum.Remove(c.CustomerNumber);
                totalMoneyInBank = totalMoneyInBank - a.Balance;
            }
            else
            {
                if (!ListOfCustomer.Contains(c) && !ListOfAccount.Contains(a))
                    throw new AccountAndCustomerNotFoundException();
                if (!ListOfCustomer.Contains(c))
                    throw new CustomerNotFountException();
                if (!ListOfAccount.Contains(a))
                    throw new AccountNotFoundException();
            }
            
        }

        internal void ChargeAnnualCommossion (float percentage)
        {
            float x = 0;
            foreach (Account a in ListOfAccount)
            {
                if (a.Balance < a.MaxMinusAllowed)
                {
                    percentage = percentage * 2.0f;
                }    
                    x = percentage * a.Balance / 100.0f;
                    a.subtract(Convert.ToInt32(x));
                    profits = profits + Convert.ToInt32(x);
            }
        }

        internal void JoinAccounts (Account a1, Account a2)
        {
            Account a3 =  a1 + a2;
            CloseAccount(a1, a1.AccountOwner);
            CloseAccount(a2, a2.AccountOwner);
            AddNewCustomer(a3.AccountOwner);
            OpenNewAccount(a3.AccountOwner, a3);
        }

   
            


    }
}
