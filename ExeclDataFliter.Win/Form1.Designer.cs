namespace ExeclDataFliter.Win
{
    partial class databox
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.excelImprot = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.datarichTextBox = new System.Windows.Forms.RichTextBox();
            this.FlightTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.FlightTimeStart = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.SealTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.SealTimeStart = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.Cabin = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.FlightLine = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.changle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.aircompany = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // excelImprot
            // 
            this.excelImprot.Location = new System.Drawing.Point(19, 16);
            this.excelImprot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.excelImprot.Name = "excelImprot";
            this.excelImprot.Size = new System.Drawing.Size(56, 18);
            this.excelImprot.TabIndex = 1;
            this.excelImprot.Text = "导入数据";
            this.excelImprot.UseVisualStyleBackColor = true;
            this.excelImprot.Click += new System.EventHandler(this.excelImprot_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(2, 16);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1094, 316);
            this.dataGridView1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.FlightTimeEnd);
            this.groupBox1.Controls.Add(this.FlightTimeStart);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.SealTimeEnd);
            this.groupBox1.Controls.Add(this.SealTimeStart);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Cabin);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.FlightLine);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.changle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.aircompany);
            this.groupBox1.Controls.Add(this.excelImprot);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(1098, 193);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作区";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.datarichTextBox);
            this.groupBox3.Location = new System.Drawing.Point(599, 22);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(474, 148);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据结果：";
            // 
            // datarichTextBox
            // 
            this.datarichTextBox.Location = new System.Drawing.Point(13, 19);
            this.datarichTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.datarichTextBox.Name = "datarichTextBox";
            this.datarichTextBox.Size = new System.Drawing.Size(458, 104);
            this.datarichTextBox.TabIndex = 0;
            this.datarichTextBox.Text = "";
            // 
            // FlightTimeEnd
            // 
            this.FlightTimeEnd.CustomFormat = "yyyy-MM-dd";
            this.FlightTimeEnd.Location = new System.Drawing.Point(323, 66);
            this.FlightTimeEnd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FlightTimeEnd.Name = "FlightTimeEnd";
            this.FlightTimeEnd.Size = new System.Drawing.Size(151, 21);
            this.FlightTimeEnd.TabIndex = 17;
            // 
            // FlightTimeStart
            // 
            this.FlightTimeStart.Cursor = System.Windows.Forms.Cursors.Default;
            this.FlightTimeStart.CustomFormat = "yyyy-MM-dd";
            this.FlightTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FlightTimeStart.Location = new System.Drawing.Point(157, 66);
            this.FlightTimeStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FlightTimeStart.Name = "FlightTimeStart";
            this.FlightTimeStart.Size = new System.Drawing.Size(151, 21);
            this.FlightTimeStart.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(92, 72);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "起飞时间：";
            // 
            // SealTimeEnd
            // 
            this.SealTimeEnd.CustomFormat = "yyyy-MM-dd";
            this.SealTimeEnd.Location = new System.Drawing.Point(323, 16);
            this.SealTimeEnd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SealTimeEnd.Name = "SealTimeEnd";
            this.SealTimeEnd.Size = new System.Drawing.Size(151, 21);
            this.SealTimeEnd.TabIndex = 14;
            // 
            // SealTimeStart
            // 
            this.SealTimeStart.Cursor = System.Windows.Forms.Cursors.Default;
            this.SealTimeStart.CustomFormat = "yyyy-MM-dd";
            this.SealTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.SealTimeStart.Location = new System.Drawing.Point(157, 17);
            this.SealTimeStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SealTimeStart.Name = "SealTimeStart";
            this.SealTimeStart.Size = new System.Drawing.Size(151, 21);
            this.SealTimeStart.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(321, 116);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "舱位：";
            // 
            // Cabin
            // 
            this.Cabin.Location = new System.Drawing.Point(364, 114);
            this.Cabin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Cabin.Name = "Cabin";
            this.Cabin.Size = new System.Drawing.Size(118, 21);
            this.Cabin.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(502, 36);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 18);
            this.button1.TabIndex = 10;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(321, 158);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "航线：";
            // 
            // FlightLine
            // 
            this.FlightLine.Location = new System.Drawing.Point(364, 150);
            this.FlightLine.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FlightLine.Name = "FlightLine";
            this.FlightLine.Size = new System.Drawing.Size(118, 21);
            this.FlightLine.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(92, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "销售时间：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 153);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "渠道：";
            // 
            // changle
            // 
            this.changle.Location = new System.Drawing.Point(158, 150);
            this.changle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.changle.Name = "changle";
            this.changle.Size = new System.Drawing.Size(150, 21);
            this.changle.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "航司：";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 0;
            // 
            // aircompany
            // 
            this.aircompany.Location = new System.Drawing.Point(158, 111);
            this.aircompany.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.aircompany.Name = "aircompany";
            this.aircompany.Size = new System.Drawing.Size(150, 21);
            this.aircompany.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(9, 230);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(1098, 334);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据区";
            // 
            // databox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 574);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "databox";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button excelImprot;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox aircompany;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox changle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FlightLine;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Cabin;
        private System.Windows.Forms.DateTimePicker SealTimeEnd;
        private System.Windows.Forms.DateTimePicker SealTimeStart;
        private System.Windows.Forms.DateTimePicker FlightTimeEnd;
        private System.Windows.Forms.DateTimePicker FlightTimeStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox datarichTextBox;
    }
}

