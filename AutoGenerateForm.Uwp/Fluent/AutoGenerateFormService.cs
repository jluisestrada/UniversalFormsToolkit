using AutoGenerateForm.Attributes;
using AutoGenerateForm.Helpers;
using AutoGenerateForm.Uwp.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoGenerateForm.Uwp
{
    public class AutoGenerateFormService
    {

        private static AutoGenerateFormService _instance;
        internal static AutoGenerateFormService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AutoGenerateFormService();
                }

                return _instance;
            }
        }

        private Dictionary<Type, EntityBag> _entities;

        private AutoGenerateFormService()
        {
            _entities = new Dictionary<Type, EntityBag>();
        }

        public static EntityConfiguration<T> ForEntity<T>()
            where T : class, new()
        {
            var entity = TryAddEntity<T>();
            return entity;
        }

        private static EntityConfiguration<T> TryAddEntity<T>() where T : new()
        {
            var type = typeof(T);
            if (_instance._entities.ContainsKey(type))
            {
                throw new ArgumentException($"Entity { type.Name } is already defined.");
            }
            var bag = new EntityBag();

            _instance._entities.Add(type, bag);

            return new EntityConfiguration<T>(bag);
        }

        internal EntityBag GetConfigFromDataContext(object dataContext)
        {
            var type = dataContext.GetType();
            return GetConfigFromDataContext(type);
        }

        internal EntityBag GetConfigFromDataContext(Type type)
        {

            if (_entities.ContainsKey(type))
            {
                return _entities[type];
            }

            var res = BuildEntityBag(type);

            _entities.Add(type, res);

            return res;
        }

        private EntityBag BuildEntityBag(Type type)
        {
            var entityBag = new EntityBag();

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                 .Where(x => x.GetCustomAttributes<AutoGeneratePropertyAttribute>(false).Any() &&
                                            x.GetCustomAttributes<AutoGeneratePropertyAttribute>(false)
                                            .Cast<AutoGeneratePropertyAttribute>()
                                            .Any(z => z.AutoGenerate == true));

            foreach (var property in properties)
            {
                var bag = default(PropertyBag);

                var tColl = typeof(ICollection<>);
                var propertyType = property.PropertyType;
                if (!propertyType.Equals(typeof(int)) &&
                    !propertyType.Equals(typeof(string)) &&
                    !propertyType.Equals(typeof(float)) &&
                    !propertyType.Equals(typeof(double)) &&
                    !propertyType.Equals(typeof(decimal)) &&
                    !propertyType.Equals(typeof(int?)) &&
                    !propertyType.Equals(typeof(float?)) &&
                    !propertyType.Equals(typeof(decimal?)) &&
                    !propertyType.Equals(typeof(double?)) &&
                    !propertyType.Equals(typeof(DateTime)) &&
                    !propertyType.Equals(typeof(DateTime?)) &&
                    !propertyType.Equals(typeof(bool)) &&
                    !propertyType.Equals(typeof(bool?)) &&
                    !propertyType.Equals(typeof(TimeSpan)) &&
                    !propertyType.Equals(typeof(TimeSpan?)) &&
                    (propertyType.GetTypeInfo().IsGenericType && tColl.IsAssignableFrom(propertyType.GetGenericTypeDefinition()) ||
                     propertyType.GetInterfaces().Any(x => x.GetTypeInfo().IsGenericType && x.GetGenericTypeDefinition() == tColl)) == false)
                {
                    //List<PropertyInfo> props = new List<PropertyInfo>(propertyType
                    //                                                              .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    //                                                              .Where(x => x.GetCustomAttributes<AutoGeneratePropertyAttribute>(false).Any() &&
                    //                                                                          x.GetCustomAttributes<AutoGeneratePropertyAttribute>(false)
                    //                                                                           .Cast<AutoGeneratePropertyAttribute>()
                    //                                                                           .Any(z => z.AutoGenerate == true))
                    //                                                              .ToList());

                    //var orderedprops1 = GetOrderedProperties(props);
                    //await GenerateForm(orderedprops1, property);
                }
                else
                {
                    bag = this.GetBagFromProperty(property, type);

                }
            }

            return entityBag;

        }

        internal PropertyBag GetBagFromProperty(PropertyInfo property, Type entityType)
        {
            var bag = new PropertyBag()
            {
                DisplayAs = property.TryGetAttribute<DisplayAttribute>(out var display) ? display.Label : null,
                //Required = property.TryGetAttribute<Required>
                Subtitle = property.TryGetAttribute<SubtitleAttribute>(out var subtitle) ? subtitle.SubTitle : null,
                EnabledWhenSource = property.TryGetAttribute<IsEnabledPropertyAttribute>(out var isEnabled) ? isEnabled.PropertyToBind : null,
                //EnabledWhen = property.TryGetAttribute<IsEnabledPropertyAttribute>(out var isEnabled) ? 
                WithOrder = property.TryGetAttribute<PropertyOrderAttribute>(out var order) ? order.Order : 0,
                Required = property.TryGetAttribute<System.ComponentModel.DataAnnotations.RequiredAttribute>(out var required)
            };


            var propertyType = property.PropertyType;
            if (propertyType.Equals(typeof(int)) ||
                propertyType.Equals(typeof(long)) ||
                propertyType.Equals(typeof(int?)) ||
                propertyType.Equals(typeof(long?)))
            {

                if (property.TryGetAttribute<IsNumericAttribute>(out var isNumeric))
                {
                    bag = new NumericPropertyBag(bag)
                    {
                        NumberOfDecimals = property.TryGetAttribute<DecimalCountAttribute>(out var decimalCount) ? decimalCount.Number : 0,
                        AutoIncrementStep = property.TryGetAttribute<AutoIncrementAttribute>(out var autoIncrement) ? autoIncrement.Step : 0,
                        Range = property.TryGetAttribute<RangeAttribute>(out var range) ? (range.Min, range.Max) : (0, 0)
                    };
                }
                else
                {
                    bag = new StringPropertyBag(bag)
                    {
                        Multiline = property.TryGetAttribute<MultilineAttribute>(out var multiline),
                        Length = property.TryGetAttribute<StringLengthAttribute>(out var length) ? length.Count : 0
                    };
                }
            }

            if (propertyType.Equals(typeof(string)))
            {
                

                if (property.TryGetAttribute<IsSuggestionsEnabledAttribute>(out var isSuggestion))
                {
                    bag = new AutoSuggestionPropertyBag(bag)
                    {
                        CollectionSourcePropertyName = isSuggestion.CollectionBindingDisplayName,
                        CollectionName = isSuggestion.CollectionName
                    };
                }
                else
                {
                    bag = new StringPropertyBag(bag)
                    {
                        Multiline = property.TryGetAttribute<MultilineAttribute>(out var multiline),
                        Length = property.TryGetAttribute<StringLengthAttribute>(out var length) ? length.Count : 0
                    };
                    //TODO: As a regular string
                }
                 

            }

            if (propertyType.Equals(typeof(float)) ||
               propertyType.Equals(typeof(decimal)) ||
               propertyType.Equals(typeof(double)) ||
               propertyType.Equals(typeof(double?)) ||
               propertyType.Equals(typeof(decimal?)) ||
               propertyType.Equals(typeof(float?))

           )
            {
                bag = new NumericPropertyBag(bag)
                {
                    NumberOfDecimals = property.TryGetAttribute<DecimalCountAttribute>(out var decimalCount) ? decimalCount.Number : 0,
                    AutoIncrementStep = property.TryGetAttribute<AutoIncrementAttribute>(out var autoIncrement) ? autoIncrement.Step : 0,
                    Range = property.TryGetAttribute<RangeAttribute>(out var range) ? (range.Min, range.Max) : (0, 0)
                };
            }

            var tColl = typeof(ICollection<>);
            if (propertyType.GetTypeInfo().IsGenericType && tColl.IsAssignableFrom(propertyType.GetGenericTypeDefinition()) ||
                propertyType.GetInterfaces().Any(x => x.GetTypeInfo().IsGenericType && x.GetGenericTypeDefinition() == tColl))
            {
                bag = new CollectionPropertyBag(bag)
                {
                    DisplayMemberPath = property.TryGetAttribute<DisplayMemberPathCollectionAttribute>(out var displayMember) ? displayMember.DisplayMemberPath : null,
                    SelectedItemPath = property.TryGetAttribute<SelectedItemCollectionAttribute>(out var selected) ? selected.PropertyNameToBind : null
                };
            }

            if (propertyType.Equals(typeof(DateTime)) || propertyType.Equals(typeof(DateTime?)))
            {
                bag = new DateTimePropertyBag(bag);
            }

            if (propertyType.Equals(typeof(bool)) || propertyType.Equals(typeof(bool?)))
            {
                bag = new BooleanPropertyBag(bag);
            }

            if (propertyType.Equals(typeof(TimeSpan)) || propertyType.Equals(typeof(TimeSpan?)))
            {
                bag = new TimeSpanPropertyBag(bag)
                {
                    MinuteIncrement = property.TryGetAttribute<MinuteIncrementAttribute>(out var increment) ? increment.Number : 0,
                    ClockFormat = property.TryGetAttribute<ClockIdentifierAttribute>(out var format) ? format.ClockFormat : null
                };
            }

            return bag;
        }
    }
}
