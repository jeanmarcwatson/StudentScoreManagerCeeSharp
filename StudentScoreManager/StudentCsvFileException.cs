using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScoring
{

    using System;

    // A bespoke exception class for CSV file-exceptions 
    public class StudentCsvFileException : Exception
    {
        public StudentCsvFileException()
        {
        }

        public StudentCsvFileException(string exceptionMessage)
            : base(exceptionMessage)
        {
        }

        public StudentCsvFileException(string exceptionMessage, Exception inner)
            : base(exceptionMessage, inner)
        {
        }
    }    
}
