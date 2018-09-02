using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core.Interfaces;

namespace Test.UnitTests.Repository
{
    public class CSVDataLoader : IDataLoader
    {
        public double[] Load(string inputLocation)
        {
            ValidateInput(inputLocation);
            return ReadValuesFromFile(inputLocation);
        }

        private static double[] ReadValuesFromFile(string inputLocation)
        {
            List<double> listItems = new List<double>();
            var lines = File.ReadLines(inputLocation);
            foreach (var line in lines)
            {
                foreach (var item in line.Split(","))
                {
                    listItems.Add(double.Parse(item));
                }
            }
            return listItems.ToArray();
        }

        private static void ValidateInput(string inputLocation)
        {
            Validate(inputLocation);
            ValidateFileNameExists(inputLocation);
        }

        private static void ValidateFileNameExists(string inputLocation)
        {
            if (!File.Exists(inputLocation))
            {
                throw new ArgumentException("invalid file path");
            }
        }

        private static void Validate(string inputLocation)
        {
            if (inputLocation == "")
            {
                throw new ArgumentException("empty filename not allowed");
            }
        }
    }
}