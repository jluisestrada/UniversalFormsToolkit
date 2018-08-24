using AutoGenerateForm.Uwp.Fluent;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace AutoGenerateForm.Uwp
{
    public class EntityConfiguration<T>
        where T:  new()
    {
        internal readonly EntityBag _entityBag;

        internal EntityConfiguration(EntityBag bag)
        {
            _entityBag = bag;
        }

        public PropertyConfiguration<T> Property(Expression<Func<T, object>> expression)
        {
            var prop = TryAddProperty(expression);
            return prop;
        }

        private PropertyConfiguration<T> TryAddProperty(Expression<Func<T, object>> expression)
        {
            var info = Helpers.Reflection.GetPropertyInfo(expression);

            if (_entityBag.Properties.ContainsKey(info))
            {
                throw new ArgumentException($"The property { info.Name } is already defined.");
            }

            var bag = new PropertyBag();

            _entityBag.Properties.Add(info, bag);

            return new PropertyConfiguration<T>(bag);
        }

        public CollectionPropertyConfiguration<T,TCollection> CollectionProperty<TCollection>(Expression<Func<T, IEnumerable<TCollection>>> expression)
            where TCollection: new()
        {
            var info = Helpers.Reflection.GetPropertyInfoFromCollection(expression);

            if (_entityBag.Properties.ContainsKey(info))
            {
                throw new ArgumentException($"The property { info.Name } is already defined.");
            }

            var bag = new PropertyBag();

            _entityBag.Properties.Add(info, bag);

            return new CollectionPropertyConfiguration<T, TCollection>(bag);
        }
    }
}
