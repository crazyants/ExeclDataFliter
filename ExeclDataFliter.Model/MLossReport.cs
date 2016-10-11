using ExeclDataFliter.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExeclDataFliter.Model
{
    [Serializable]
    public class MLossReport
    {

        /// <summary>
        /// 创建日期
        /// </summary>
        [DataField("创建日期")]
        public string CreateTime
        {
            get;
            set;
        }
        /// <summary>
        /// 订单号
        /// </summary>
        [DataField("订单号")]
        public string OrderID
        {
            get;
            set;
        }
        /// <summary>
        /// 分众基础产品ID
        /// </summary>
        [DataField("分众基础产品ID")]
        public string ProductCode
        {
            get;
            set;
        }
        /// <summary>
        /// 比例
        /// </summary>
        [DataField("比例")]
        public float Ratio
        {
            get;
            set;
        }
        /// <summary>
        /// 起飞日期
        /// </summary>
        [DataField("起飞日期")]
        public string TakeoffDate
        {
            get;
            set;
        }
        /// <summary>
        /// 供应商
        /// </summary>
        [DataField("供应商")]
        public string Supplier
        {
            get;
            set;
        }
        /// <summary>
        /// 首次供应商
        /// </summary>
        [DataField("首次供应商")]
        public string FirstSupplier
        {
            get;
            set;
        }
        /// <summary>
        /// 航空公司
        /// </summary>
        [DataField("航空公司")]
        public string AirCompany
        {
            get;
            set;
        }
        /// <summary>
        /// 舱位
        /// </summary>
        [DataField("舱位")]
        public string CabinCode
        {
            get;
            set;
        }
        /// <summary>
        /// 起始地
        /// </summary>
        [DataField("起始地")]
        public string StartAirPort
        {
            get;
            set;
        }
        /// <summary>
        /// 抵达地
        /// </summary>
        [DataField("抵达地")]
        public string ArriveAirPort
        {
            get;
            set;
        }
        /// <summary>
        /// 系统票价
        /// </summary>
        [DataField("系统票价")]
        public decimal SystemPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 电子客票号票价
        /// </summary>
        [DataField("电子客票号票价")]
        public decimal BasePrice
        {
            get;
            set;
        }
        /// <summary>
        /// 基建
        /// </summary>
        [DataField("基建")]
        public decimal JijianPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 燃油
        /// </summary>
        [DataField("燃油")]
        public decimal OilPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 客户应付票价
        /// </summary>
        [DataField("客户应付票价")]
        public decimal ClientShouldPayTicketPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 首次应付供应商
        /// </summary>
        [DataField("首次应付供应商")]
        public decimal FirstShouldPaySupplierPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 实付航司金额
        /// </summary>
        [DataField("实付航司金额")]
        public decimal PayAirCompanyPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 实收客户
        /// </summary>
        [DataField("实收客户")]
        public decimal RealIncomeFromClientPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 实付供应商
        /// </summary>
        [DataField("实付供应商")]
        public decimal PaySupplierPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 保险金额
        /// </summary>
        [DataField("保险金额")]
        public decimal InsurancePrice
        {
            get;
            set;
        }
        /// <summary>
        /// 邮寄
        /// </summary>
        [DataField("邮寄")]
        public decimal MailPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 使用红包
        /// </summary>
        [DataField("使用红包")]
        public decimal RedPackagePrice
        {
            get;
            set;
        }
        /// <summary>
        /// 票价利润
        /// </summary>
        [DataField("票价利润")]
        public decimal OrderProfit
        {
            get;
            set;
        }
        /// <summary>
        /// 录入返点
        /// </summary>
        [DataField("录入返点")]
        public decimal InBackRatio
        {
            get;
            set;
        }
        /// <summary>
        /// 出票返点
        /// </summary>
        [DataField("出票返点")]
        public decimal OutBackRatio
        {
            get;
            set;
        }
        /// <summary>
        /// 返点差
        /// </summary>
        [DataField("返点差")]
        public decimal BackRatioDiff
        {
            get;
            set;
        }
        /// <summary>
        /// 最终亏损
        /// </summary>
        [DataField("最终亏损")]
        public decimal FinalLoss
        {
            get;
            set;
        }
        /// <summary>
        /// 供应商返点亏损
        /// </summary>
        [DataField("供应商返点亏损")]
        public decimal BackRatioLoss
        {
            get;
            set;
        }
        /// <summary>
        /// 供应商补差亏损
        /// </summary>
        [DataField("供应商补差亏损")]
        public decimal MakeupLoss
        {
            get;
            set;
        }
        /// <summary>
        /// 原始贴钱
        /// </summary>
        [DataField("原始贴钱")]
        public decimal StickMoney
        {
            get;
            set;
        }
        /// <summary>
        /// 客人实付
        /// </summary>
        [DataField("客人实付")]
        public decimal ClientRealPayPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 客人应付
        /// </summary>
        [DataField("客人应付")]
        public decimal ClientShouldPayPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 客人端亏损
        /// </summary>
        [DataField("客人端亏损")]
        public decimal ClientLoss
        {
            get;
            set;
        }
        /// <summary>
        /// 航线类型
        /// </summary>
        [DataField("航线类型")]
        public string FlightLine
        {
            get;
            set;
        }
        /// <summary>
        /// 航段数
        /// </summary>
        [DataField("航段数")]
        public int FlightLeg
        {
            get;
            set;
        }
        /// <summary>
        /// 成人航段数
        /// </summary>
        [DataField("成人航段数")]
        public int AdultFlightLeg
        {
            get;
            set;
        }
        /// <summary>
        /// 儿童航段数
        /// </summary>
        [DataField("儿童航段数")]
        public int ChildFlightLeg
        {
            get;
            set;
        }
        /// <summary>
        /// 婴儿航段
        /// </summary>
        [DataField("婴儿航段")]
        public int BabyFlightLeg
        {
            get;
            set;
        }
        /// <summary>
        /// 政策类型
        /// </summary>
        [DataField("政策类型")]
        public string PolicyType
        {
            get;
            set;
        }
        /// <summary>
        /// 渠道名称
        /// </summary>
        [DataField("渠道名称")]
        public string ChannelName
        {
            get;
            set;
        }
        /// <summary>
        /// 分众基础产品
        /// </summary>
        [DataField("分众基础产品")]
        public string FZProductName
        {
            get;
            set;
        }
        /// <summary>
        /// 分众产品形态
        /// </summary>
        [DataField("分众产品形态")]
        public string FZProductShape
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
        /// <summary>
        /// 订单状态
        /// </summary>
        [DataField("订单状态")]
        public string OrderStatus
        {
            get;
            set;
        }
        /// <summary>
        /// 支付方式
        /// </summary>
        [DataField("支付方式")]
        public string PayType
        {
            get;
            set;
        }
        /// <summary>
        /// 子渠道名称
        /// </summary>
        [DataField("子渠道名称")]
        public string SubChannel
        {
            get;
            set;
        }
        /// <summary>
        /// 舱位折扣
        /// </summary>
        [DataField("舱位折扣")]
        public string CabinRebate
        {
            get;
            set;
        }
        /// <summary>
        /// 会员ID
        /// </summary>
        [DataField("会员ID")]
        public string MemberID
        {
            get;
            set;
        }
        /// <summary>
        /// 小编码
        /// </summary>
        [DataField("小编码")]
        public string LittlePNR
        {
            get;
            set;
        }
        /// <summary>
        /// 黑屏解析系统价
        /// </summary>
        [DataField("黑屏解析系统价")]
        public string PATAPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 改签费
        /// </summary>
        [DataField("改签费")]
        public decimal TicketChangesPrice
        {
            get;
            set;
        }

        /// <summary>
        /// 抵扣金额
        /// </summary>
        [DataField("抵扣金额")]
        public decimal DeductiblePrice
        {
            get;
            set;
        }

    }

}
