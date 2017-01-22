using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
