using ExeclDataFliter.Bll;
using ExeclDataFliter.Model;
using ExeclDataFliter.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;


namespace ExeclDataFliter.Win
{
    public partial class databox : Form
    {

        private List<MFlightSeal> flightSealList = new List<MFlightSeal>();

        private Dictionary<string, List<MFlightSeal>> flightSealDic = new Dictionary<string, List<MFlightSeal>>();

        public databox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 导入数据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            List<MFlightSeal> TempflightSealList = new List<MFlightSeal>();

            //开始销售时间
            string sealTimeStart = this.SealTimeStart.Text.Trim();

            string sealTimeEnd = this.SealTimeEnd.Text.Trim();

            // 起飞时间
            string flightStartTime = this.FlightTimeStart.Text.Trim();

            string flightEndTime = this.FlightTimeEnd.Text.Trim();

            // 航司 逗号分隔 3U，MU 不区分大小写
            string aircompany = this.aircompany.Text.Trim().ToUpper();

            string flightLine = this.FlightLine.Text.Trim();

            string changle = this.changle.Text.Trim();

            string Cabin = this.Cabin.Text.Trim();

            string conditionStr = string.Empty;

            if (!string.IsNullOrEmpty(aircompany))
            {
                string[] aircompanys = aircompany.ToUpper().Split(',');
                if (aircompanys != null)
                {
                    foreach (var item in aircompanys)
                    {
                        if (flightSealDic.ContainsKey(item))
                        {
                            TempflightSealList.AddRange(flightSealDic[item]);
                        }
                    }
                }
            }
            else
            {
                TempflightSealList = this.flightSealList;
            }

            List<MFlightSeal> dataflightSealList = new List<MFlightSeal>();
            int segmentCount = 0;
            decimal priceCount = 0;
            foreach (var item in TempflightSealList)
            {

                object value = DataToModel<MFlightSeal>(item, "供应商");
                bool isfit = false;
                if (!string.IsNullOrEmpty(sealTimeStart))
                {
                    isfit = item.CreateTime >= Convert.ToDateTime(sealTimeStart);
                }

                if (!string.IsNullOrEmpty(sealTimeEnd))
                {
                    isfit = item.CreateTime <= Convert.ToDateTime(sealTimeEnd);
                }


                //if (!string.IsNullOrEmpty(flightStartTime))
                //{
                //  //  isfit = 
                //}


                //if (!string.IsNullOrEmpty(flightEndTime))
                //{
                //}

                if (!string.IsNullOrEmpty(flightLine) && !string.IsNullOrEmpty(item.FlightLine))
                {
                    isfit = flightLine.ToUpper().Contains(item.FlightLine.ToUpper());
                }


                if (!string.IsNullOrEmpty(changle) && !string.IsNullOrEmpty(item.ChannelName))
                {
                    isfit = changle.ToUpper().Contains(item.ChannelName.ToUpper());
                }


                if (!string.IsNullOrEmpty(Cabin) && !string.IsNullOrEmpty(item.Cabin))
                {
                    isfit = Cabin.ToUpper().Contains(item.Cabin.ToUpper());
                }
                if (isfit)
                {
                    dataflightSealList.Add(item);
                    segmentCount += item.SegmentCount;
                    priceCount += item.SystemPrice;
                }
            }
            this.datarichTextBox.AppendText(string.Format("符合条件的数据总数{0}，航段数：{1}，总票价{2}", dataflightSealList.Count, segmentCount, priceCount));
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
            LargeTransferData<MFlightSeal> largeTransferData = new LargeTransferData<MFlightSeal>();

            largeTransferData.ToListThread(exceldata);

            flightSealList = largeTransferData.DataList;
            if (flightSealList != null && flightSealList.Count > 0)
            {
                foreach (var item in flightSealList)
                {
                    if (string.IsNullOrEmpty(item.AirCompany))
                    {
                        continue;
                    }

                    if (flightSealDic.ContainsKey(item.AirCompany.ToUpper()))
                    {
                        flightSealDic[item.AirCompany.ToUpper()].Add(item);
                    }
                    else
                    {
                        flightSealDic.Add(item.AirCompany.ToUpper(), new List<MFlightSeal>() { item });
                    }
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
