using MESFactoryVO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win_MES_Factory.MyControl;
using Win_MES_Factory.Services;
using Win_MES_Factory.Utility;
using WinMSFactory;

namespace Win_MES_Factory
{
    public partial class frmFactory : Form
    {
        MainForm mainForm;
        DataTable dt;
        FacService factoryService = new FacService();
        public EmpVO Emp { get; set; }

        public frmFactory()
        {
            InitializeComponent();
        }

        private void frmFactory_Load(object sender, EventArgs e)
        {

            mainForm = (MainForm)this.MdiParent;
            mainForm.Search += Search;
            mainForm.Delete += Delete;
            mainForm.Add += Add;
            mainForm.Use += Use;
            mainForm.Reset += Clear;

            DataGridViewContentAlignment RightAlign = DataGridViewContentAlignment.MiddleRight;
            this.dgvFactory.Font = new Font("Tahoma", 12, FontStyle.Regular);

            dgvFactory.IsAllCheckColumnHeader = true; //0
            dgvFactory.AddNewColumns("공장 아이디", "facID", 160, true, true, false, RightAlign);//1
            dgvFactory.AddNewColumns("공장이름", "facNAME", 140, true);//2
            dgvFactory.AddNewColumns("공장순번", "facNUM", 110, true);//3
            dgvFactory.AddNewColumns("공장상태", "facUSE", 120, true);//4
            dgvFactory.AddNewColumns("최초 등록 시간", "firstTIME", 180, true);//5
            dgvFactory.AddNewColumns("최초 등록 사원", "firstUSER", 180, true);//6
            dgvFactory.AddNewColumns("최종 등록 시간", "lastTIME", 180, true);//7
            dgvFactory.AddNewColumns("최종 등록 사원", "lastUSER", 180, true);//8
            dgvFactory.AddNewColumns("비고", "facADD", 180, true);//9

            Emp = this.GetEmployee();
            LoadData();
        }

       

        private  void LoadData()
        {

            dt = factoryService.GetAllFacCode();

            dgvFactory.DataSource = null;
            dgvFactory.DataSource = dt;
        }

        private void frmFactory_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Search -= Search;
            mainForm.Delete -= Delete;
            mainForm.Add -= Add;
            mainForm.Use -= Use;
            mainForm.Reset -= Clear;
        }

        private void frmFactory_Activated(object sender, EventArgs e)
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

        private void Search(object sender, EventArgs e)
        {
            if (mainForm.ActiveMdiChild == this)
            {
                // 할 작업
                string facName = txtFac.Text.Trim();
                FactoryVO vo = new FactoryVO();

                dt = factoryService.SearchName(vo);

                DataView dv = dt.DefaultView;
                if (facName.Length > 0)
                {
                    dv.RowFilter = $"facName like '%{facName}%'";
                }
                dgvFactory.DataSource = dv;
                DataTable dgvdt = dv.ToTable();
                dgvFactory.DataSource = dgvdt;
            }
        }

        private void Clear(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                txtFac.Text = "";
                LoadData();
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
                    dgvFactory.EndEdit();

                    List<int> CheckList = new List<int>();
                    List<string> UseList = new List<string>();
                    foreach (DataGridViewRow row in dgvFactory.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvFactory[0, row.Index];

                        if (chk.Value == null)
                            continue;

                        else if ((bool)chk.Value == true)
                        {
                            CheckList.Add(dgvFactory[1, row.Index].Value.ToInt());
                            UseList.Add(dgvFactory[4, row.Index].Value.ToString());
                        }
                    }

                    int facid = Convert.ToInt32(dgvFactory.SelectedRows[0].Cells[1].Value);

                    if (CheckList.Count > 0)
                    {
                        factoryService.UseFacID(CheckList, UseList);

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

        private void Add(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                frmFacPopup frm = new frmFacPopup(Emp.EmpNAME, false, null);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void Delete(object sender, EventArgs e)
        {

            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                if (MessageBox.Show("공장을 삭제 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                try
                {
                    dgvFactory.EndEdit();

                    List<int> CheckList = new List<int>();

                    foreach (DataGridViewRow row in dgvFactory.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvFactory[0, row.Index];

                        if (chk.Value == null)
                            continue;

                        else if ((bool)chk.Value == true)
                            CheckList.Add(dgvFactory[1, row.Index].Value.ToInt());

                    }

                    int facid = Convert.ToInt32(dgvFactory.SelectedRows[0].Cells[1].Value);

                    if (CheckList.Count > 0)
                    {
                        factoryService.FacDelete(CheckList);

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

        private void OpenPopup(bool IsUpdate, FactoryVO vo = null)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                frmFacPopup frm = new frmFacPopup(Emp.EmpNAME, IsUpdate, vo);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void dgvFactory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvFactory.Rows)
            {
                if (dgvFactory[4, row.Index].Value.ToString() == "Y")
                    dgvFactory[4, row.Index].Value = "사용";
                else if (dgvFactory[4, row.Index].Value.ToString() == "N")
                    dgvFactory[4, row.Index].Value = "미사용";
            }
        }

        private void dgvFactory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex == 9)
                return;

            FactoryVO updatevo = new FactoryVO
            {
                FacID = dgvFactory[1, e.RowIndex].Value.ToString(),
                FacNAME = dgvFactory[2, e.RowIndex].Value.ToString(),
                FacNUM = dgvFactory[3, e.RowIndex].Value.ToInt(),
                FacADD = dgvFactory[9, e.RowIndex].Value.ToString(),
            };
            if (dgvFactory[4, e.RowIndex].Value.ToString() == "사용")
                updatevo.FacUSE = "Y";
            else
                updatevo.FacUSE = "N";

            OpenPopup(true, updatevo);
        }

        private void txtFac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search(sender, e);
        }
    }
}
