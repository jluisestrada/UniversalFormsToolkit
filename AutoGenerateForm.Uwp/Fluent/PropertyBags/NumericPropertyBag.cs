namespace AutoGenerateForm.Uwp.Fluent
{
    internal class NumericPropertyBag : PropertyBag
    {


        public NumericPropertyBag(PropertyBag bag)
        {
            this.DisplayAs = bag.DisplayAs;
            this.Required = bag.Required;
            this.VisibleWhen = bag.VisibleWhen;
            this.WithOrder = bag.WithOrder;
        }

        internal (double min, double max) Range { get; set; }

        internal int NumberOfDecimals { get; set; }

        internal bool AutoIncrement { get; set; }

    }
}
