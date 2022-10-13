namespace Win_MES_Factory
{
    partial class frmOrderItem
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboItem = new System.Windows.Forms.ComboBox();
            this.cboFactory = new System.Windows.Forms.ComboBox();
            this.lblChartname = new System.Windows.Forms.Label();
            this.chItem = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnDate = new WinMSFactory.ButtonControl();
            this.dgvOrder = new Win_MES_Factory.MyControl.DataGridViewControl();
            this.fromToDateControl1 = new WinMSFactory.Control.FromToDateControl();
            ((System.ComponentModel.ISupportInitialize)(this.chItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(230, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 41;
            this.label6.Text = "품목";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(467, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 40;
            this.label3.Text = "작업지시일자";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 39;
            this.label2.Text = "공장";
            // 
            // cboItem
            // 
            this.cboItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItem.FormattingEnabled = true;
            this.cboItem.Location = new System.Drawing.Point(277, 121);
            this.cboItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(115, 20);
            this.cboItem.TabIndex = 38;
            // 
            // cboFactory
            // 
            this.cboFactory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFactory.FormattingEnabled = true;
            this.cboFactory.Location = new System.Drawing.Point(75, 121);
            this.cboFactory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboFactory.Name = "cboFactory";
            this.cboFactory.Size = new System.Drawing.Size(115, 20);
            this.cboFactory.TabIndex = 37;
            // 
            // lblChartname
            // 
            this.lblChartname.AutoSize = true;
            this.lblChartname.BackColor = System.Drawing.Color.FloralWhite;
            this.lblChartname.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblChartname.Location = new System.Drawing.Point(12, 577);
            this.lblChartname.Name = "lblChartname";
            this.lblChartname.Size = new System.Drawing.Size(170, 24);
            this.lblChartname.TabIndex = 45;
            this.lblChartname.Text = "불량 정상 차트";
            // 
            // chItem
            // 
            chartArea1.Name = "ChartArea1";
            this.chItem.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chItem.Legends.Add(legend1);
            this.chItem.Location = new System.Drawing.Point(12, 604);
            this.chItem.Name = "chItem";
            this.chItem.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "정상";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "불량";
            this.chItem.Series.Add(series1);
            this.chItem.Series.Add(series2);
            this.chItem.Size = new System.Drawing.Size(1534, 300);
            this.chItem.TabIndex = 0;
            // 
            // btnDate
            // 
            this.btnDate.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDate.FlatAppearance.BorderSize = 0;
            this.btnDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDate.ForeColor = System.Drawing.Color.Black;
            this.btnDate.Location = new System.Drawing.Point(758, 119);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(127, 23);
            this.btnDate.TabIndex = 44;
            this.btnDate.Text = "날짜별 차트 조회";
            this.btnDate.UseVisualStyleBackColor = false;
            this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
            // 
            // dgvOrder
            // 
            this.dgvOrder.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvOrder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrder.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrder.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrder.IsAllCheckColumnHeader = false;
            this.dgvOrder.IsAutoGenerateColumns = false;
            this.dgvOrder.Location = new System.Drawing.Point(12, 173);
            this.dgvOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvOrder.MultiSelect = false;
            this.dgvOrder.Name = "dgvOrder";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOrder.RowHeadersVisible = false;
            this.dgvOrder.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dgvOrder.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOrder.RowTemplate.Height = 23;
            this.dgvOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrder.Size = new System.Drawing.Size(1545, 297);
            this.dgvOrder.TabIndex = 43;
            this.dgvOrder.TabStop = false;
            // 
            // fromToDateControl1
            // 
            this.fromToDateControl1.From = new System.DateTime(2022, 10, 12, 9, 57, 23, 770);
            this.fromToDateControl1.Location = new System.Drawing.Point(550, 116);
            this.fromToDateControl1.Name = "fromToDateControl1";
            this.fromToDateControl1.Size = new System.Drawing.Size(202, 30);
            this.fromToDateControl1.TabIndex = 42;
            this.fromToDateControl1.To = new System.DateTime(2022, 10, 13, 9, 57, 23, 770);
            // 
            // frmOrderItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1569, 981);
            this.ControlBox = false;
            this.Controls.Add(this.chItem);
            this.Controls.Add(this.lblChartname);
            this.Controls.Add(this.btnDate);
            this.Controls.Add(this.dgvOrder);
            this.Controls.Add(this.fromToDateControl1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboItem);
            this.Controls.Add(this.cboFactory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOrderItem";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmOrderItem";
            this.Activated += new System.EventHandler(this.frmOrderItem_Activated);
            this.Load += new System.EventHandler(this.frmOrderItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinMSFactory.ButtonControl btnDate;
        private MyControl.DataGridViewControl dgvOrder;
        private WinMSFactory.Control.FromToDateControl fromToDateControl1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboItem;
        private System.Windows.Forms.ComboBox cboFactory;
        private System.Windows.Forms.Label lblChartname;
        private System.Windows.Forms.DataVisualization.Charting.Chart chItem;
    }
}