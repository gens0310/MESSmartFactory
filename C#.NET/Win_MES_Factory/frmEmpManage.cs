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
    public partial class frmEmpManage : Form
    {
        MainForm mainForm;
        EmpService employeeService = new EmpService();
        DataTable dt;
        public EmpVO Emp { get; set; }


        public frmEmpManage()
        {
            InitializeComponent();
        }


        private void frmEmpManage_Load(object sender, EventArgs e)
        {

            mainForm = (MainForm)this.MdiParent;
            mainForm.Search += Search;
            mainForm.Delete += Delete;
            mainForm.Add += Add;
            mainForm.Use += Use;
            mainForm.Reset += Clear;
            mainForm.Excel += Excel;



            DataGridViewContentAlignment RightAlign = DataGridViewContentAlignment.MiddleRight;
            this.dgvEmp.Font = new Font("Tahoma", 12, FontStyle.Regular);

            cboFac.ComboBinding(employeeService.ComboFacGet(), "FacID", "FacNAME", "------전체------", "");
            cboRank.ComboBinding(employeeService.ComboRankGet(), "RankID", "RankNAME", "------전체------", "");

            dgvEmp.IsAllCheckColumnHeader = true; //0
            dgvEmp.AddNewColumns("직원ID", "EmpID", 100, true, true, false, RightAlign);//1
            dgvEmp.AddNewColumns("직원RFID", "EmpRFID", 140, true);//2
            dgvEmp.AddNewColumns("직원명", "EmpNAME", 110, true);//3
            dgvEmp.AddNewColumns("공장명", "FacName", 120, true);//4
            dgvEmp.AddNewColumns("직급", "RankName", 100, true);//5
            dgvEmp.AddNewColumns("사용유무", "EmpUSE", 120, true);//6
            dgvEmp.AddNewColumns("최초 등록 시간", "FirstTIME", 180, true);//7
            dgvEmp.AddNewColumns("최초 등록 사원", "FirstUSER", 180, true);//8
            dgvEmp.AddNewColumns("최종 등록 시간", "LastTIME", 180, true);//9
            dgvEmp.AddNewColumns("최종 등록 사원", "LastUSER", 180, true);//10
            dgvEmp.AddNewColumns("비고 사항", "EmpADD", 160, true);//11
            dgvEmp.AddNewColumns("비밀번호", "EmpPW", 160, false);//12
            dgvEmp.AddNewColumns("공장코드", "FacID", 120, false);//13
            dgvEmp.AddNewColumns("직급코드", "RankID", 100, false);//14
            dgvEmp.AddNewColumns("비밀번호", "EmpPW", 100, false);//15

            LoadData();
        }

        private void Excel(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                String[] columList = new string[15] { @"직원ID", "직원RFID" , "직원명" , "공장명" ,
                                                        "직급" , "사용유무" , "최초 등록 시간" , "최초 등록 사원",
                                                        "최종 등록 시간", "최종 등록 사원", "비고 사항", "비밀번호", "공장코드", "직급코드", "비밀번호"};
                dt = employeeService.GetAllEmpCode();

                ExcelUtil.DataTableToExcel(columList, dt);
            }
        }

        private void frmEmpManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Search -= Search;
            mainForm.Delete -= Delete;
            mainForm.Add -= Add;
            mainForm.Use -= Use;
            mainForm.Reset -= Clear;

        }

        private void frmEmpManage_Activated(object sender, EventArgs e)
        {
            // 공통적으로 써야 될 메서드
            // Tsb visible 다 false 하는 메서드 호출 할 것
            mainForm.TsbSearchVisible = true;            
            mainForm.TsbDeleteVisible = true;
            mainForm.TsbAddVisible = true;
            mainForm.TsbUseVisible = true;
            mainForm.TsbClearVisible = true;
            mainForm.TsbExcelVisible = true;

            mainForm.TsbSaveVisible = false;            
            mainForm.TsbExcelVisible = true;
            mainForm.TsbPrintVisible = false;
        }

        private void Search(object sender, EventArgs e)
        {
            if (mainForm.ActiveMdiChild == this)
            {
                string empname = txtEmpName.Text.Trim();

                EmpVO vo = new EmpVO()
                {
                    RankID = cboRank.SelectedValue.ToString(),
                    FacID = cboFac.SelectedValue.ToString()
                };
 

                dt = employeeService.SearchName(vo);

                DataView dv = dt.DefaultView;
                if (empname.Length > 0)
                {
                    dv.RowFilter = $"EmpName like '%{empname}%'";
                }


                dgvEmp.DataSource = dv;
                DataTable dgvdt = dv.ToTable();
                List<EmpVO> sortData = SqlHelper.ConvertDataTableToList<EmpVO>(dt);
                dgvEmp.DataSource = sortData;

                dgvEmp.DataSource = dgvdt; //dt
            }
        }

        private void Add(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                frmEmpPopup frm = new frmEmpPopup(Emp.EmpNAME, false, null);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void Delete(object sender, EventArgs e)
        {

            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                if (MessageBox.Show("사원을 삭제 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                try
                {
                    dgvEmp.EndEdit();

                    List<int> CheckList = new List<int>();

                    foreach (DataGridViewRow row in dgvEmp.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvEmp[0, row.Index];

                        if (chk.Value == null)
                            continue;

                        else if ((bool)chk.Value == true)
                           CheckList.Add(dgvEmp[1, row.Index].Value.ToInt());

                    }

                    int empid = Convert.ToInt32(dgvEmp.SelectedRows[0].Cells[1].Value);

                    if (CheckList.Count > 0)
                    {
                        employeeService.EmpDelete(CheckList);

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

        private void Use(object sender, EventArgs e)
        {

            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                if (MessageBox.Show("사용전환 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                try
                {
                    dgvEmp.EndEdit();

                    List<int> CheckList = new List<int>();
                    List<string> UseList = new List<string>();
                    foreach (DataGridViewRow row in dgvEmp.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvEmp[0, row.Index];

                        if (chk.Value == null)
                            continue;

                        else if ((bool)chk.Value == true)
                        { 
                            CheckList.Add(dgvEmp[1, row.Index].Value.ToInt());
                            UseList.Add(dgvEmp[6, row.Index].Value.ToString());
                        }
                    }

                    int empid = Convert.ToInt32(dgvEmp.SelectedRows[0].Cells[1].Value);

                    if (CheckList.Count > 0)
                    {
                        employeeService.UseEmpID(CheckList, UseList);

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

        private void LoadData()
        {
           
            dt = employeeService.GetAllEmpCode();

            dgvEmp.DataSource = null;
            dgvEmp.DataSource = dt;
        }

        private void Clear(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                cboFac.SelectedIndex = 0;
                cboRank.SelectedIndex = 0;
                txtEmpName.Text = "";
                LoadData();
            }
        }

       

        private void OpenPopup(bool IsUpdate, EmpVO vo = null)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                frmEmpPopup frm = new frmEmpPopup(Emp.EmpNAME, IsUpdate, vo);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }


        private void dgvEmp_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvEmp.Rows)
            {
                if (dgvEmp[6, row.Index].Value.ToString() == "Y")
                    dgvEmp[6, row.Index].Value = "사용";
                else if (dgvEmp[6, row.Index].Value.ToString() == "N")
                    dgvEmp[6, row.Index].Value = "미사용";
            }
        }

        /// <summary>
        /// 수정시 더블클릭 수정 가능 데이터 팝업창으로 보냄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEmp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex == 15)
                return;

            EmpVO updatevo = new EmpVO
            {
                EmpID = dgvEmp[1, e.RowIndex].Value.ToString() , //직원아이디
                EmpRFID = dgvEmp[2, e.RowIndex].Value.ToString(),
                EmpNAME = dgvEmp[3, e.RowIndex].Value.ToString(),
                FacID = dgvEmp[13, e.RowIndex].Value.ToString(),
                RankID = dgvEmp[14, e.RowIndex].Value.ToString(),
                EmpPW = dgvEmp[15, e.RowIndex].Value.ToString() ,
                EmpADD = dgvEmp[11, e.RowIndex].Value.ToString(),
                FacName = dgvEmp[4, e.RowIndex].Value.ToString(),
                RankName = dgvEmp[5, e.RowIndex].Value.ToString()
            };
            if (dgvEmp[4, e.RowIndex].Value.ToString() == "사용")            
                updatevo.EmpUSE = "Y";            
            else
                updatevo.EmpUSE = "N";

            OpenPopup(true, updatevo);
        }

        private void txtEmpName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search(sender, e);
        }
    }
}
