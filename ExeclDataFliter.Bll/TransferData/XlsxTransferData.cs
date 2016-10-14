//-----------------------------------------------------------------------
// <copyright file="XlsxTransferData.cs" company="LY.COM Enterprises">
// * Copyright (C) 2016 同程网络科技股份有限公司 版权所有。
// * author  : tzq24955
// * FileName: XlsxTransferData.cs
// * history : created by tzq24955 2016/8/4 17:04:33 
// </copyright>
//-----------------------------------------------------------------------

using NPOI.XSSF.UserModel;
using System.Data;
using System.IO;

namespace ExeclDataFliter.Bll
{
    public class XlsxTransferData : ExcelTransferData
    {
        public override Stream GetStream(DataTable table)
        {
            base._workBook = new XSSFWorkbook();
            return base.GetStream(table);
        }

        public override DataTable GetData(Stream stream)
        {
            base._workBook = new XSSFWorkbook(stream);
            return base.GetData(stream);
        }
    }
}
