using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Test.UnitTests.Services;

namespace Core.Services
{
    public class AssignmentService : IAssignmentService
    {
        private IDataLoader _dataLoader;
        private IStatsService _statsServic;

        public AssignmentService(IDataLoader dataLoader,IStatsService statsService)
        {
            ValidateConstructor(dataLoader, statsService);

            _dataLoader = dataLoader;
            _statsServic = statsService;
        }

        private static void ValidateConstructor(IDataLoader dataLoader, IStatsService statsService)
        {
            if (dataLoader == null || statsService == null)
            {
                throw new ArgumentException("Both dataloader and statsservice must be supplied.");
            }
        }

        //Using C#, write some code to:
        //Read the file contents into memory
        //Avoiding built in methods like.Sum, .Average etc, write your own algorithms to
        //Calculate the arithmetic mean
        //Calculate the standard deviation
        //Compute the frequencies of numbers in bins of 10 (histogram   0  to<10,  10  to<20 etc.)
        public void DoAssignment(string dataSourceLocation)
        {
            //Read the file contents into memory
            var dataSet = _dataLoader.Load(dataSourceLocation);
            Console.WriteLine("dataset loaded - {0} items", dataSet.Length);

            //Calculate the arithmetic mean
            var mean = _statsServic.CalcArithmeticMean(dataSet);
            Console.WriteLine("arithmetic mean calculated - {0} ", mean);

            //Calculate the standard deviation
            var standardDeviation = _statsServic.CalcStandardDeviation(dataSet);
            Console.WriteLine("standard deviation calculated - {0} ", standardDeviation);

            //historam
            var histogram = _statsServic.GetHistogram(dataSet);
            Console.WriteLine("histogram loaded");
            foreach (var item in histogram)
            {                
                Console.WriteLine("bin {0} to < {1} --> {2}", item.Key * 10, (item.Key + 1) * 10, item.Value);
            }
        }
    }
}
