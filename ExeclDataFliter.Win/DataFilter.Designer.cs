namespace ExeclDataFliter.Win
{
    partial class DataFilter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.importData = new System.Windows.Forms.Button();
            this.keywords1 = new System.Windows.Forms.TextBox();
            this.serchBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FieldName1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nextbutton = new System.Windows.Forms.Button();
            this.beforbtn = new System.Windows.Forms.Button();
            this.tabletitle = new System.Windows.Forms.Label();
            this.tabletitle_textBox = new System.Windows.Forms.TextBox();
            this.FieldName2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.keywords2 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // importData
            // 
            this.importData.Location = new System.Drawing.Point(15, 15);
            this.importData.Name = "importData";
            this.importData.Size = new System.Drawing.Size(107, 23);
            this.importData.TabIndex = 0;
            this.importData.Text = "批量导入数据源";
            this.importData.UseVisualStyleBackColor = true;
            this.importData.Click += new System.EventHandler(this.importData_Click);
            // 
            // keywords1
            // 
            this.keywords1.Location = new System.Drawing.Point(350, 119);
            this.keywords1.Name = "keywords1";
            this.keywords1.Size = new System.Drawing.Size(120, 21);
            this.keywords1.TabIndex = 1;
            // 
            // serchBtn
            // 
            this.serchBtn.Location = new System.Drawing.Point(494, 165);
            this.serchBtn.Name = "serchBtn";
            this.serchBtn.Size = new System.Drawing.Size(75, 23);
            this.serchBtn.TabIndex = 2;
            this.serchBtn.Text = "开始检索";
            this.serchBtn.UseVisualStyleBackColor = true;
            this.serchBtn.Click += new System.EventHandler(this.serchBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "关键字：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "数据字段：";
            // 
            // FieldName1
            // 
            this.FieldName1.Location = new System.Drawing.Point(140, 118);
            this.FieldName1.Name = "FieldName1";
            this.FieldName1.Size = new System.Drawing.Size(120, 21);
            this.FieldName1.TabIndex = 6;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(140, 15);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(574, 88);
            this.listBox1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(15, 259);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 287);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据结果";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(693, 267);
            this.dataGridView1.TabIndex = 0;
            // 
            // nextbutton
            // 
            this.nextbutton.Location = new System.Drawing.Point(659, 163);
            this.nextbutton.Name = "nextbutton";
            this.nextbutton.Size = new System.Drawing.Size(59, 23);
            this.nextbutton.TabIndex = 9;
            this.nextbutton.Text = "下一页";
            this.nextbutton.UseVisualStyleBackColor = true;
            this.nextbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // beforbtn
            // 
            this.beforbtn.Location = new System.Drawing.Point(575, 164);
            this.beforbtn.Name = "beforbtn";
            this.beforbtn.Size = new System.Drawing.Size(75, 23);
            this.beforbtn.TabIndex = 11;
            this.beforbtn.Text = "前一页";
            this.beforbtn.UseVisualStyleBackColor = true;
            this.beforbtn.Click += new System.EventHandler(this.beforbtn_Click);
            // 
            // tabletitle
            // 
            this.tabletitle.AutoSize = true;
            this.tabletitle.Location = new System.Drawing.Point(23, 227);
            this.tabletitle.Name = "tabletitle";
            this.tabletitle.Size = new System.Drawing.Size(59, 12);
            this.tabletitle.TabIndex = 13;
            this.tabletitle.Text = "表    名:";
            // 
            // tabletitle_textBox
            // 
            this.tabletitle_textBox.Location = new System.Drawing.Point(140, 222);
            this.tabletitle_textBox.Name = "tabletitle_textBox";
            this.tabletitle_textBox.Size = new System.Drawing.Size(338, 21);
            this.tabletitle_textBox.TabIndex = 14;
            // 
            // FieldName2
            // 
            this.FieldName2.Location = new System.Drawing.Point(140, 165);
            this.FieldName2.Name = "FieldName2";
            this.FieldName2.Size = new System.Drawing.Size(120, 21);
            this.FieldName2.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "数据字段：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "关键字：";
            // 
            // keywords2
            // 
            this.keywords2.Location = new System.Drawing.Point(350, 166);
            this.keywords2.Name = "keywords2";
            this.keywords2.Size = new System.Drawing.Size(120, 21);
            this.keywords2.TabIndex = 15;
            // 
            // DataFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 558);
            this.Controls.Add(this.FieldName2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.keywords2);
            this.Controls.Add(this.tabletitle_textBox);
            this.Controls.Add(this.tabletitle);
            this.Controls.Add(this.beforbtn);
            this.Controls.Add(this.nextbutton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.FieldName1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serchBtn);
            this.Controls.Add(this.keywords1);
            this.Controls.Add(this.importData);
            this.Name = "DataFilter";
            this.Text = "DataFilter";
            this.Load += new System.EventHandler(this.DataFilter_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button importData;
        private System.Windows.Forms.TextBox keywords1;
        private System.Windows.Forms.Button serchBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FieldName1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button nextbutton;
        private System.Windows.Forms.Button beforbtn;
        private System.Windows.Forms.Label tabletitle;
        private System.Windows.Forms.TextBox tabletitle_textBox;
        private System.Windows.Forms.TextBox FieldName2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox keywords2;
    }
}