using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IDataLoader
    {
        double[] Load(string inputLocation);
    }
}
