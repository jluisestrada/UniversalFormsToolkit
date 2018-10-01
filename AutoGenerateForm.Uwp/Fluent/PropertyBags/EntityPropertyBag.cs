using System.Collections.Generic;
using System.Reflection;

namespace AutoGenerateForm.Uwp.Fluent.PropertyBags
{
    internal class EntityPropertyBag: PropertyBag
    {
        internal Dictionary<PropertyInfo, PropertyBag> Properties { get; private set; }
    }
}
