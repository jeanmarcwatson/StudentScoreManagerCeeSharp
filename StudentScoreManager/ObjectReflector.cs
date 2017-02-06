using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Diagnostics;

namespace StudentScoring
{
	/* A custom reflection-based class which allows propertyOrder attributes (and derived) on 
	 * any class to be used to sort the order in which the class properties are accessed/used */
	public sealed class ObjectReflector<T> : IReflectableSortedProperties<T>
	{
		// Return a container of sorted object class properties (type U denotes attribute associated class)
		public IEnumerable<PropertyInfo> GetSortedProperties<U>()
		{
            try
            {
                /* In essence the following is happening:
                 * 
                 * Step 1:  Retrieve the properties for type T
                 * Step 2:  Invoke LINQ ordering using a lambda to sort (for all properties of T)
                 * Step 3:  For each property in object T (sorting)
                 *          (a) Get the first custom attribute for the property (as type U so we can discriminate)
                 *          (b) For the custom attribute returned get its type and then get the first property for that type (nesting)
                 *          (c) Then get its GetterMethod (for the nested property)
                 *          (d) Invoke the getter-method using the parent custom attribute instance (first one only) that belongs to type T 
                 *              which will return the integer value associated with the property.
                 * Step 4:  Return the sorted property-list that was generated using lambda scope in step 3.
                 *          */               
                PropertyInfo[] properties = typeof(T).GetProperties();

                return properties.OrderBy(property =>
                {
                    U customAttribute = ((U)property.GetCustomAttributes(typeof(U), false).First());
                    PropertyInfo customAttributeProperty = customAttribute.GetType().GetProperties().First();
                    MethodInfo customAttributePropertyGetMethod = customAttributeProperty.GetGetMethod();
                    return customAttributePropertyGetMethod.Invoke((U)customAttribute, null);                                       
                });
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"There was a problem trying to obtain the custom attributes for a class property: {exception.Message}");
            }

            return null;
        }

		/* Given a container of objects create a container of strings based upon 
		 * the (sorted) property values of each distinct object */
		public List<string> GetOrderedPropertyValuesFromObjects<U>(List<T> objects)
		{
			var line = "";

			// Repeat for each object instantiation
			foreach(var objectInstance in objects)
			{
				// Get the property values for the instance
				IEnumerable<PropertyInfo> propertyInfo  = GetSortedProperties<U>();

				// Build a comma-separated string from the values
				propertyInfo?.ToList().ForEach(prop => line += $"{prop.GetValue(objectInstance)},");

				/* Only terminate the line if we definitely had sorted container of
				 * properties provided by the instance */
				if (propertyInfo != null)
				{
					line = line.Remove(line.LastIndexOf(","));
					line += System.Environment.NewLine;
				}
			}

			/* Return the complete list of strings (as CSV) which represents all values read from all
			 * provided object instances */            
			return new List<string>(line.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
