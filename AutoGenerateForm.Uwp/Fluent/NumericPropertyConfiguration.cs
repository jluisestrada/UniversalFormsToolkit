using AutoGenerateForm.Uwp.Fluent;
using System;

namespace AutoGenerateForm.Uwp
{
    public class NumericPropertyConfiguration<T, TNumeric> : PropertyConfiguration<T>
        where T : new()
        where TNumeric : struct,
                        IComparable,
                        IComparable<TNumeric>,
                        IConvertible,
                        IEquatable<TNumeric>,
                        IFormattable
    {
        internal new  NumericPropertyBag _bag;

        internal NumericPropertyConfiguration(PropertyBag bag): base()
        {
            _bag = new NumericPropertyBag(bag);
        }
    }

    public static class NumericPropertyConfigurationExtensions
    {
        public static NumericPropertyConfiguration<T, TNumeric> WithRange<T, TNumeric>(this NumericPropertyConfiguration<T, TNumeric> propertyConfig, TNumeric min, TNumeric max)
               where T : new()
               where TNumeric : struct,
                        IComparable,
                        IComparable<TNumeric>,
                        IConvertible,
                        IEquatable<TNumeric>,
                        IFormattable
        {
            propertyConfig._bag.Range = (Convert.ToDouble(min), Convert.ToDouble(max));
            return propertyConfig;
        }

        public static NumericPropertyConfiguration<T, TNumeric> NumberOfDecimals<T, TNumeric>(this NumericPropertyConfiguration<T, TNumeric> propertyConfig, int decimals)
            where T : new()
            where TNumeric : struct,
                        IComparable,
                        IComparable<TNumeric>,
                        IConvertible,
                        IEquatable<TNumeric>,
                        IFormattable
        {
            propertyConfig._bag.NumberOfDecimals = decimals;
            return propertyConfig;
        }

        public static NumericPropertyConfiguration<T, TNumeric> AutoIncrement<T, TNumeric>(this NumericPropertyConfiguration<T, TNumeric> propertyConfig)
            where T : new()
            where TNumeric : struct,
                        IComparable,
                        IComparable<TNumeric>,
                        IConvertible,
                        IEquatable<TNumeric>,
                        IFormattable
        {
            propertyConfig._bag.AutoIncrement = true;
            return propertyConfig;
        }
    }
}
