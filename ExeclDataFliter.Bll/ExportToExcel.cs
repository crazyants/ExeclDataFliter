//-----------------------------------------------------------------------
// <copyright file="FliterLossReportToExcel.cs" company="LY.COM Enterprises">
// * Copyright (C) 2016 同程网络科技股份有限公司 版权所有。
// * author  : tzq24955
// * FileName: FliterLossReportToExcel.cs
// * history : created by tzq24955 2016/10/14 16:20:46 
// </copyright>
//-----------------------------------------------------------------------

using ExeclDataFliter.Model;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExeclDataFliter.Bll
{
    public class ExportToExcel : BaseExport
    {

        /// <summary>
        /// 报表数据
        /// </summary>
        private List<MLossReport> modellist = null;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="modellist"></param>
        /// <param name="filePath"></param>
        public ExportToExcel(List<MLossReport> modellist, string filePath) : base(filePath)
        {
            this.modellist = modellist;
        }

        /// <summary>
        /// 导出报表
        /// </summary>
        /// <param name="modellist"></param>
        /// <param name="strExcelFileName"></param>
        public override Stream AanalysisReport()
        {
            XSSFWorkbook book = new XSSFWorkbook();

            int pagesize = 5000;
            int pageCount = modellist.Count / pagesize;

            if (modellist.Count % pagesize > 0)
            {
                pageCount++;
            }
            for (int i = 0; i < pageCount; i++)
            {
                List<MLossReport> TempList = modellist.Skip(pagesize * i).Take(pagesize).ToList();
                //添加一个sheet
                ISheet sheet1 = book.CreateSheet(string.Format("Sheet{0}", i));
                //获取list数据
                //给sheet1添加第一行的头部标题
                IRow headerRow = sheet1.CreateRow(0);
                headerRow.CreateCell(0).SetCellValue("创建日期");
                headerRow.CreateCell(1).SetCellValue("订单号");
                headerRow.CreateCell(2).SetCellValue("分众基础产品ID");
                headerRow.CreateCell(3).SetCellValue("比例");
                headerRow.CreateCell(4).SetCellValue("起飞日期");
                headerRow.CreateCell(5).SetCellValue("供应商");
                headerRow.CreateCell(6).SetCellValue("首次供应商");
                headerRow.CreateCell(7).SetCellValue("航空公司");
                headerRow.CreateCell(8).SetCellValue("舱位");
                headerRow.CreateCell(9).SetCellValue("起始地");
                headerRow.CreateCell(10).SetCellValue("抵达地");
                headerRow.CreateCell(11).SetCellValue("系统票价");
                headerRow.CreateCell(12).SetCellValue("电子客票号票价");
                headerRow.CreateCell(13).SetCellValue("基建");
                headerRow.CreateCell(14).SetCellValue("燃油");
                headerRow.CreateCell(15).SetCellValue("客户应付票价");
                headerRow.CreateCell(16).SetCellValue("首次应付供应商");
                headerRow.CreateCell(17).SetCellValue("实付航司金额");
                headerRow.CreateCell(18).SetCellValue("实收客户");
                headerRow.CreateCell(19).SetCellValue("实付供应商");
                headerRow.CreateCell(20).SetCellValue("保险金额");
                headerRow.CreateCell(21).SetCellValue("邮寄");
                headerRow.CreateCell(22).SetCellValue("使用红包");
                headerRow.CreateCell(23).SetCellValue("票价利润");
                headerRow.CreateCell(24).SetCellValue("录入返点");
                headerRow.CreateCell(25).SetCellValue("出票返点");
                headerRow.CreateCell(26).SetCellValue("返点差");
                headerRow.CreateCell(27).SetCellValue("最终亏损");
                headerRow.CreateCell(28).SetCellValue("供应商返点亏损");
                headerRow.CreateCell(29).SetCellValue("供应商补差亏损");
                headerRow.CreateCell(30).SetCellValue("原始贴钱");
                headerRow.CreateCell(31).SetCellValue("客人实付");
                headerRow.CreateCell(32).SetCellValue("客人应付");
                headerRow.CreateCell(33).SetCellValue("客人端亏损");
                headerRow.CreateCell(34).SetCellValue("航线类型");
                headerRow.CreateCell(35).SetCellValue("航段数");
                headerRow.CreateCell(36).SetCellValue("成人航段数");
                headerRow.CreateCell(37).SetCellValue("儿童航段数");
                headerRow.CreateCell(38).SetCellValue("婴儿航段");
                headerRow.CreateCell(39).SetCellValue("政策类型");
                headerRow.CreateCell(40).SetCellValue("渠道名称");
                headerRow.CreateCell(41).SetCellValue("分众基础产品");
                headerRow.CreateCell(42).SetCellValue("分众产品形态");
                headerRow.CreateCell(43).SetCellValue("航班号");
                headerRow.CreateCell(44).SetCellValue("订单状态");
                headerRow.CreateCell(45).SetCellValue("支付方式");
                headerRow.CreateCell(46).SetCellValue("子渠道名称");
                headerRow.CreateCell(47).SetCellValue("舱位折扣");
                headerRow.CreateCell(48).SetCellValue("会员ID");
                headerRow.CreateCell(49).SetCellValue("小编码");
                headerRow.CreateCell(50).SetCellValue("黑屏解析系统价");
                headerRow.CreateCell(51).SetCellValue("改签费");
                headerRow.CreateCell(52).SetCellValue("抵扣金额");
                NPOI.SS.UserModel.IRow rowtemp = null;
                ////将数据逐步写入sheet1各个行
                for (int j = 0; j < modellist.Count; j++)
                {
                    var model = modellist[j];
                    rowtemp = sheet1.CreateRow(j + 1);
                    rowtemp.CreateCell(0).SetCellValue(model.CreateTime);
                    rowtemp.CreateCell(1).SetCellValue(model.OrderID);
                    rowtemp.CreateCell(2).SetCellValue(model.ProductCode);
                    rowtemp.CreateCell(3).SetCellValue((double)model.Ratio);
                    rowtemp.CreateCell(4).SetCellValue(model.TakeoffDate);
                    rowtemp.CreateCell(5).SetCellValue(model.Supplier);
                    rowtemp.CreateCell(6).SetCellValue(model.FirstSupplier);
                    rowtemp.CreateCell(7).SetCellValue(model.AirCompany);
                    rowtemp.CreateCell(8).SetCellValue(model.CabinCode);
                    rowtemp.CreateCell(9).SetCellValue(model.StartAirPort);
                    rowtemp.CreateCell(10).SetCellValue(model.ArriveAirPort);
                    rowtemp.CreateCell(11).SetCellValue((double)model.SystemPrice);
                    rowtemp.CreateCell(12).SetCellValue((double)model.ETCBasePrice);
                    rowtemp.CreateCell(13).SetCellValue((double)model.JijianPrice);
                    rowtemp.CreateCell(14).SetCellValue((double)model.OilPrice);
                    rowtemp.CreateCell(15).SetCellValue((double)model.ClientShouldPayTicketPrice);
                    rowtemp.CreateCell(16).SetCellValue((double)model.FirstShouldPaySupplierPrice);
                    rowtemp.CreateCell(17).SetCellValue((double)model.PayAirCompanyPrice);
                    rowtemp.CreateCell(18).SetCellValue((double)model.RealIncomeFromClientPrice);
                    rowtemp.CreateCell(19).SetCellValue((double)model.PaySupplierPrice);
                    rowtemp.CreateCell(20).SetCellValue((double)model.InsurancePrice);
                    rowtemp.CreateCell(21).SetCellValue((double)model.MailPrice);
                    rowtemp.CreateCell(22).SetCellValue((double)model.RedPackagePrice);
                    rowtemp.CreateCell(23).SetCellValue((double)model.OrderProfit);
                    rowtemp.CreateCell(24).SetCellValue((double)model.InBackRatio);

                    rowtemp.CreateCell(25).SetCellValue((double)model.OutBackRatio);

                    rowtemp.CreateCell(26).SetCellValue((double)model.BackRatioDiff);
                    rowtemp.CreateCell(27).SetCellValue((double)model.FinalLoss);
                    rowtemp.CreateCell(28).SetCellValue((double)model.BackRatioLoss);
                    rowtemp.CreateCell(29).SetCellValue((double)model.MakeupLoss);
                    rowtemp.CreateCell(30).SetCellValue((double)model.StickMoney);
                    rowtemp.CreateCell(31).SetCellValue((double)model.ClientRealPayPrice);
                    rowtemp.CreateCell(32).SetCellValue((double)model.ClientShouldPayPrice);
                    rowtemp.CreateCell(33).SetCellValue((double)model.ClientLoss);
                    rowtemp.CreateCell(34).SetCellValue(model.FlightLineType);
                    rowtemp.CreateCell(35).SetCellValue(model.FlightLeg);
                    rowtemp.CreateCell(36).SetCellValue(model.AdultFlightLeg);
                    rowtemp.CreateCell(37).SetCellValue(model.ChildFlightLeg);
                    rowtemp.CreateCell(38).SetCellValue(model.BabyFlightLeg);
                    rowtemp.CreateCell(39).SetCellValue(model.PolicyType);
                    rowtemp.CreateCell(40).SetCellValue(model.ChannelName);
                    rowtemp.CreateCell(41).SetCellValue(model.FZProductName);
                    rowtemp.CreateCell(42).SetCellValue(model.FZProductShape);
                    rowtemp.CreateCell(43).SetCellValue(model.FlightNo);
                    rowtemp.CreateCell(44).SetCellValue(model.OrderStatus);
                    rowtemp.CreateCell(45).SetCellValue(model.PayType);
                    rowtemp.CreateCell(46).SetCellValue(model.SubChannel);
                    rowtemp.CreateCell(47).SetCellValue(model.CabinRebate);
                    rowtemp.CreateCell(48).SetCellValue(model.MemberID);
                    rowtemp.CreateCell(49).SetCellValue(model.LittlePNR);
                    rowtemp.CreateCell(50).SetCellValue(model.PATAPrice);
                    rowtemp.CreateCell(51).SetCellValue((double)model.TicketChangesPrice);
                    rowtemp.CreateCell(52).SetCellValue((double)model.DeductiblePrice);
                }
            }

            MemoryStream stream = new MemoryStream();
            book.Write(stream);
            return stream;
        }
    }
}
