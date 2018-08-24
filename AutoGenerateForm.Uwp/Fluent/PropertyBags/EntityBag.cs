using System.Collections.Generic;
using System.Reflection;

namespace AutoGenerateForm.Uwp.Fluent
{
    internal class EntityBag : PropertyBag
    {
        internal Dictionary<PropertyInfo, PropertyBag> Properties { get; private set; }
    }
}
