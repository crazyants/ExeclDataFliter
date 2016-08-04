using ExeclDataFliter.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeclDataFliter.Model
{
    /// <summary>
    ///  机票销售数据
    /// </summary>
    [Serializable]
    public class MFlightSeal
    {

        /// <summary>
        /// 创建日期
        /// </summary>
        [DataField("创建日期")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        [DataField("供应商")]
        public string MerchantName { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        [DataField("支付方式")]
        public string PayType { get; set; }

        /// <summary>
        /// 航空公司
        /// </summary>
        [DataField("航空公司")]
        public string AirCompany { get; set; }

        /// <summary>
        /// 舱位
        /// </summary>
        [DataField("舱位")]
        public string Cabin { get; set; }

        /// <summary>
        /// 出发三字码
        /// </summary>
        [DataField("出发三字码")]
        public string FlightStartCode { get; set; }

        /// <summary>
        /// 到达三字码
        /// </summary>
        [DataField("到达三字码")]
        public string FlightEndCode { get; set; }


        /// <summary>
        /// 出发城市
        /// </summary>
        [DataField("航线")]
        public string FlightLine { get; set; }

        /// <summary>
        /// 出发城市
        /// </summary>
        [DataField("起始地1")]
        public string FlightStartName { get; set; }


        /// <summary>
        /// 到达城市
        /// </summary>
        [DataField("抵达地1")]
        public string FlightEndName { get; set; }

        /// <summary>
        /// 航段数
        /// </summary>
        [DataField("航段数")]
        public int SegmentCount { get; set; }

        /// <summary>
        /// 系统票价
        /// </summary>
        [DataField("系统票价")]
        public decimal SystemPrice { get; set; }

        /// <summary>
        /// 政策类型
        /// </summary>
        [DataField("政策类型")]
        public string PolicyType { get; set; }

        /// <summary>
        /// 分众基础产品
        /// </summary>
        [DataField("分众基础产品")]
        public string ProductName { get; set; }

        /// <summary>
        /// 子渠道名称
        /// </summary>
        [DataField("子渠道名称")]
        public string ChannelName { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        [DataField("订单状态")]
        public string OrderType
        {
            get;
            set;
        }

        /// <summary>
        /// 航班号
        /// </summary>
        [DataField("航班号")]
        public string FlightNo
        {
            get;
            set;
        }
    }
}
