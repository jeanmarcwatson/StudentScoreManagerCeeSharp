using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Collections.Generic;

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
                studentCsvFileManager.ReadCsv("c:\\NonexistantDirectory\\DoesntExist.txt");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Could not find a part of the path 'c:\\NonexistantDirectory\\DoesntExist.txt'.");
            }
        }
        [TestMethod()]
        public void WriteCsvTestFileNoAssociatedInputFile()
        {
            StudentCsvFileManager studentCsvFileManager = new StudentCsvFileManager();
            var students = new List<string>() { "JOHN, DOE, 99", "JAMES, SMITH, 25" };

            try
            {
                studentCsvFileManager.WriteCsv(students);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "No respective CSV input-file provided. Output incorporates use of input-file name");
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
                Debug.WriteLine(ex.Message);
            }

            Assert.AreEqual(fileContents[0], "TED,BUNDY,88");
            Assert.AreEqual(fileContents[1], "ALLAN,SMITH,85");
            Assert.AreEqual(fileContents[2], "MADISON,KING,83");
            Assert.AreEqual(fileContents[3], "FRANCIS,SMITH,85");

        }

        [TestMethod()]
        public void ReadStudentsTest()
        {
            StudentCsvFileManager studentCsvFileManager = new StudentCsvFileManager();
            List<Student> students = new List<Student>();

            try
            {
                students = studentCsvFileManager.ReadStudents("..\\..\\Data\\students.txt");               
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
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
        public void ReadStudentsUsingMalformedInputFileTest()
        {

            /* The variant input file looks like this (blank line, missing score and insufficient field delimiters):
             * 
             *  TED,BUNDY,88
             *
             *  ALLAN,SMITH,85
             *  MADISON,KING,83
             *  HARRY,NORMAN,
             *  WENDY,JONES,100
             *  JAMES, BUTLER
             *  FRANCIS,SMITH,85
             *  */

            StudentCsvFileManager studentCsvFileManager = new StudentCsvFileManager();
            List<Student> students = new List<Student>();

            try
            {
                students = studentCsvFileManager.ReadStudents("..\\..\\Data\\students-variant.txt");
            }
            catch (Exception ex)
            {
				Debug.WriteLine(ex.Message);
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

            Assert.AreEqual(students[3].FirstName, "HARRY");
            Assert.AreEqual(students[3].LastName, "NORMAN");
            Assert.AreEqual(students[3].Score, (System.UInt32)0);

            Assert.AreEqual(students[4].FirstName, "WENDY");
            Assert.AreEqual(students[4].LastName, "JONES");
            Assert.AreEqual(students[4].Score, (System.UInt32)100);

            Assert.AreEqual(students[5].FirstName, "FRANCIS");
            Assert.AreEqual(students[5].LastName, "SMITH");
            Assert.AreEqual(students[5].Score, (System.UInt32)85);

        }
    }
}
 