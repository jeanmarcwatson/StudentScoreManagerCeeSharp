using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StudentScoring.Tests
{
	[TestClass()]
	public class StudentReflectorTests
	{
		[TestMethod()]
		public void GetOrderedPropertyValuesFromObjects()
		{
			StudentCsvFileManager studentCsvFileManager = new StudentCsvFileManager();            
			StudentReflector<Student> studentReflector = new StudentReflector<Student>();
			List<Student> students = new List<Student>();

			try
			{
				students = studentCsvFileManager.ReadStudents("..\\..\\Data\\students.txt");                          
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}

			List<string> propertyOrderedData = studentReflector.GetOrderedPropertyValuesFromObjects(students);

			Assert.AreEqual(propertyOrderedData[0], "BUNDY,TED,88");
			Assert.AreEqual(propertyOrderedData[1], "SMITH,ALLAN,85");
			Assert.AreEqual(propertyOrderedData[2], "KING,MADISON,83");
			Assert.AreEqual(propertyOrderedData[3], "SMITH,FRANCIS,85");

		}
	}
}