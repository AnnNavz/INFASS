using System.Reflection;

namespace INFASS.Services
{
    public class DynamicDelete
    {
        public static string FormatDeleteData<T>(T model)
        {
            if (model == null)
            {
                return "No data received.";
            }

            Type type = typeof(T);
            string tableName = type.Name;

            PropertyInfo[] properties = type.GetProperties();

            string idColumnName = "";
            object? idValue = null;

            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo prop = properties[i];
                string propName = prop.Name;

                if (propName == "Id" || propName == "id" || propName == "ID")
                {
                    idColumnName = propName;
                    idValue = prop.GetValue(model, null);
                    break;
                }
            }

            if (idColumnName == "" || idValue == null)
            {
                return "No valid ID found.";
            }

            return "DELETE FROM " + tableName + " WHERE " + idColumnName + " = " + idValue.ToString() + ";";
        }
    }
}
