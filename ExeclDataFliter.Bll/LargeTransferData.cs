//-----------------------------------------------------------------------
// <copyright file="LargeTransferData.cs" company="LY.COM Enterprises">
// * Copyright (C) 2016 同程网络科技股份有限公司 版权所有。
// * author  : tzq24955
// * FileName: LargeTransferData.cs
// * history : created by tzq24955 2016/8/5 14:25:20 
// </copyright>
//-----------------------------------------------------------------------

using Amib.Threading;
using ExeclDataFliter.Util;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ExeclDataFliter.Bll
{
    public class LargeTransferData<T> where T : new()
    {
        /// <summary>
        /// 数据集合
        /// </summary>
        private List<T> dataList = new List<T>();

        /// <summary>
        /// 静态锁
        /// </summary>
        private static object lockobject = new object();

        /// <summary>
        /// 构造函数
        /// </summary>
        public LargeTransferData()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        public void ToListThread(DataTable dt)
        {
            DataList = new List<T>(dt.Rows.Count);
            int pagesize = 500;
            int threadCount = dt.Rows.Count / pagesize;
            threadCount = dt.Rows.Count % pagesize > 0 ? threadCount + 1 : threadCount;

            SmartThreadPool smartThreadPool = new SmartThreadPool();
            for (int i = 0; i < threadCount; i++)
            {
                var query = dt.AsEnumerable().Skip(i * pagesize).Take(pagesize);
                smartThreadPool.QueueWorkItem(ToList, query.ToArray());
            }
            smartThreadPool.WaitForIdle();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datarows"></param>
        private void ToList(DataRow[] datarows)
        {
            List<T> list = new List<T>(datarows.Length);

            for (int i = 0; i < datarows.Length; i++)
            {
                list.Add(DataConvert<T>.ToEntity(datarows[i]));
            }

            if (list != null && list.Count > 0)
            {
                lock (lockobject)
                {
                    DataList.AddRange(list);
                }
            }
        }

        /// <summary>
        /// 数据集合
        /// </summary>
        public List<T> DataList
        {
            get
            {
                return dataList;
            }

            set
            {
                dataList = value;
            }
        }
    }
}
