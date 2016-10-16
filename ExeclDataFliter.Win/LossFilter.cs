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
using Amib.Threading;

namespace ExeclDataFliter.Win
{
    public partial class LossFilter : Form
    {
        private List<MOriginalLossReport> flightSealList = new List<MOriginalLossReport>();

        /// <summary>
        /// 财务报表
        /// </summary>
        Dictionary<string, MFinanceReport> financeReportDic = null;

        /// <summary>
        /// 原始报表文件路径
        /// </summary>
        private string OrgReportFilepath = string.Empty;

        /// <summary>
        /// 文件路径
        /// </summary>
        private string FinanceReportFilepath = string.Empty;


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
            if (string.IsNullOrEmpty(this.OrgReportFilepath))
            {
                MessageBox.Show("你在逗我？");
                return;
            }

            string fileType = System.IO.Path.GetExtension(this.OrgReportFilepath);
            if (string.IsNullOrEmpty(fileType))
            {
                return;
            }

            System.Action action = new System.Action(LoadData);
            action.BeginInvoke(null, null);
        }



        /// <summary>
        /// 导入数据
        /// </summary>
        private void LoadData()
        {
            SmartThreadPool smartThreadPool = new SmartThreadPool();
            smartThreadPool.QueueWorkItem(LoadFlightSealData);
            smartThreadPool.QueueWorkItem(LoadFinanceData);
            smartThreadPool.WaitForIdle();
            AanalysisReport();
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="exceldata"></param>
        private void LoadFlightSealData()
        {
            ShowAction.ShowMsg("开始加载原始报表数据");
            FileStream stream = new FileStream(OrgReportFilepath, FileMode.Open, FileAccess.Read);
            var util = TransferDataFactory.GetUtil(OrgReportFilepath);
            DataTable exceldata = util.GetData(stream);
            LargeTransferData<MOriginalLossReport> largeTransferData = new LargeTransferData<MOriginalLossReport>();
            largeTransferData.ToListThread(exceldata);
            flightSealList = largeTransferData.DataList;
            ShowAction.ShowMsg("数据加载原始报表完成");
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="exceldata"></param>
        private void LoadFinanceData()
        {
            ShowAction.ShowMsg("开始加载财务报表数据");
            FileStream stream = new FileStream(FinanceReportFilepath, FileMode.Open, FileAccess.Read);
            var util = TransferDataFactory.GetUtil(FinanceReportFilepath);
            DataTable exceldata = util.GetData(stream);
            LargeTransferData<MFinanceReport> largeTransferData = new LargeTransferData<MFinanceReport>();
            largeTransferData.ToListThread(exceldata);
            List<MFinanceReport> financeReportList = largeTransferData.DataList;
            financeReportDic = new Dictionary<string, MFinanceReport>();
            if (financeReportList != null && financeReportList.Count > 0)
            {
                foreach (var item in financeReportList)
                {
                    if (string.IsNullOrEmpty(item.OrderID))
                    {
                        continue;
                    }
                    if (!financeReportDic.ContainsKey(item.OrderID))
                    {
                        financeReportDic.Add(item.OrderID, item);
                    }
                }
            }

            ShowAction.ShowMsg("数据加载财务报表完成");
        }

        /// <summary>
        /// 分析数据数据
        /// </summary>
        /// <param name="exceldata"></param>
        private void AanalysisReport()
        {
            ShowAction.ShowMsg("开始分析数据");
            // 未匹配
            List<MLossReport> noMatchLossReportList = null;

            // 已经匹配
            List<MLossReport> matchedLossReportList = null;

            List<MLossReport> guochangLossReport = null;
            if (flightSealList != null && flightSealList.Count > 0)
            {
                try
                {
                    noMatchLossReportList = new List<MLossReport>();
                    matchedLossReportList = new List<MLossReport>();
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
                            if (financeReportDic != null)
                            {
                                if (financeReportDic.ContainsKey(lossReport.OrderID))
                                {
                                    lossReport.PayAirCompanyPrice = financeReportDic[lossReport.OrderID].RealPay;
                                    matchedLossReportList.Add(lossReport);
                                }
                                else
                                {
                                    noMatchLossReportList.Add(lossReport);
                                }
                            }
                        }
                    }


                    ShowAction.ShowMsg("分析数据完成");
                    ShowAction.ShowMsg("开始生成报表数据");

                    string noMatchfilenames = string.Format("D://未匹配亏损日报.csv");
                    string matchedfilenames = string.Format("D://亏损日报.csv");
                    string guochangfilenames = string.Format("D://国长亏损日报.csv");

                    System.Action<List<MLossReport>, string> exportAction = new System.Action<List<MLossReport>, string>(Export);
                    exportAction.BeginInvoke(guochangLossReport, guochangfilenames, null, null);

                    System.Action<List<MLossReport>, string> matchedexportAction = new System.Action<List<MLossReport>, string>(Export);
                    exportAction.BeginInvoke(matchedLossReportList, matchedfilenames, null, null);

                    System.Action<List<MLossReport>, string> noMatchexportAction = new System.Action<List<MLossReport>, string>(Export);
                    exportAction.BeginInvoke(noMatchLossReportList, noMatchfilenames, null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }


        public void Export(List<MLossReport> modellist, string strExcelFileName)
        {
            BaseExport guochangexport = new ExportToCsv(modellist, strExcelFileName);
            guochangexport.ExexcuteExport();
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

            this.OrgReportFilepath = openFile.FileName;
            this.textBox1.Text = this.OrgReportFilepath;
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
            this.richTextBox1.AppendText(string.Format("{0}----{1}", DateTime.Now.ToLongTimeString(), msg));
        }

        private void LossFilter_Load(object sender, EventArgs e)
        {
            // 处理底层到页面显示的事件
            ShowAction.ShowMsgEvent += new Action<string>(this.ShowMessge_ShowMsg);
            // 页面显示委托
            this.showMsgHandler = new Action<string>(this.PrintMsg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Excel(*.csv)|*.csv|Excel(*.xlsx)|*.xlsx|Excel(*.xls)|*.xls";
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFile.Multiselect = false;
            if (openFile.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            this.FinanceReportFilepath = openFile.FileName;
            this.textBox2.Text = this.FinanceReportFilepath;
        }
    }
}
