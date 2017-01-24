using System;

namespace StudentScoring
{
	// A custom-attribute class which defines an order for respective class properties */
	[AttributeUsage(AttributeTargets.Property)]
	public class PropertyOrderAttribute : Attribute
	{
		private int order;

		public PropertyOrderAttribute(int order)
		{
			this.order = order;
		}

		/* Accessor can be used for determining the respective attribute
		 * order ordinal */
		public int PropertyOrder
		{
			get
			{
				return order;
			}
		}
	}
}
