using ExeclDataFliter.Bll;
using ExeclDataFliter.Model;
using ExeclDataFliter.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace ExeclDataFliter.Win
{
    public partial class Form1 : Form
    {
        public Form1()
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

            List<MFlightSeal> flightSealList = new List<MFlightSeal>();


            LargeTransferData<MFlightSeal> largeTransferData = new LargeTransferData<MFlightSeal>();

            largeTransferData.ToListThread(exceldata);

            flightSealList = largeTransferData.DataList;

            int SegmentCount = flightSealList.Sum(p => p.SegmentCount);

            this.dataGridView1.DataSource = exceldata;
            this.dataGridView1.Show();
        }

        private DataTable GetDataFromExcel(string filepath, bool hasTitle = false)
        {
            FileStream stream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            var util = TransferDataFactory.GetUtil(filepath);
            return util.GetData(stream);
        }
    }
}
