using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MESFactoryVO;
using Win_MES_Factory.Services;
using Win_MES_Factory.Utility;
using WinMSFactory;


namespace Win_MES_Factory
{
    public partial class frmOrdPopup : Form
    {
        frmOrderManage frmOrder = new frmOrderManage();
        OrderService orderService = new OrderService();
        EmpVO empVO;
        DataTable toDoesDt;
        public frmOrdPopup(EmpVO empVO)
        {

            InitializeComponent();
            this.empVO = empVO; 

        }

        private void frmOrdPopup_Load(object sender, EventArgs e)
        {
            cboFactory.ComboBinding(orderService.ComboFacGet(), "FacID", "FacNAME", "------선택------", "");
            cboLine.ComboBinding(orderService.ComboLineGet(), "LinID", "LinNAME", "------선택------", "");
            cboProcess.ComboBinding(orderService.ComboProGet(), "ProID", "ProNAME", "------선택------", "");
            cboEmp.ComboBinding(orderService.ComboEmpGet(), "EmpID", "EmpNAME", "------선택------", "");

            dgvContract.headerCheckBox.Visible = false;
            dgvContract.ColumnHeadersDefaultCellStyle.ForeColor = Color.LightBlue;
            dgvContract.ColumnHeadersHeight = 30;

   
            dgvContract.IsAllCheckColumnHeader = true;
            dgvContract.AddNewColumns("발주받은 순서", "ConID", 80, false);
            dgvContract.AddNewColumns("품목", "ItemID", 80, true);
            dgvContract.AddNewColumns("품명", "ItemNAME", 120, true);
            dgvContract.AddNewColumns("발주받은 날짜", "ConDATE", 170, true);
            dgvContract.AddNewColumns("작업지시등록상태", "ConUSE", 150, true);
            dgvContract.AddNewColumns("비고", "ConADD", 120, true);


            

            toDoesDt = orderService.GetToDoes();
            dgvContract.DataSource = null;
            dgvContract.DataSource = toDoesDt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboFactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string facID = cboFactory.SelectedValue.ToString();
            cboLine.ComboBinding(orderService.FactoryLinCombo(facID), "LinID", "LinNAME", "------선택------", "");
            cboEmp.ComboBinding(orderService.LineEmpCombo(facID), "EmpID", "EmpNAME", "------선택------", "");
        }

        private void cboLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            string linID = cboLine.SelectedValue.ToString();
            cboProcess.ComboBinding(orderService.LineProcessCombo(linID), "ProID", "ProNAME", "------선택------", "");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dgvContract.EndEdit();

            List<OrderVO> olist = new List<OrderVO>();
            List<int> cnt = new List<int>();

            foreach (DataGridViewRow row in dgvContract.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvContract[0, row.Index];

                if (chk.Value == null)
                    continue;

                else if ((bool)chk.Value == true)
                    cnt.Add(1);
            }

            if (cnt.Count < 1)
            {
                MessageBox.Show("작업지시 할 내역을 선택해주세요.");
                return;
            }

            for (int i = 0; i < dgvContract.RowCount; i++)
            {
                if (dgvContract.Rows[i].Cells[0].Value != null)
                {
                    bool IsCheck = (bool)dgvContract.Rows[i].Cells[0].Value;

                    if (IsCheck && dgvContract.Rows[i].Cells[1].Value != null)
                    {

                        OrderVO orderVO = new OrderVO();

                        orderVO.ProID = cboProcess.SelectedValue.ToString();
                        orderVO.EmpID = cboEmp.SelectedValue.ToString();
                        orderVO.ItemID = dgvContract.Rows[i].Cells[2].Value.ToString();
                        orderVO.OrdNAME = txtOrdName.Text.ToString();
                        orderVO.OrdDATE = Convert.ToDateTime((dgvContract.Rows[i].Cells[4].Value));
                        orderVO.OrdAMT = numericControl1.Value.ToInt();
                        orderVO.OrdCPLT = 0;
                        orderVO.OrdFLT = 0;
                        orderVO.WorkDATE = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                        
                        orderVO.FirstUSER = empVO.EmpNAME.ToString();
                        orderVO.LastUSER = empVO.EmpNAME.ToString();
                        orderVO.OrdADD = txtADD.Text.ToString();
                        orderVO.ConID = dgvContract.Rows[i].Cells[1].Value.ToInt();
                        olist.Add(orderVO);

                    }
                }
            }

            if (olist.Count > 0)
            {
                orderService.SaveOrder(olist);

                MessageBox.Show("작업지시 완료 되었습니다. ");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("작업지시 실패");
            }
        }
    }
}
