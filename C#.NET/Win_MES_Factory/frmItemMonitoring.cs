using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Win_MES_Factory.Services;
using Win_MES_Factory.Utility;
namespace Win_MES_Factory
{
    public partial class frmItemMonitoring : Form
    {
        MainForm mainForm;
        ItemMonitoringService itemmonitoringservice = new ItemMonitoringService();
        DataTable dt;
        // 제품 이름
        string ITEMNAME;
        // 모니터링 상태 (0: 아직 시작 안 함, 1: 시작, 2: 종료)
        int monitoring_check = 0;
        // 차트 값
        int v1, v2, v3, v4, v5, v6;
        public frmItemMonitoring()
        {
            InitializeComponent();
        }
        private void frmLinMonitoring_Load(object sender, EventArgs e)
        {
            mainForm = (MainForm)this.MdiParent;
            DataGridViewContentAlignment RightAlign = DataGridViewContentAlignment.MiddleRight;
            this.dgvItemMonitoring.Font = new Font("Tahoma", 12, FontStyle.Regular);
            dgvItemMonitoring.IsAllCheckColumnHeader = true;
            dgvItemMonitoring.AddNewColumns("제품명", "itemNAME", 110, true, true, false, RightAlign);
            dgvItemMonitoring.AddNewColumns("작업 지시", "ordNAME", 140, true);
            dgvItemMonitoring.AddNewColumns("불량 유형", "faulttypeNAME", 140, true);
        }
        private void frmItemMonitoring_Activated(object sender, EventArgs e)
        {
            mainForm.TsbSearchVisible = false;
            mainForm.TsbDeleteVisible = false;
            mainForm.TsbAddVisible = false;
            mainForm.TsbSaveVisible = false;
            mainForm.TsbClearVisible = false;
            mainForm.TsbExcelVisible = false;
            mainForm.TsbPrintVisible = false;
        }
        private void LoadData()
        {
            dt = itemmonitoringservice.GetItemMonitoringCode();
            dgvItemMonitoring.DataSource = null;
            dgvItemMonitoring.DataSource = dt;
            // 차트 값
            v1 = v2 = v3 = v4 = v5 = v6 = 0;
            // 정상 수량, 불량 수량 텍스트 박스
            TxtBox_Normal.Text = TxtBox_Fault.Text = "0";
            // 전체 수량
            int AMOUNT = 0;
            foreach (DataRow rows in dt.Rows)
            {
                // (작업 지시 전체 수량) - (실시간 불량 수량) = (실시간 정상 수량)
                AMOUNT += int.Parse(rows["ordAMT"].ToString());
                TxtBox_Fault.Text = dt.Rows.Count.ToString();
                TxtBox_Normal.Text = (AMOUNT - dt.Rows.Count).ToString();
                ITEMNAME = rows["itemNAME"].ToString();
                if (ITEMNAME == "PCB")
                {
                    v1++;
                }
                else if (ITEMNAME == "RED_LED")
                {
                    v2++;
                }
                else if (ITEMNAME == "GREEN_LED")
                {
                    v3++;
                }
                else if (ITEMNAME == "YELLOW_LED")
                {
                    v4++;
                }
                else if (ITEMNAME == "BLUE_LED")
                {
                    v5++;
                }
                else if (ITEMNAME == "PRODUCT")
                {
                    v6++;
                }
            }
            DrawPieChart(Chart_Fault, "불량 현황", v1, v2, v3, v4, v5, v6);
        }
        private void DrawPieChart(Chart chart, string title, int value1, int value2, int value3, int value4, int value5, int value6)
        {
            try
            {
                //reset your chart series and legends
                chart.Series.Clear();
                chart.Legends.Clear();
                //Add a new Legend(if needed) and do some formating
                chart.Legends.Add("Legends");
                chart.Legends[0].LegendStyle = LegendStyle.Table;
                chart.Legends[0].Docking = Docking.Bottom;
                chart.Legends[0].Alignment = StringAlignment.Center;
                chart.Legends[0].Title = title;
                chart.Legends[0].BorderColor = Color.Black;
                //Add a new chart-series
                string seriesname = "물품";
                chart.Series.Add(seriesname);
                //set the chart-type to "Pie"
                chart.Series[seriesname].ChartType = SeriesChartType.Pie;
                //Add some datapoints so the series. in this case you can pass the values to this method
                chart.Series[seriesname].Points.AddXY("PCB", value1);
                chart.Series[seriesname].Points.AddXY("RED_LED", value2);
                chart.Series[seriesname].Points.AddXY("GREEN_LED", value3);
                chart.Series[seriesname].Points.AddXY("YELLOW_LED", value4);
                chart.Series[seriesname].Points.AddXY("BLUE_LED", value5);
                chart.Series[seriesname].Points.AddXY("완제품", value6);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        private void Btn_Fault_Start_Click(object sender, EventArgs e)
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
        private void Btn_Fault_Quit_Click(object sender, EventArgs e)
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