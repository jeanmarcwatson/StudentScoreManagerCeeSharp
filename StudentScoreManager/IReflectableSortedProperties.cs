using System;
using System.Collections.Generic;
using System.Reflection;

namespace StudentScoring
{
	/* An interface which describes reflection-based functionality
	 * for the ordering of class properties */
	public interface IReflectableSortedProperties<T>
	{
		IEnumerable<PropertyInfo> GetSortedProperties<U>();
		List<String> GetOrderedPropertyValuesFromObjects<U>(List<T> objects);
	}
 }
