using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Test.UnitTests.Repository
{
    public class CSVDataLoaderTest
    {
        [Fact]
        public void InitFile()
        {
            IDataLoader dataLoader = new CSVDataLoader();
        }

        [Fact]
        public void LoadFile()
        {
            IDataLoader dataLoader = new CSVDataLoader();
            double[] dataArray = dataLoader.Load("");
        }

        [Fact]
        public void LoadFile_InvalidInput_Fail()
        {
            IDataLoader dataLoader = new CSVDataLoader();
            Assert.Throws<ArgumentException>(() => dataLoader.Load(""));
        }
    }
}
