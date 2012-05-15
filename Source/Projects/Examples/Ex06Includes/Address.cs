using System;

namespace Examples.Ex06Includes
{
    [Serializable]
    public class Address
    {
        public string Street { get; set; }

        public string Zip { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}