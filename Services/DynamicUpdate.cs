using System.Reflection;

namespace INFASS.Services
{
    public class DynamicUpdate
    {
        public static string FormatUpdateData<T>(T model)
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

            string setClause = "";

            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo prop = properties[i];
                string propName = prop.Name;
                object? value = prop.GetValue(model, null);

                bool isId = false;

                if (propName == "Id" || propName == "id" || propName == "ID")
                {
                    isId = true;
                }
                else if (propName.Length > 2)
                {
                    int len = propName.Length;
                    char last = propName[len - 1];
                    char secondLast = propName[len - 2];

                    if ((secondLast == 'I' || secondLast == 'i') && (last == 'd' || last == 'D'))
                    {
                        isId = true;
                    }
                }

                if (isId == true)
                {
                    idColumnName = propName;
                    idValue = value;
                }
                else
                {
                    if (setClause != "")
                    {
                        setClause = setClause + ", ";
                    }

                    if (value == null)
                    {
                        setClause = setClause + propName + " = NULL";
                    }
                    else
                    {
                        Type valueType = value.GetType();

                        if (valueType == typeof(string) || valueType == typeof(DateTime) || valueType == typeof(Guid))
                        {
                            string strValue = value.ToString();
                            string escapedString = "'";

                            for (int j = 0; j < strValue.Length; j++)
                            {
                                char c = strValue[j];
                                if (c == '\'')
                                {
                                    escapedString = escapedString + "''";
                                }
                                else
                                {
                                    escapedString = escapedString + c;
                                }
                            }

                            escapedString = escapedString + "'";
                            setClause = setClause + propName + " = " + escapedString;
                        }

                        else if (valueType == typeof(bool))
                        {
                            bool boolValue = (bool)value;
                            if (boolValue == true)
                            {
                                setClause = setClause + propName + " = 1";
                            }
                            else
                            {
                                setClause = setClause + propName + " = 0";
                            }
                        }
                        else
                        {
                            setClause = setClause + propName + " = " + value.ToString();
                        }
                    }
                }
            }

            if (idColumnName == "" || idValue == null)
            {
                return "No valid ID property found to update.";
            }

            return "UPDATE " + tableName + " SET " + setClause + " WHERE " + idColumnName + " = " + idValue.ToString() + ";";
        }
    }
}


