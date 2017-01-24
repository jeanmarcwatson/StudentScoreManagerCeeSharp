using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudentScoring.Tests
{
	[TestClass()]
	public class StudentComparerTests
	{
		[TestMethod()]
		public void CompareStudentOneTrailsStudentTwo()
		{
			StudentComparer comparer = new StudentComparer();

			Student student1 = new Student("Jean-Marc", "Watson", 100);
			Student student2 = new Student("Ewan", "Watson", 100);

			var position = comparer.Compare(student1, student2);

			Assert.IsTrue(position == 1);
		}

		[TestMethod()]
		public void CompareStudentTwoTrailsStudentOne()
		{
			StudentComparer comparer = new StudentComparer();

			Student student1 = new Student("Jean-Marc", "Watson", 100);
			Student student2 = new Student("Ewan", "Watson", 50);

			var position = comparer.Compare(student2, student1);

			Assert.IsTrue(position == 1);
		}

		[TestMethod()]
		public void CompareStudentOneEqualsStudentTwo()
		{
			StudentComparer comparer = new StudentComparer();

			Student student1 = new Student("Jean-Marc", "Watson", 100);
			Student student2 = new Student("Jean-Marc", "Watson", 100);

			var position = comparer.Compare(student1, student2);

			Assert.IsTrue(position == 0);
		}

		[TestMethod()]
		public void CompareStudentOneScoresHigherStudentTwo()
		{
			StudentComparer comparer = new StudentComparer();

			Student student1 = new Student("Jean-Marc", "Watson", 100);
			Student student2 = new Student("Ewan", "Watson", 50);

			var position = comparer.Compare(student1, student2);

			Assert.IsTrue(position == -1);
		}

		[TestMethod()]
		public void CompareStudentOneScoresLowerStudentTwo()
		{
			StudentComparer comparer = new StudentComparer();

			Student student1 = new Student("Jean-Marc", "Watson", 10);
			Student student2 = new Student("Ewan", "Watson", 50);

			var position = comparer.Compare(student1, student2);

			Assert.IsTrue(position == 1);
		}
	}
}