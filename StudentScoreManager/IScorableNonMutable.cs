using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScoring
{
    /* A very simple interface for non-mutable scoring 
     * implementation */
    public interface IScorableNonMutable
    {
        // Scores cannot be negative
        uint Score
        {
            get;
        }

    }
}
