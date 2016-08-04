//-----------------------------------------------------------------------
// <copyright file="TransferDataFactory.cs" company="LY.COM Enterprises">
// * Copyright (C) 2016 同程网络科技股份有限公司 版权所有。
// * author  : tzq24955
// * FileName: TransferDataFactory.cs
// * history : created by tzq24955 2016/8/4 17:05:44 
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeclDataFliter.Bll
{
    public class TransferDataFactory
    {
        public static ITransferData GetUtil(string fileName)
        {
            var array = fileName.Split('.');
            var dataType = (DataFileType)Enum.Parse(typeof(DataFileType), array[array.Length - 1], true);
            return GetUtil(dataType);
        }

        public static ITransferData GetUtil(DataFileType dataType)
        {
            switch (dataType)
            {
                case DataFileType.CSV: return new CsvTransferData();
                case DataFileType.XLS: return new XlsTransferData();
                case DataFileType.XLSX: return new XlsxTransferData();
                default: return new CsvTransferData();
            }
        }
    }
}
