namespace AutoGenerateForm.Uwp.Fluent
{
    internal class NumericPropertyBag : PropertyBag
    {


        internal NumericPropertyBag(PropertyBag bag)
        {
            this.DisplayAs = bag.DisplayAs;
            this.Required = bag.Required;
            this.VisibleWhen = bag.VisibleWhen;
            this.WithOrder = bag.WithOrder;
        }

        internal (double min, double max) Range { get; set; }

        internal int NumberOfDecimals { get; set; }

        internal double AutoIncrementStep { get; set; }

    }
}
