using System;

namespace ExeclDataFliter.Util
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class DataFieldAttribute : Attribute
    {
        /// <summary>
        /// 表对应的字段名
        /// </summary>
        public string ColumnName { set; get; }

        public DataFieldAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
}
