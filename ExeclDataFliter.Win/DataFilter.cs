using ExeclDataFliter.Bll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExeclDataFliter.Win
{
    public partial class DataFilter : Form
    {

        /// <summary>
        /// 显示页面信息委托
        /// </summary>
        private Action<string> addItemsHandler = null;

        /// <summary>
        /// 数据显示委托
        /// </summary>
        private Action<object, string> dataViewsHandler = null;


        /// <summary>
        /// 数据源
        /// </summary>
        private Dictionary<string, DataTable> exceldata = new Dictionary<string, DataTable>();

        /// <summary>
        /// 筛选后的集合
        /// </summary>
        private Dictionary<string, DataTable> filtedDatas = new Dictionary<string, DataTable>();

        private List<string> dataFlies = new List<string>();
        private int index = 0;

        public DataFilter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示需要显示的页面提示信息的事件实现
        /// </summary>
        /// <param name="msg">页面提示信息</param>
        private void AddItemsHandler(string msg)
        {
            this.Invoke(this.addItemsHandler, msg);
        }

        /// <summary>
        /// 显示需要显示的页面提示信息的事件实现
        /// </summary>
        /// <param name="msg">页面提示信息</param>
        private void AddDataViewsHandler(object data, string filepath)
        {
            this.Invoke(this.dataViewsHandler, data, filepath);
        }

        /// <summary>
        /// 具体页面显示
        /// </summary>
        /// <param name="msg">页面显示内容</param>
        private void AddItems(string filepath)
        {
            listBox1.Items.Add(filepath);
        }


        /// <summary>
        /// 具体页面显示
        /// </summary>
        /// <param name="msg">页面显示内容</param>
        private void DataViews(object datas, string filepath)
        {
            this.dataGridView1.DataSource = datas;
            this.tabletitle_textBox.Text = filepath;
        }

        private void DataFilter_Load(object sender, EventArgs e)
        {
            // 处理底层到页面显示的事件
            ShowAction.ShowMsgEvent += new Action<string>(this.AddItemsHandler);
            ShowAction.ShowDataEvent += new Action<object, string>(this.AddDataViewsHandler);
            // 页面显示委托
            this.addItemsHandler = new Action<string>(AddItems);
            this.dataViewsHandler = new Action<object, string>(DataViews);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Excel(*.xlsx)|*.xlsx|Excel(*.xls)|*.xls|Excel(*.csv)|*.csv";
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFile.Multiselect = true;
            if (openFile.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            List<string> filePaths = openFile.FileNames.ToList();
            foreach (var item in filePaths)
            {
                Action<string> loaddatacation = new Action<string>(GetDataFromExcel);
                loaddatacation.BeginInvoke(item, null, null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serchBtn_Click(object sender, EventArgs e)
        {
            this.nextbutton.Enabled = false;
            SerchData();
            MessageBox.Show("检索完毕！");
            this.nextbutton.Enabled = true;
        }

        /// <summary>
        /// 从excel中获取数据
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="hasTitle"></param>
        /// <returns></returns>
        private void GetDataFromExcel(string filepath)
        {
            ShowAction.ShowMsg(filepath);
            FileStream stream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            var util = TransferDataFactory.GetUtil(filepath);
            exceldata.Add(filepath, util.GetData(stream));
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="dataTable"></param>
        private void SerchData()
        {
            filtedDatas.Clear();
            dataFlies.Clear();
            string filterName1 = this.FieldName1.Text;
            string keywords1 = this.keywords1.Text;

            string filterName2 = this.FieldName2.Text;
            string keywords2 = this.keywords2.Text;
            foreach (var item in exceldata)
            {
                string selectSql = string.Empty;

                if (!string.IsNullOrEmpty(filterName1) && !string.IsNullOrEmpty(keywords1))
                {
                    selectSql = string.Format("{0} like '%{1}%'", filterName1, keywords1);
                }


                if (!string.IsNullOrEmpty(filterName2) && !string.IsNullOrEmpty(keywords2))
                {
                    if (!string.IsNullOrEmpty(selectSql))
                    {
                        selectSql += " and ";
                    }

                    selectSql += string.Format("{0} like '%{1}%'", filterName2, keywords2);
                }

                DataRow[] rows = item.Value.Select(selectSql);
                if (rows == null || rows.Length == 0)
                {
                    continue;
                }

                DataTable tmp = rows[0].Table.Clone(); // 复制DataRow的表结构
                foreach (DataRow row in rows)
                {
                    tmp.ImportRow(row); // 将DataRow添加到DataTable中
                }
                filtedDatas.Add(item.Key, tmp);
                dataFlies.Add(item.Key);
            }

            this.nextbutton.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (filtedDatas != null && filtedDatas.Count > 0)
            {
                if (index >= filtedDatas.Count)
                {
                    MessageBox.Show("已经是最后一页！");
                    index = filtedDatas.Count - 1;
                }

                string key = dataFlies[index];
                ShowAction.ShowData(filtedDatas[key], key);
                index++;
            }
            else
            {
                MessageBox.Show("数据检索完毕。");
            }
        }

        private void beforbtn_Click(object sender, EventArgs e)
        {
            index--;
            if (filtedDatas != null && filtedDatas.Count > 0)
            {
                if (index < 0)
                {
                    MessageBox.Show("已经是首页");
                    index = 0;
                }
                string key = dataFlies[index];
                ShowAction.ShowData(filtedDatas[key], key);
            }
        }
    }
}
