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
    public class StudentReflectorTests
    {
        [TestMethod()]
        public void GetOrderedPropertyValuesFromObjectsTest()
        {
            StudentCsvFileManager studentCsvFileManager = new StudentCsvFileManager();            
            StudentReflector<Student> studentReflector = new StudentReflector<Student>();
            List<Student> students = new List<Student>();

            try
            {
                students = studentCsvFileManager.GetStudents("..\\..\\Data\\students.txt");                          
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Could not find file 'students.txt'");
            }

            List<string> propertyOrderedData = studentReflector.GetOrderedPropertyValuesFromObjects(students);

            Assert.AreEqual(propertyOrderedData[0], "BUNDY,TED,88");
            Assert.AreEqual(propertyOrderedData[1], "SMITH,ALLAN,85");
            Assert.AreEqual(propertyOrderedData[2], "KING,MADISON,83");
            Assert.AreEqual(propertyOrderedData[3], "SMITH,FRANCIS,85");

        }
    }
}