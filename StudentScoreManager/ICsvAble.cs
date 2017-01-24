using System.Collections.Generic;

namespace StudentScoring
{
	/* An interface which describes how any CSV-related 
	 * read/write operations should function */
	public interface ICSVable
	{
		List<string> ReadCsv(string sourceFile);
		void WriteCsv(List<string> content);
	}
}
