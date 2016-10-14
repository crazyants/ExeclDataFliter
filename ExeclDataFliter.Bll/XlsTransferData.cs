//-----------------------------------------------------------------------
// <copyright file="XlsTransferData.cs" company="LY.COM Enterprises">
// * Copyright (C) 2016 同程网络科技股份有限公司 版权所有。
// * author  : tzq24955
// * FileName: XlsTransferData.cs
// * history : created by tzq24955 2016/8/4 17:03:43 
// </copyright>
//-----------------------------------------------------------------------

using NPOI.HSSF.UserModel;
using System.Data;
using System.IO;

namespace ExeclDataFliter.Bll
{
    public class XlsTransferData : ExcelTransferData
    {
        public override Stream GetStream(DataTable table)
        {
            base._workBook = new HSSFWorkbook();
            return base.GetStream(table);
        }

        public override DataTable GetData(Stream stream)
        {
            base._workBook = new HSSFWorkbook(stream);
            return base.GetData(stream);
        }
    }
}
