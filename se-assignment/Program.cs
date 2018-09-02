using Core.Interfaces;
using Core.Services;
using System;
using Test.UnitTests.Repository;
using Test.UnitTests.Services;

namespace se_assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IDataLoader dataLoader = new CSVDataLoader(); //note, we dould implement different data loaders e.g. google sheets data loader.
                IStatsService statsService = new StatsService();

                //note for simplicity we are not using a service locator for example.
                IAssignmentService assignment = new AssignmentService(dataLoader,statsService);
                assignment.DoAssignment("SampleData.csv");

            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine("Invalid argument");
                Console.WriteLine(argEx.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine("exceptions occured while running the program");
                Console.WriteLine(ex.ToString());
            }

            Console.ReadLine();
        }
    }
}
