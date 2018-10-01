using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGenerateForm.Uwp.Fluent
{
    internal class DateTimePropertyBag: PropertyBag
    {
        internal DateTimePropertyBag(PropertyBag bag)
        {
            this.DisplayAs = bag.DisplayAs;
            this.Required = bag.Required;
            this.VisibleWhen = bag.VisibleWhen;
            this.WithOrder = bag.WithOrder;
        }
    }
}
