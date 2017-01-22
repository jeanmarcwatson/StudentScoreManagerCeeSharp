using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StudentScoring
{
    // Abstract definition of required file-operations
    public abstract class FileOperations
    {
        abstract protected void WriteFile(string fileName, List<string> contents);
        abstract protected List<string> ReadFile(string fileName);
    }
}
