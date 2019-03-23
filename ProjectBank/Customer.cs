using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBank
{
    public class Customer
    {
        private static int numberOfCust;
        private readonly int customerId;
        private readonly int customerNumber;
        public string Name { get; private set; }
        public int PhNumber { get; private set; }
        public int CustomerId
        {
            get
            {
                return customerId;
            }
        }
        public int CustomerNumber
        {
            get
            {
                return customerNumber;
            }
        }

        public Customer(int id, string name, int phone)
        {
            this.customerId = id;
            this.Name = name;
            this.PhNumber = phone;
            numberOfCust++;
            this.customerNumber = numberOfCust;
        }

        public static bool operator== (Customer c1, Customer c2)
        {
            if (c1.CustomerNumber == c2.CustomerNumber)
                return true;
            return false;
        }

        public static bool operator !=(Customer c1, Customer c2)
        {
            if (c1.CustomerNumber != c2.CustomerNumber)
                return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj is Customer)
            {
             Customer c = obj as Customer;
                return this == c;
            }
            return false;
           
        }

        public override int GetHashCode()
        {
            return this.CustomerNumber;
        }

        public override string ToString()
        {
            return $"name: {Name}, id: {CustomerId}, number of customer: {CustomerNumber}";
        }
    }
}
