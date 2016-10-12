using ExeclDataFliter.Bll;
using ExeclDataFliter.Model;
using ExeclDataFliter.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExeclDataFliter.Win
{
    public partial class LossFilter : Form
    {
        private List<MOriginalLossReport> flightSealList = new List<MOriginalLossReport>();

        public LossFilter()
        {
            InitializeComponent();
        }

        private void excelImprot_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Excel(*.csv)|*.csv|Excel(*.xlsx)|*.xlsx|Excel(*.xls)|*.xls";
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFile.Multiselect = false;
            if (openFile.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            var filePath = openFile.FileName;

            string fileType = System.IO.Path.GetExtension(filePath);
            if (string.IsNullOrEmpty(fileType))
            {
                return;
            }

            DataTable exceldata = GetDataFromExcel(filePath);
            this.dataGridView1.DataSource = exceldata;
            this.dataGridView1.Show();
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
            string filename = string.Format("D://亏损日报.xlsx");
            LargeTransferData<MOriginalLossReport> largeTransferData = new LargeTransferData<MOriginalLossReport>();

            largeTransferData.ToListThread(exceldata);

            flightSealList = largeTransferData.DataList;
            List<MLossReport> lossReportList = null;
            if (flightSealList != null && flightSealList.Count > 0)
            {
                try
                {


                    lossReportList = new List<MLossReport>();
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
                        lossReport.FlightLine = item.FlightLine;
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
                        lossReportList.Add(lossReport);
                    }

                    NPioExcelHelper.FliterDataOrg(lossReportList, filename);
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
    }
}
