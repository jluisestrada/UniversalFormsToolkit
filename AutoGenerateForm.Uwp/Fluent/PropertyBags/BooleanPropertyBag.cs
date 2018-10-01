namespace AutoGenerateForm.Uwp.Fluent
{
    internal class BooleanPropertyBag: PropertyBag
    {
        internal BooleanPropertyBag(PropertyBag bag)
        {
            this.DisplayAs = bag.DisplayAs;
            this.Required = bag.Required;
            this.VisibleWhen = bag.VisibleWhen;
            this.WithOrder = bag.WithOrder;
        }
    }
}
