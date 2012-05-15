using System;

namespace Examples.Ex06Includes
{
    [Serializable]
    public class Customer
    {
        public Guid Id { get; set; }

        public string CustomerNo { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public Address InvoiceAddress { get; set; }

        public Phone Phone1 { get; set; }

        public Phone Phone2 { get; set; }

        public Customer()
        {
            InvoiceAddress = new Address();
        }
    }
}