using System;
using System.Collections.Generic;
using System.Linq;
namespace StudentScoring
{
	// A simple class/type to implement a "student score"
	public class Student : IPersonNameableNonMutable, IScorableNonMutable
	{
		uint score;
		string firstName;
		string lastName;

		// Set the order (to be used by reflection on output)
		[CSVOutputPropertyOrder(1)]
		public string FirstName
		{
			get
			{
				return firstName;
			}
		}

		// Set the order (to be used by reflection on output)
		[CSVOutputPropertyOrder(0)]
		public string LastName
		{
			get
			{
				return lastName;
			}
		}

		// Set the order (to be used by reflection on output)
		[CSVOutputPropertyOrder(2)]
		public uint Score
		{
			get
			{
				return score;
			}
		}
		
		public Student(string firstName, string lastName, uint Score)
		{
			this.firstName = firstName ?? "John";
			this.lastName = lastName ?? "Doe";
			this.score = Score;
		}

		public Student(string studentDetails)
		{
			// De-compose the string into its constituent parts
			string[] items = studentDetails.Split(new string[] { "," }, StringSplitOptions.None);

			/* Check length for semantic completeness of provided "Student"
			 * NOTE:    Anything that does not conform to the expected input format is
			 *          essentially rejected */
			if (items.Count() == 3)
			{
				// If we have null strings for First and last name then default the name
				this.firstName = items[0] ?? "JOHN";
				this.lastName = items[1] ?? "DOE";

				/* Ensure the value provided for score meets the unsigned requirement. Anything non-sensical
				 * will default to zero for score */
				this.score = uint.TryParse(items[2], out this.score) ? Convert.ToUInt32(items[2]) : 0;
			}
		}

	}
}
