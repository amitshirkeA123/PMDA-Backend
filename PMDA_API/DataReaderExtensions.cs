namespace PMDA_API
{
    using System.Reflection;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.Data.SqlClient;

    public static class DataReaderExtensions
    {
        public static T MapToObject<T>(this SqlDataReader reader) where T : new()
        {
            T obj = new T();
            Type type = typeof(T);

            foreach (PropertyInfo prop in type.GetProperties())
            {
                // Get column name from attribute or property name
                string columnName = prop.GetCustomAttribute<ColumnAttribute>()?.Name ?? prop.Name;

                int columnIndex;
                try
                {
                    columnIndex = reader.GetOrdinal(columnName);
                }
                catch (IndexOutOfRangeException)
                {
                    // Column not found, skipping
                    continue;
                }

                if (columnIndex >= 0 && !reader.IsDBNull(columnIndex))
                {
                    object value = reader.GetValue(columnIndex);

                    // Type conversion handling
                    if (prop.PropertyType == typeof(int))
                        value = Convert.ToInt32(value);
                    else if (prop.PropertyType == typeof(decimal))
                        value = Convert.ToDecimal(value);
                    else if (prop.PropertyType == typeof(double))
                        value = Convert.ToDouble(value);
                    else if (prop.PropertyType == typeof(TimeSpan))
                        value = (TimeSpan)value;
                    else if (prop.PropertyType == typeof(DateTime))
                        value = (DateTime)value;
                    else if (prop.PropertyType == typeof(bool))
                        value = Convert.ToBoolean(value);
                    else if (prop.PropertyType == typeof(string))
                        value = value.ToString();

                    prop.SetValue(obj, value);
                }
            }

            return obj;
        }
    }

}
