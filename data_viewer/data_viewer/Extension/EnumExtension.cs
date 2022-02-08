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
        public Group EnumValue { get; set; }
        public string EnumName { get; set; }
    }
    public class EnumExtension<T> where T : Enum
    {
        public T EnumValue { get; set; }
        public string EnumName { get; set; }

        public EnumExtension(T value, String name)
        {
            this.EnumValue = value;
            this.EnumName = name;
        }

        public static EnumExtension<T> getEnumExtension(T value)
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

        public static List<EnumExtension<T>> getEnumExtension(IList<T> values)
        {
            List<EnumExtension<T>> enumExtendedList = new ();
            foreach (T item in values)
                enumExtendedList.Add(getEnumExtension(item));
            return enumExtendedList;
        }

        public static List<EnumExtension<T>> getAllEnumExtension()
        {
            List<EnumExtension<T>> enumExtendedList = new ();
            foreach (T item in Enum.GetValues(typeof(T)))
                enumExtendedList.Add(getEnumExtension(item));
            return enumExtendedList;
        }
    }
}