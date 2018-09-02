using Core.Interfaces;
using Core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Test.UnitTests.Services
{
    public class AssignmentServiceTest
    {
        [Fact]
        public void InitClass()
        {
            var dataLoaderMock = new Mock<IDataLoader>();
            var statsServiceMock = new Mock<IStatsService>();

            IAssignmentService service = new AssignmentService(dataLoaderMock.Object, statsServiceMock.Object);
            Assert.NotNull(service);
        }

        [Fact]
        public void DoAssighment()
        {
            const string InputLocation = "mockLocation";
            Dictionary<int, int> histDummy = new Dictionary<int, int>
            {
                { 0, 3 },
                { 1, 1 }
            };

            double[] testSet = new double[] { 3, 7, 7, 19 };
            var dataLoaderMock = new Mock<IDataLoader>();
            
            dataLoaderMock.Setup(n => n.Load(InputLocation)).Returns(testSet);

            var statsServiceMock = new Mock<IStatsService>();
            statsServiceMock.Setup(n => n.CalcArithmeticMean(testSet)).Returns(9);
            statsServiceMock.Setup(n => n.CalcStandardDeviation(testSet)).Returns(6);
            statsServiceMock.Setup(n => n.GetHistogram(testSet)).Returns(histDummy);

            IAssignmentService service = new AssignmentService(dataLoaderMock.Object, statsServiceMock.Object);
            service.DoAssignment(InputLocation);

            dataLoaderMock.Verify(m => m.Load(InputLocation));
            statsServiceMock.Verify(n => n.CalcArithmeticMean(testSet));
            statsServiceMock.Verify(n => n.CalcStandardDeviation(testSet));
            statsServiceMock.Verify(n => n.GetHistogram(testSet));
        }
    }
}
