using MESFactoryDAC;
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
using Win_MES_Factory.Utility;
using WinMSFactory;

namespace Win_MES_Factory
{
    public partial class frmOrderItem : Form
    {

        MainForm mainForm;
        OrderService orderService = new OrderService();
        List<OrderVO> orderVO;
        List<OrderVO> orderitemVO;
        DataTable dt;
        public EmpVO Emp { get; set; }

        public frmOrderItem()
        {
            InitializeComponent();
        }

        private void frmOrderItem_Load(object sender, EventArgs e)
        {
			mainForm = (MainForm)this.MdiParent;
			mainForm.Search += Search;
			mainForm.Reset += Clear;
            mainForm.Excel += Excel;

            DataGridViewContentAlignment RightAlign = DataGridViewContentAlignment.MiddleRight;

			try
			{
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
				dgvOrder.AddNewColumns("비고", "OrdADD", 100, true);


				fromToDateControl1.From = DateTime.Now.AddDays(-7);
				cboFactory.ComboBinding(orderService.ComboFacGet(), "FacID", "FacNAME", "-----전체-----", "");
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
                cboItem.SelectedIndex = 0;

                chItem.Series[0].Points.Clear();
                chItem.Series[1].Points.Clear();

                LoadData();
            }
        }

        private void Search(object sender, EventArgs e)
        {
            if (mainForm.ActiveMdiChild == this)
            {

                OrderVO vo = new OrderVO()
                {
                    FacID = cboFactory.SelectedValue.ToString(),
                    ItemID = cboItem.SelectedValue.ToString()
                };


                dt = orderService.SearchOrderItem(vo);

                DataView dv = dt.DefaultView;
                
                dgvOrder.DataSource = dv;
                DataTable dgvdt = dv.ToTable();
                List<EmpVO> sortData = SqlHelper.ConvertDataTableToList<EmpVO>(dt);
                dgvOrder.DataSource = sortData;
               
                dgvOrder.DataSource = dgvdt; //dt
                
            }
        }

        private void LoadData()
        {
            dt = orderService.GetAllOrderCode();

            dgvOrder.DataSource = null;
            dgvOrder.DataSource = dt;
        }


        private void ChartData(string from, string to, string facID, string itemID)
        {

            chItem.Series[0].Points.Clear();
            chItem.Series[1].Points.Clear();

            OrderVO vo = new OrderVO()
            {
                FacID = facID,
                ItemID = itemID
            };

            orderVO = orderService.SearchOrderItem2(vo);


            orderitemVO = orderService.GetChart(from, to, facID, itemID);

            foreach (var charbar in orderitemVO)
            {
                chItem.Series[0].Points.AddXY(charbar.WorkDATE.ToString("yyyy-MM-dd"), Convert.ToInt64(charbar.SumOrdCPLT));
                chItem.Series[1].Points.AddXY(charbar.WorkDATE.ToString("yyyy-MM-dd"), Convert.ToInt64(charbar.SumOrdFLT));
            }

        }

        private void frmOrderItem_Activated(object sender, EventArgs e)
        {
            // 공통적으로 써야 될 메서드
            // Tsb visible 다 false 하는 메서드 호출 할 것
            mainForm.TsbSearchVisible = true;
            mainForm.TsbClearVisible = true;
            mainForm.TsbExcelVisible = true;

            mainForm.TsbDeleteVisible = false;
            mainForm.TsbAddVisible = false;
            mainForm.TsbUseVisible = false;
            mainForm.TsbSaveVisible = false;
            
            mainForm.TsbPrintVisible = false;
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            string fromDate = fromToDateControl1.From.ToShortDateString();
            string toDate = fromToDateControl1.To.ToShortDateString();
            string facID = cboFactory.SelectedValue.ToString();
            string itemID = cboItem.SelectedValue.ToString();


            dgvOrder.DataSource = orderService.GetOrderListByDate(fromDate, toDate, facID, "", "", itemID);
            ChartData(fromDate, toDate, facID, itemID);
        }

        private void Excel(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                String[] columList = new string[19] { @"작업지시번호","작업지시이름","지시일자","작업일자","공장명칭","라인명칭",
                                   "공정명칭","작업자","품목명칭","지시수량","양품수량","불량수량","작업지시 상태","작업지시 상태",
                                    "최초등록시간","최초등록사원","최종등록시간","최종등록사원","비고"};
                dt = orderService.GetExcelOrders();

                ExcelUtil.DataTableToExcel(columList, dt);
            }
        }
    }
}
