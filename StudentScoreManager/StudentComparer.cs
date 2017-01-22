using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScoring
{
    public class StudentComparer : Comparer<Student>
    {

        public string NameToLower(string name)
        {
            return name?.ToLower();
        }

        // Overridden container sort method for <Student>
        public override int Compare(Student x, Student y)
        {
            // Indicate equality of Student objects
            if (x == y)
            {
                return 0;
            }           

            var xFirstName = NameToLower(x.FirstName);
            var xLastName = NameToLower(x.LastName);
            var yFirstName = NameToLower(y.FirstName);
            var yLastName = NameToLower(y.LastName);

            /* Score is the first discriminator but if equal revert 
             * to comparing last-name and if equality for that then
             * compare using first-name */
            if (x.Score == y.Score)
            {
                if (xLastName == yLastName)
                {
                    return xFirstName.CompareTo(yFirstName);
                }
                else
                {
                    return xLastName.CompareTo(yLastName);
                }  
            }
            else if (x.Score > y.Score)
            {
                /* Score ordering is descending as
                 * apposed to the default ordering of
                 * the 'CompareTo' method */
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
