using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScoring
{
    /* An interface which describes how any CSV-related 
     * read/write operations should function */
    public interface ICSVable
    {
        List<string> ReadCsv(string sourceFile);
        void WriteCsv(List<string> content);
    }
}
