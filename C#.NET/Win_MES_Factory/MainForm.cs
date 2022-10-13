
using Google.Protobuf.WellKnownTypes;
using MESFactoryVO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinMSFactory;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Win_MES_Factory
{
    public partial class MainForm : Form
    {
        // EVENT
        public event EventHandler Search;
        public event EventHandler Add;
        public event EventHandler Save;
        public event EventHandler Delete;
        public event EventHandler Reset;
        public event EventHandler Excel;
        public event EventHandler Print;
        public event EventHandler Use;

        // LIST
        //private List<MenuVO> menuList; 메뉴 고정 불필요
        //private List<MethodVO> methodList; 메뉴 고정 불필요
        private List<int> checkMenuList = new List<int>();
        private frmEmpManage frmEmpManage;
        private frmFactory frmFactory;
        private frmLine frmLine;
        private frmProcessManage frmProcess;
        private frmOrderManage frmOrder;
        private frmItem frmitem;
        private frmOrderItem frmOrderItem;
        private frmLinMonitoring frmLinMonitoring;
        private frmItemMonitoring frmItemMonitoring;

        public EmpVO Employee { get; set; }
        // BUTTON VISIBLE STATUS
        /// <summary>
        /// Tool 조회 버튼
        /// </summary>
        public bool TsbSearchVisible
        {
            set { tsbSearch.Visible = value; }
        }
        /// <summary>
        /// Tool 추가 버튼
        /// </summary>
        public bool TsbAddVisible
        {
            set { tsbAdd.Visible = value; }
        }
        /// <summary>
        /// Tool 저장 버튼
        /// </summary>
        public bool TsbSaveVisible
        {
            set { tsbSave.Visible = value; }
        }
        /// <summary>
        /// Tool 삭제 버튼
        /// </summary>
        public bool TsbDeleteVisible
        {
            set { tsbDelete.Visible = value; }
        }
        /// <summary>
        /// Tool 초기화 버튼
        /// </summary>
        public bool TsbClearVisible
        {
            set { tsbClear.Visible = value; }
        }
        /// <summary>
        /// Tool 엑셀 버튼
        /// </summary>
        public bool TsbExcelVisible
        {
            set { tsbExcell.Visible = value; }
        }
        /// <summary>
        /// Tool 인쇄 버튼 
        /// </summary>
        public bool TsbPrintVisible
        {
            set { tsbPrint.Visible = value; }
        }

        /// <summary>
        /// Tool 인쇄 버튼 
        /// </summary>
        public bool TsbUseVisible
        {
            set { tsbUse.Visible = value; }
        }

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowLoginForm();

            // TIMER
            timer1.Tick += ((send, args) => lblDateTime.Text = DateTime.Now.ToString("yyyy년 MM월 dd일 HH시 mm분 ss초"));

            // BUTTON HIDE
            this.TsbSearchVisible = false;
            this.TsbAddVisible = false;
            this.TsbSaveVisible = false;
            this.TsbDeleteVisible = false;
            this.TsbClearVisible = false;
            this.TsbExcelVisible = false;
            this.TsbPrintVisible = false;
            this.TsbUseVisible = false;

            // Form Backgroud Show

            //로그인 취소 버튼 클릭시 발생오류
            //System.ArgumentException: '이 폼의 MdiParent로 지정한 폼이 MdiContainer가 아닙니다. 매개 변수 이름: value'

            frmEmpManage = new frmEmpManage() { MdiParent = this, Dock = DockStyle.Fill};
            frmFactory = new frmFactory() { MdiParent = this, Dock = DockStyle.Fill };
            frmLine = new frmLine() { MdiParent=this,Dock = DockStyle.Fill };
            frmProcess = new frmProcessManage() { MdiParent = this, Dock = DockStyle.Fill };
            frmOrder = new frmOrderManage() { MdiParent = this, Dock = DockStyle.Fill };
            frmitem = new frmItem() { MdiParent = this, Dock = DockStyle.Fill };
            frmOrderItem = new frmOrderItem() { MdiParent = this, Dock = DockStyle.Fill };
            frmLinMonitoring = new frmLinMonitoring() { MdiParent = this, Dock = DockStyle.Fill };
            frmItemMonitoring = new frmItemMonitoring() { MdiParent = this, Dock = DockStyle.Fill };
        }

        private void ShowLoginForm()
        {
            this.Hide();

            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }

            frmLogin frm = new frmLogin();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (!this.Visible)
                    this.Visible = true;

                this.Employee = frm.Employee;
                tslEmpName.Text = $"{this.Employee.EmpID}({this.Employee.EmpNAME})";
            }
            else //if (frm.ShowDialog() == DialogResult.Cancel)
            {
                Application.Exit();
            }
                
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            if (Add != null)
                Add(this, new EventArgs());
        }
        private void tsbSearch_Click(object sender, EventArgs e)
        {
            if (Search != null)
                Search(this, new EventArgs());
        }
        private void tsbSave_Click(object sender, EventArgs e)
        {
            if(Save != null)
                Save(this, new EventArgs());
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if(Delete != null)
                Delete(this, new EventArgs());
        }
        private void tsbUse_Click(object sender, EventArgs e)
        {
            if (Use != null)
                 Use(this, new EventArgs());
        }
        private void tsbClear_Click(object sender, EventArgs e)
        {
            if (Reset != null)
                Reset(this, new EventArgs());
        }

        private void tsbExcell_Click(object sender, EventArgs e)
        {
            if (Excel != null)
                Excel(this, new EventArgs());
        }

        private void tsbLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// /////////////////////////////////////////////////////////////////////////////////////////////////


        private void tsbEmp_Click(object sender, EventArgs e)
        {
            frmEmpManage.Show();
            frmEmpManage.Activate();
            frmEmpManage.Emp = Employee;
        }

        private void tsbFactory_Click(object sender, EventArgs e)
        {
             frmFactory.Show();
             frmFactory.Activate();
             frmFactory.Emp = Employee;
        }

        private void tsbLine_Click(object sender, EventArgs e)
        {
             frmLine.Show();
             frmLine.Activate();
             frmLine.Emp = Employee;
        }

        private void tsbProcess_Click(object sender, EventArgs e)
        {
              frmProcess.Show();
              frmProcess.Activate();
              frmProcess.Emp = Employee;
        }

        private void tsbItem_Click(object sender, EventArgs e)
        {
            frmitem.Show();
            frmitem.Activate();
            frmitem.Emp = Employee;
        }

        private void tsbOrder_Click(object sender, EventArgs e)
        {
            frmOrder.Show();    
            frmOrder.Activate();
            frmFactory.Emp = Employee;
        }
        private void tsbMoniter_Click(object sender, EventArgs e)
        {
            frmLinMonitoring.Show();
            frmLinMonitoring.Activate();
        }
        private void tsbProduct_Click(object sender, EventArgs e)
        {
            frmItemMonitoring.Show();
            frmItemMonitoring.Activate();
        }

        private void tsbOrderItem_Click(object sender, EventArgs e)
        {
            frmOrderItem.Show();
            frmOrderItem.Activate();
            frmOrderItem.Emp = Employee;
        }

      


        //private void tsbLogout_Click(object sender, EventArgs e)
        //{
        //    if (LoginVO == null)
        //    {
        //        LoginForm frm = new LoginForm(this);

        //        if (frm.ShowDialog() == DialogResult.OK)
        //        {
        //            ClearForm();
        //            ShowMainDataView();
        //            toolStripButton2.Image = Properties.Resources.logout;
        //        }
        //    }
        //    else
        //    {
        //        if (MessageBox.Show("정말로 로그아웃하시겠습니까?", "로그아웃", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //        {
        //            MessageBox.Show("로그아웃되었습니다.");

        //            ClearForm();
        //            //this.MdiChildrenShow<ShoppingForm>(false, false, false, false);
        //            toolStripButton2.Image = Properties.Resources.login;
        //            LoginVO = null;
        //        }
        //    }
        //}
    }
}
