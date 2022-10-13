namespace MESFactoryPOP
{
    partial class frmPOP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOP));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbx_Line1_ON = new System.Windows.Forms.PictureBox();
            this.pbx_Line2_ON = new System.Windows.Forms.PictureBox();
            this.pbx_Line3_ON = new System.Windows.Forms.PictureBox();
            this.pbx_Line4_ON = new System.Windows.Forms.PictureBox();
            this.pbx_Line1_OFF = new System.Windows.Forms.PictureBox();
            this.pbx_Line2_OFF = new System.Windows.Forms.PictureBox();
            this.pbx_Line3_OFF = new System.Windows.Forms.PictureBox();
            this.pbx_Line4_OFF = new System.Windows.Forms.PictureBox();
            this.listView_Line1_ORDER = new System.Windows.Forms.ListView();
            this.btn_Line1_ON = new System.Windows.Forms.Button();
            this.btn_Line1_OFF = new System.Windows.Forms.Button();
            this.btn_Line2_ON = new System.Windows.Forms.Button();
            this.btn_Line3_ON = new System.Windows.Forms.Button();
            this.btn_Line4_ON = new System.Windows.Forms.Button();
            this.btn_Line2_OFF = new System.Windows.Forms.Button();
            this.btn_Line3_OFF = new System.Windows.Forms.Button();
            this.btn_Line4_OFF = new System.Windows.Forms.Button();
            this.listView_Line2_ORDER = new System.Windows.Forms.ListView();
            this.listView_Line3_ORDER = new System.Windows.Forms.ListView();
            this.listView_Line4_ORDER = new System.Windows.Forms.ListView();
            this.listView_Line1_WORK = new System.Windows.Forms.ListView();
            this.columnHeaderLine1FaultType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLine1FaultTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar_Line1 = new System.Windows.Forms.ProgressBar();
            this.progressBar_Line2 = new System.Windows.Forms.ProgressBar();
            this.listView_Line2_WORK = new System.Windows.Forms.ListView();
            this.columnHeaderLine2FaultType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLine2FaultTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar_Line3 = new System.Windows.Forms.ProgressBar();
            this.listView_Line3_WORK = new System.Windows.Forms.ListView();
            this.columnHeaderLine3FaultType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLine3FaultTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar_Line4 = new System.Windows.Forms.ProgressBar();
            this.listView_Line4_WORK = new System.Windows.Forms.ListView();
            this.columnHeaderLine4FaultType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLine4FaultTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.columnHeaderLine1ProName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLine1OrdName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLine1OrdAmt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLine2ProName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLine2OrdName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLine2OrdAmt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLine3ProName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLine3OrdName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLine3OrdAmt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLine4ProName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLine4OrdName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLine4OrdAmt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Line1_ON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Line2_ON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Line3_ON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Line4_ON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Line1_OFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Line2_OFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Line3_OFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Line4_OFF)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F);
            this.label1.Location = new System.Drawing.Point(20, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "LINE_1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18F);
            this.label2.Location = new System.Drawing.Point(20, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "LINE_2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 18F);
            this.label3.Location = new System.Drawing.Point(20, 393);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "LINE_3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 18F);
            this.label4.Location = new System.Drawing.Point(20, 543);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "LINE_4";
            // 
            // pbx_Line1_ON
            // 
            this.pbx_Line1_ON.Image = ((System.Drawing.Image)(resources.GetObject("pbx_Line1_ON.Image")));
            this.pbx_Line1_ON.Location = new System.Drawing.Point(117, 61);
            this.pbx_Line1_ON.Name = "pbx_Line1_ON";
            this.pbx_Line1_ON.Size = new System.Drawing.Size(400, 100);
            this.pbx_Line1_ON.TabIndex = 5;
            this.pbx_Line1_ON.TabStop = false;
            // 
            // pbx_Line2_ON
            // 
            this.pbx_Line2_ON.Image = ((System.Drawing.Image)(resources.GetObject("pbx_Line2_ON.Image")));
            this.pbx_Line2_ON.Location = new System.Drawing.Point(117, 211);
            this.pbx_Line2_ON.Name = "pbx_Line2_ON";
            this.pbx_Line2_ON.Size = new System.Drawing.Size(400, 100);
            this.pbx_Line2_ON.TabIndex = 6;
            this.pbx_Line2_ON.TabStop = false;
            // 
            // pbx_Line3_ON
            // 
            this.pbx_Line3_ON.Image = ((System.Drawing.Image)(resources.GetObject("pbx_Line3_ON.Image")));
            this.pbx_Line3_ON.Location = new System.Drawing.Point(117, 362);
            this.pbx_Line3_ON.Name = "pbx_Line3_ON";
            this.pbx_Line3_ON.Size = new System.Drawing.Size(400, 100);
            this.pbx_Line3_ON.TabIndex = 7;
            this.pbx_Line3_ON.TabStop = false;
            // 
            // pbx_Line4_ON
            // 
            this.pbx_Line4_ON.Image = ((System.Drawing.Image)(resources.GetObject("pbx_Line4_ON.Image")));
            this.pbx_Line4_ON.Location = new System.Drawing.Point(117, 513);
            this.pbx_Line4_ON.Name = "pbx_Line4_ON";
            this.pbx_Line4_ON.Size = new System.Drawing.Size(400, 100);
            this.pbx_Line4_ON.TabIndex = 8;
            this.pbx_Line4_ON.TabStop = false;
            // 
            // pbx_Line1_OFF
            // 
            this.pbx_Line1_OFF.Image = ((System.Drawing.Image)(resources.GetObject("pbx_Line1_OFF.Image")));
            this.pbx_Line1_OFF.Location = new System.Drawing.Point(117, 61);
            this.pbx_Line1_OFF.Name = "pbx_Line1_OFF";
            this.pbx_Line1_OFF.Size = new System.Drawing.Size(400, 100);
            this.pbx_Line1_OFF.TabIndex = 9;
            this.pbx_Line1_OFF.TabStop = false;
            // 
            // pbx_Line2_OFF
            // 
            this.pbx_Line2_OFF.Image = ((System.Drawing.Image)(resources.GetObject("pbx_Line2_OFF.Image")));
            this.pbx_Line2_OFF.Location = new System.Drawing.Point(117, 211);
            this.pbx_Line2_OFF.Name = "pbx_Line2_OFF";
            this.pbx_Line2_OFF.Size = new System.Drawing.Size(400, 100);
            this.pbx_Line2_OFF.TabIndex = 9;
            this.pbx_Line2_OFF.TabStop = false;
            // 
            // pbx_Line3_OFF
            // 
            this.pbx_Line3_OFF.Image = ((System.Drawing.Image)(resources.GetObject("pbx_Line3_OFF.Image")));
            this.pbx_Line3_OFF.Location = new System.Drawing.Point(117, 362);
            this.pbx_Line3_OFF.Name = "pbx_Line3_OFF";
            this.pbx_Line3_OFF.Size = new System.Drawing.Size(400, 100);
            this.pbx_Line3_OFF.TabIndex = 9;
            this.pbx_Line3_OFF.TabStop = false;
            // 
            // pbx_Line4_OFF
            // 
            this.pbx_Line4_OFF.Image = ((System.Drawing.Image)(resources.GetObject("pbx_Line4_OFF.Image")));
            this.pbx_Line4_OFF.Location = new System.Drawing.Point(117, 513);
            this.pbx_Line4_OFF.Name = "pbx_Line4_OFF";
            this.pbx_Line4_OFF.Size = new System.Drawing.Size(400, 100);
            this.pbx_Line4_OFF.TabIndex = 9;
            this.pbx_Line4_OFF.TabStop = false;
            // 
            // listView_Line1_ORDER
            // 
            this.listView_Line1_ORDER.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLine1ProName,
            this.columnHeaderLine1OrdName,
            this.columnHeaderLine1OrdAmt});
            this.listView_Line1_ORDER.HideSelection = false;
            this.listView_Line1_ORDER.Location = new System.Drawing.Point(693, 61);
            this.listView_Line1_ORDER.Name = "listView_Line1_ORDER";
            this.listView_Line1_ORDER.Size = new System.Drawing.Size(256, 100);
            this.listView_Line1_ORDER.TabIndex = 10;
            this.listView_Line1_ORDER.UseCompatibleStateImageBehavior = false;
            this.listView_Line1_ORDER.View = System.Windows.Forms.View.Details;
            // 
            // btn_Line1_ON
            // 
            this.btn_Line1_ON.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_Line1_ON.Location = new System.Drawing.Point(537, 61);
            this.btn_Line1_ON.Name = "btn_Line1_ON";
            this.btn_Line1_ON.Size = new System.Drawing.Size(132, 40);
            this.btn_Line1_ON.TabIndex = 11;
            this.btn_Line1_ON.Text = "LINE_1 ON";
            this.btn_Line1_ON.UseVisualStyleBackColor = true;
            this.btn_Line1_ON.Click += new System.EventHandler(this.btn_Line1_ON_Click);
            // 
            // btn_Line1_OFF
            // 
            this.btn_Line1_OFF.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_Line1_OFF.Location = new System.Drawing.Point(537, 121);
            this.btn_Line1_OFF.Name = "btn_Line1_OFF";
            this.btn_Line1_OFF.Size = new System.Drawing.Size(132, 40);
            this.btn_Line1_OFF.TabIndex = 12;
            this.btn_Line1_OFF.Text = "LINE_1 OFF";
            this.btn_Line1_OFF.UseVisualStyleBackColor = true;
            this.btn_Line1_OFF.Click += new System.EventHandler(this.btn_Line1_OFF_Click);
            // 
            // btn_Line2_ON
            // 
            this.btn_Line2_ON.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_Line2_ON.Location = new System.Drawing.Point(537, 211);
            this.btn_Line2_ON.Name = "btn_Line2_ON";
            this.btn_Line2_ON.Size = new System.Drawing.Size(132, 40);
            this.btn_Line2_ON.TabIndex = 13;
            this.btn_Line2_ON.Text = "LINE_2 ON";
            this.btn_Line2_ON.UseVisualStyleBackColor = true;
            this.btn_Line2_ON.Click += new System.EventHandler(this.btn_Line2_ON_Click);
            // 
            // btn_Line3_ON
            // 
            this.btn_Line3_ON.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_Line3_ON.Location = new System.Drawing.Point(537, 362);
            this.btn_Line3_ON.Name = "btn_Line3_ON";
            this.btn_Line3_ON.Size = new System.Drawing.Size(132, 40);
            this.btn_Line3_ON.TabIndex = 14;
            this.btn_Line3_ON.Text = "LINE_3 ON";
            this.btn_Line3_ON.UseVisualStyleBackColor = true;
            this.btn_Line3_ON.Click += new System.EventHandler(this.btn_Line3_ON_Click);
            // 
            // btn_Line4_ON
            // 
            this.btn_Line4_ON.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_Line4_ON.Location = new System.Drawing.Point(537, 513);
            this.btn_Line4_ON.Name = "btn_Line4_ON";
            this.btn_Line4_ON.Size = new System.Drawing.Size(132, 40);
            this.btn_Line4_ON.TabIndex = 15;
            this.btn_Line4_ON.Text = "LINE_4 ON";
            this.btn_Line4_ON.UseVisualStyleBackColor = true;
            this.btn_Line4_ON.Click += new System.EventHandler(this.btn_Line4_ON_Click);
            // 
            // btn_Line2_OFF
            // 
            this.btn_Line2_OFF.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_Line2_OFF.Location = new System.Drawing.Point(537, 271);
            this.btn_Line2_OFF.Name = "btn_Line2_OFF";
            this.btn_Line2_OFF.Size = new System.Drawing.Size(132, 40);
            this.btn_Line2_OFF.TabIndex = 16;
            this.btn_Line2_OFF.Text = "LINE_2 OFF";
            this.btn_Line2_OFF.UseVisualStyleBackColor = true;
            this.btn_Line2_OFF.Click += new System.EventHandler(this.btn_Line2_OFF_Click);
            // 
            // btn_Line3_OFF
            // 
            this.btn_Line3_OFF.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_Line3_OFF.Location = new System.Drawing.Point(537, 422);
            this.btn_Line3_OFF.Name = "btn_Line3_OFF";
            this.btn_Line3_OFF.Size = new System.Drawing.Size(132, 40);
            this.btn_Line3_OFF.TabIndex = 17;
            this.btn_Line3_OFF.Text = "LINE_3 OFF";
            this.btn_Line3_OFF.UseVisualStyleBackColor = true;
            this.btn_Line3_OFF.Click += new System.EventHandler(this.btn_Line3_OFF_Click);
            // 
            // btn_Line4_OFF
            // 
            this.btn_Line4_OFF.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btn_Line4_OFF.Location = new System.Drawing.Point(537, 573);
            this.btn_Line4_OFF.Name = "btn_Line4_OFF";
            this.btn_Line4_OFF.Size = new System.Drawing.Size(132, 40);
            this.btn_Line4_OFF.TabIndex = 18;
            this.btn_Line4_OFF.Text = "LINE_4 OFF";
            this.btn_Line4_OFF.UseVisualStyleBackColor = true;
            this.btn_Line4_OFF.Click += new System.EventHandler(this.btn_Line4_OFF_Click);
            // 
            // listView_Line2_ORDER
            // 
            this.listView_Line2_ORDER.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLine2ProName,
            this.columnHeaderLine2OrdName,
            this.columnHeaderLine2OrdAmt});
            this.listView_Line2_ORDER.HideSelection = false;
            this.listView_Line2_ORDER.Location = new System.Drawing.Point(693, 211);
            this.listView_Line2_ORDER.Name = "listView_Line2_ORDER";
            this.listView_Line2_ORDER.Size = new System.Drawing.Size(256, 100);
            this.listView_Line2_ORDER.TabIndex = 19;
            this.listView_Line2_ORDER.UseCompatibleStateImageBehavior = false;
            this.listView_Line2_ORDER.View = System.Windows.Forms.View.Details;
            // 
            // listView_Line3_ORDER
            // 
            this.listView_Line3_ORDER.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLine3ProName,
            this.columnHeaderLine3OrdName,
            this.columnHeaderLine3OrdAmt});
            this.listView_Line3_ORDER.HideSelection = false;
            this.listView_Line3_ORDER.Location = new System.Drawing.Point(693, 362);
            this.listView_Line3_ORDER.Name = "listView_Line3_ORDER";
            this.listView_Line3_ORDER.Size = new System.Drawing.Size(256, 100);
            this.listView_Line3_ORDER.TabIndex = 20;
            this.listView_Line3_ORDER.UseCompatibleStateImageBehavior = false;
            this.listView_Line3_ORDER.View = System.Windows.Forms.View.Details;
            // 
            // listView_Line4_ORDER
            // 
            this.listView_Line4_ORDER.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLine4ProName,
            this.columnHeaderLine4OrdName,
            this.columnHeaderLine4OrdAmt});
            this.listView_Line4_ORDER.HideSelection = false;
            this.listView_Line4_ORDER.Location = new System.Drawing.Point(693, 513);
            this.listView_Line4_ORDER.Name = "listView_Line4_ORDER";
            this.listView_Line4_ORDER.Size = new System.Drawing.Size(256, 100);
            this.listView_Line4_ORDER.TabIndex = 21;
            this.listView_Line4_ORDER.UseCompatibleStateImageBehavior = false;
            this.listView_Line4_ORDER.View = System.Windows.Forms.View.Details;
            // 
            // listView_Line1_WORK
            // 
            this.listView_Line1_WORK.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLine1FaultType,
            this.columnHeaderLine1FaultTime});
            this.listView_Line1_WORK.HideSelection = false;
            this.listView_Line1_WORK.Location = new System.Drawing.Point(972, 61);
            this.listView_Line1_WORK.Name = "listView_Line1_WORK";
            this.listView_Line1_WORK.Size = new System.Drawing.Size(256, 61);
            this.listView_Line1_WORK.TabIndex = 22;
            this.listView_Line1_WORK.UseCompatibleStateImageBehavior = false;
            this.listView_Line1_WORK.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderLine1FaultType
            // 
            this.columnHeaderLine1FaultType.Text = "불량 유형";
            this.columnHeaderLine1FaultType.Width = 70;
            // 
            // columnHeaderLine1FaultTime
            // 
            this.columnHeaderLine1FaultTime.Text = "발생 시간";
            this.columnHeaderLine1FaultTime.Width = 180;
            // 
            // progressBar_Line1
            // 
            this.progressBar_Line1.Location = new System.Drawing.Point(972, 137);
            this.progressBar_Line1.Name = "progressBar_Line1";
            this.progressBar_Line1.Size = new System.Drawing.Size(256, 23);
            this.progressBar_Line1.TabIndex = 23;
            // 
            // progressBar_Line2
            // 
            this.progressBar_Line2.Location = new System.Drawing.Point(972, 287);
            this.progressBar_Line2.Name = "progressBar_Line2";
            this.progressBar_Line2.Size = new System.Drawing.Size(256, 23);
            this.progressBar_Line2.TabIndex = 25;
            // 
            // listView_Line2_WORK
            // 
            this.listView_Line2_WORK.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLine2FaultType,
            this.columnHeaderLine2FaultTime});
            this.listView_Line2_WORK.HideSelection = false;
            this.listView_Line2_WORK.Location = new System.Drawing.Point(972, 211);
            this.listView_Line2_WORK.Name = "listView_Line2_WORK";
            this.listView_Line2_WORK.Size = new System.Drawing.Size(256, 61);
            this.listView_Line2_WORK.TabIndex = 24;
            this.listView_Line2_WORK.UseCompatibleStateImageBehavior = false;
            this.listView_Line2_WORK.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderLine2FaultType
            // 
            this.columnHeaderLine2FaultType.Text = "불량 유형";
            this.columnHeaderLine2FaultType.Width = 70;
            // 
            // columnHeaderLine2FaultTime
            // 
            this.columnHeaderLine2FaultTime.Text = "발생 시간";
            this.columnHeaderLine2FaultTime.Width = 180;
            // 
            // progressBar_Line3
            // 
            this.progressBar_Line3.Location = new System.Drawing.Point(972, 438);
            this.progressBar_Line3.Name = "progressBar_Line3";
            this.progressBar_Line3.Size = new System.Drawing.Size(256, 23);
            this.progressBar_Line3.TabIndex = 27;
            // 
            // listView_Line3_WORK
            // 
            this.listView_Line3_WORK.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLine3FaultType,
            this.columnHeaderLine3FaultTime});
            this.listView_Line3_WORK.HideSelection = false;
            this.listView_Line3_WORK.Location = new System.Drawing.Point(972, 362);
            this.listView_Line3_WORK.Name = "listView_Line3_WORK";
            this.listView_Line3_WORK.Size = new System.Drawing.Size(256, 61);
            this.listView_Line3_WORK.TabIndex = 26;
            this.listView_Line3_WORK.UseCompatibleStateImageBehavior = false;
            this.listView_Line3_WORK.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderLine3FaultType
            // 
            this.columnHeaderLine3FaultType.Text = "불량 유형";
            this.columnHeaderLine3FaultType.Width = 70;
            // 
            // columnHeaderLine3FaultTime
            // 
            this.columnHeaderLine3FaultTime.Text = "발생 시간";
            this.columnHeaderLine3FaultTime.Width = 180;
            // 
            // progressBar_Line4
            // 
            this.progressBar_Line4.Location = new System.Drawing.Point(972, 589);
            this.progressBar_Line4.Name = "progressBar_Line4";
            this.progressBar_Line4.Size = new System.Drawing.Size(256, 23);
            this.progressBar_Line4.TabIndex = 29;
            // 
            // listView_Line4_WORK
            // 
            this.listView_Line4_WORK.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLine4FaultType,
            this.columnHeaderLine4FaultTime});
            this.listView_Line4_WORK.HideSelection = false;
            this.listView_Line4_WORK.Location = new System.Drawing.Point(972, 513);
            this.listView_Line4_WORK.Name = "listView_Line4_WORK";
            this.listView_Line4_WORK.Size = new System.Drawing.Size(256, 61);
            this.listView_Line4_WORK.TabIndex = 28;
            this.listView_Line4_WORK.UseCompatibleStateImageBehavior = false;
            this.listView_Line4_WORK.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderLine4FaultType
            // 
            this.columnHeaderLine4FaultType.Text = "불량 유형";
            this.columnHeaderLine4FaultType.Width = 70;
            // 
            // columnHeaderLine4FaultTime
            // 
            this.columnHeaderLine4FaultTime.Text = "발생 시간";
            this.columnHeaderLine4FaultTime.Width = 180;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // columnHeaderLine1ProName
            // 
            this.columnHeaderLine1ProName.Text = "공정명";
            this.columnHeaderLine1ProName.Width = 70;
            // 
            // columnHeaderLine1OrdName
            // 
            this.columnHeaderLine1OrdName.Text = "작업지시명";
            this.columnHeaderLine1OrdName.Width = 80;
            // 
            // columnHeaderLine1OrdAmt
            // 
            this.columnHeaderLine1OrdAmt.Text = "작업지시수량";
            this.columnHeaderLine1OrdAmt.Width = 100;
            // 
            // columnHeaderLine2ProName
            // 
            this.columnHeaderLine2ProName.Text = "공정명";
            this.columnHeaderLine2ProName.Width = 70;
            // 
            // columnHeaderLine2OrdName
            // 
            this.columnHeaderLine2OrdName.Text = "작업지시명";
            this.columnHeaderLine2OrdName.Width = 80;
            // 
            // columnHeaderLine2OrdAmt
            // 
            this.columnHeaderLine2OrdAmt.Text = "작업지시수량";
            this.columnHeaderLine2OrdAmt.Width = 100;
            // 
            // columnHeaderLine3ProName
            // 
            this.columnHeaderLine3ProName.Text = "공정명";
            this.columnHeaderLine3ProName.Width = 70;
            // 
            // columnHeaderLine3OrdName
            // 
            this.columnHeaderLine3OrdName.Text = "작업지시명";
            this.columnHeaderLine3OrdName.Width = 80;
            // 
            // columnHeaderLine3OrdAmt
            // 
            this.columnHeaderLine3OrdAmt.Text = "작업지시수량";
            this.columnHeaderLine3OrdAmt.Width = 100;
            // 
            // columnHeaderLine4ProName
            // 
            this.columnHeaderLine4ProName.Text = "공정명";
            this.columnHeaderLine4ProName.Width = 70;
            // 
            // columnHeaderLine4OrdName
            // 
            this.columnHeaderLine4OrdName.Text = "작업지시명";
            this.columnHeaderLine4OrdName.Width = 80;
            // 
            // columnHeaderLine4OrdAmt
            // 
            this.columnHeaderLine4OrdAmt.Text = "작업지시수량";
            this.columnHeaderLine4OrdAmt.Width = 100;
            // 
            // frmPOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.progressBar_Line4);
            this.Controls.Add(this.listView_Line4_WORK);
            this.Controls.Add(this.progressBar_Line3);
            this.Controls.Add(this.listView_Line3_WORK);
            this.Controls.Add(this.progressBar_Line2);
            this.Controls.Add(this.listView_Line2_WORK);
            this.Controls.Add(this.progressBar_Line1);
            this.Controls.Add(this.listView_Line1_WORK);
            this.Controls.Add(this.listView_Line4_ORDER);
            this.Controls.Add(this.listView_Line3_ORDER);
            this.Controls.Add(this.listView_Line2_ORDER);
            this.Controls.Add(this.btn_Line4_OFF);
            this.Controls.Add(this.btn_Line3_OFF);
            this.Controls.Add(this.btn_Line2_OFF);
            this.Controls.Add(this.btn_Line4_ON);
            this.Controls.Add(this.btn_Line3_ON);
            this.Controls.Add(this.btn_Line2_ON);
            this.Controls.Add(this.btn_Line1_OFF);
            this.Controls.Add(this.btn_Line1_ON);
            this.Controls.Add(this.listView_Line1_ORDER);
            this.Controls.Add(this.pbx_Line4_OFF);
            this.Controls.Add(this.pbx_Line3_OFF);
            this.Controls.Add(this.pbx_Line2_OFF);
            this.Controls.Add(this.pbx_Line1_OFF);
            this.Controls.Add(this.pbx_Line4_ON);
            this.Controls.Add(this.pbx_Line3_ON);
            this.Controls.Add(this.pbx_Line2_ON);
            this.Controls.Add(this.pbx_Line1_ON);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmPOP";
            this.Text = "POP";
            this.Load += new System.EventHandler(this.frmPOP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Line1_ON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Line2_ON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Line3_ON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Line4_ON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Line1_OFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Line2_OFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Line3_OFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Line4_OFF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbx_Line1_ON;
        private System.Windows.Forms.PictureBox pbx_Line2_ON;
        private System.Windows.Forms.PictureBox pbx_Line3_ON;
        private System.Windows.Forms.PictureBox pbx_Line4_ON;
        private System.Windows.Forms.PictureBox pbx_Line1_OFF;
        private System.Windows.Forms.PictureBox pbx_Line2_OFF;
        private System.Windows.Forms.PictureBox pbx_Line3_OFF;
        private System.Windows.Forms.PictureBox pbx_Line4_OFF;
        private System.Windows.Forms.ListView listView_Line1_ORDER;
        private System.Windows.Forms.Button btn_Line1_ON;
        private System.Windows.Forms.Button btn_Line1_OFF;
        private System.Windows.Forms.Button btn_Line2_ON;
        private System.Windows.Forms.Button btn_Line3_ON;
        private System.Windows.Forms.Button btn_Line4_ON;
        private System.Windows.Forms.Button btn_Line2_OFF;
        private System.Windows.Forms.Button btn_Line3_OFF;
        private System.Windows.Forms.Button btn_Line4_OFF;
        private System.Windows.Forms.ListView listView_Line2_ORDER;
        private System.Windows.Forms.ListView listView_Line3_ORDER;
        private System.Windows.Forms.ListView listView_Line4_ORDER;
        private System.Windows.Forms.ListView listView_Line1_WORK;
        private System.Windows.Forms.ProgressBar progressBar_Line1;
        private System.Windows.Forms.ProgressBar progressBar_Line2;
        private System.Windows.Forms.ListView listView_Line2_WORK;
        private System.Windows.Forms.ProgressBar progressBar_Line3;
        private System.Windows.Forms.ListView listView_Line3_WORK;
        private System.Windows.Forms.ProgressBar progressBar_Line4;
        private System.Windows.Forms.ListView listView_Line4_WORK;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ColumnHeader columnHeaderLine1FaultType;
        private System.Windows.Forms.ColumnHeader columnHeaderLine1FaultTime;
        private System.Windows.Forms.ColumnHeader columnHeaderLine2FaultType;
        private System.Windows.Forms.ColumnHeader columnHeaderLine2FaultTime;
        private System.Windows.Forms.ColumnHeader columnHeaderLine3FaultType;
        private System.Windows.Forms.ColumnHeader columnHeaderLine3FaultTime;
        private System.Windows.Forms.ColumnHeader columnHeaderLine4FaultType;
        private System.Windows.Forms.ColumnHeader columnHeaderLine4FaultTime;
        private System.Windows.Forms.ColumnHeader columnHeaderLine1ProName;
        private System.Windows.Forms.ColumnHeader columnHeaderLine1OrdName;
        private System.Windows.Forms.ColumnHeader columnHeaderLine1OrdAmt;
        private System.Windows.Forms.ColumnHeader columnHeaderLine2ProName;
        private System.Windows.Forms.ColumnHeader columnHeaderLine2OrdName;
        private System.Windows.Forms.ColumnHeader columnHeaderLine2OrdAmt;
        private System.Windows.Forms.ColumnHeader columnHeaderLine3ProName;
        private System.Windows.Forms.ColumnHeader columnHeaderLine3OrdName;
        private System.Windows.Forms.ColumnHeader columnHeaderLine3OrdAmt;
        private System.Windows.Forms.ColumnHeader columnHeaderLine4ProName;
        private System.Windows.Forms.ColumnHeader columnHeaderLine4OrdName;
        private System.Windows.Forms.ColumnHeader columnHeaderLine4OrdAmt;
    }
}

