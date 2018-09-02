using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IAssignmentService
    {

        //Using C#, write some code to:
        //Read the file contents into memory
        //Avoiding built in methods like.Sum, .Average etc, write your own algorithms to
        //Calculate the arithmetic mean
        //Calculate the standard deviation
        //Compute the frequencies of numbers in bins of 10 (histogram   0  to<10,  10  to<20 etc.)

        void DoAssignment(string dataSourceLocation);
    }
}
