using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace StudentScoring.Tests
{
    [TestClass()]
    public class StudentTests
    {
        [TestMethod()]
        public void StudentTestIndividualCTORParams()
        {
            Student student = new Student("Jean-Marc", "Watson", 100);

            Assert.AreEqual(student.FirstName, "Jean-Marc");
            Assert.AreEqual(student.LastName, "Watson");
            Assert.AreEqual(student.Score, (System.UInt32)100);
        }

        [TestMethod()]
        public void StudentTestStringCTORParam()
        {
            Student student = new Student("Jean-Marc,Watson,100");

            Assert.AreEqual(student.FirstName, "Jean-Marc");
            Assert.AreEqual(student.LastName, "Watson");
            Assert.AreEqual(student.Score, (System.UInt32)100);
        }
        
    }
}