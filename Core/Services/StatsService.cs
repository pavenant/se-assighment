using System;
using System.Collections.Generic;

namespace Test.UnitTests.Services
{
    public class StatsService : IStatsService
    {
        public double CalcArithmeticMean(double[] inputSet)
        {
            ValidateCalcArithmeticMean(inputSet);

            double total = 0;
            foreach (var item in inputSet)
            {
                total += item;
            }
            return total / inputSet.Length;
        }

        private static void ValidateCalcArithmeticMean(double[] inputSet)
        {
            if (inputSet == null || inputSet.Length == 0)
            {
                throw new ArgumentException("Inputset musst contain at least 1 value");
            }
        }

        public double CalcStandardDeviation(double[] inputSet)
        {
            ValidateCalcStandardDeviationInputSet(inputSet);

            //step 1 find mean
            var mean = CalcArithmeticMean(inputSet);

            //step 2 subtract each item from mean and square result
            double varianceSqrTotal = GetVarSqrTotal(inputSet, mean);

            //step 3 find the mean of the differences
            double varMean = varianceSqrTotal / inputSet.Length;

            //step 4 squery route result for standard deviation (todo my own Sqrt route ??)
            return Math.Sqrt(varMean);
        }

        private static void ValidateCalcStandardDeviationInputSet(double[] inputSet)
        {
            if ((inputSet == null) || (inputSet.Length < 2))
            {
                throw new ArgumentException("Inputset must contain at least 2 different numbers for a meaningful example.");
            }
        }

        private static double GetVarSqrTotal(double[] inputSet, double mean)
        {
            double varianceSqrTotal = 0;

            foreach (var item in inputSet)
            {
                var a = (item - mean);
                varianceSqrTotal += (a * a);
            }

            return varianceSqrTotal;
        }

        /// <summary>
        /// Returns dictionary where the Key is the Bucket and the value is the number of occurences of the values in the bucket.
        /// The value of the key indicates the range. (Key 0 for values 0 to < 10) etc
        /// </summary>
        /// <param name="inputSet"></param>
        /// <returns></returns>
        public Dictionary<int, int> GetHistogram(double[] inputSet)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            foreach (var item in inputSet)
            {
                var key = (int)(item / 10);
                if (result.ContainsKey(key))
                {
                    result[key] += 1;
                }
                else
                {
                    result.Add(key, 1);
                }
            }
            return result;
        }
    }
}