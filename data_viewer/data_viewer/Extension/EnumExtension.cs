using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Resources;
using data_viewer.Model.Notification;

namespace data_viewer.Extension
{
    public class EnumType
    {
        public Group enumValue { get; set; }
        public string enumName { get; set; }
    }
    public class EnumExtension<T> where T : Enum
    {
        public T enumValue { get; }
        public string enumName { get; }

        private EnumExtension(T value, string name)
        {
            enumValue = value;
            enumName = name;
        }

        public static EnumExtension<T> GetEnumExtension(T value)
        {
            var enumType = typeof(T);
            var memberInfo = enumType.GetMember(value.ToString()).First();

            if (memberInfo == null || !memberInfo.CustomAttributes.Any())
                return new EnumExtension<T>(value, value.ToString());

            var displayAttribute = memberInfo.GetCustomAttribute<DisplayAttribute>();

            if (displayAttribute == null) return new EnumExtension<T>(value, value.ToString());

            if (displayAttribute.ResourceType != null && displayAttribute.Name != null)
            {
                var manager = new ResourceManager(displayAttribute.ResourceType);
                return new EnumExtension<T>(value, displayAttribute.Name);
            }
            return displayAttribute.Name != null ? new EnumExtension<T>(value, displayAttribute.Name) : new EnumExtension<T>(value, value.ToString());
        }

        public static List<EnumExtension<T>> GetEnumExtension(IList<T> values)
        {
            return values.Select(GetEnumExtension).ToList();
        }

        public static List<EnumExtension<T>> GetAllEnumExtension()
        {
            return (from T item in Enum.GetValues(typeof(T)) select GetEnumExtension(item)).ToList();
        }
    }
}