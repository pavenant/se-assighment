using System.Collections.Generic;

namespace Test.UnitTests.Services
{
    public interface IStatsService
    {
        double CalcArithmeticMean(double[] inputSet);
        double CalcStandardDeviation(double[] inputSet);

        /// <summary>
        /// Returns dictionary where the Key is the Bucket and the value is the number of occurences of the values in the bucket.
        /// The value of the key indicates the range. (Key 0 for values 0 to < 10) etc
        /// </summary>
        /// <param name="inputSet"></param>
        /// <returns></returns>
        Dictionary<int, int> GetHistogram(double[] inputSet);
    }
}