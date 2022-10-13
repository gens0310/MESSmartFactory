namespace Win_MES_Factory
{
    partial class frmLinMonitoring
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LINE_1 = new System.Windows.Forms.Label();
            this.LINE_3 = new System.Windows.Forms.Label();
            this.LINE_2 = new System.Windows.Forms.Label();
            this.LINE_4 = new System.Windows.Forms.Label();
            this.Btn_Monitoring_Quit = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dgvLinMonitoring = new Win_MES_Factory.MyControl.DataGridViewControl();
            this.Btn_Monitoring_Start = new System.Windows.Forms.Button();
            this.Lin4OffPicBox = new System.Windows.Forms.PictureBox();
            this.Lin3OffPicBox = new System.Windows.Forms.PictureBox();
            this.Lin2OffPicBox = new System.Windows.Forms.PictureBox();
            this.Lin1OffPicBox = new System.Windows.Forms.PictureBox();
            this.Lin4OnPicBox = new System.Windows.Forms.PictureBox();
            this.Lin3OnPicBox = new System.Windows.Forms.PictureBox();
            this.Lin2OnPicBox = new System.Windows.Forms.PictureBox();
            this.Lin1OnPicBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinMonitoring)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lin4OffPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lin3OffPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lin2OffPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lin1OffPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lin4OnPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lin3OnPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lin2OnPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lin1OnPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LINE_1
            // 
            this.LINE_1.AutoSize = true;
            this.LINE_1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.LINE_1.Location = new System.Drawing.Point(539, 81);
            this.LINE_1.Name = "LINE_1";
            this.LINE_1.Size = new System.Drawing.Size(61, 19);
            this.LINE_1.TabIndex = 5;
            this.LINE_1.Text = "LINE_1";
            // 
            // LINE_3
            // 
            this.LINE_3.AutoSize = true;
            this.LINE_3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.LINE_3.Location = new System.Drawing.Point(539, 329);
            this.LINE_3.Name = "LINE_3";
            this.LINE_3.Size = new System.Drawing.Size(61, 19);
            this.LINE_3.TabIndex = 6;
            this.LINE_3.Text = "LINE_3";
            // 
            // LINE_2
            // 
            this.LINE_2.AutoSize = true;
            this.LINE_2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.LINE_2.Location = new System.Drawing.Point(539, 206);
            this.LINE_2.Name = "LINE_2";
            this.LINE_2.Size = new System.Drawing.Size(61, 19);
            this.LINE_2.TabIndex = 7;
            this.LINE_2.Text = "LINE_2";
            // 
            // LINE_4
            // 
            this.LINE_4.AutoSize = true;
            this.LINE_4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.LINE_4.Location = new System.Drawing.Point(539, 453);
            this.LINE_4.Name = "LINE_4";
            this.LINE_4.Size = new System.Drawing.Size(61, 19);
            this.LINE_4.TabIndex = 8;
            this.LINE_4.Text = "LINE_4";
            // 
            // Btn_Monitoring_Quit
            // 
            this.Btn_Monitoring_Quit.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Btn_Monitoring_Quit.Location = new System.Drawing.Point(394, 413);
            this.Btn_Monitoring_Quit.Name = "Btn_Monitoring_Quit";
            this.Btn_Monitoring_Quit.Size = new System.Drawing.Size(111, 33);
            this.Btn_Monitoring_Quit.TabIndex = 14;
            this.Btn_Monitoring_Quit.Text = "모니터링 종료";
            this.Btn_Monitoring_Quit.UseVisualStyleBackColor = true;
            this.Btn_Monitoring_Quit.Click += new System.EventHandler(this.Btn_Monitoring_Quit_Click);
            // 
            // dgvLinMonitoring
            // 
            this.dgvLinMonitoring.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvLinMonitoring.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLinMonitoring.BackgroundColor = System.Drawing.Color.White;
            this.dgvLinMonitoring.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLinMonitoring.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLinMonitoring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLinMonitoring.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLinMonitoring.IsAllCheckColumnHeader = false;
            this.dgvLinMonitoring.IsAutoGenerateColumns = false;
            this.dgvLinMonitoring.Location = new System.Drawing.Point(38, 164);
            this.dgvLinMonitoring.MultiSelect = false;
            this.dgvLinMonitoring.Name = "dgvLinMonitoring";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLinMonitoring.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLinMonitoring.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.dgvLinMonitoring.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLinMonitoring.RowTemplate.Height = 23;
            this.dgvLinMonitoring.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLinMonitoring.Size = new System.Drawing.Size(467, 224);
            this.dgvLinMonitoring.TabIndex = 0;
            // 
            // Btn_Monitoring_Start
            // 
            this.Btn_Monitoring_Start.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Btn_Monitoring_Start.Location = new System.Drawing.Point(264, 413);
            this.Btn_Monitoring_Start.Name = "Btn_Monitoring_Start";
            this.Btn_Monitoring_Start.Size = new System.Drawing.Size(111, 33);
            this.Btn_Monitoring_Start.TabIndex = 15;
            this.Btn_Monitoring_Start.Text = "모니터링 시작";
            this.Btn_Monitoring_Start.UseVisualStyleBackColor = true;
            this.Btn_Monitoring_Start.Click += new System.EventHandler(this.Btn_Monitoring_Start_Click);
            // 
            // Lin4OffPicBox
            // 
            this.Lin4OffPicBox.Image = global::Win_MES_Factory.Properties.Resources.Conveyor1;
            this.Lin4OffPicBox.Location = new System.Drawing.Point(611, 413);
            this.Lin4OffPicBox.Name = "Lin4OffPicBox";
            this.Lin4OffPicBox.Size = new System.Drawing.Size(400, 100);
            this.Lin4OffPicBox.TabIndex = 12;
            this.Lin4OffPicBox.TabStop = false;
            this.Lin4OffPicBox.Visible = false;
            // 
            // Lin3OffPicBox
            // 
            this.Lin3OffPicBox.Image = global::Win_MES_Factory.Properties.Resources.Conveyor1;
            this.Lin3OffPicBox.Location = new System.Drawing.Point(611, 288);
            this.Lin3OffPicBox.Name = "Lin3OffPicBox";
            this.Lin3OffPicBox.Size = new System.Drawing.Size(400, 100);
            this.Lin3OffPicBox.TabIndex = 11;
            this.Lin3OffPicBox.TabStop = false;
            this.Lin3OffPicBox.Visible = false;
            // 
            // Lin2OffPicBox
            // 
            this.Lin2OffPicBox.Image = global::Win_MES_Factory.Properties.Resources.Conveyor1;
            this.Lin2OffPicBox.Location = new System.Drawing.Point(611, 164);
            this.Lin2OffPicBox.Name = "Lin2OffPicBox";
            this.Lin2OffPicBox.Size = new System.Drawing.Size(400, 100);
            this.Lin2OffPicBox.TabIndex = 10;
            this.Lin2OffPicBox.TabStop = false;
            this.Lin2OffPicBox.Visible = false;
            // 
            // Lin1OffPicBox
            // 
            this.Lin1OffPicBox.Image = global::Win_MES_Factory.Properties.Resources.Conveyor1;
            this.Lin1OffPicBox.Location = new System.Drawing.Point(611, 40);
            this.Lin1OffPicBox.Name = "Lin1OffPicBox";
            this.Lin1OffPicBox.Size = new System.Drawing.Size(400, 100);
            this.Lin1OffPicBox.TabIndex = 9;
            this.Lin1OffPicBox.TabStop = false;
            this.Lin1OffPicBox.Visible = false;
            // 
            // Lin4OnPicBox
            // 
            this.Lin4OnPicBox.Image = global::Win_MES_Factory.Properties.Resources.Conveyor;
            this.Lin4OnPicBox.Location = new System.Drawing.Point(611, 413);
            this.Lin4OnPicBox.Name = "Lin4OnPicBox";
            this.Lin4OnPicBox.Size = new System.Drawing.Size(400, 100);
            this.Lin4OnPicBox.TabIndex = 4;
            this.Lin4OnPicBox.TabStop = false;
            this.Lin4OnPicBox.Visible = false;
            // 
            // Lin3OnPicBox
            // 
            this.Lin3OnPicBox.Image = global::Win_MES_Factory.Properties.Resources.Conveyor;
            this.Lin3OnPicBox.Location = new System.Drawing.Point(611, 288);
            this.Lin3OnPicBox.Name = "Lin3OnPicBox";
            this.Lin3OnPicBox.Size = new System.Drawing.Size(400, 100);
            this.Lin3OnPicBox.TabIndex = 3;
            this.Lin3OnPicBox.TabStop = false;
            this.Lin3OnPicBox.Visible = false;
            // 
            // Lin2OnPicBox
            // 
            this.Lin2OnPicBox.Image = global::Win_MES_Factory.Properties.Resources.Conveyor;
            this.Lin2OnPicBox.Location = new System.Drawing.Point(611, 164);
            this.Lin2OnPicBox.Name = "Lin2OnPicBox";
            this.Lin2OnPicBox.Size = new System.Drawing.Size(400, 100);
            this.Lin2OnPicBox.TabIndex = 2;
            this.Lin2OnPicBox.TabStop = false;
            this.Lin2OnPicBox.Visible = false;
            // 
            // Lin1OnPicBox
            // 
            this.Lin1OnPicBox.Image = global::Win_MES_Factory.Properties.Resources.Conveyor;
            this.Lin1OnPicBox.Location = new System.Drawing.Point(611, 40);
            this.Lin1OnPicBox.Name = "Lin1OnPicBox";
            this.Lin1OnPicBox.Size = new System.Drawing.Size(400, 100);
            this.Lin1OnPicBox.TabIndex = 1;
            this.Lin1OnPicBox.TabStop = false;
            this.Lin1OnPicBox.Visible = false;
            // 
            // frmLinMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 557);
            this.ControlBox = false;
            this.Controls.Add(this.Btn_Monitoring_Start);
            this.Controls.Add(this.Btn_Monitoring_Quit);
            this.Controls.Add(this.Lin4OffPicBox);
            this.Controls.Add(this.Lin3OffPicBox);
            this.Controls.Add(this.Lin2OffPicBox);
            this.Controls.Add(this.Lin1OffPicBox);
            this.Controls.Add(this.LINE_4);
            this.Controls.Add(this.LINE_2);
            this.Controls.Add(this.LINE_3);
            this.Controls.Add(this.LINE_1);
            this.Controls.Add(this.Lin4OnPicBox);
            this.Controls.Add(this.Lin3OnPicBox);
            this.Controls.Add(this.Lin2OnPicBox);
            this.Controls.Add(this.Lin1OnPicBox);
            this.Controls.Add(this.dgvLinMonitoring);
            this.Font = new System.Drawing.Font("굴림", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLinMonitoring";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmLinMonitoring";
            this.Activated += new System.EventHandler(this.frmLinMonitoring_Activated);
            this.Load += new System.EventHandler(this.frmLinMonitoring_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinMonitoring)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lin4OffPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lin3OffPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lin2OffPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lin1OffPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lin4OnPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lin3OnPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lin2OnPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lin1OnPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyControl.DataGridViewControl dgvLinMonitoring;
        private System.Windows.Forms.PictureBox Lin1OnPicBox;
        private System.Windows.Forms.PictureBox Lin2OnPicBox;
        private System.Windows.Forms.PictureBox Lin3OnPicBox;
        private System.Windows.Forms.PictureBox Lin4OnPicBox;
        private System.Windows.Forms.Label LINE_1;
        private System.Windows.Forms.Label LINE_3;
        private System.Windows.Forms.Label LINE_2;
        private System.Windows.Forms.Label LINE_4;
        private System.Windows.Forms.PictureBox Lin1OffPicBox;
        private System.Windows.Forms.PictureBox Lin2OffPicBox;
        private System.Windows.Forms.PictureBox Lin3OffPicBox;
        private System.Windows.Forms.PictureBox Lin4OffPicBox;
        private System.Windows.Forms.Button Btn_Monitoring_Quit;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Btn_Monitoring_Start;
    }
}