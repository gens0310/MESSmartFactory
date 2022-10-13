namespace Win_MES_Factory
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbUse = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.tsbExcell = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbLogout = new System.Windows.Forms.ToolStripButton();
            this.tslEmpName = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbEmp = new System.Windows.Forms.ToolStripButton();
            this.tsbFactory = new System.Windows.Forms.ToolStripButton();
            this.tsbLine = new System.Windows.Forms.ToolStripButton();
            this.tsbProcess = new System.Windows.Forms.ToolStripButton();
            this.tsbItem = new System.Windows.Forms.ToolStripButton();
            this.tsbOrder = new System.Windows.Forms.ToolStripButton();
            this.tsbMoniter = new System.Windows.Forms.ToolStripButton();
            this.tsbProduct = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tsbOrderItem = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.tsbSearch,
            this.tsbAdd,
            this.tsbSave,
            this.tsbUse,
            this.tsbDelete,
            this.tsbClear,
            this.tsbExcell,
            this.tsbPrint,
            this.tsbLogout,
            this.tslEmpName});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1904, 77);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.BackgroundImage")));
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(112, 60);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // tsbSearch
            // 
            this.tsbSearch.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsbSearch.ForeColor = System.Drawing.Color.White;
            this.tsbSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearch.Image")));
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(38, 74);
            this.tsbSearch.Text = "조회";
            this.tsbSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSearch.Click += new System.EventHandler(this.tsbSearch_Click);
            // 
            // tsbAdd
            // 
            this.tsbAdd.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsbAdd.ForeColor = System.Drawing.Color.White;
            this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(38, 74);
            this.tsbAdd.Text = "추가";
            this.tsbAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsbSave.ForeColor = System.Drawing.Color.White;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(38, 74);
            this.tsbSave.Text = "저장";
            this.tsbSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbUse
            // 
            this.tsbUse.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsbUse.ForeColor = System.Drawing.Color.White;
            this.tsbUse.Image = ((System.Drawing.Image)(resources.GetObject("tsbUse.Image")));
            this.tsbUse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUse.Name = "tsbUse";
            this.tsbUse.Size = new System.Drawing.Size(64, 74);
            this.tsbUse.Text = "사용전환";
            this.tsbUse.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbUse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbUse.Click += new System.EventHandler(this.tsbUse_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsbDelete.ForeColor = System.Drawing.Color.White;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(38, 74);
            this.tsbDelete.Text = "삭제";
            this.tsbDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbClear
            // 
            this.tsbClear.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsbClear.ForeColor = System.Drawing.Color.White;
            this.tsbClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbClear.Image")));
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(51, 74);
            this.tsbClear.Text = "초기화";
            this.tsbClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbClear.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // tsbExcell
            // 
            this.tsbExcell.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsbExcell.ForeColor = System.Drawing.Color.White;
            this.tsbExcell.Image = ((System.Drawing.Image)(resources.GetObject("tsbExcell.Image")));
            this.tsbExcell.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExcell.Name = "tsbExcell";
            this.tsbExcell.Size = new System.Drawing.Size(38, 74);
            this.tsbExcell.Text = "엑셀";
            this.tsbExcell.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbExcell.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbExcell.Click += new System.EventHandler(this.tsbExcell_Click);
            // 
            // tsbPrint
            // 
            this.tsbPrint.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsbPrint.ForeColor = System.Drawing.Color.White;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(38, 74);
            this.tsbPrint.Text = "인쇄";
            this.tsbPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tsbLogout
            // 
            this.tsbLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbLogout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbLogout.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsbLogout.ForeColor = System.Drawing.Color.White;
            this.tsbLogout.Image = ((System.Drawing.Image)(resources.GetObject("tsbLogout.Image")));
            this.tsbLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLogout.Name = "tsbLogout";
            this.tsbLogout.Size = new System.Drawing.Size(64, 74);
            this.tsbLogout.Text = "로그아웃";
            this.tsbLogout.Click += new System.EventHandler(this.tsbLogout_Click);
            // 
            // tslEmpName
            // 
            this.tslEmpName.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslEmpName.ForeColor = System.Drawing.Color.White;
            this.tslEmpName.Name = "tslEmpName";
            this.tslEmpName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tslEmpName.Size = new System.Drawing.Size(71, 74);
            this.tslEmpName.Text = "로그인 정보";
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.Gray;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbEmp,
            this.tsbFactory,
            this.tsbLine,
            this.tsbProcess,
            this.tsbItem,
            this.tsbOrder,
            this.tsbMoniter,
            this.tsbProduct,
            this.tsbOrderItem});
            this.toolStrip2.Location = new System.Drawing.Point(0, 77);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(133, 964);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbEmp
            // 
            this.tsbEmp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbEmp.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsbEmp.ForeColor = System.Drawing.Color.White;
            this.tsbEmp.Image = ((System.Drawing.Image)(resources.GetObject("tsbEmp.Image")));
            this.tsbEmp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEmp.Name = "tsbEmp";
            this.tsbEmp.Size = new System.Drawing.Size(131, 29);
            this.tsbEmp.Text = "사원관리";
            this.tsbEmp.ToolTipText = "작업자관리";
            this.tsbEmp.Click += new System.EventHandler(this.tsbEmp_Click);
            // 
            // tsbFactory
            // 
            this.tsbFactory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbFactory.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsbFactory.ForeColor = System.Drawing.Color.White;
            this.tsbFactory.Image = ((System.Drawing.Image)(resources.GetObject("tsbFactory.Image")));
            this.tsbFactory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFactory.Name = "tsbFactory";
            this.tsbFactory.Size = new System.Drawing.Size(131, 29);
            this.tsbFactory.Text = "공장관리";
            this.tsbFactory.ToolTipText = "공장관리";
            this.tsbFactory.Click += new System.EventHandler(this.tsbFactory_Click);
            // 
            // tsbLine
            // 
            this.tsbLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbLine.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsbLine.ForeColor = System.Drawing.Color.White;
            this.tsbLine.Image = ((System.Drawing.Image)(resources.GetObject("tsbLine.Image")));
            this.tsbLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLine.Name = "tsbLine";
            this.tsbLine.Size = new System.Drawing.Size(131, 29);
            this.tsbLine.Text = "라인관리";
            this.tsbLine.ToolTipText = "라인관리";
            this.tsbLine.Click += new System.EventHandler(this.tsbLine_Click);
            // 
            // tsbProcess
            // 
            this.tsbProcess.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbProcess.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsbProcess.ForeColor = System.Drawing.Color.White;
            this.tsbProcess.Image = ((System.Drawing.Image)(resources.GetObject("tsbProcess.Image")));
            this.tsbProcess.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProcess.Name = "tsbProcess";
            this.tsbProcess.Size = new System.Drawing.Size(131, 29);
            this.tsbProcess.Text = "공정관리";
            this.tsbProcess.ToolTipText = "공정관리";
            this.tsbProcess.Click += new System.EventHandler(this.tsbProcess_Click);
            // 
            // tsbItem
            // 
            this.tsbItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbItem.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsbItem.ForeColor = System.Drawing.Color.White;
            this.tsbItem.Image = ((System.Drawing.Image)(resources.GetObject("tsbItem.Image")));
            this.tsbItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbItem.Name = "tsbItem";
            this.tsbItem.Size = new System.Drawing.Size(131, 29);
            this.tsbItem.Text = "제품관리";
            this.tsbItem.Click += new System.EventHandler(this.tsbItem_Click);
            // 
            // tsbOrder
            // 
            this.tsbOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOrder.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsbOrder.ForeColor = System.Drawing.Color.White;
            this.tsbOrder.Image = ((System.Drawing.Image)(resources.GetObject("tsbOrder.Image")));
            this.tsbOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOrder.Name = "tsbOrder";
            this.tsbOrder.Size = new System.Drawing.Size(131, 29);
            this.tsbOrder.Text = "작업관리";
            this.tsbOrder.ToolTipText = "작업관리";
            this.tsbOrder.Click += new System.EventHandler(this.tsbOrder_Click);
            // 
            // tsbMoniter
            // 
            this.tsbMoniter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbMoniter.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tsbMoniter.ForeColor = System.Drawing.Color.White;
            this.tsbMoniter.Image = ((System.Drawing.Image)(resources.GetObject("tsbMoniter.Image")));
            this.tsbMoniter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMoniter.Name = "tsbMoniter";
            this.tsbMoniter.Size = new System.Drawing.Size(131, 29);
            this.tsbMoniter.Text = "실시간모니터";
            this.tsbMoniter.Click += new System.EventHandler(this.tsbMoniter_Click);
            // 
            // tsbProduct
            // 
            this.tsbProduct.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbProduct.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold);
            this.tsbProduct.ForeColor = System.Drawing.Color.White;
            this.tsbProduct.Image = ((System.Drawing.Image)(resources.GetObject("tsbProduct.Image")));
            this.tsbProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProduct.Name = "tsbProduct";
            this.tsbProduct.Size = new System.Drawing.Size(131, 29);
            this.tsbProduct.Text = "실시간모니터2";
            this.tsbProduct.Click += new System.EventHandler(this.tsbProduct_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDateTime});
            this.statusStrip1.Location = new System.Drawing.Point(133, 1019);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1771, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblDateTime
            // 
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(33, 17);
            this.lblDateTime.Text = "Time";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // tsbOrderItem
            // 
            this.tsbOrderItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOrderItem.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold);
            this.tsbOrderItem.ForeColor = System.Drawing.Color.White;
            this.tsbOrderItem.Image = ((System.Drawing.Image)(resources.GetObject("tsbOrderItem.Image")));
            this.tsbOrderItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOrderItem.Name = "tsbOrderItem";
            this.tsbOrderItem.Size = new System.Drawing.Size(131, 29);
            this.tsbOrderItem.Text = "생산관리";
            this.tsbOrderItem.Click += new System.EventHandler(this.tsbOrderItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "+";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbSearch;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripButton tsbExcell;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbEmp;
        private System.Windows.Forms.ToolStripButton tsbFactory;
        private System.Windows.Forms.ToolStripButton tsbProcess;
        private System.Windows.Forms.ToolStripButton tsbLine;
        private System.Windows.Forms.ToolStripButton tsbOrder;
        private System.Windows.Forms.ToolStripButton tsbItem;
        private System.Windows.Forms.ToolStripButton tsbMoniter;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblDateTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton tsbLogout;
        private System.Windows.Forms.ToolStripLabel tslEmpName;
        private System.Windows.Forms.ToolStripButton tsbProduct;
        private System.Windows.Forms.ToolStripButton tsbUse;
        private System.Windows.Forms.ToolStripButton tsbOrderItem;
    }
}

