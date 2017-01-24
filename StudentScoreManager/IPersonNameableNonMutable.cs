namespace StudentScoring
{
	/* An interface which describes how non-mutable 
	 * personified names should function */
	public interface IPersonNameableNonMutable
	{
		string FirstName
		{
			get;
		}

		string LastName
		{
			get;
		}
	}
}
