namespace Win_MES_Factory
{
    partial class frmItemMonitoring
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgvItemMonitoring = new Win_MES_Factory.MyControl.DataGridViewControl();
            this.NORMAL_ITEM_AMT = new System.Windows.Forms.Label();
            this.FAULT_ITEM_AMT = new System.Windows.Forms.Label();
            this.TxtBox_Normal = new System.Windows.Forms.TextBox();
            this.TxtBox_Fault = new System.Windows.Forms.TextBox();
            this.Chart_Fault = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Btn_Fault_Start = new System.Windows.Forms.Button();
            this.Btn_Fault_Quit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemMonitoring)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Fault)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItemMonitoring
            // 
            this.dgvItemMonitoring.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvItemMonitoring.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItemMonitoring.BackgroundColor = System.Drawing.Color.White;
            this.dgvItemMonitoring.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemMonitoring.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvItemMonitoring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItemMonitoring.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvItemMonitoring.IsAllCheckColumnHeader = false;
            this.dgvItemMonitoring.IsAutoGenerateColumns = false;
            this.dgvItemMonitoring.Location = new System.Drawing.Point(549, 92);
            this.dgvItemMonitoring.MultiSelect = false;
            this.dgvItemMonitoring.Name = "dgvItemMonitoring";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemMonitoring.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvItemMonitoring.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dgvItemMonitoring.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvItemMonitoring.RowTemplate.Height = 23;
            this.dgvItemMonitoring.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemMonitoring.Size = new System.Drawing.Size(405, 319);
            this.dgvItemMonitoring.TabIndex = 0;
            // 
            // NORMAL_ITEM_AMT
            // 
            this.NORMAL_ITEM_AMT.AutoSize = true;
            this.NORMAL_ITEM_AMT.Font = new System.Drawing.Font("Tahoma", 12F);
            this.NORMAL_ITEM_AMT.Location = new System.Drawing.Point(69, 44);
            this.NORMAL_ITEM_AMT.Name = "NORMAL_ITEM_AMT";
            this.NORMAL_ITEM_AMT.Size = new System.Drawing.Size(82, 19);
            this.NORMAL_ITEM_AMT.TabIndex = 11;
            this.NORMAL_ITEM_AMT.Text = "[정상 수량]";
            // 
            // FAULT_ITEM_AMT
            // 
            this.FAULT_ITEM_AMT.AutoSize = true;
            this.FAULT_ITEM_AMT.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FAULT_ITEM_AMT.Location = new System.Drawing.Point(348, 46);
            this.FAULT_ITEM_AMT.Name = "FAULT_ITEM_AMT";
            this.FAULT_ITEM_AMT.Size = new System.Drawing.Size(82, 19);
            this.FAULT_ITEM_AMT.TabIndex = 12;
            this.FAULT_ITEM_AMT.Text = "[불량 수량]";
            // 
            // TxtBox_Normal
            // 
            this.TxtBox_Normal.Location = new System.Drawing.Point(169, 44);
            this.TxtBox_Normal.Name = "TxtBox_Normal";
            this.TxtBox_Normal.Size = new System.Drawing.Size(115, 21);
            this.TxtBox_Normal.TabIndex = 13;
            // 
            // TxtBox_Fault
            // 
            this.TxtBox_Fault.Location = new System.Drawing.Point(450, 46);
            this.TxtBox_Fault.Name = "TxtBox_Fault";
            this.TxtBox_Fault.Size = new System.Drawing.Size(115, 21);
            this.TxtBox_Fault.TabIndex = 14;
            // 
            // Chart_Fault
            // 
            chartArea1.Name = "ChartArea1";
            this.Chart_Fault.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Chart_Fault.Legends.Add(legend1);
            this.Chart_Fault.Location = new System.Drawing.Point(73, 92);
            this.Chart_Fault.Name = "Chart_Fault";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.Chart_Fault.Series.Add(series1);
            this.Chart_Fault.Size = new System.Drawing.Size(408, 372);
            this.Chart_Fault.TabIndex = 15;
            this.Chart_Fault.Text = "불량 수량";
            // 
            // Btn_Fault_Start
            // 
            this.Btn_Fault_Start.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Btn_Fault_Start.Location = new System.Drawing.Point(610, 432);
            this.Btn_Fault_Start.Name = "Btn_Fault_Start";
            this.Btn_Fault_Start.Size = new System.Drawing.Size(115, 32);
            this.Btn_Fault_Start.TabIndex = 16;
            this.Btn_Fault_Start.Text = "모니터링 시작";
            this.Btn_Fault_Start.UseVisualStyleBackColor = true;
            this.Btn_Fault_Start.Click += new System.EventHandler(this.Btn_Fault_Start_Click);
            // 
            // Btn_Fault_Quit
            // 
            this.Btn_Fault_Quit.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Btn_Fault_Quit.Location = new System.Drawing.Point(785, 432);
            this.Btn_Fault_Quit.Name = "Btn_Fault_Quit";
            this.Btn_Fault_Quit.Size = new System.Drawing.Size(115, 32);
            this.Btn_Fault_Quit.TabIndex = 17;
            this.Btn_Fault_Quit.Text = "모니터링 종료";
            this.Btn_Fault_Quit.UseVisualStyleBackColor = true;
            this.Btn_Fault_Quit.Click += new System.EventHandler(this.Btn_Fault_Quit_Click);
            // 
            // frmItemMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 557);
            this.ControlBox = false;
            this.Controls.Add(this.Btn_Fault_Quit);
            this.Controls.Add(this.Btn_Fault_Start);
            this.Controls.Add(this.Chart_Fault);
            this.Controls.Add(this.TxtBox_Fault);
            this.Controls.Add(this.TxtBox_Normal);
            this.Controls.Add(this.FAULT_ITEM_AMT);
            this.Controls.Add(this.NORMAL_ITEM_AMT);
            this.Controls.Add(this.dgvItemMonitoring);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmItemMonitoring";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmLinMonitoring";
            this.Load += new System.EventHandler(this.frmLinMonitoring_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemMonitoring)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Fault)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyControl.DataGridViewControl dgvItemMonitoring;
        private System.Windows.Forms.Label NORMAL_ITEM_AMT;
        private System.Windows.Forms.Label FAULT_ITEM_AMT;
        private System.Windows.Forms.TextBox TxtBox_Normal;
        private System.Windows.Forms.TextBox TxtBox_Fault;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_Fault;
        private System.Windows.Forms.Button Btn_Fault_Start;
        private System.Windows.Forms.Button Btn_Fault_Quit;
    }
}