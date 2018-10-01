using System;

namespace AutoGenerateForm.Uwp.Fluent
{
    internal class PropertyBag
    {
        internal string Subtitle { get;  set; }

        internal string EnabledWhenSource { get; set; }

        internal Delegate EnabledWhen { get; set; }

        internal string DisplayAs { get; set; }

        internal int? WithOrder { get; set; }

        internal Delegate VisibleWhen { get; set; }

        internal bool Required { get; set; }
    }
}
