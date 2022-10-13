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
using System.Xml.Linq;
using Win_MES_Factory.Services;
using WinMSFactory;

namespace Win_MES_Factory
{
    public partial class frmFacPopup : Form
    {
        FacService service = new FacService();
        FactoryVO vo;
        bool IsDataExists;
        string employeeName;

        public frmFacPopup(string employeeName, bool IsDataExists, FactoryVO vo)
        {
            InitializeComponent();
            this.IsDataExists = IsDataExists;

            this.employeeName = employeeName;
            if (IsDataExists == true)
            {
                this.vo = vo;
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFacPopup_Load(object sender, EventArgs e)
        {

            if (IsDataExists == false)
            {
                btnOK.Text = "등록";
                rdoY.Checked = true;
            }
            else if (IsDataExists == true)
            {
                btnOK.Text = "수정";
                txtID.Enabled = false;

                if (vo.FacUSE == "Y")
                {
                    rdoY.Checked = true;
                    rdoN.Checked = false;
                }
                else
                {
                    rdoY.Checked = false;
                    rdoN.Checked = true;
                }

                txtID.Text = vo.FacID.ToString();
                txtName.Text = vo.FacNAME.ToString();
                numSeq.Value = vo.FacNUM;
                txtAdd.Text = vo.FacADD.ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.TextLength < 1)
                {
                    MessageBox.Show("공장 명을 입력해주세요");
                    return;
                }

                string UseCheck;

                if (rdoY.Checked == true)
                    UseCheck = "Y";
                else
                    UseCheck = "N";
                if (IsDataExists == false)
                    FacInsert(UseCheck, "등록", "");

                else
                    FacUpdate(UseCheck, "수정", vo.FacID);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        private void FacInsert(string UseCheck, string Status, string empID)
        {
            if (MessageBox.Show($"공장 정보를 {Status}하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                FactoryVO facvo = new FactoryVO
                {
                    FacID = txtID.Text.Trim(),
                    FacNAME = txtName.Text.ToString(),
                    FacUSE = UseCheck,
                    FacNUM = numSeq.Value.ToInt(),
                    FirstUSER = employeeName,
                    LastUSER = employeeName,
                    FacADD = txtAdd.Text

                };

                service.InsertFac(facvo);

                MessageBox.Show("정상적으로 등록되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
        }

        private void FacUpdate(string UseCheck, string Status, string empID)
        {
            if (MessageBox.Show($"공장 정보를 {Status}하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                FactoryVO facvo = new FactoryVO
                {
                    FacID = txtID.Text.Trim(),
                    FacNAME = txtName.Text.ToString(),
                    FacUSE = UseCheck,
                    FacNUM = numSeq.Value.ToInt(),
                    LastUSER = employeeName,
                    FacADD = txtAdd.Text

                };

                service.UpdateFac(facvo);

                MessageBox.Show("정상적으로 수정되었습니다.");
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
