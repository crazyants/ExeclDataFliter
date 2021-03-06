﻿//-----------------------------------------------------------------------
// <copyright file="ExcelTransferData.cs" company="LY.COM Enterprises">
// * Copyright (C) 2016 同程网络科技股份有限公司 版权所有。
// * author  : tzq24955
// * FileName: ExcelTransferData.cs
// * history : created by tzq24955 2016/8/4 17:01:34 
// </copyright>
//-----------------------------------------------------------------------

using NPOI.SS.UserModel;
using System.Data;
using System.IO;

namespace ExeclDataFliter.Bll
{
    public class ExcelTransferData : ITransferData
    {
        protected IWorkbook _workBook;

        public virtual Stream GetStream(DataTable table)
        {
            var sheet = _workBook.CreateSheet();
            if (table != null)
            {
                var rowCount = table.Rows.Count;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    var row = sheet.CreateRow(i);
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        var cell = row.CreateCell(j);
                        if (table.Rows[i][j] != null)
                        {
                            cell.SetCellValue(table.Rows[i][j].ToString());
                        }
                    }
                }
            }
            MemoryStream ms = new MemoryStream();
            _workBook.Write(ms);
            return ms;
        }

        public virtual DataTable GetData(Stream stream)
        {
            using (stream)
            {
                var sheet = _workBook.GetSheet("巡查明细");
                if (sheet == null)
                {
                    sheet = _workBook.GetSheetAt(0);
                }

                if (sheet != null)
                {
                    var headerRow = sheet.GetRow(0);
                    DataTable dt = new DataTable();
                    int columnCount = headerRow.Cells.Count;
                    var row = sheet.GetRowEnumerator();
                    int index = 0;
                    while (row.MoveNext())
                    {
                        var dtRow = dt.NewRow();
                        var excelRow = row.Current as IRow;
                        for (int i = 0; i < columnCount; i++)
                        {
                            var cell = excelRow.GetCell(i);
                            if (cell == null)
                            {
                                continue;
                            }

                            if (index == 0)
                            {
                                dt.Columns.Add(cell.StringCellValue);
                            }
                            else
                            {
                                if (cell != null)
                                {
                                    dtRow[i] = GetValue(cell);
                                }
                            }

                        }

                        if (index > 0)
                        {
                            dt.Rows.Add(dtRow);
                        }

                        index++;
                    }
                    return dt;
                }
            }

            return null;
        }


        private object GetValue(ICell cell)
        {
            object value = null;
            switch (cell.CellType)
            {
                case CellType.Blank:
                    break;
                case CellType.Boolean:
                    value = cell.BooleanCellValue ? "1" : "0"; break;
                case CellType.Error:
                    value = cell.ErrorCellValue; break;
                case CellType.Formula:
                    value = "=" + cell.CellFormula; break;
                case CellType.Numeric:
                    value = cell.NumericCellValue.ToString(); break;
                case CellType.String:
                    value = cell.StringCellValue; break;
                case CellType.Unknown:
                    break;
            }
            return value;
        }

    }
}

