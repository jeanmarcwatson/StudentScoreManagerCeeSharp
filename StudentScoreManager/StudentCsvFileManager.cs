using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StudentScoring
{
    // The main management entity for reading/writing of CSV files
    public class StudentCsvFileManager : FileIO, ICSVable
    {
        string outputFilePostfix => "-graded.txt";
        string inputFileNameAndPathWithoutExtension;

        /* The reflection object used for ordering the Student properties
         * subsequently used for creating the sorted output CSV */
        StudentReflector<Student> studentReflector;

        public StudentCsvFileManager()
        {
            inputFileNameAndPathWithoutExtension = "";
            studentReflector = new StudentReflector<Student>();
        }

        // CSV Reader method which is abstracted away from the notion of Student types
        public List<string> ReadCsv(string sourceFile)
        {
            // Input-filename kept as intrinsic to the creation of the output-CSV-file
            inputFileNameAndPathWithoutExtension = sourceFile.Substring(0, sourceFile.LastIndexOf("."));
            return new List<string>(ReadFile(sourceFile));
        }
        
        // CSV Writer method
        public void WriteCsv(List<string> content)
        {
            // We cannot generate an output file if no input-file(name) provided
            if (inputFileNameAndPathWithoutExtension.Length == 0)
            {
                throw new StudentCsvFileException("No respective CSV input-file provided. Output incorporates use of input-file name");
            }
                
            // We must have a valid input-file so proceed to create an output file
            WriteFile(inputFileNameAndPathWithoutExtension + outputFilePostfix, content);
        }

        // A method to return CSV data from input-file as a container of Student objects
        public List<Student> ReadStudents(string sourceFile)
        {
            List<string> csvContent = ReadCsv(sourceFile);
            var students = new List<Student>();

            // Remove all blank lines from container
            csvContent.RemoveAll(IsBlankLine);

            // Initialise Student objects using the CSV string
            foreach(var csvLine in csvContent)
            {
                /* We need at least two comma separators in the line
                 * before we attempt to create a Student instance with 
                 * the string data */
                if (csvLine.Split(',').Length == 3)
                {
                    students.Add(new Student(csvLine));
                }                
            }

            return students;
        }

        private bool IsBlankLine(String line)
        {
            return line.Length == 0;
        }

        // A method to serialise (loosely speaking) a container of Student objects as CSV to a text file
        public void WriteStudents(List<Student> students)
        {
            
            try
            {
                /* NOTE: The serialisation depends on the Student object having the 
                 * property-order custom-attribute and will not provide CSV text (lines) 
                 * without them */
                WriteCsv(studentReflector.GetOrderedPropertyValuesFromObjects(students));
            }
            catch (StudentCsvFileException exception)
            {
                Debug.WriteLine($"Attempt to write the output CSV file generated message: {exception.Message}");

                /* Re-throw so dependant methods 
                 * can also catch the exception */
                throw;
            }
        }
    }
}
