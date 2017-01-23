using System.Collections.Generic;

namespace StudentScoring
{
    /* The top-level Student container management class */
    public class StudentScoreManager
    {
        // All of our students
        List<Student> students;

        // File-management type
        StudentCsvFileManager studentCSVFileManager;

        // Provide read-only access the student container
        public List<Student> Students
        {
            get
            {
                return students ?? new List<Student>();
            }
        }

        public StudentScoreManager()
        {
            studentCSVFileManager = new StudentCsvFileManager();
        }

        // Simple method for creating the container of Students using a CSV file
        public void CreateStudents(string sourceFile)
        {
            // Create our Student container based upon the contents of the input-file
            students = studentCSVFileManager.ReadStudents(sourceFile);

            // Sort the Student(s) according to our sort criteria
            Students.Sort(new StudentComparer());
        }

        /* Method to allow the sorted student container to be written
         * to an output CSV file */
        public void PersistStudents(List<Student> students)
        {
            /* Output-file is inferred from input file so we only provide the
             * students */
            studentCSVFileManager.WriteStudents(students);
        }
    }
}
