using System;
using System.Linq;

namespace Examples.Ex04Json
{
    public class JsonExample : Example
    {
        public override void Run()
        {
            var json = "{\"Firstname\":\"Daniel\",\"Lastname\":\"Wertheim\",\"Age\":31}";

            using(var session = Db.BeginSession())
            {
                session.InsertJson<Person>(json);

                var person = session.Query<Person>().Take(1).Single();

                Console.Out.WriteLine("person.Firstname = {0}", person.Firstname);
                Console.Out.WriteLine("person.Lastname = {0}", person.Lastname);
                Console.Out.WriteLine("person.Age = {0}", person.Age);
            }
        }
    }

    public class Person
    {
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int Age { get; set; }
    }
}