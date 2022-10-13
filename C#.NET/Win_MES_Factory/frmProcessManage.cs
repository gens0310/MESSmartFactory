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
    public partial class frmProcessManage : Form
    {
        public frmProcessManage()
        {
            InitializeComponent();
        }


        MainForm mainForm;

        DataTable dt;

        ProService proService = new ProService();
        EmpService facService = new EmpService();
        public EmpVO Emp { get; set; }


       

        private void LoadData()
        {

            dt = proService.GetAllPro();

            dgvProcess.DataSource = null;
            dgvProcess.DataSource = dt;
        }


        ///////////////////////////////////
        ///
       

        private void frmProcessManage_Load(object sender, EventArgs e)
        {
            cboFactory.ComboBinding(facService.ComboFacGet(), "FacID", "FacNAME", "-----전체-----", "");

            mainForm = (MainForm)this.MdiParent;
            mainForm.Search += Search;
            mainForm.Delete += Delete;
            mainForm.Add += Add;
            mainForm.Use += Use;
            mainForm.Reset += Clear;

            DataGridViewContentAlignment RightAlign = DataGridViewContentAlignment.MiddleRight;
            dgvProcess.IsAllCheckColumnHeader = true;//0

            dgvProcess.AddNewColumns("공장명", "facNAME", 100, true);//1
            dgvProcess.AddNewColumns("라인코드", "linID", 100, false);//2
            dgvProcess.AddNewColumns("라인명", "linNAME", 100, true);//3
            dgvProcess.AddNewColumns("공정코드", "proID", 100, false);//4
            dgvProcess.AddNewColumns("공정명", "proNAME", 100, true);//5
            dgvProcess.AddNewColumns("공정순번", "proNUM", 100, true);//6
            dgvProcess.AddNewColumns("사용여부", "proUSE", 100, true); //7
            dgvProcess.AddNewColumns("최초등록시각", "firstTIME", 180, true);//8
            dgvProcess.AddNewColumns("최초등록사원", "firstUSER", 180, true);//9
            dgvProcess.AddNewColumns("최종등록시각", "lastTIME", 180, true);//10
            dgvProcess.AddNewColumns("최종등록사원", "lastUSER", 180, true);//11
            dgvProcess.AddNewColumns("비고", "proADD", 180, true);//12

            LoadData();

            //, "전체", 0); 이게 왜 이렇게 작동??
            Emp = this.GetEmployee();
        }

        private void frmProcessManage_Activated(object sender, EventArgs e)
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

        private void txtProcess_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search(sender, e);
        }

        private void frmProcessManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Search -= Search;
            mainForm.Delete -= Delete;
            mainForm.Add -= Add;
            mainForm.Use -= Use;
            mainForm.Reset -= Clear;
        }

        private void dgvProcess_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvProcess.Rows)
            {
                if (dgvProcess[7, row.Index].Value.ToString() == "Y")
                    dgvProcess[7, row.Index].Value = "사용";
                else if (dgvProcess[7, row.Index].Value.ToString() == "N")
                    dgvProcess[7, row.Index].Value = "미사용";
            }
        }

        private void dgvProcess_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex == 13)
                return;

            ProVO updatevo = new ProVO
            {
                LinID = dgvProcess[2, e.RowIndex].Value.ToString(), //직원아이디
                ProID = dgvProcess[4, e.RowIndex].Value.ToString(),
                ProNAME = dgvProcess[5, e.RowIndex].Value.ToString(),
                ProNUM = dgvProcess[6, e.RowIndex].Value.ToInt(),
                ProADD = dgvProcess[12, e.RowIndex].Value.ToString(),
                FirstUSER = Emp.EmpNAME,
                LastUSER = Emp.EmpNAME
            };
            if (dgvProcess[7, e.RowIndex].Value.ToString() == "사용")
                updatevo.ProUSE = "Y";
            else
                updatevo.ProUSE = "N";

            OpenPopup(true, updatevo);
        }

        private void Search(object sender, EventArgs e)
        {
            if (mainForm.ActiveMdiChild == this)
            {
                // 할 작업
                string proName = txtProcess.Text.Trim();
                ProVO vo = new ProVO()
                {
                    FacID = cboFactory.SelectedValue.ToString(),
                    LinID = cboLine.SelectedValue.ToString()
                };

                dt = proService.SearchName(vo);

                DataView dv = dt.DefaultView;
                if (proName.Length > 0)
                {
                    dv.RowFilter = $"proName like '%{proName}%'";
                }
                dgvProcess.DataSource = dv;
                DataTable dgvdt = dv.ToTable();
                dgvProcess.DataSource = dgvdt;
            }
        }


        private void Clear(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                cboFactory.SelectedIndex = 0;
                cboLine.SelectedIndex = 0;
                txtProcess.Text = "";
                LoadData();
            }
        }

        private void Add(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                frmProPopup frm = new frmProPopup(Emp.EmpNAME, false, null);
                if (frm.ShowDialog() == DialogResult.OK)
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
                    dgvProcess.EndEdit();

                    List<int> CheckList = new List<int>();

                    foreach (DataGridViewRow row in dgvProcess.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvProcess[0, row.Index];

                        if (chk.Value == null)
                            continue;

                        else if ((bool)chk.Value == true)
                            CheckList.Add(dgvProcess[4, row.Index].Value.ToInt());

                    }

                    if (CheckList.Count > 0)
                    {
                        proService.DeletePro(CheckList);

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
                    dgvProcess.EndEdit();

                    List<int> CheckList = new List<int>();
                    List<string> UseList = new List<string>();
                    foreach (DataGridViewRow row in dgvProcess.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvProcess[0, row.Index];

                        if (chk.Value == null)
                            continue;

                        else if ((bool)chk.Value == true)
                        {
                            CheckList.Add(dgvProcess[4, row.Index].Value.ToInt());
                            UseList.Add(dgvProcess[7, row.Index].Value.ToString());
                        }
                    }

                    if (CheckList.Count > 0)
                    {
                        proService.UseProID(CheckList, UseList);

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

        private void OpenPopup(bool IsUpdate, ProVO vo = null)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                frmProPopup frm = new frmProPopup(Emp.EmpNAME, IsUpdate, vo);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void cboFactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string facID = cboFactory.SelectedValue.ToString();
            cboLine.ComboBinding(proService.FactoryLinCombo(facID), "LinID", "LinNAME", "------전체------", "");
        }
    }
}
