using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace StudentScoring
{
    // This class serves as the file reader/writer and cannot be extended any further
    public class FileIO : FileOperations
    {        
        /* Concrete implementation for the writing of a file */
        sealed override protected void WriteFile(string fileName, List<string> contents)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach(var line in contents)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"The file could not be written: {exception.Message}");

								// Allow exception to be caught be caller
								throw;
            }

        }

        /* Concrete implementation for the reading of a file */
        sealed override protected List<string> ReadFile(string fileName)
        {
            var contents = new List<string>();
            var line = "";

            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        contents.Add(line);
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"The file could not be read: {exception.Message}");

								// Allow exception to be caught be caller
								throw;
						}

            return contents;

        }

    }
}
