using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentScoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScoring.Tests
{
    [TestClass()]
    public class StudentCsvFileManagerTests
    {
        [TestMethod()]
        public void ReadCsvTestFileDoesNotExist()
        {
            StudentCsvFileManager studentCsvFileManager = new StudentCsvFileManager();

            try
            {
                studentCsvFileManager.ReadCsv("c:\\DoesntExist.txt");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, $"Could not find file 'c:\\DoesntExist.txt'");
            }
        }

        [TestMethod()]
        public void ReadCsvTestCheckContentsReturned()
        {
            StudentCsvFileManager studentCsvFileManager = new StudentCsvFileManager();
            List<string> fileContents = new List<string>();

            try
            {
                fileContents = studentCsvFileManager.ReadCsv("..\\..\\Data\\students.txt");                
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, $"Could not find file 'students.txt'");
            }

            Assert.AreEqual(fileContents[0], "TED,BUNDY,88");
            Assert.AreEqual(fileContents[1], "ALLAN,SMITH,85");
            Assert.AreEqual(fileContents[2], "MADISON,KING,83");
            Assert.AreEqual(fileContents[3], "FRANCIS,SMITH,85");

        }

        [TestMethod()]
        public void GetStudentsTest()
        {
            StudentCsvFileManager studentCsvFileManager = new StudentCsvFileManager();
            List<Student> students = new List<Student>();

            try
            {
                students = studentCsvFileManager.GetStudents("..\\..\\Data\\students.txt");               
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, $"Could not find file 'students.txt'");
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
    }
}