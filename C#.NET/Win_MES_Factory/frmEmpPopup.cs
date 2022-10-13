using MESFactoryVO;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win_MES_Factory.Services;
using WinMSFactory;

namespace Win_MES_Factory
{
    public partial class frmEmpPopup : Form
    {
        EmpService service = new EmpService();
        EmpVO vo;
        bool IsDataExists;
        string employeeName;

        public frmEmpPopup(string employeeName, bool IsDataExists, EmpVO vo)
        {
            InitializeComponent();

            this.IsDataExists = IsDataExists;

            this.employeeName = employeeName;
            if (IsDataExists == true)
            {
                this.vo = vo;
            }
        }

        private void frmEmpPopup_Load(object sender, EventArgs e)
        {
            cboFac.ComboBinding(service.ComboFacGet(), "FacID", "FacNAME", "------선택------", "");
            cboRank.ComboBinding(service.ComboRankGet(), "RankID", "RankNAME", "------선택------", "");

            if (IsDataExists == false)
                rdoY.Checked = true;

            else if (IsDataExists == true)
            {
                txtID.Enabled = false;
                cboFac.Enabled = false;

                if (vo.EmpUSE == "Y")
                {
                    rdoY.Checked = true;
                    rdoN.Checked = false;
                }
                else
                {
                    rdoY.Checked = false;
                    rdoN.Checked = true;
                }

                txtID.Text = vo.EmpID.ToString();
                txtName.Text = vo.EmpNAME.ToString();
                txtPW.Text = vo.EmpPW.ToString();
                txtRFID.Text = vo.EmpRFID.ToString();
                txtAdd.Text = vo.EmpADD.ToString();
                cboFac.SelectedIndex = cboFac.FindString(vo.FacName);
                cboRank.SelectedIndex = cboRank.FindString(vo.RankName);
            }

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.TextLength < 1)
                {
                    MessageBox.Show("사원을 입력해주세요");
                    return;
                }

                string UseCheck;

                if (rdoY.Checked == true)
                    UseCheck = "Y";
                else
                    UseCheck = "N";
                if (IsDataExists == false)
                    EmpSave(UseCheck, "등록", "");

                else
                    EmpSave(UseCheck, "수정", vo.EmpID);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        private void EmpSave(string UseCheck, string Status, string empID)
        {
            if (MessageBox.Show($"사원 정보를 {Status}하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                EmpVO empvo = new EmpVO
                {
                    EmpID = txtID.Text.Trim(),
                    FacID = cboFac.SelectedValue.ToString(),
                    RankID = cboRank.SelectedValue.ToString(),
                    EmpNAME = txtName.Text,
                    EmpUSE = UseCheck,
                    EmpRFID = txtRFID.Text,
                    EmpPW = txtPW.Text,
                    FirstUSER = employeeName,
                    LastUSER = employeeName,
                    EmpADD = txtAdd.Text
                    
                };

                    service.SaveEmp(empvo);
            
                    MessageBox.Show("정상적으로 저장되었습니다.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
           
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
