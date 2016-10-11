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
            LargeTransferData<MOriginalLossReport> largeTransferData = new LargeTransferData<MOriginalLossReport>();

            largeTransferData.ToListThread(exceldata);

            flightSealList = largeTransferData.DataList;
            List<MLossReport> lossReportList = null;
            if (flightSealList != null && flightSealList.Count > 0)
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
