using System;

namespace Examples.Ex07ModelUpdates.New
{
    public class SalesPerson
    {
        public Guid Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public Address Office { get; set; }

        public SalesPerson()
        {
            Office = new Address();
        }
    }

    public class Address
    {
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
    }
}