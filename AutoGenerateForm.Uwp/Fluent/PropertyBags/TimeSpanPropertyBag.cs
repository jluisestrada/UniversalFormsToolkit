namespace AutoGenerateForm.Uwp.Fluent
{
    internal class TimeSpanPropertyBag: PropertyBag
    {
        public TimeSpanPropertyBag(PropertyBag bag)
        {
            this.DisplayAs = bag.DisplayAs;
            this.Required = bag.Required;
            this.VisibleWhen = bag.VisibleWhen;
            this.WithOrder = bag.WithOrder;
        }

        internal int MinuteIncrement { get; set; }

        internal string ClockFormat { get; set; }
    }
}
