using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoGenerateForm.Uwp
{
    public class CollectionPropertyConfiguration<T, TCollection>: PropertyConfiguration<T>
        where T: new()
        where TCollection: new()
    {
        public CollectionPropertyConfiguration<T, TCollection> DisplayMember(Expression<Func<TCollection, object>> expression)
        {
            return this;
        }

        public CollectionPropertyConfiguration<T, TCollection> SelectedItem(Expression<Func<T, object>> expression)
        {
            return this;
        }
    }

    public static class CollectionPropertyConfigurationExtensions
    {
        public static CollectionPropertyConfiguration<T, TCollection> DisplayAs<T, TCollection>(this CollectionPropertyConfiguration<T, TCollection> propertyConfig, string caption)
            where T : new()
            where TCollection: new()
        {
            propertyConfig.DisplayAs = caption;
            return propertyConfig;
        }

        public static CollectionPropertyConfiguration<T, TCollection> WithOrder<T, TCollection>(this CollectionPropertyConfiguration<T, TCollection> propertyConfig, int order)
            where T : new()
            where TCollection : new()
        {
            propertyConfig.WithOrder = order;
            return propertyConfig;
        }

        public static CollectionPropertyConfiguration<T, TCollection> VisibleWhen<T, TCollection>(this CollectionPropertyConfiguration<T, TCollection> propertyConfig, Func<T, bool> func)
            where T : new()
            where TCollection : new()
        {
            propertyConfig.VisibleWhen = func;
            return propertyConfig;
        }
    }
