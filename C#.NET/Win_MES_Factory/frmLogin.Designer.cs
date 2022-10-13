using Win_MES_Factory.Properties;

namespace Win_MES_Factory
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnadminLogin = new System.Windows.Forms.Button();
            this.txtadminPwd = new System.Windows.Forms.TextBox();
            this.txtadminID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightBlue;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(168, 131);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "취소";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnadminLogin
            // 
            this.btnadminLogin.BackColor = System.Drawing.Color.LightBlue;
            this.btnadminLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnadminLogin.BackgroundImage")));
            this.btnadminLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadminLogin.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadminLogin.ForeColor = System.Drawing.Color.Black;
            this.btnadminLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnadminLogin.Location = new System.Drawing.Point(46, 131);
            this.btnadminLogin.Name = "btnadminLogin";
            this.btnadminLogin.Size = new System.Drawing.Size(75, 23);
            this.btnadminLogin.TabIndex = 14;
            this.btnadminLogin.Text = "로그인";
            this.btnadminLogin.UseVisualStyleBackColor = true;
            this.btnadminLogin.Click += new System.EventHandler(this.btnadminLogin_Click);
            // 
            // txtadminPwd
            // 
            this.txtadminPwd.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtadminPwd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtadminPwd.Location = new System.Drawing.Point(143, 81);
            this.txtadminPwd.Name = "txtadminPwd";
            this.txtadminPwd.PasswordChar = '*';
            this.txtadminPwd.Size = new System.Drawing.Size(100, 21);
            this.txtadminPwd.TabIndex = 13;
            this.txtadminPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtadminPwd_KeyDown);
            // 
            // txtadminID
            // 
            this.txtadminID.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtadminID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtadminID.Location = new System.Drawing.Point(143, 38);
            this.txtadminID.Name = "txtadminID";
            this.txtadminID.Size = new System.Drawing.Size(100, 21);
            this.txtadminID.TabIndex = 12;
            this.txtadminID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtadminID_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "비밀번호";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "아이디";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(-2, -2);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 40);
            this.button1.TabIndex = 16;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(308, 185);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnadminLogin);
            this.Controls.Add(this.txtadminPwd);
            this.Controls.Add(this.txtadminID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "관리자로그인";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnadminLogin;
        private System.Windows.Forms.TextBox txtadminPwd;
        private System.Windows.Forms.TextBox txtadminID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}