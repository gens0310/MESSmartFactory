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
using Win_MES_Factory.Utility;
using WinMSFactory;
using MESFactoryDAC;
using MESFactoryVO;
using WinMSFactory.Control;

namespace Win_MES_Factory
{
    public partial class frmOrderManage : Form
    {

		MainForm mainForm;
		EmpService employeeService = new EmpService();
		OrderService orderService = new OrderService();

		DataTable dt;
        public EmpVO Emp { get; set; }



        public frmOrderManage()
        {
            InitializeComponent();
        }

        private void frmOrderManage_Load(object sender, EventArgs e)
        {

			mainForm = (MainForm)this.MdiParent;
			mainForm.Search += Search;
			mainForm.Delete += Delete;
			mainForm.Add += Add;
			mainForm.Reset += Clear;

			DataGridViewContentAlignment RightAlign = DataGridViewContentAlignment.MiddleRight;

			try
			{
				dgvOrder.IsAllCheckColumnHeader = true;
				dgvOrder.AddNewColumns("작업지시번호", "OrdID", 180, true);
				dgvOrder.AddNewColumns("작업지시이름", "OrdNAME", 180, true);
				dgvOrder.AddNewColumns("지시일자", "OrdDATE", 100, true);
				dgvOrder.AddNewColumns("작업일자", "WorkDATE", 100, true);
				dgvOrder.AddNewColumns("공장명칭", "FacNAME", 100, true);
				dgvOrder.AddNewColumns("라인명칭", "LinNAME", 100, true);
				dgvOrder.AddNewColumns("공정명칭", "ProNAME", 100, true);
				dgvOrder.AddNewColumns("작업자", "EmpNAME", 100, true);
				dgvOrder.AddNewColumns("품목명칭", "ItemNAME", 100, true);
				dgvOrder.AddNewColumns("지시수량", "OrdAMT", 100, true);//, true, false, DataGridViewContentAlignment.MiddleRight);
				dgvOrder.AddNewColumns("양품수량", "OrdCPLT", 100, true);//, true, false, DataGridViewContentAlignment.MiddleRight);
				dgvOrder.AddNewColumns("불량수량", "OrdFLT", 100, true);//, true, false, DataGridViewContentAlignment.MiddleRight);
                dgvOrder.AddNewColumns("작업지시 상태", "CommonNAME", 180, true);
                dgvOrder.AddNewColumns("작업지시 상태", "OrdSTATUS", 180, false);
				dgvOrder.AddNewColumns("최초등록시간", "FirstTIME", 180, true);
				dgvOrder.AddNewColumns("최초등록사원", "FirstUSER", 160, true);
				dgvOrder.AddNewColumns("최종등록시간", "LastTIME", 180, true);
				dgvOrder.AddNewColumns("최종등록사원", "LastUSER", 160, true);
				dgvOrder.AddNewColumns("비고", "OrdADD", 100);


                fromToDateControl1.From = DateTime.Now.AddDays(-7);
                cboFactory.ComboBinding(orderService.ComboFacGet(), "FacID", "FacNAME", "-----전체-----", "");
				cboLine.ComboBinding(orderService.ComboLineGet(), "LinID", "LinNAME", "-----전체-----", "");
				cboProcess.ComboBinding(orderService.ComboProGet(), "ProID", "ProNAME", "-----전체-----", "");
				cboItem.ComboBinding(orderService.ComboItemGet(), "ItemID", "ItemNAME", "-----전체-----", "");

				LoadData();
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}


		}

		private void Clear(object sender, EventArgs e)
		{
            if (mainForm.ActiveMdiChild == this)
            {
                fromToDateControl1.From = DateTime.Now.AddDays(-7);
                cboFactory.SelectedIndex = 0;
                cboLine.SelectedIndex = 0;
                cboProcess.SelectedIndex = 0;
                cboItem.SelectedIndex = 0;

                LoadData();
            }
        }

		private void Delete(object sender, EventArgs e)
		{
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                if (MessageBox.Show("공정을 삭제 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                try
                {
                    dgvOrder.EndEdit();

                    List<int> CheckList = new List<int>();

                    foreach (DataGridViewRow row in dgvOrder.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvOrder[0, row.Index];

                        if (chk.Value == null)
                            continue;

                        else if ((bool)chk.Value == true)
                            CheckList.Add(dgvOrder[1, row.Index].Value.ToInt());

                    }

                    if (CheckList.Count > 0)
                    {
                        orderService.OrderDelete(CheckList);

                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("다시 선택해주세요");
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

		public void LoadData()
		{
			dt = orderService.GetAllOrderCode();

			dgvOrder.DataSource = null;
			dgvOrder.DataSource = dt;
		}

		private void frmOrderManage_Activated(object sender, EventArgs e)
		{
			// 공통적으로 써야 될 메서드
			// Tsb visible 다 false 하는 메서드 호출 할 것
			mainForm.TsbSearchVisible = true;
			mainForm.TsbDeleteVisible = true;
			mainForm.TsbAddVisible = true;			
			mainForm.TsbClearVisible = true;

            mainForm.TsbUseVisible = false;
            mainForm.TsbSaveVisible = false;
			mainForm.TsbExcelVisible = false;
			mainForm.TsbPrintVisible = false;
		}


        private void Search(object sender, EventArgs e)
        {
            if (mainForm.ActiveMdiChild == this)
            {
                string empname = txtUser.Text.Trim();

                OrderVO vo = new OrderVO()
                {
                    FacID = cboFactory.SelectedValue.ToString(),
                    LinID = cboLine.SelectedValue.ToString(),
					ProID = cboProcess.SelectedValue.ToString(),
                    ItemID = cboItem.SelectedValue.ToString()

                };


                dt = orderService.SearchNameOrder(vo);

                DataView dv = dt.DefaultView;
                if (empname.Length > 0)
                {
                    dv.RowFilter = $"EmpName like '%{empname}%'";
                }


                dgvOrder.DataSource = dv;
                DataTable dgvdt = dv.ToTable();
                List<EmpVO> sortData = SqlHelper.ConvertDataTableToList<EmpVO>(dt);
                dgvOrder.DataSource = sortData;

                dgvOrder.DataSource = dgvdt; //dt
            }
        }

        private void Add(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
				EmpVO empVO = this.GetEmployee();
                frmOrdPopup frm = new frmOrdPopup(empVO);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

		private void cboFactory_SelectedIndexChanged(object sender, EventArgs e)
		{
            string facID = cboFactory.SelectedValue.ToString();
            cboLine.ComboBinding(orderService.FactoryLinCombo(facID), "LinID", "LinNAME", "------전체------", "");
        }

		private void cboLine_SelectedIndexChanged(object sender, EventArgs e)
		{
            string linID = cboLine.SelectedValue.ToString();
            cboProcess.ComboBinding(orderService.LineProcessCombo(linID), "ProID", "ProNAME", "------전체------", "");
        }

		private void btnDate_Click(object sender, EventArgs e)
		{

            string fromDate = fromToDateControl1.From.ToShortDateString();
            string toDate = fromToDateControl1.To.ToShortDateString();
			string facID = cboFactory.SelectedValue.ToString();
            string linID = cboLine.SelectedValue.ToString();
            string proID = cboProcess.SelectedValue.ToString();
            string itemID = cboItem.SelectedValue.ToString();

            dgvOrder.DataSource = orderService.GetOrderListByDate(fromDate, toDate, facID, linID, proID, itemID);
        }

        private void fromToDateControl1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
