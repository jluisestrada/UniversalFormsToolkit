using System.Linq;
using System.Reflection;
namespace AutoGenerateForm.Helpers
{
    public static class AttributeHelper
    {
        public static T GetAttribute<T>(this PropertyInfo property )
            where T: System.Attribute
        {

            var attribute = property.GetCustomAttributes<T>(false).Cast<T>().SingleOrDefault();

            return attribute;
        }

        public static bool TryGetAttribute<T>(this PropertyInfo property, out T attribute)
            where T : System.Attribute
        {

            attribute = property.GetCustomAttributes<T>(false).Cast<T>().SingleOrDefault();

            return attribute != null;
        }


    }
}