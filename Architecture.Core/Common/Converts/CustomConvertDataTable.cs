using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Core.Common.Converts
{
    public static class CustomConvertDataTable
    {
        public static List<T> ConvertDataTableToList<T>(DataTable dt)
        {
            List<T> data = new List<T>();

            foreach (DataRow row in dt.Rows)
            {
                T item = ConvertDataTableToObject<T>(row);
                data.Add(item);
            }

            return data;
        }

        public static T ConvertDataTableToObject<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (!dr.IsNull(column.ColumnName) && pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }

            return obj;
        }
    }
}
