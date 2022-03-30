using System.Data;
using System.Reflection;

namespace DotnetAngular.Utilities
{
    public static class DataTableUtility
    {
        public static IEnumerable<T> ConvertToModel<T>(DataTable dt, object mapValue = null)
        {
            IList<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row, mapValue);
                data.Add(item);
            }

            return data;
        }

        private static T GetItem<T>(DataRow dr, object mapValue = null)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo property in temp.GetProperties())
                {
                    if (mapValue != null)
                    {
                        var mapValuePro = Convert.ToString(mapValue.GetType().GetProperty(property.Name).GetValue(mapValue));

                        if (mapValuePro == column.ColumnName && property.PropertyType.Name == "String")
                        {
                            var value = Convert.ToString(dr[column.ColumnName]);
                            property.SetValue(obj, value, null);
                        }
                    }
                    else
                    {
                        if (property.Name == column.ColumnName && property.PropertyType.Name == "String")
                        {
                            var value = Convert.ToString(dr[column.ColumnName]);
                            property.SetValue(obj, value, null);
                        }
                    }
                }
            }

            return obj;
        }
    }

}
