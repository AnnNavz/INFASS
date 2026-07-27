using System;
using System.Reflection;

namespace INFASS.Services
{
    public class DynamicInsert
    {
        public static string FormatModelData<T>(T model)
        {
            if (model == null)
            {
                return "No data received.";
            }

            Type type = typeof(T);
            string tableName = type.Name;

            PropertyInfo[] properties = type.GetProperties();

            string columnNames = "";
            string columnValues = "";

            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo prop = properties[i];
                object? value = prop.GetValue(model, null);

                columnNames = columnNames + prop.Name;

                if (value == null)
                {
                    columnValues = columnValues + "NULL";
                }
                else
                {
                    Type valueType = value.GetType();

                    if (valueType == typeof(string) || valueType == typeof(DateTime) || valueType == typeof(Guid))
                    {
                        string strValue = value.ToString();

                        string formattedString = "'";

                        for (int j = 0; j < strValue.Length; j++)
                        {
                            char c = strValue[j];
                            if (c == '\'')
                            {
                                formattedString = formattedString + "''";
                            }
                            else
                            {
                                formattedString = formattedString + c;
                            }
                        }

                        formattedString = formattedString + "'";
                        columnValues = columnValues + formattedString;
                    }

                    else if (valueType == typeof(bool))
                    {
                        bool boolValue = (bool)value;
                        if (boolValue == true)
                        {
                            columnValues = columnValues + "1";
                        }
                        else
                        {
                            columnValues = columnValues + "0";
                        }
                    }

                    else if (valueType == typeof(decimal) || valueType == typeof(double) || valueType == typeof(float))
                    {
                        string numStr = value.ToString();
                        string formattedNum = "";

                        for (int k = 0; k < numStr.Length; k++)
                        {
                            char c = numStr[k];
                            if (c == ',')
                            {
                                formattedNum = formattedNum + ".";
                            }
                            else
                            {
                                formattedNum = formattedNum + c;
                            }
                        }

                        columnValues = columnValues + formattedNum;
                    }

                    else
                    {
                        columnValues = columnValues + value.ToString();
                    }
                }

                if (i < properties.Length - 1)
                {
                    columnNames = columnNames + ", ";
                    columnValues = columnValues + ", ";
                }
            }

            return "INSERT INTO " + tableName + " (" + columnNames + ") VALUES (" + columnValues + ");";
        }
    }
}