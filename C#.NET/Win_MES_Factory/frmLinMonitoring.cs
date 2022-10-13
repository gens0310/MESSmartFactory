using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Win_MES_Factory.Services;
using Win_MES_Factory.Utility;
using WinMSFactory;

namespace Win_MES_Factory
{
    public partial class frmLinMonitoring : Form
    {
        MainForm mainForm;
        LinMonitoringService linemonitoringservice = new LinMonitoringService();
        DataTable dt;
        // 라인 이름
        string LINENAME;
        // 라인 상태
        string LINESTATUS;
        // 모니터링 상태 (0: 아직 시작 안 함, 1: 시작, 2: 종료)
        int monitoring_check = 0;
        public frmLinMonitoring()
        {
            InitializeComponent();
        }

        

        private void frmLinMonitoring_Load(object sender, EventArgs e)
        {
            mainForm = (MainForm)this.MdiParent;
            mainForm.Use += Use;

            DataGridViewContentAlignment RightAlign = DataGridViewContentAlignment.MiddleRight;
            this.dgvLinMonitoring.Font = new Font("Tahoma", 12, FontStyle.Regular);
            dgvLinMonitoring.IsAllCheckColumnHeader = true;
            dgvLinMonitoring.AddNewColumns("생산라인", "linNAME", 90, true, true, false, RightAlign);
            dgvLinMonitoring.AddNewColumns("제품명", "itemNAME", 110, true);
            dgvLinMonitoring.AddNewColumns("라인상태", "linUSE", 90, true);
            dgvLinMonitoring.AddNewColumns("비고", "linADD", 140, true);
            dgvLinMonitoring.AddNewColumns("작업자", "empNAME", 80, true);
            dgvLinMonitoring.AddNewColumns("라인코드", "linID", 80, false);
        }

        private void Use(object sender, EventArgs e)
        {

            if (((MainForm)this.MdiParent).ActiveMdiChild == this)
            {
                if (MessageBox.Show("사용전환 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                try
                {
                    dgvLinMonitoring.EndEdit();

                    List<int> CheckList = new List<int>();
                    List<string> UseList = new List<string>();
                    foreach (DataGridViewRow row in dgvLinMonitoring.Rows)
                    {
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvLinMonitoring[0, row.Index];

                        if (chk.Value == null)
                            continue;

                        else if ((bool)chk.Value == true)
                        {
                            CheckList.Add(dgvLinMonitoring[6, row.Index].Value.ToInt());
                            UseList.Add(dgvLinMonitoring[3, row.Index].Value.ToString());
                        }
                    }

                    int linid = Convert.ToInt32(dgvLinMonitoring.SelectedRows[0].Cells[6].Value);

                    if (CheckList.Count > 0)
                    {
                        linemonitoringservice.UseLinID(CheckList, UseList);

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

        private void frmLinMonitoring_Activated(object sender, EventArgs e)
        {
            mainForm.TsbSearchVisible = false;
            mainForm.TsbDeleteVisible = false;
            mainForm.TsbAddVisible = false;
            mainForm.TsbSaveVisible = false;
            mainForm.TsbClearVisible = false;
            mainForm.TsbExcelVisible = false;
            mainForm.TsbPrintVisible = false;
            mainForm.TsbUseVisible = true;
        }
        private void LoadData()
        {
            dt = linemonitoringservice.GetLinMonitoringCode();
            dgvLinMonitoring.DataSource = null;
            dgvLinMonitoring.DataSource = dt;
            foreach (DataRow rows in dt.Rows)
            {
                LINENAME = rows["linNAME"].ToString();
                LINESTATUS = rows["linUSE"].ToString();
                if (LINENAME == "조립라인")
                {
                    if (LINESTATUS == "Y")
                    {
                        Lin1OffPicBox.Visible = false;
                        Lin1OnPicBox.Visible = true;
                    }
                    else
                    {
                        Lin1OffPicBox.Visible = true;
                        Lin1OnPicBox.Visible = false;
                    }
                }
                else if (LINENAME == "생산라인")
                {
                    if (LINESTATUS == "Y")
                    {
                        Lin2OffPicBox.Visible = false;
                        Lin2OnPicBox.Visible = true;
                    }
                    else
                    {
                        Lin2OffPicBox.Visible = true;
                        Lin2OnPicBox.Visible = false;
                    }
                }
                else if (LINENAME == "도색라인")
                {
                    if (LINESTATUS == "Y")
                    {
                        Lin3OffPicBox.Visible = false;
                        Lin3OnPicBox.Visible = true;
                    }
                    else
                    {
                        Lin3OffPicBox.Visible = true;
                        Lin3OnPicBox.Visible = false;
                    }
                }
                else if (LINENAME == "시공라인")
                {
                    if (LINESTATUS == "Y")
                    {
                        Lin4OffPicBox.Visible = false;
                        Lin4OnPicBox.Visible = true;
                    }
                    else
                    {
                        Lin4OffPicBox.Visible = true;
                        Lin4OnPicBox.Visible = false;
                    }
                }
            }
        }
        private void Btn_Monitoring_Start_Click(object sender, EventArgs e)
        {
            // 1: 모니터링 시작
            monitoring_check = 1;
            while (monitoring_check == 1)
            {
                // 2초 간격으로 데이터테이블 로드
                LoadData();
                // 2: 모니터링 종료
                if (monitoring_check == 2) break;
                Delay(2000);
            }
        }
        private void Btn_Monitoring_Quit_Click(object sender, EventArgs e)
        {
            // 2: 모니터링 종료
            monitoring_check = 2;
        }
        public void Delay(int ms)
        {
            DateTime dateTimeNow = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, ms);
            DateTime dateTimeAdd = dateTimeNow.Add(duration);
            while (dateTimeAdd >= dateTimeNow)
            {
                Application.DoEvents();
                dateTimeNow = DateTime.Now;
            }
            return;
        }
    }
}