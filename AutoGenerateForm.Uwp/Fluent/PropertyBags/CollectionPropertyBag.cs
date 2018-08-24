﻿using System.Reflection;

namespace AutoGenerateForm.Uwp.Fluent
{
    internal class CollectionPropertyBag: PropertyBag
    {
        public CollectionPropertyBag(PropertyBag bag)
        {
            this.DisplayAs = bag.DisplayAs;
            this.Required = bag.Required;
            this.VisibleWhen = bag.VisibleWhen;
            this.WithOrder = bag.WithOrder;
        }

        internal PropertyInfo DisplayMember { get; set; }

        internal PropertyInfo SelectedItem { get; set; }
    }
}
