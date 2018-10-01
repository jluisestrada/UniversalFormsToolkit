using System.Reflection;

namespace AutoGenerateForm.Uwp.Fluent
{
    internal class AutoSuggestionPropertyBag: PropertyBag
    {
        internal AutoSuggestionPropertyBag(PropertyBag bag)
        {
            this.DisplayAs = bag.DisplayAs;
            this.Required = bag.Required;
            this.VisibleWhen = bag.VisibleWhen;
            this.WithOrder = bag.WithOrder;
        }

        public PropertyInfo CollectionSourceProperty { get; set; }

        public string CollectionSourcePropertyName { get; set; }

        public string CollectionName { get; set; }
    }
}
