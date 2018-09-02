using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Test.UnitTests.Repository;
using Xunit;

namespace Test.IntegrationTests.Repository
{
    public class CSVDataLoaderIntegrationTest
    {
        [Fact]
        public void LoadFile_ValidFile_Success()
        {
            IDataLoader dataLoader = new CSVDataLoader();
            var result = dataLoader.Load(".\\IntegrationTests\\Repository\\Test.csv");
            Assert.Equal(3, result.Length);
        }

        [Fact]
        public void LoadFile_FileNotExists_ArgumentException()
        {
            IDataLoader dataLoader = new CSVDataLoader();
            Assert.Throws<ArgumentException>(() => dataLoader.Load(".\\IntegrationTests\\Repository\\DoesNotExists.csv"));
        }
    }
}
