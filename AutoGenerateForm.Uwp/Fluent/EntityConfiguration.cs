using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoGenerateForm.Uwp
{
    public class EntityConfiguration<T>
        where T: class, new()
    {
        private Dictionary<string, PropertyConfiguration<T>> _properties;

        internal EntityConfiguration()
        {
            _properties = new Dictionary<string, PropertyConfiguration<T>>();
        }

        public PropertyConfiguration<T> Property(Expression<Func<T, object>> expression)
        {
            var prop = new PropertyConfiguration<T>();
            return prop;
        }

        public CollectionPropertyConfiguration<T,TCollection> CollectionProperty<TCollection>(Expression<Func<T, IEnumerable<TCollection>>> expression)
            where TCollection: new()
        {
            var prop = new CollectionPropertyConfiguration<T, TCollection>();
            return prop;
        }
    }
}
