namespace Examples.Ex08ControlWhatToIndex
{
    public class ControlWhatToIndexExample : Example
    {
        public override void Run()
        {
            Db.StructureSchemas.StructureTypeFactory
                .Configurations.NewForType<Person>()
                .OnlyIndexThis(p => p.Lastname, p => p.Firstname);

            var person = new Person
                             {
                                 Firstname = "Daniel",
                                 Lastname = "Wertheim",
                                 Age = 22
                             };

            Db.UseOnceTo().Insert(person);
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