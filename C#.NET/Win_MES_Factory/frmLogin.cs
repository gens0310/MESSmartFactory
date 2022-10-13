using MESFactoryVO;
using System;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using Win_MES_Factory.Services;
using Win_MES_Factory.Utility;
using WinMSFactory;

namespace Win_MES_Factory
{
    public partial class frmLogin : Form
    {
        EmpService employeeService = new EmpService();

        public EmpVO Employee { get; set; }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnadminLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string employee_id = txtadminID.Text.Trim();
                string employee_pwd = txtadminPwd.Text.Trim();

                Employee = employeeService.GetLoginEmployee(employee_id, employee_pwd);

                if (Employee != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("로그인에 실패했습니다. ID혹은 비밀번호를 확인해주세요.");
                    txtadminPwd.Focus();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtadminID.Text = "0";
            txtadminPwd.Text = "1234";
            btnadminLogin.PerformClick();
        }

        private void txtadminPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnadminLogin_Click(sender, e);
        }

        private void txtadminID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnadminLogin_Click(sender, e);
        }
    }
}