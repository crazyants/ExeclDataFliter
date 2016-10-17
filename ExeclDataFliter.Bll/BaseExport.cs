//-----------------------------------------------------------------------
// <copyright file="BaseExport.cs" company="LY.COM Enterprises">
// * Copyright (C) 2016 同程网络科技股份有限公司 版权所有。
// * author  : tzq24955
// * FileName: BaseExport.cs
// * history : created by tzq24955 2016/10/14 16:28:00 
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExeclDataFliter.Bll
{
    public abstract class BaseExport : IDisposable
    {
        /// <summary>
        /// 内存回收标识
        /// </summary>
        private bool disposed;

        /// <summary>
        /// 导出文件全路径
        /// </summary>
        private string filePath = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseExport(string filePath)
        {
            this.filePath = filePath;
            disposed = false;
        }


        /// <summary>
        /// 执行导出
        /// </summary>
        public void ExexcuteExport()
        {
            try
            {
                using (MemoryStream filestream = (MemoryStream)AanalysisReport())
                {
                    FileStream file = new FileStream(this.filePath, FileMode.Create);
                    filestream.WriteTo(file);
                    file.Flush();
                    file.Close();
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                disposed = true;
                Dispose();
            }
        }


        /// <summary>
        /// 解析报表数据到流
        /// </summary>
        public abstract Stream AanalysisReport();

        /// <summary>
        /// GC回收
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                }

                disposed = true;
            }
        }
    }
}
