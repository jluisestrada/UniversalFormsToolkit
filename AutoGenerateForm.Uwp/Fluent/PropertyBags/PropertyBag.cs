using System;

namespace AutoGenerateForm.Uwp.Fluent
{
    internal class PropertyBag
    {
        internal string DisplayAs { get; set; }

        internal int? WithOrder { get; set; }

        internal Delegate VisibleWhen { get; set; }

        internal bool Required { get; set; }
    }
}
