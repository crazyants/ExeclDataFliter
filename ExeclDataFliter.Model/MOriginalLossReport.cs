using ExeclDataFliter.Util;
using System;

namespace ExeclDataFliter.Model
{
    [Serializable]
    public class MOriginalLossReport
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
        public decimal ETCBasePrice
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
        /// 航线类型
        /// </summary>
        [DataField("航线类型")]
        public string FlightLineType
        {
            get;
            set;
        }

        /// <summary>
        /// 航线类型
        /// </summary>
        [DataField("航线")]
        public string FlightLine
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
        /// 航线类型
        /// </summary>
        [DataField("航线1")]
        public string FlightLine1
        {
            get;
            set;
        }

        /// <summary>
        /// 起始地
        /// </summary>
        [DataField("起始地1")]
        public string StartAirPort1
        {
            get;
            set;
        }
        /// <summary>
        /// 抵达地
        /// </summary>
        [DataField("抵达地1")]
        public string ArriveAirPort1
        {
            get;
            set;
        }

        /// <summary>
        /// Y
        /// </summary>
        [DataField("Y")]
        public decimal YRatio
        {
            get;
            set;
        }

        /// <summary>
        /// Z
        /// </summary>
        [DataField("Z")]
        public decimal ZRatio
        {
            get;
            set;
        }

        /// <summary>
        /// Y裸价
        /// </summary>
        [DataField("Y裸价")]
        public decimal YLuoPrice
        {
            get;
            set;
        }

        /// <summary>
        /// Z裸价
        /// </summary>
        [DataField("Z裸价")]
        public decimal ZLuoPrice
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

        /// <summary>
        /// 直减金额
        /// </summary>
        [DataField("直减金额")]
        public decimal zhijianPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 保险规则
        /// </summary>
        [DataField("保险规则")]
        public string BaoxianRule
        {
            get;
            set;
        }

        /// <summary>
        /// 产品类型
        /// </summary>
        [DataField("产品类型")]
        public string ProductType
        {
            get;
            set;
        }

        /// <summary>
        /// 订单类型
        /// </summary>
        [DataField("订单类型")]
        public string OrderType
        {
            get;
            set;
        }
        /// <summary>
        /// TCFlat
        /// </summary>
        [DataField("TCFlat")]
        public string TCFlat
        {
            get;
            set;
        }
        /// <summary>
        /// IsTCOutOrder
        /// </summary>
        [DataField("IsTCOutOrder")]
        public string IsTCOutOrder
        {
            get;
            set;
        }

        /// <summary>
        /// TCAllianceID
        /// </summary>
        [DataField("TCAllianceID")]
        public string TCAllianceID
        {
            get;
            set;
        }
        /// <summary>
        /// 电子客票号基建费
        /// </summary>
        [DataField("电子客票号基建费")]
        public string ETCJijianPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 电子客票号燃油费
        /// </summary>
        [DataField("电子客票号燃油费")]
        public decimal ETCOilPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 行程单
        /// </summary>
        [DataField("行程单")]
        public string Xinchengdan
        {
            get;
            set;
        }
        /// <summary>
        /// 是否绑定保险
        /// </summary>
        [DataField("是否绑定保险")]
        public string IsBangdingInsurance
        {
            get;
            set;
        }
        /// <summary>
        /// 应返红包
        /// </summary>
        [DataField("应返红包")]
        public decimal ShouldBackRedPackage
        {
            get;
            set;
        }

        /// <summary>
        /// 大编码
        /// </summary>
        [DataField("大编码")]
        public string BigPNR
        {
            get;
            set;
        }
        /// <summary>
        /// 搜索类型
        /// </summary>
        [DataField("搜索类型")]
        public string SearchType
        {
            get;
            set;
        }
        /// <summary>
        /// 渠道
        /// </summary>
        [DataField("渠道")]
        public string Channel
        {
            get;
            set;
        }
        /// <summary>
        /// 同程裸价
        /// </summary>
        [DataField("同程裸价")]
        public decimal TcLouPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 获得同程里程
        /// </summary>
        [DataField("获得同程里程")]
        public int TcLicheng
        {
            get;
            set;
        }
        /// <summary>
        /// 25险总份数
        /// </summary>
        [DataField("25险总份数")]
        public int Insurance25Count
        {
            get;
            set;
        }
        /// <summary>
        /// 25险总金额
        /// </summary>
        [DataField("25险总金额")]
        public decimal Insurance25TotalAmount
        {
            get;
            set;
        }
        /// <summary>
        /// 是否共享航班
        /// </summary>
        [DataField("是否共享航班")]
        public string IsShare
        {
            get;
            set;
        }
        /// <summary>
        /// 承运航班号
        /// </summary>
        [DataField("承运航班号")]
        public string RealFlightNo
        {
            get;
            set;
        }
        /// <summary>
        /// 出票时长
        /// </summary>
        [DataField("出票时长")]
        public string TakeOutTime
        {
            get;
            set;
        }
        /// <summary>
        /// 出票参考时长
        /// </summary>
        [DataField("出票参考时长")]
        public string ShouldTakeOutTime
        {
            get;
            set;
        }
        /// <summary>
        /// 贵宾厅价格
        /// </summary>
        [DataField("贵宾厅价格")]
        public string GuiBingtingPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 退改无忧价格
        /// </summary>
        [DataField("退改无忧价格")]
        public decimal TuigaiwuyouPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 产品规则直减金额
        /// </summary>
        [DataField("产品规则直减金额")]
        public decimal ProductZhijianPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 产品规则直减比例
        /// </summary>
        [DataField("产品规则直减比例")]
        public decimal ProductZhijianRatio
        {
            get;
            set;
        }
        /// <summary>
        /// 冻结金额
        /// </summary>
        [DataField("冻结金额")]
        public decimal FrozenPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 冻结比例
        /// </summary>
        [DataField("冻结比例")]
        public decimal FrozenRatio
        {
            get;
            set;
        }
        /// <summary>
        /// 返点类型
        /// </summary>
        [DataField("返点类型")]
        public string BackRatioType
        {
            get;
            set;
        }
    }
}
