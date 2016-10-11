namespace ExeclDataFliter.Win
{
    partial class LossFilter
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
            this.excelImprot = new System.Windows.Forms.Button();
            this.数据区 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.数据区.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // excelImprot
            // 
            this.excelImprot.Location = new System.Drawing.Point(27, 34);
            this.excelImprot.Name = "excelImprot";
            this.excelImprot.Size = new System.Drawing.Size(75, 23);
            this.excelImprot.TabIndex = 2;
            this.excelImprot.Text = "导入数据";
            this.excelImprot.UseVisualStyleBackColor = true;
            this.excelImprot.Click += new System.EventHandler(this.excelImprot_Click);
            // 
            // 数据区
            // 
            this.数据区.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.数据区.Controls.Add(this.dataGridView1);
            this.数据区.Location = new System.Drawing.Point(27, 102);
            this.数据区.Name = "数据区";
            this.数据区.Size = new System.Drawing.Size(1176, 633);
            this.数据区.TabIndex = 5;
            this.数据区.TabStop = false;
            this.数据区.Text = "数据区";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1170, 609);
            this.dataGridView1.TabIndex = 2;
            // 
            // LossFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 747);
            this.Controls.Add(this.数据区);
            this.Controls.Add(this.excelImprot);
            this.Name = "LossFilter";
            this.Text = "LossFilter";
            this.数据区.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button excelImprot;
        private System.Windows.Forms.GroupBox 数据区;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}