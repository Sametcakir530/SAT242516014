using System;
using System.ComponentModel;
using System.Reflection; // GetField için bu kütüphane gereklidir
namespace SAT242516014.Models.MyEnums
{
    public static class EnumExtensions
    {
        public static string Description<T>(this T value)
        {
            var result = value.ToString();
            try
            {
                var fi = value.GetType().GetField(value.ToString());
                if (fi != null)
                {
                    var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    result = attributes != null && attributes.Length > 0 ? attributes[0].Description : value.ToString();
                }
            }
            catch (Exception) { }
            return result;
        }
    }
}