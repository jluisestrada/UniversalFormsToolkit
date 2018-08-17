using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGenerateForm.Uwp
{
    public class StringPropertyConfiguration<T>: PropertyConfiguration<T>
        where T: class, new()
    {
    }
}
