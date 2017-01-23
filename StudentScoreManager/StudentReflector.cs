using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Diagnostics;

namespace StudentScoring
{
    /* A custom reflection-based class which allows propertyOrder attributes on a Student class to be used to sort the order in which the
     * class properties are accessed/used */
    public sealed class StudentReflector<Student> : IReflectableSortedProperties<Student>
    {
        // Return a container of sorted Student class properties
        public IEnumerable<PropertyInfo> GetSortedProperties()
        {
            try
            {
                return typeof(Student).GetProperties().OrderBy(property => 
                    ((CSVOutputPropertyOrderAttribute)property.GetCustomAttributes(typeof(CSVOutputPropertyOrderAttribute), false).First()).CSVPropertyOrder);
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"There was a problem trying to obtain the custom attributes for a class property: {exception.Message}");
            }

            return null;       
        }

        /* Given a container of Student objects create a container of strings based upon 
         * the (sorted) property values of each distinct Student object */
        public List<string> GetOrderedPropertyValuesFromObjects(List<Student> objects)
        {
            var line = "";

            // Repeat for each Student object instantiation
            foreach(var student in objects)
            {
                // Get the property values for the Student instance
                IEnumerable<PropertyInfo> propertyInfo  = GetSortedProperties();

                // Build a comma-separated string from the values
                propertyInfo?.ToList().ForEach(prop => line += $"{prop.GetValue(student)},");

                /* Only terminate the line if we definitely had sorted container of
                 * properties provided by the Student instance */
                if (propertyInfo != null)
                {
                    line = line.Remove(line.LastIndexOf(","));
                    line += System.Environment.NewLine;
                }
            }

            /* Return the complete list of strings (as CSV) which represents all values read from all
             * provided Student instances */            
            return new List<string>(line.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
