using System;
using Examples.Ex01Crud;
using Examples.Ex02Interfaces;
using Examples.Ex03Image;
using Examples.Ex04Json;
using Examples.Ex05TransactionScopes;
using Examples.Ex06Includes;
using Examples.Ex07ModelUpdates;
using Examples.Ex08ControlWhatToIndex;

namespace TheConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Before running the examples, ensure the connection string is ok in the App.Config, since the database will be dropped and overwritten!!!");
            //Console.WriteLine();

            //new CrudExample().Run();
            //new InterfaceExample().Run();
            //new ImageExample().Run(); //Just showning you could. Not saying you should store binary content like this. Store a path instead!!!
            //new JsonExample().Run();
            //new ScenarioWithoutTransactionScopeExample().Run();
            //new ScenarioWithTransactionScopeExample().Run();
            //new IncludesExample().Run();
            //new ModelUpdatesExample().Run();
            //new ControlWhatToIndexExample().Run();

            Console.WriteLine("-- Done --");
            Console.ReadKey();
        }
    }
}
