using MESFactoryVO;
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
    public partial class frmLinePopup : Form
    {
        LineService service = new LineService();
        LineVO vo;
        bool IsDataExists;
        string employeeName;
        public frmLinePopup(string employeeName, bool IsDataExists, LineVO vo)
        {
            InitializeComponent();

            this.IsDataExists = IsDataExists;

            this.employeeName = employeeName;
            if (IsDataExists == true)
            {
                this.vo = vo;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.TextLength < 1)
                {
                    MessageBox.Show("라인을 입력해주세요");
                    return;
                }
                else if(txtlin.TextLength < 1)
                {
                    MessageBox.Show("라인을 입력해주세요");
                    return;
                }

                string UseCheck;

                if (rdoY.Checked == true)
                    UseCheck = "Y";
                else
                    UseCheck = "N";
                if (IsDataExists == false)
                    LineSave(UseCheck, "등록", "");

                else
                    LineSave(UseCheck, "수정", vo.LinID);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        private void LineSave(string UseCheck, string Status, string linID)
        {
            if (MessageBox.Show($"라인을 {Status}하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                LineVO line = new LineVO
                {
                    LinID = txtID.Text.Trim(),
                    LinNAME = txtlin.Text,
                    FacID = cboFac.SelectedValue.ToString(),
                    EmpID = cboEmp.SelectedValue.ToString(),
                    LinNUM = Convert.ToInt32((numSeq.Value.ToString().Length > 0) ? numSeq.Value.ToString() : "0"),
                    LinUSE = UseCheck,
                    FirstUSER = employeeName,
                    LastUSER = employeeName,                    
                    LinADD = txtAdd.Text
                };

                if (service.SaveLine(line))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLinePopup_Load(object sender, EventArgs e)
        {
            cboFac.ComboBinding(service.ComboFacGet(), "FacID", "FacNAME", "------전체------", "");

            if (IsDataExists == false)
            {
                btnOK.Text = "등록";
                rdoY.Checked = true;
            }
            else if (IsDataExists == true)
            {
                btnOK.Text = "수정";
                txtID.Enabled = false;
                cboFac.Enabled = false;

                if (vo.LinUSE == "Y")
                {
                    rdoY.Checked = true;
                    rdoN.Checked = false;
                }
                else
                {
                    rdoY.Checked = false;
                    rdoN.Checked = true;
                }

                txtID.Text = vo.LinID.ToString();
                txtlin.Text = vo.LinNAME.ToString();
                cboFac.SelectedValue = vo.FacID.ToString();
                cboEmp.SelectedValue = vo.EmpID.ToString();
                numSeq.Value = vo.LinNUM;
                txtAdd.Text = vo.LinADD.ToString();
            }
        }

        private void cboFac_SelectedIndexChanged(object sender, EventArgs e)
        {
            string facID = cboFac.SelectedValue.ToString();
            cboEmp.ComboBinding(service.FactoryEMPCombo(facID), "EmpID", "EmpNAME", "------전체------", "");
        }
    }
}
