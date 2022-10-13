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
using MESFactoryVO;



namespace Win_MES_Factory
{
    public partial class frmItem : Form
    {
        MainForm mainForm;

        DataTable dt;
        ItemService itemService = new ItemService();

        public ItemVO Item { get; set; }
        public EmpVO Emp { get; set; }


        public frmItem()
        {
            InitializeComponent();
        }

        private void frmItem_Load(object sender, EventArgs e)
        {
            mainForm = (MainForm)this.MdiParent;
            mainForm.Search += Search;
            mainForm.Delete += Delete;
            mainForm.Add += Add;
            mainForm.Use += Use;
            mainForm.Reset += Clear;

            DataGridViewContentAlignment RightAlign = DataGridViewContentAlignment.MiddleRight;
            dataGridViewControl1.IsAllCheckColumnHeader = true;//0

            dataGridViewControl1.AddNewColumns("제품코드", "ItemID", 100, true);//1
            dataGridViewControl1.AddNewColumns("제품명", "ItemNAME", 100, true);//2
            dataGridViewControl1.AddNewColumns("순번", "ItemNUM", 100, true);//3
            dataGridViewControl1.AddNewColumns("제품상태", "ItemUSE", 100, true);//4
            dataGridViewControl1.AddNewColumns("최초등록시각", "FirstTIME", 180, true);//5
            dataGridViewControl1.AddNewColumns("최초등록사원", "FirstUSER", 180, true);//6
            dataGridViewControl1.AddNewColumns("최종등록시각", "LastTIME", 180, true);//7
            dataGridViewControl1.AddNewColumns("최종등록사원", "LastUSER", 180, true);//8
            dataGridViewControl1.AddNewColumns("제품비고", "ItemADD", 100, true);      //9
            dataGridViewControl1.AddNewColumns("직원아이디", "EmpID", 100, false);//10
            dataGridViewControl1.AddNewColumns("직원이름", "EmpNAME", 100, false);//11

            LoadData();

        }

        private void LoadData()
        {

            dt = itemService.GetAllItem();

            dataGridViewControl1.DataSource = null;
            dataGridViewControl1.DataSource = dt;
        }

        private void Search(object sender, EventArgs e)
        {
            if (mainForm.ActiveMdiChild == this)
            {
                // 할 작업
                string ItemName = txtNAME.Text.Trim();
                ItemVO vo = new ItemVO();
                //{
                //    FacID = cboFactory.SelectedValue.ToString()
                //};

                dt = itemService.SearchName(vo);

                DataView dv = dt.DefaultView;
                if (ItemName.Length > 0)
                {
                    dv.RowFilter = $"ItemName like '%{ItemName}%'";
                }
                dataGridViewControl1.DataSource = dv;
                DataTable dgvdt = dv.ToTable();
                dataGridViewControl1.DataSource = dgvdt;
            }
        }

        private void Clear(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                txtNAME.Text = "";
                LoadData();
            }
        }

        private void Add(object sender, EventArgs e)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                frmItemPopup frm = new frmItemPopup(Emp.EmpNAME, false, null);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void Delete(object sender, EventArgs e)
        {

            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                if (MessageBox.Show("제품을 삭제 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                try
                {
                    dataGridViewControl1.EndEdit();

                    List<int> CheckList = new List<int>();

                    foreach (DataGridViewRow row in dataGridViewControl1.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridViewControl1[0, row.Index];

                        if (chk.Value == null)
                            continue;

                        else if ((bool)chk.Value == true)
                            CheckList.Add(dataGridViewControl1[1, row.Index].Value.ToInt());

                    }

                    //int empid = Convert.ToInt32(dgvLine.SelectedRows[0].Cells[1].Value);

                    if (CheckList.Count > 0)
                    {
                        itemService.DeleteItem(CheckList);

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
                    dataGridViewControl1.EndEdit();

                    List<int> CheckList = new List<int>();
                    List<string> UseList = new List<string>();
                    foreach (DataGridViewRow row in dataGridViewControl1.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridViewControl1[0, row.Index];

                        if (chk.Value == null)
                            continue;

                        else if ((bool)chk.Value == true)
                        {
                            CheckList.Add(dataGridViewControl1[1, row.Index].Value.ToInt());
                            UseList.Add(dataGridViewControl1[4, row.Index].Value.ToString());
                        }
                    }

                    //int itemid = Convert.ToInt32(dataGridViewControl1.SelectedRows[0].Cells[2].Value);

                    if (CheckList.Count > 0)
                    {
                        itemService.UseItemID(CheckList, UseList);

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

        private void dgvItem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewControl1.Rows)
            {
                if (dataGridViewControl1[4, row.Index].Value.ToString() == "Y")
                    dataGridViewControl1[4, row.Index].Value = "사용";
                else if (dataGridViewControl1[4, row.Index].Value.ToString() == "N")
                    dataGridViewControl1[4, row.Index].Value = "미사용";
            }
        }

        private void frmItem_Activated(object sender, EventArgs e)
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

        private void txtItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search(sender, e);
        }

        private void OpenPopup(bool IsUpdate, ItemVO vo = null)
        {
            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                frmItemPopup frm = new frmItemPopup(Emp.EmpNAME, IsUpdate, vo);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void frmItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Search -= Search;
            mainForm.Delete -= Delete;
            mainForm.Add -= Add;
            mainForm.Use -= Use;
            mainForm.Reset -= Clear;
        }

        private void dgvItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex == 13)
                return;

            ItemVO updatevo = new ItemVO
            {
                ItemID = dataGridViewControl1[1, e.RowIndex].Value.ToString(), //직원아이디
                ItemNAME = dataGridViewControl1[2, e.RowIndex].Value.ToString(),
                ItemNUM = dataGridViewControl1[3, e.RowIndex].Value.ToInt(),
                ItemADD = dataGridViewControl1[9, e.RowIndex].Value.ToString(),
                //FirstUSER = Emp.EmpNAME,
                //LastUSER = Emp.EmpNAME
            };
            if (dataGridViewControl1[4, e.RowIndex].Value.ToString() == "사용")
                updatevo.ItemUSE = "Y";
            else
                updatevo.ItemUSE = "N";

            OpenPopup(true, updatevo);
        }

    }
}
