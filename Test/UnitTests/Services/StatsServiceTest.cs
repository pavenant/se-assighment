using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Test.UnitTests.Services
{
    public class StatsServiceTest
    {
        [Fact]
        public void InitService()
        {
            IStatsService statsService = new StatsService();
        }

        [Fact]
        public void CalArithmeticMean_IntInputValues_Success()
        {
            IStatsService statsService = new StatsService();
            double mean = statsService.CalcArithmeticMean(new double[] { 1, 1 });
            Assert.Equal(1, mean);
        }

        [Fact]
        public void CalArithmeticMean_DoubleInputValues_Success()
        {
            IStatsService statsService = new StatsService();
            double mean = statsService.CalcArithmeticMean(new double[] { 1.5, 1.5, 1.5 });
            Assert.Equal(1.5, mean);
        }

        [Fact]
        public void CalArithmeticMean_EmptyList_Exception()
        {
            IStatsService statsService = new StatsService();
            Assert.Throws<ArgumentException>(() => statsService.CalcArithmeticMean(new double[] { }));
        }

        [Fact]
        public void CalArithmeticMean_CornerCase_ZeroValue()
        {
            IStatsService statsService = new StatsService();
            Assert.Equal(0, statsService.CalcArithmeticMean(new double[] { 0 }));
        }

        [Fact]
        public void CalcStandardDeviation()
        {
            IStatsService statsService = new StatsService();
            double standardDeviation = statsService.CalcStandardDeviation(new double[] { 3, 7, 7, 19 });
            Assert.Equal(6, standardDeviation);
        }

        [Fact]
        public void CalcStandardDeviation_CornerCaseOneItem()
        {
            IStatsService statsService = new StatsService();
            Assert.Throws<ArgumentException>(() => statsService.CalcStandardDeviation(new double[] { 10 }));
        }

        [Fact]
        public void CalcHistogram()
        {
            IStatsService statsService = new StatsService();
            Dictionary<int, int> histogram = statsService.GetHistogram(new double[] { 3, 70, 110, 6, 110, 110.5 });
            Assert.Equal(3, histogram.Count);
            Assert.Equal(2, histogram[0]);
            Assert.Equal(3, histogram[11]);
        }

        [Fact]
        public void CalcHistogram_CornerCaseEmptyList()
        {
            IStatsService statsService = new StatsService();
            Dictionary<int, int> histogram = statsService.GetHistogram(new double[] { });
            Assert.Empty(histogram);
        }
    }
}
