using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HandApiTest.Utilities
{
    public static class CommaDelimitedPrinter
    {
        public static string PrintObject<T>(T obj)
        {
            Type objType = typeof(T);
            PropertyInfo[] properties = objType.GetProperties();

            StringBuilder sb = new StringBuilder();

            foreach (PropertyInfo property in properties)
            {
                sb.Append($"\"{property.GetValue(obj)}\",");
            }

            return sb.ToString();
        }

        public static string PrintNestedObject<T>(T obj)
        {
            Type objType = typeof(T);
            PropertyInfo[] properties = objType.GetProperties();

            StringBuilder sb = new StringBuilder();

            foreach (PropertyInfo property in properties)
            {
                dynamic propertyValue = property.GetValue(obj);

                if (property.PropertyType != typeof(string) && propertyValue != null)
                {
                    string nestedObjectPrint = PrintNestedObject(propertyValue);
                    sb.Append($"{nestedObjectPrint},");
                }
                else
                {
                    sb.Append($"\"{propertyValue}\",");
                }
            }

            return sb.ToString().TrimEnd(',', ' ');
        }
    }
}

