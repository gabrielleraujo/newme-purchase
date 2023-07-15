using System.ComponentModel;
using System.Reflection;

namespace Newme.Purchase.Domain.Extensions
{
    public static class EnumExtension
    {
        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}