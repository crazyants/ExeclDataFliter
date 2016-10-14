﻿using System;

namespace ExeclDataFliter.Bll
{
    public class ShowAction
    {
        /// <summary>
        /// 通知页面显示的事件
        /// </summary>
        public static event Action<string> ShowMsgEvent = null;

        /// <summary>
        /// 需要显示页面的方法
        /// </summary>
        /// <param name="msg">显示信息</param>
        public static void ShowMsg(string msg)
        {
            ShowMsgEvent(msg);
        }
    }
}
