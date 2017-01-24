using System;
using System.Diagnostics;

namespace StudentScoring
{
	class Program
	{
		static void Main(string[] args)
		{
			// Force the debug output to be written to console, in debug
			System.Diagnostics.TextWriterTraceListener writer = new TextWriterTraceListener(System.Console.Out);
			Debug.Listeners.Add(writer);

			if (args.Length > 1)
			{
				/* Output to console regardless of whether running debug/release as we don't want
				   the application to fail silently when no parameters/bad parameters are provided for
				   input file **/
				Console.WriteLine("You provided more than one argument for the input file-name/path.");
				return;
			}
			else if (args.Length == 0)
			{
				/* Same principle as above, for writing to console */
				Console.WriteLine("You did not provide any argument for the input file-name/path.");
				return;
			}

			/* Read an input CSV file, sort the contents and write the resulting output file */
			StudentScoreManager studentScoreManager = new StudentScoreManager();

			studentScoreManager.CreateStudents(args[0]);            
			studentScoreManager.PersistStudents(studentScoreManager.Students);
		}
	}
}
