using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace ExeclDataFliter.Util
{
    public static class DataConvert<T> where T : new()
    {
        /// <summary>
        /// 将DataRow行转换成Entity
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static T ToEntity(DataRow dr)
        {
            T entity = new T();
            Type info = typeof(T);
            var members = info.GetMembers();
            foreach (var mi in members)
            {
                if (mi.MemberType == MemberTypes.Property)
                {
                    //读取属性上的DataField特性
                    object[] attributes = mi.GetCustomAttributes(typeof(DataFieldAttribute), true);
                    foreach (var attr in attributes)
                    {
                        var dataFieldAttr = attr as DataFieldAttribute;
                        if (dataFieldAttr != null)
                        {
                            var propInfo = info.GetProperty(mi.Name);
                            if (dr.Table.Columns.Contains(dataFieldAttr.ColumnName))
                            {
                                //根据ColumnName，将dr中的相对字段赋值给Entity属性
                                if (dr[dataFieldAttr.ColumnName].ToString() == dataFieldAttr.ColumnName)
                                {
                                    // 这行应该是标题
                                    string title = dr[dataFieldAttr.ColumnName].ToString();
                                }
                                else
                                {
                                    if (dr[dataFieldAttr.ColumnName] != DBNull.Value)
                                    {
                                        propInfo.SetValue(entity, Convert.ChangeType(dr[dataFieldAttr.ColumnName], propInfo.PropertyType), null);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return entity;
        }

        /// <summary>
        /// 将DataTable转换成Entity列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ToList(DataTable dt)
        {
            List<T> list = new List<T>(dt.Rows.Count);

            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                list.Add(ToEntity(dt.Rows[i]));
            }

            return list;
        }
    }
}
