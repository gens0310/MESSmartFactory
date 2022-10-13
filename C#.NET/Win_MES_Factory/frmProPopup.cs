using MESFactoryVO;
using Org.BouncyCastle.Asn1.X500;
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
    public partial class frmProPopup : Form
    {
        ProService service = new ProService();
        //LineService lineservice = new LineService();
        ProVO vo;
        bool IsDataExists;
        string employeeName;

        public frmProPopup(string employeeName, bool IsDataExists, ProVO vo)
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
                else if (txtNAME.TextLength < 1)
                {
                    MessageBox.Show("라인을 입력해주세요");
                    return;
                }

                string UseCheck;

                if (radY.Checked == true)
                    UseCheck = "Y";
                else
                    UseCheck = "N";
                if (IsDataExists == false)
                    ProSave(UseCheck, "등록", "");

                else
                    ProSave(UseCheck, "수정", vo.LinID);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        private void ProSave(string UseCheck, string Status, string ProID)
        {
            if (MessageBox.Show($"공정을 {Status}하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                ProVO pro = new ProVO
                {
                    ProID = txtID.Text.Trim(),
                    ProNAME = txtNAME.Text,
                    //FacID = cboFac.SelectedValue.ToString(),
                    LinID = cboLine.SelectedValue.ToString(),
                    //EmpID = cboEmp.SelectedValue.ToString(),
                    ProNUM = Convert.ToInt32((numSeq.Value.ToString().Length > 0) ? numSeq.Value.ToString() : "0"),
                    ProUSE = UseCheck,
                    FirstUSER = employeeName,
                    LastUSER = employeeName,
                    ProADD = txtAdd.Text
                };

                if (service.SavePro(pro))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProPopup_Load(object sender, EventArgs e)
        {
            cboFac.ComboBinding(service.ComboFacGetPro(), "FacID", "FacNAME", "------전체------", "");

            if (IsDataExists == false)
            {
                btnOK.Text = "등록";
                radY.Checked = true;
            }
            else if (IsDataExists == true)
            {
                btnOK.Text = "수정";
                txtID.Enabled = false;
                cboFac.Enabled = false;

                if (vo.ProUSE == "Y")
                {
                    radY.Checked = true;
                    radN.Checked = false;
                }
                else
                {
                    radY.Checked = false;
                    radN.Checked = true;
                }

                txtID.Text = vo.ProID.ToString();
                txtNAME.Text = vo.ProNAME.ToString();
                cboFac.SelectedValue = vo.FacID.ToString();
                cboLine.SelectedValue = vo.LinID.ToString();
                //cboEmp.SelectedValue = vo.EmpID.ToString();
                numSeq.Value = vo.ProNUM;
                txtAdd.Text = vo.ProADD.ToString();
            }
        }

        private void cboFac_SelectedIndexChanged(object sender, EventArgs e)
        {
            string facID = cboFac.SelectedValue.ToString();
            cboLine.ComboBinding(service.FactoryLinCombo(facID), "LinID", "LinNAME", "------전체------", "");
        }

        //private void cboLin_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string facID = cboFac.SelectedValue.ToString();
        //    cboEmp.ComboBinding(lineservice.FactoryEMPCombo(facID), "EmpID", "EmpNAME", "------전체------", "");
        //}
    }
}
