using System;

namespace Examples.Ex07ModelUpdates.Old
{
    public class Person //Change: Rename to SalesPerson
    {
        public Guid Id { get; set; }

        public string Name { get; set; } //Change: Split to Firstname and Lastname

        public string Address { get; set; } //Change: Split to Street, Zip, City

        public string HairColor { get; set; } //Change: Drop
    }
}