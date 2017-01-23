using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace StudentScoring.Tests
{
    [TestClass()]
    public class StudentScoreManagerTests
    {
        [TestMethod()]
        public void PersistStudentsTest()
        {
            StudentCsvFileManager studentCsvFileManager = new StudentCsvFileManager();
            var students = new List<String> { "John", "Doe", "5" };

            try
            {
                studentCsvFileManager.WriteCsv(students);
            }
            catch (StudentCsvFileException ex)
            {
                Assert.AreEqual(ex.Message, "No respective CSV input-file provided. Output incorporates use of input-file name");
            }
        }

        [TestMethod()]
        public void CreateStudentsTest()
        {
            StudentCsvFileManager studentCsvFileManager = new StudentCsvFileManager();
            List<Student> students = new List<Student>();

            try
            {
                students = studentCsvFileManager.GetStudents("..\\..\\Data\\students.txt");                
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Could not find file 'students.txt'");
            }

            Assert.AreEqual(students[0].FirstName, "TED");
            Assert.AreEqual(students[0].LastName, "BUNDY");
            Assert.AreEqual(students[0].Score, (System.UInt32)88);

            Assert.AreEqual(students[1].FirstName, "ALLAN");
            Assert.AreEqual(students[1].LastName, "SMITH");
            Assert.AreEqual(students[1].Score, (System.UInt32)85);

            Assert.AreEqual(students[2].FirstName, "MADISON");
            Assert.AreEqual(students[2].LastName, "KING");
            Assert.AreEqual(students[2].Score, (System.UInt32)83);

            Assert.AreEqual(students[3].FirstName, "FRANCIS");
            Assert.AreEqual(students[3].LastName, "SMITH");
            Assert.AreEqual(students[3].Score, (System.UInt32)85);
        }

        [TestMethod()]
        public void PersistStudentsTestCheckSortedOutputCSV()
        {
            StudentCsvFileManager studentCsvFileManager = new StudentCsvFileManager();
            StudentScoreManager studentScoreManager = new StudentScoreManager();

            try
            {
                studentScoreManager.CreateStudents("..\\..\\Data\\students.txt");                
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Could not find file 'students.txt'");
            }

            List<Student> students = studentScoreManager.Students;

            Assert.AreEqual(students[0].FirstName, "TED");
            Assert.AreEqual(students[0].LastName, "BUNDY");
            Assert.AreEqual(students[0].Score, (System.UInt32)88);

            Assert.AreEqual(students[1].FirstName, "ALLAN");
            Assert.AreEqual(students[1].LastName, "SMITH");
            Assert.AreEqual(students[1].Score, (System.UInt32)85);

            Assert.AreEqual(students[2].FirstName, "FRANCIS");
            Assert.AreEqual(students[2].LastName, "SMITH");
            Assert.AreEqual(students[2].Score, (System.UInt32)85);

            Assert.AreEqual(students[3].FirstName, "MADISON");
            Assert.AreEqual(students[3].LastName, "KING");
            Assert.AreEqual(students[3].Score, (System.UInt32)83);

            studentScoreManager.PersistStudents(students);

            List<string> outputCSV = studentCsvFileManager.ReadCsv("..\\..\\Data\\students-graded.txt");

            Assert.AreEqual(outputCSV[0], "BUNDY,TED,88");
            Assert.AreEqual(outputCSV[1], "SMITH,ALLAN,85");
            Assert.AreEqual(outputCSV[2], "SMITH,FRANCIS,85");
            Assert.AreEqual(outputCSV[3], "KING,MADISON,83");
        }
    }
}