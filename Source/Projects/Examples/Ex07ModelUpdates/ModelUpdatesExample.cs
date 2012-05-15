using System;
using Examples.Ex07ModelUpdates.New;
using Examples.Ex07ModelUpdates.Old;
using SisoDb;
using SisoDb.Maintenance;

namespace Examples.Ex07ModelUpdates
{
    public class ModelUpdatesExample : Example
    {
        public override void Run()
        {
            var person = new Person
            {
                Name = "Daniel Wertheim",
                Address = "The Street 1\r\n12345\r\nThe City",
                HairColor = "Black"
            };

            Db.UseOnceTo().Insert(person);
            /******************** NEW ENTITY SALESPERSON ***************************/

            Db.Maintenance.Migrate<Person, SalesPerson>((p, sp) =>
            {
                var names = p.Name.Split(' ');
                sp.Firstname = names[0];
                sp.Lastname = names[1];

                var address = p.Address
                    .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                sp.Office.Street = address[0];
                sp.Office.Zip = address[1];
                sp.Office.City = address[2];

                return MigrationStatuses.Keep;
            });



            using(var session = Db.BeginSession())
            {
                var salesPerson = session.GetById<SalesPerson>(person.Id);
                
                Console.Out.WriteLine("salesPerson.Firstname = {0}", salesPerson.Firstname);
                Console.Out.WriteLine("salesPerson.Lastname = {0}", salesPerson.Lastname);
                Console.Out.WriteLine("salesPerson.Office.Street = {0}", salesPerson.Office.Street);
                Console.Out.WriteLine("salesPerson.Office.Zip = {0}", salesPerson.Office.Zip);
                Console.Out.WriteLine("salesPerson.Office.City = {0}", salesPerson.Office.City);
            }
        }
    }
}