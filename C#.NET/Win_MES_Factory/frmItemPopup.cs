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
using MESFactoryVO;

namespace Win_MES_Factory
{
    public partial class frmItemPopup : Form
    {
        ItemService service = new ItemService();
        ItemVO vo;
        bool IsDataExists;
        string employeeName;
        //string itemName;


        public frmItemPopup(string employeeName, bool IsDataExists, ItemVO vo)
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
                    MessageBox.Show("제품ID을 입력해주세요");
                    return;
                }
                else if (txtNAME.TextLength < 1)
                {
                    MessageBox.Show("제품명을 입력해주세요");
                    return;
                }

                string UseCheck;

                if (radY.Checked == true)
                    UseCheck = "Y";
                else
                    UseCheck = "N";
                if (IsDataExists == false)
                    ItemSave(UseCheck, "등록", "");

                else
                    ItemSave(UseCheck, "수정", vo.ItemID);
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        private void ItemSave(string UseCheck, string Status, string ItemID)
        {
            if (MessageBox.Show($"제품을 {Status}하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                ItemVO item = new ItemVO
                {
                    ItemID = txtID.Text.Trim(),
                    ItemNAME = txtNAME.Text,
                    ItemNUM = Convert.ToInt32((numSeq.Value.ToString().Length > 0) ? numSeq.Value.ToString() : "0"),
                    ItemUSE = UseCheck,
                    FirstUSER = employeeName,
                    LastUSER = employeeName,
                    ItemADD = txtADD.Text
                };

                if (service.SaveItem(item))
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

        private void frmItemPopup_Load(object sender, EventArgs e)
        {

            if (IsDataExists == false)
            {
                btnOK.Text = "등록";
                radY.Checked = true;
            }
            else if (IsDataExists == true)
            {
                btnOK.Text = "수정";
                txtID.Enabled = false;
                //cboFac.Enabled = false;

                if (vo.ItemUSE == "Y")
                {
                    radY.Checked = true;
                    radN.Checked = false;
                }
                else
                {
                    radY.Checked = false;
                    radN.Checked = true;
                }

                txtID.Text = vo.ItemID.ToString();
                txtNAME.Text = vo.ItemNAME.ToString();
                numSeq.Value = vo.ItemNUM;
                txtADD.Text = vo.ItemADD.ToString();
            }
        }
    }
}
