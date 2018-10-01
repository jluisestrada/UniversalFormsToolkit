using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGenerateForm.Uwp.Fluent
{
    internal class StringPropertyBag: PropertyBag
    {
        internal StringPropertyBag(PropertyBag bag)
        {
            this.DisplayAs = bag.DisplayAs;
            this.Required = bag.Required;
            this.VisibleWhen = bag.VisibleWhen;
            this.WithOrder = bag.WithOrder;
        }

        internal bool Multiline { get; set; }
        internal int Length { get; set; }
        internal (int MinWidth, int MinHeight, int MaxHeight, int MaxWidth) MinAndMaxSize { get; set; }
    }
}
