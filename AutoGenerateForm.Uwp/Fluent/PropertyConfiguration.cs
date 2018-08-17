using System;

namespace AutoGenerateForm.Uwp
{


    public class PropertyConfiguration<T>
        where T : new()
    {
        internal string DisplayAs { get; set; }

        internal int? WithOrder { get; set; }

        internal Func<T, bool> VisibleWhen { get; set; }
    }



    public static class PropertyConfigurationExtensions
    {
        public static PropertyConfiguration<T> DisplayAs<T>(this PropertyConfiguration<T> propertyConfig, string caption)
            where T: new()
        {
            propertyConfig.DisplayAs = caption;
            return propertyConfig;
        }

        public static PropertyConfiguration<T> WithOrder<T>(this PropertyConfiguration<T> propertyConfig, int order)
            where T :  new()
        {
            propertyConfig.WithOrder = order;
            return propertyConfig;
        }

        public static PropertyConfiguration<T> VisibleWhen<T>(this PropertyConfiguration<T> propertyConfig, Func<T, bool> func)
            where T :  new()
        {
            propertyConfig.VisibleWhen = func;
            return propertyConfig;
        }
    }
}
