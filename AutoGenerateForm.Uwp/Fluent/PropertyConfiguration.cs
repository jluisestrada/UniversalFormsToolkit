using System;
using AutoGenerateForm.Uwp.Fluent;

namespace AutoGenerateForm.Uwp
{


    public class PropertyConfiguration<T>
        where T : new()
    {
        internal PropertyBag _bag;

        internal PropertyConfiguration(PropertyBag bag)
        {
            _bag = bag;
        }

        internal PropertyConfiguration()
        {

        }
    }

    public static class PropertyConfigurationExtensions
    {
        public static PropertyConfiguration<T> DisplayAs<T>(this PropertyConfiguration<T> propertyConfig, string caption)
            where T: new()
        {
            propertyConfig._bag.DisplayAs = caption;
            return propertyConfig;
        }

        public static PropertyConfiguration<T> WithOrder<T>(this PropertyConfiguration<T> propertyConfig, int order)
            where T :  new()
        {
            propertyConfig._bag.WithOrder = order;
            return propertyConfig;
        }

        public static PropertyConfiguration<T> VisibleWhen<T>(this PropertyConfiguration<T> propertyConfig, Func<T, bool> func)
            where T :  new()
        {
            propertyConfig._bag.VisibleWhen = func;
            return propertyConfig;
        }

        public static PropertyConfiguration<T> Required<T>(this PropertyConfiguration<T> propertyConfig)
            where T : new()
        {
            propertyConfig._bag.Required = true;
            return propertyConfig;
        }
    }
}
