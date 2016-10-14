using ExeclDataFliter.Bll;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ExeclDataFliter.Model;
using ExeclDataFliter.Util;

namespace ExeclDataFliter.Win
{
    public partial class LossFilter : Form
    {
        private List<MOriginalLossReport> flightSealList = new List<MOriginalLossReport>();

        /// <summary>
        /// 文件路径
        /// </summary>
        private string filepath = string.Empty;

        /// <summary>
        /// 显示页面信息委托
        /// </summary>
        private Action<string> showMsgHandler = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public LossFilter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 开始分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void excelImprot_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.filepath))
            {
                MessageBox.Show("你在逗我？");
                return;
            }

            string fileType = System.IO.Path.GetExtension(this.filepath);
            if (string.IsNullOrEmpty(fileType))
            {
                return;
            }

            ShowAction.ShowMsg("开始加载数据");
            DataTable exceldata = GetDataFromExcel(this.filepath);
            ShowAction.ShowMsg("数据加载完成");
            Action<DataTable> loaddatacation = new Action<DataTable>(LoadData);
            loaddatacation.BeginInvoke(exceldata, null, null);

        }

        /// <summary>
        /// 从excel中获取数据
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="hasTitle"></param>
        /// <returns></returns>
        private DataTable GetDataFromExcel(string filepath, bool hasTitle = false)
        {
            FileStream stream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            var util = TransferDataFactory.GetUtil(filepath);
            return util.GetData(stream);
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="exceldata"></param>
        private void LoadData(DataTable exceldata)
        {
            ShowAction.ShowMsg("开始分析数据");


            LargeTransferData<MOriginalLossReport> largeTransferData = new LargeTransferData<MOriginalLossReport>();
            largeTransferData.ToListThread(exceldata);
            flightSealList = largeTransferData.DataList;
            ShowAction.ShowMsg("分析数据完成");
            List<MLossReport> lossReportList = null;
            List<MLossReport> guochangLossReport = null;
            if (flightSealList != null && flightSealList.Count > 0)
            {
                try
                {
                    lossReportList = new List<MLossReport>();
                    guochangLossReport = new List<MLossReport>();
                    MLossReport lossReport = null;
                    foreach (var item in flightSealList)
                    {
                        lossReport = new MLossReport();
                        lossReport.AdultFlightLeg = item.AdultFlightLeg;
                        lossReport.AirCompany = item.AirCompany;
                        lossReport.ArriveAirPort = item.ArriveAirPort;
                        lossReport.BabyFlightLeg = item.FlightLeg - item.AdultFlightLeg - item.ChildFlightLeg;
                        lossReport.ClientRealPayPrice = item.RealIncomeFromClientPrice - item.InsurancePrice - item.MailPrice;
                        lossReport.Ratio = 0;
                        lossReport.StickMoney = item.SystemPrice * item.InBackRatio * lossReport.Ratio;
                        lossReport.ClientShouldPayPrice = item.SystemPrice + item.JijianPrice + item.OilPrice - lossReport.StickMoney;
                        lossReport.ClientLoss = lossReport.ClientRealPayPrice - lossReport.ClientShouldPayTicketPrice;
                        lossReport.OutBackRatio = item.ETCBasePrice == 0 ? 0 : (item.ETCBasePrice + item.JijianPrice + item.OilPrice - item.PayAirCompanyPrice) / item.ETCBasePrice;
                        lossReport.BackRatioDiff = lossReport.OutBackRatio - item.InBackRatio;
                        lossReport.BackRatioLoss = lossReport.BackRatioDiff * item.ETCBasePrice;
                        lossReport.CabinCode = item.CabinCode;
                        lossReport.CabinRebate = item.CabinRebate;
                        lossReport.ChannelName = item.ChannelName;
                        lossReport.ChildFlightLeg = item.ChildFlightLeg;
                        lossReport.ClientShouldPayTicketPrice = item.ClientShouldPayTicketPrice;
                        lossReport.CreateTime = item.CreateTime;
                        lossReport.DeductiblePrice = item.DeductiblePrice;
                        lossReport.ETCBasePrice = item.ETCBasePrice;
                        //lossReport.FinalLoss
                        lossReport.FirstShouldPaySupplierPrice = item.FirstShouldPaySupplierPrice;
                        lossReport.FirstSupplier = item.FirstSupplier;
                        lossReport.FlightLeg = item.FlightLeg;
                        lossReport.FlightLineType = item.FlightLineType;
                        lossReport.FlightNo = item.FlightNo;
                        lossReport.FZProductName = item.FZProductName;
                        lossReport.FZProductShape = item.FZProductShape;
                        lossReport.InBackRatio = item.InBackRatio;
                        lossReport.InsurancePrice = item.InsurancePrice;
                        lossReport.JijianPrice = item.JijianPrice;
                        lossReport.LittlePNR = item.LittlePNR;
                        lossReport.MailPrice = item.MailPrice;
                        lossReport.MakeupLoss = item.SystemPrice * (1 - item.InBackRatio) - item.ETCBasePrice * (1 - lossReport.OutBackRatio);
                        lossReport.PATAPrice = item.PATAPrice;
                        lossReport.PayAirCompanyPrice = item.PayAirCompanyPrice;
                        lossReport.PaySupplierPrice = item.PaySupplierPrice;
                        lossReport.PayType = item.PayType;
                        lossReport.PolicyType = item.PolicyType;
                        lossReport.ProductCode = item.ProductCode;
                        lossReport.RealIncomeFromClientPrice = item.RealIncomeFromClientPrice;
                        lossReport.RedPackagePrice = item.RedPackagePrice;
                        lossReport.StartAirPort = item.StartAirPort;
                        lossReport.SubChannel = item.SubChannel;
                        lossReport.Supplier = item.Supplier;
                        lossReport.SystemPrice = item.SystemPrice;
                        lossReport.TakeoffDate = item.TakeoffDate;
                        lossReport.TicketChangesPrice = item.TicketChangesPrice;
                        lossReport.OrderID = item.OrderID;
                        lossReport.OrderStatus = item.OrderStatus;
                        if (lossReport.FZProductName != null && lossReport.FZProductName.Contains("国长"))
                        {
                            guochangLossReport.Add(lossReport);
                        }
                        else
                        {
                            lossReportList.Add(lossReport);
                        }
                    }

                    ShowAction.ShowMsg("开始生成报表数据");
                    NPioExcelHelper nPioExcelHelper = new NPioExcelHelper();
                    string filenames = string.Format("D://亏损日报.csv");
                    string guochangfilenames = string.Format("D://国长亏损日报.csv");

                    nPioExcelHelper.FliterDataOrgtoSvc(guochangLossReport, guochangfilenames);

                    nPioExcelHelper.FliterDataOrgtoSvc(lossReportList, filenames);


                    MessageBox.Show(string.Format("好了，亲爱的！文件在{0},{1}", guochangfilenames, filenames));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        /// <summary>
        /// 数据模型转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        private object DataToModel<T>(T model, string description)
        {
            Type modetype = typeof(T);
            var members = modetype.GetMembers();
            object value = null;
            foreach (var mi in members)
            {
                if (mi.MemberType == MemberTypes.Property)
                {
                    //读取属性上的DataField特性
                    object[] attributes = mi.GetCustomAttributes(typeof(DataFieldAttribute), true);
                    foreach (var attr in attributes)
                    {
                        var dataFieldAttr = attr as DataFieldAttribute;
                        if (dataFieldAttr != null)
                        {
                            var propInfo = modetype.GetProperty(mi.Name);

                            if (dataFieldAttr.ColumnName == description)
                            {
                                value = propInfo.GetValue(model, null);
                                break;
                            }
                        }
                    }
                }
            }

            return value;
        }

        /// <summary>
        /// 选择文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Excel(*.csv)|*.csv|Excel(*.xlsx)|*.xlsx|Excel(*.xls)|*.xls";
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFile.Multiselect = false;
            if (openFile.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            this.filepath = openFile.FileName;
            this.textBox1.Text = this.filepath;
        }

        /// <summary>
        /// 显示需要显示的页面提示信息的事件实现
        /// </summary>
        /// <param name="msg">页面提示信息</param>
        private void ShowMessge_ShowMsg(string msg)
        {
            this.Invoke(this.showMsgHandler, msg);
        }

        /// <summary>
        /// 具体页面显示
        /// </summary>
        /// <param name="msg">页面显示内容</param>
        private void PrintMsg(string msg)
        {
            this.richTextBox1.AppendText("\n");
            this.richTextBox1.AppendText(string.Format("{0}----{1}", DateTime.Now.ToShortTimeString(), msg));
        }

        private void LossFilter_Load(object sender, EventArgs e)
        {
            // 处理底层到页面显示的事件
            ShowAction.ShowMsgEvent += new Action<string>(this.ShowMessge_ShowMsg);
            // 页面显示委托
            this.showMsgHandler = new Action<string>(this.PrintMsg);
        }
    }
}
