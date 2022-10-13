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
    public partial class frmLine : Form
    {
        MainForm mainForm;

        DataTable dt;
        LineService lineService = new LineService();
        EmpService facService = new EmpService();
        public EmpVO Emp { get; set; }

        public frmLine()
        {
            InitializeComponent();
        }
   

        private void frmLine_Load(object sender, EventArgs e)
        {
            mainForm = (MainForm)this.MdiParent;
            mainForm.Search += Search;
            mainForm.Delete += Delete;
            mainForm.Add += Add;
            mainForm.Use += Use;
            mainForm.Reset += Clear;

            DataGridViewContentAlignment RightAlign = DataGridViewContentAlignment.MiddleRight;
            dgvLine.IsAllCheckColumnHeader = true;//0

            dgvLine.AddNewColumns("공장명", "facNAME", 100, true);//1
            dgvLine.AddNewColumns("라인코드", "linID", 100, true, true, false, RightAlign);//2
            dgvLine.AddNewColumns("라인명", "linNAME", 100, true);//3
            dgvLine.AddNewColumns("라인순번", "linNUM", 100, true);//4
            dgvLine.AddNewColumns("담당직원", "empNAME", 100, true);//5
            //dataGridViewControl1.AddNewBtnCol("사용여부", "", new Padding(1, 1, 1, 1), true); // 6 버튼
            dgvLine.AddNewColumns("사용여부", "linUSE", 100, true); //6
            dgvLine.AddNewColumns("최초등록시각", "firstTIME", 180, true);//7
            dgvLine.AddNewColumns("최초등록사원", "firstUSER", 180, true);//8
            dgvLine.AddNewColumns("최종등록시각", "lastTIME", 180, true);//9
            dgvLine.AddNewColumns("최종등록사원", "lastUSER", 180, true);//10
            dgvLine.AddNewColumns("라인비고", "linADD", 100, true);      //11
            dgvLine.AddNewColumns("직원아이디", "empID", 100, false);      //12
            dgvLine.AddNewColumns("공장코드", "facID", 100, false);      //13

            LoadData();

            cboFactory.ComboBinding(facService.ComboFacGet(), "FacID", "FacNAME", "-----전체-----", "");//, "전체", 0); 이게 왜 이렇게 작동??
            Emp = this.GetEmployee();
        }

        private void LoadData()
        {

            dt = lineService.GetAllLine();

            dgvLine.DataSource = null;
            dgvLine.DataSource = dt;
        }


        ///////////////////////////////////
        ///
        private void Search(object sender, EventArgs e)
        {
            if (mainForm.ActiveMdiChild == this)
            {
                // 할 작업
                string linName = txtLine.Text.Trim();
                LineVO vo = new LineVO()
                {
                    FacID = cboFactory.SelectedValue.ToString()
                };

                dt = lineService.SearchName(vo);

                DataView dv = dt.DefaultView;
                if (linName.Length > 0)
                {
                    dv.RowFilter = $"linName like '%{linName}%'";
                }
                dgvLine.DataSource = dv;
                DataTable dgvdt = dv.ToTable();
                dgvLine.DataSource = dgvdt;
            }
        }


        private void Clear(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                cboFactory.SelectedIndex = 0;
                txtLine.Text = "";
                LoadData();
            }
        }

        private void Add(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                frmLinePopup frm = new frmLinePopup(Emp.EmpNAME, false, null);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void Delete(object sender, EventArgs e)
        {

            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                if (MessageBox.Show("라인을 삭제 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                try
                {
                    dgvLine.EndEdit();

                    List<int> CheckList = new List<int>();

                    foreach (DataGridViewRow row in dgvLine.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvLine[0, row.Index];

                        if (chk.Value == null)
                            continue;

                        else if ((bool)chk.Value == true)
                            CheckList.Add(dgvLine[2, row.Index].Value.ToInt());

                    }

                    //int empid = Convert.ToInt32(dgvLine.SelectedRows[0].Cells[1].Value);

                    if (CheckList.Count > 0)
                    {
                        lineService.DeleteLine(CheckList);

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
                    dgvLine.EndEdit();

                    List<int> CheckList = new List<int>();
                    List<string> UseList = new List<string>();
                    foreach (DataGridViewRow row in dgvLine.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvLine[0, row.Index];

                        if (chk.Value == null)
                            continue;

                        else if ((bool)chk.Value == true)
                        {
                            CheckList.Add(dgvLine[2, row.Index].Value.ToInt());
                            UseList.Add(dgvLine[6, row.Index].Value.ToString());
                        }
                    }

                    int linid = Convert.ToInt32(dgvLine.SelectedRows[0].Cells[2].Value);

                    if (CheckList.Count > 0)
                    {
                        lineService.UseLinID(CheckList, UseList);

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

        private void dgvline_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvLine.Rows)
            {
                if (dgvLine[6, row.Index].Value.ToString() == "Y")
                    dgvLine[6, row.Index].Value = "사용";
                else if (dgvLine[6, row.Index].Value.ToString() == "N")
                    dgvLine[6, row.Index].Value = "미사용";
            }
        }

        

        private void frmLine_Activated(object sender, EventArgs e)
        {
            mainForm.TsbSearchVisible = true;
            mainForm.TsbDeleteVisible = true;
            mainForm.TsbAddVisible = true;
            mainForm.TsbUseVisible = true;
            mainForm.TsbClearVisible = true;

            mainForm.TsbSaveVisible = false;
            mainForm.TsbExcelVisible = false;
            mainForm.TsbPrintVisible = false;
        }

        private void txtLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search(sender, e);
        }
        private void OpenPopup(bool IsUpdate, LineVO vo = null)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                frmLinePopup frm = new frmLinePopup(Emp.EmpNAME, IsUpdate, vo);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void frmLine_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Search -= Search;
            mainForm.Delete -= Delete;
            mainForm.Add -= Add;
            mainForm.Use -= Use;
            mainForm.Reset -= Clear;
        }

        private void dgvLine_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex == 13)
                return;

            LineVO updatevo = new LineVO
            {
                LinID = dgvLine[2, e.RowIndex].Value.ToString(), //직원아이디
                FacID = dgvLine[13, e.RowIndex].Value.ToString(),
                EmpID = dgvLine[12, e.RowIndex].Value.ToString(),
                LinNAME = dgvLine[3, e.RowIndex].Value.ToString(),
                LinNUM = dgvLine[4, e.RowIndex].Value.ToInt(),
                LinUSE = dgvLine[6, e.RowIndex].Value.ToString(),
                LinADD = dgvLine[11, e.RowIndex].Value.ToString(),
                FirstUSER = Emp.EmpNAME,
                LastUSER = Emp.EmpNAME
            };
            if (dgvLine[6, e.RowIndex].Value.ToString() == "사용")
                updatevo.LinUSE = "Y";
            else
                updatevo.LinUSE = "N";

            OpenPopup(true, updatevo);
        }
    }
}
