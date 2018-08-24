using AutoGenerateForm.Uwp.Fluent;
using System;
using System.Linq.Expressions;

namespace AutoGenerateForm.Uwp
{
    public class CollectionPropertyConfiguration<T, TCollection> : PropertyConfiguration<T>
        where T : new()
        where TCollection : new()
    {
        internal new CollectionPropertyBag _bag;

        internal CollectionPropertyConfiguration(PropertyBag bag): base()
        {
            _bag = new CollectionPropertyBag(bag);
        }
    }

    public static class CollectionPropertyConfigurationExtensions
    {
        public static CollectionPropertyConfiguration<T, TCollection> DisplayAs<T, TCollection>(this CollectionPropertyConfiguration<T, TCollection> propertyConfig, string caption)
            where T : new()
            where TCollection : new()
        {
            propertyConfig._bag.DisplayAs = caption;
            return propertyConfig;
        }

        public static CollectionPropertyConfiguration<T, TCollection> WithOrder<T, TCollection>(this CollectionPropertyConfiguration<T, TCollection> propertyConfig, int order)
            where T : new()
            where TCollection : new()
        {
            propertyConfig._bag.WithOrder = order;
            return propertyConfig;
        }

        public static CollectionPropertyConfiguration<T, TCollection> VisibleWhen<T, TCollection>(this CollectionPropertyConfiguration<T, TCollection> propertyConfig, Func<T, bool> func)
            where T : new()
            where TCollection : new()
        {
            propertyConfig._bag.VisibleWhen = func;
            return propertyConfig;
        }

        public static CollectionPropertyConfiguration<T, TCollection> DisplayMember<T, TCollection>(this CollectionPropertyConfiguration<T, TCollection> propertyConfig, Expression<Func<TCollection, object>> expression)
             where T : new()
            where TCollection : new()
        {
            return propertyConfig;
        }

        public static CollectionPropertyConfiguration<T, TCollection> SelectedItem<T, TCollection>(this CollectionPropertyConfiguration<T, TCollection> propertyConfig, Expression<Func<T, object>> expression)
             where T : new()
            where TCollection : new()
        {
            return propertyConfig;
        }
    }
}
