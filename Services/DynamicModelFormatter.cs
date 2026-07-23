using System;
using System.Reflection;
using System.Text;

namespace INFASS.Services
{
    public class DynamicModelFormatter
    {
        public static string FormatModelData<T>(T model)
        {
            if (model == null)
            {
                return "No data received.";
            }

            Type type = typeof(T);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Successfully received {type.Name} data:\n");

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                object? value = prop.GetValue(model, null);
                sb.AppendLine($"{prop.Name}: {value}");
            }

            return sb.ToString();
        }
    }
}
