using System.Collections.Generic;
using System.Reflection;

namespace AutoGenerateForm.Uwp.Fluent
{
    internal class EntityPropertyBag: PropertyBag
    {
        internal Dictionary<PropertyInfo, PropertyBag> Properties { get; private set; }

        internal EntityPropertyBag(PropertyBag bag)
        {
            this.DisplayAs = bag.DisplayAs;
            this.Required = bag.Required;
            this.VisibleWhen = bag.VisibleWhen;
            this.WithOrder = bag.WithOrder;
        }
    }
}
