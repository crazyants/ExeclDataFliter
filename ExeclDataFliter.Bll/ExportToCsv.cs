//-----------------------------------------------------------------------
// <copyright file="ExportToCsv.cs" company="LY.COM Enterprises">
// * Copyright (C) 2016 同程网络科技股份有限公司 版权所有。
// * author  : tzq24955
// * FileName: ExportToCsv.cs
// * history : created by tzq24955 2016/10/14 16:24:12 
// </copyright>
//-----------------------------------------------------------------------

using ExeclDataFliter.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExeclDataFliter.Bll
{
    public class ExportToCsv : BaseExport
    {
        /// <summary>
        /// 报表数据
        /// </summary>
        private List<MLossReport> modellist = null;

        /// <summary>
        /// 导出名称
        /// </summary>
        private string strExcelFileName = string.Empty;

        /// <summary>
        /// 构建函数
        /// </summary>
        public ExportToCsv(List<MLossReport> modellist, string strExcelFileName) : base(strExcelFileName)
        {
            this.modellist = modellist;
            this.strExcelFileName = strExcelFileName;
        }

        /// <summary>
        /// 导出报表
        /// </summary>
        /// <param name="modellist"></param>
        /// <param name="strExcelFileName"></param>
        public override Stream AanalysisReport()
        {
            ShowAction.ShowMsg(string.Format("开始生成报表数据{0}", strExcelFileName));
            MemoryStream stream = new MemoryStream(Encoding.GetEncoding("GB2312").GetBytes(AssembleReport()));
            ShowAction.ShowMsg(string.Format("生成报表数据{0}完成", strExcelFileName));
            return stream;
        }

        public string AssembleReport()
        {
            StringBuilder svcsb = new StringBuilder();
            svcsb.Append("\"").Append("创建日期").Append("\"").Append(",");
            svcsb.Append("\"").Append("订单号").Append("\"").Append(",");
            svcsb.Append("\"").Append("分众基础产品ID").Append("\"").Append(",");
            svcsb.Append("\"").Append("比例").Append("\"").Append(",");
            svcsb.Append("\"").Append("起飞日期").Append("\"").Append(",");
            svcsb.Append("\"").Append("供应商").Append("\"").Append(",");
            svcsb.Append("\"").Append("首次供应商").Append("\"").Append(",");
            svcsb.Append("\"").Append("航空公司").Append("\"").Append(",");
            svcsb.Append("\"").Append("舱位").Append("\"").Append(",");
            svcsb.Append("\"").Append("起始地").Append("\"").Append(",");
            svcsb.Append("\"").Append("抵达地").Append("\"").Append(",");
            svcsb.Append("\"").Append("系统票价").Append("\"").Append(",");
            svcsb.Append("\"").Append("电子客票号票价").Append("\"").Append(",");
            svcsb.Append("\"").Append("基建").Append("\"").Append(",");
            svcsb.Append("\"").Append("燃油").Append("\"").Append(",");
            svcsb.Append("\"").Append("客户应付票价").Append("\"").Append(",");
            svcsb.Append("\"").Append("首次应付供应商").Append("\"").Append(",");
            svcsb.Append("\"").Append("实付航司金额").Append("\"").Append(",");
            svcsb.Append("\"").Append("实收客户").Append("\"").Append(",");
            svcsb.Append("\"").Append("实付供应商").Append("\"").Append(",");
            svcsb.Append("\"").Append("保险金额").Append("\"").Append(",");
            svcsb.Append("\"").Append("邮寄").Append("\"").Append(",");
            svcsb.Append("\"").Append("使用红包").Append("\"").Append(",");
            svcsb.Append("\"").Append("票价利润").Append("\"").Append(",");
            svcsb.Append("\"").Append("录入返点").Append("\"").Append(",");
            svcsb.Append("\"").Append("出票返点").Append("\"").Append(",");
            svcsb.Append("\"").Append("返点差").Append("\"").Append(",");
            svcsb.Append("\"").Append("最终亏损").Append("\"").Append(",");
            svcsb.Append("\"").Append("供应商返点亏损").Append("\"").Append(",");
            svcsb.Append("\"").Append("供应商补差亏损").Append("\"").Append(",");
            svcsb.Append("\"").Append("原始贴钱").Append("\"").Append(",");
            svcsb.Append("\"").Append("客人实付").Append("\"").Append(",");
            svcsb.Append("\"").Append("客人应付").Append("\"").Append(",");
            svcsb.Append("\"").Append("客人端亏损").Append("\"").Append(",");
            svcsb.Append("\"").Append("航线类型").Append("\"").Append(",");
            svcsb.Append("\"").Append("航段数").Append("\"").Append(",");
            svcsb.Append("\"").Append("成人航段数").Append("\"").Append(",");
            svcsb.Append("\"").Append("儿童航段数").Append("\"").Append(",");
            svcsb.Append("\"").Append("婴儿航段").Append("\"").Append(",");
            svcsb.Append("\"").Append("政策类型").Append("\"").Append(",");
            svcsb.Append("\"").Append("渠道名称").Append("\"").Append(",");
            svcsb.Append("\"").Append("分众基础产品").Append("\"").Append(",");
            svcsb.Append("\"").Append("分众产品形态").Append("\"").Append(",");
            svcsb.Append("\"").Append("航班号").Append("\"").Append(",");
            svcsb.Append("\"").Append("订单状态").Append("\"").Append(",");
            svcsb.Append("\"").Append("支付方式").Append("\"").Append(",");
            svcsb.Append("\"").Append("子渠道名称").Append("\"").Append(",");
            svcsb.Append("\"").Append("舱位折扣").Append("\"").Append(",");
            svcsb.Append("\"").Append("会员ID").Append("\"").Append(",");
            svcsb.Append("\"").Append("小编码").Append("\"").Append(",");
            svcsb.Append("\"").Append("黑屏解析系统价").Append("\"").Append(",");
            svcsb.Append("\"").Append("改签费").Append("\"").Append(",");
            svcsb.Append("\"").Append("抵扣金额").Append("\"").Append(",");
            svcsb.Append("\"").Append("返点类型").Append("\"");
            svcsb.Append("\n");
            ////将数据逐步写入sheet1各个行
            for (int j = 0; j < modellist.Count; j++)
            {
                var model = modellist[j];
                svcsb.Append("\"").Append(model.CreateTime).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.OrderID).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.ProductCode).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.Ratio).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.TakeoffDate).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.Supplier).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.FirstSupplier).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.AirCompany).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.CabinCode).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.StartAirPort).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.ArriveAirPort).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.SystemPrice).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.ETCBasePrice).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.JijianPrice).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.OilPrice).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.ClientShouldPayTicketPrice).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.FirstShouldPaySupplierPrice).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.PayAirCompanyPrice).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.RealIncomeFromClientPrice).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.PaySupplierPrice).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.InsurancePrice).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.MailPrice).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.RedPackagePrice).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.OrderProfit).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.InBackRatio).Append("\"").Append(",");
                if (model.ETCBasePrice == 0)
                {
                    svcsb.Append("\"").Append("#DIV/0!").Append("\"").Append(",");
                }
                else
                {
                    svcsb.Append("\"").Append((double)model.OutBackRatio).Append("\"").Append(",");
                }

                svcsb.Append("\"").Append((double)model.BackRatioDiff).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.FinalLoss).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.BackRatioLoss).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.MakeupLoss).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.StickMoney).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.ClientRealPayPrice).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.ClientShouldPayPrice).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.ClientLoss).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.FlightLineType).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.FlightLeg).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.AdultFlightLeg).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.ChildFlightLeg).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.BabyFlightLeg).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.PolicyType).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.ChannelName).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.FZProductName).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.FZProductShape).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.FlightNo).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.OrderStatus).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.PayType).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.SubChannel).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.CabinRebate).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.MemberID).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.LittlePNR).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.PATAPrice).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.TicketChangesPrice).Append("\"").Append(",");
                svcsb.Append("\"").Append((double)model.DeductiblePrice).Append("\"").Append(",");
                svcsb.Append("\"").Append(model.BackRatioType).Append("\"");
                svcsb.Append("\n");
                if (j > 72440)
                {
                    string wenti = string.Empty;
                }
            }

            return svcsb.ToString();
        }
    }
}
