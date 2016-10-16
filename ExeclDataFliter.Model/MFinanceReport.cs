using ExeclDataFliter.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExeclDataFliter.Model
{
    /// <summary>
    /// 财务报表
    /// </summary>
    public class MFinanceReport
    {
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
        /// 实收总额 对应 PayAirCompanyPrice
        /// </summary>
        [DataField("实收总额")]
        public decimal RealIncome
        {
            get;
            set;
        }

        /// <summary>
        /// 实付总额
        /// </summary>
        [DataField("实付总额")]
        public decimal RealPay
        {
            get;
            set;
        }


        /// <summary>
        /// 机票款
        /// </summary>
        [DataField("机票款")]
        public decimal FlightPrice
        {
            get;
            set;
        }

        /// <summary>
        /// 邮寄费
        /// </summary>
        [DataField("邮寄费")]
        public decimal MailPrice
        {
            get;
            set;
        }

        /// <summary>
        /// 保费
        /// </summary>
        [DataField("保费")]
        public decimal InsurancePrice
        {
            get;
            set;
        }

        /// <summary>
        /// 辅营利润
        /// </summary>
        [DataField("辅营利润")]
        public decimal ExtraProfit
        {
            get;
            set;
        }

        /// <summary>
        /// 航信价
        /// </summary>
        [DataField("航信价")]
        public decimal SystemPrice
        {
            get;
            set;
        }

        /// <summary>
        /// 机建费
        /// </summary>
        [DataField("机建费")]
        public decimal JijianPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 燃油税
        /// </summary>
        [DataField("燃油税")]
        public decimal OilPrice
        {
            get;
            set;
        }



        /// <summary>
        /// 机票供应商
        /// </summary>
        [DataField("机票供应商")]
        public string FlightSupplierPrice
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
        /// 销售渠道
        /// </summary>
        [DataField("销售渠道")]
        public string SealChannel
        {
            get;
            set;
        }

        /// <summary>
        /// 产品形态
        /// </summary>
        [DataField("产品形态")]
        public string ProductShape
        {
            get;
            set;
        }

        /// <summary>
        /// 航段
        /// </summary>
        [DataField("航段")]
        public string Segment
        {
            get;
            set;
        }

        /// <summary>
        /// 时间
        /// </summary>
        [DataField("时间")]
        public DateTime OrderTime
        {
            get;
            set;
        }
    }
}
