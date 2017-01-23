namespace StudentScoring
{
    /* A specialised derivation of the base custom attribute class, used for property-ordering,
     * which is semantically aligned with CSV property ordering (for outputting CSV) */
    public class CSVOutputPropertyOrderAttribute : PropertyOrderAttribute
    {
        public CSVOutputPropertyOrderAttribute(int order) : base(order) { }

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
