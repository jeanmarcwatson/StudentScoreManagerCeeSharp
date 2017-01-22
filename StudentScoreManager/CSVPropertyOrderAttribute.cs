using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScoring
{
    /* A specialised derivation of the base custom attribute class, used for property-ordering,
     * which is semantically aligned with CSV property ordering (for outputting CSV) */
    public class CSVPropertyOrderAttribute : PropertyOrderAttribute
    {
        public CSVPropertyOrderAttribute(int order) : base(order) { }

        public int CSVPropertyOrder
        {
            get
            {
                // Use the base class order property
                return base.PropertyOrder;
            }
        }
    }
}
