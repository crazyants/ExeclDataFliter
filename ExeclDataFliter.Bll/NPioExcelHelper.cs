using ExeclDataFliter.Model;
using ExeclDataFliter.Util;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ExeclDataFliter.Bll
{
    public class NPioExcelHelper : IDisposable
    {
        private string fileName = null; //文件名
        private IWorkbook workbook = null;
        private FileStream fs = null;
        private bool disposed;

        /// <summary>
        /// 显示页面信息委托
        /// </summary>
        private Action<string> showMsgHandler = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public NPioExcelHelper()
        {
            disposed = false;
        }

        /// <summary>
        /// 将DataTable数据导入到excel中
        /// </summary>
        /// <param name="data">要导入的数据</param>
        /// <param name="isColumnWritten">DataTable的列名是否要导入</param>
        /// <param name="sheetName">要导入的excel的sheet的名称</param>
        /// <returns>导入数据行数(包含列名那一行)</returns>
        public int DataTableToExcel(DataTable data, string sheetName, bool isColumnWritten)
        {
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;

            fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                workbook = new XSSFWorkbook();
            else if (fileName.IndexOf(".xls") > 0) // 2003版本
                workbook = new HSSFWorkbook();

            try
            {
                if (workbook != null)
                {
                    sheet = workbook.CreateSheet(sheetName);
                }
                else
                {
                    return -1;
                }

                if (isColumnWritten == true) //写入DataTable的列名
                {
                    IRow row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }
                    count = 1;
                }
                else
                {
                    count = 0;
                }

                for (i = 0; i < data.Rows.Count; ++i)
                {
                    IRow row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }
                    ++count;
                }
                workbook.Write(fs); //写入到excel
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// 将excel中的数据导入到DataTable中
        /// </summary>
        /// <param name="sheetName">excel工作薄sheet的名称</param>
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>
        /// <returns>返回的DataTable</returns>
        public DataTable ExcelToDataTable(string sheetName, bool isFirstRowColumn)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0) // 2007版本
                    workbook = new XSSFWorkbook(fs);

                else if (fileName.IndexOf(".xls") > 0) // 2003版本
                    workbook = new HSSFWorkbook(fs);

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 根据model转excel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modellist"></param>
        /// <returns></returns>
        public void FliterData<T>(IList<T> modellist, string strExcelFileName)
        {
            XSSFWorkbook book = new XSSFWorkbook();
            //添加一个sheet
            ISheet sheet1 = book.CreateSheet("Sheet1");
            //获取list数据
            //给sheet1添加第一行的头部标题
            IRow row1 = sheet1.CreateRow(0);

            Type type1 = typeof(T);

            System.Reflection.PropertyInfo[] ps = type1.GetProperties();
            if (ps != null && ps.Length > 0)
            {
                for (int i = 0; i < ps.Length; i++)
                {
                    var des = ((DataFieldAttribute)Attribute.GetCustomAttribute(ps[i], typeof(DataFieldAttribute))).ColumnName;
                    row1.CreateCell(i).SetCellValue(des);
                }
            }
            ////将数据逐步写入sheet1各个行
            for (int i = 0; i < modellist.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 1);
                for (int j = 0; j < ps.Length; j++)
                {
                    var des = ((DataFieldAttribute)Attribute.GetCustomAttribute(ps[j], typeof(DataFieldAttribute))).ColumnName;
                    var value = GetValueByDes(modellist[i], ps, des);
                    string cellvalue = string.Empty;
                    if (ps[j].PropertyType == typeof(DateTime))
                    {
                        cellvalue = Convert.ToDateTime(value).ToString("yyyy-MM-dd HH:mm:ss");
                    }

                    else if (ps[j].PropertyType == typeof(decimal))
                    {
                        cellvalue = Math.Round(Convert.ToDecimal(value), 2).ToString();

                    }
                    else
                    {
                        if (null == value)
                        {
                            cellvalue = string.Empty;
                        }
                        else
                        {
                            cellvalue = value.ToString();
                        }
                    }

                    rowtemp.CreateCell(j).SetCellValue(cellvalue);
                }
            }
            //写Excel
            FileStream file = new FileStream(strExcelFileName, FileMode.OpenOrCreate);
            book.Write(file);
            file.Flush();
            file.Close();
        }

        /// <summary>
        /// 通过反射获取model指定字段的值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="model">数据实体</param>
        /// <param name="propertyInfo">属性</param>
        /// <param name="description">描述</param>
        /// <returns></returns>
        private object GetValueByDes<T>(T model, PropertyInfo[] propertyInfo, string description)
        {
            Type modetype = typeof(T);
            object value = null;
            for (int j = 0; j < propertyInfo.Length; j++)
            {
                string des = ((DataFieldAttribute)Attribute.GetCustomAttribute(propertyInfo[j], typeof(DataFieldAttribute))).ColumnName;
                if (des == description)
                {
                    var propInfo = modetype.GetProperty(propertyInfo[j].Name);
                    value = propInfo.GetValue(model, null);
                    break;
                }
            }

            return value;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (fs != null)
                        fs.Close();
                }

                fs = null;
                disposed = true;
            }
        }
    }
}
