using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGenerateForm.Uwp.Fluent
{
    internal class StringPropertyBag: PropertyBag
    {
        public StringPropertyBag(PropertyBag bag)
        {
            this.DisplayAs = bag.DisplayAs;
            this.Required = bag.Required;
            this.VisibleWhen = bag.VisibleWhen;
            this.WithOrder = bag.WithOrder;
        }

        public bool Multiline { get; set; }
        public int Length { get; internal set; }
    }
}
