using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
/* ======================================================================== DATEBASE STRUCTURE ======================================================================= *
 * | OrdTBL                | NonopTypeTBL                | NonopTBL                 | FaultTypeTBL                | FaultTBL                | ItemTBL                | *
 * ------------------------------------------------------------------------------------------------------------------------------------------------------------------- *
 * | ordID(N)(PK)(VARCHAR) | nonoptypeID(N)(PK)(VARCHAR) | nonopID(N)(PK)(VARCHAR)  | faulttypeID(N)(PK)(VARCHAR) | faultID(N)(PK)(VARCHAR) | itemID(N)(PK)(VARCHAR) | *
 * | proID(VARCHAR)        | nonoptypeNAME(VARCHAR)      | nonoptypeID(VARCHAR)     | faulttypeNAME(VARCHAR)      | ordID(VARCHAR)          | itemNAME(VARCHAR)      | *
 * | empID(VARCHAR)        | nonopNUM(INT)               | nonopstartTIME(DATETIME) | faultNUM(INT)               | faulttypeID(VARCHAR)    | itemNUM(INT)           | *
 * | itemID(VARCHAR)       | nonopUSE(CHAR)              | nonopendTIME(DATETIME)   | faultUSE(CHAR)              | faultDATE(DATETIME)     | itemUSE(CHAR)          | *
 * | ordNAME(VARCHAR)      | nonopTIME(CHAR)             | firstTIME(DATETIME)      | firstTIME(DATETIME)         | faultADD(VARCHAR)       | firstTIME(DATETIME)    | *
 * | ordAMT(BIGINT)        | firstTIME(DATETIME)         | firstUSER(VARCHAR)       | firstUSER(VARCHAR)          |                         | firstUSER(VARCHAR)     | *
 * | ordCPLT(INT)          | firstUSER(VARCHAR)          | lastTIME(DATETIME)       | lastTIME(DATETIME)          |                         | lastTIME(DATETIME)     | *
 * | workDATE(DATE)        | lastTIME(DATETIME)          | lastUSER(VARCHAR)        | lastUSER(VARCHAR)           |                         | lastUSER(VARCHAR)      | *
 * | startTIME(TIME)       | lastUSER(VARCHAR)           | nonopADD(VARCHAR)        | faulttypeADD(VARCHAR)       |                         | itemADD(VARCHAR)       | *
 * | endTIME(TIME)         | nonoptypeADD(VARCHAR)       |                          |                             |                         |                        | *
 * | ordSTATUS(VARCHAR)    |                             |                          |                             |                         |                        | *
 * | firstTIME(DATETIME)   |                             |                          |                             |                         |                        | *
 * | firstUSER(VARCHAR)    |                             |                          |                             |                         |                        | *
 * | lastTIME(DATETIME)    |                             |                          |                             |                         |                        | *
 * | lastUSER(VARCHAR)     |                             |                          |                             |                         |                        | *
 * | ordADD(VARCHAR)       |                             |                          |                             |                         |                        | *
 * =================================================================================================================================================================== */
namespace MESFactoryPOP
{
    public partial class frmPOP : Form
    {
        static string connStr = "Server=192.168.7.160;Port=3306;Database=FactoryDB;Uid=admin;Pwd=1234;";
        static string sql = "";
        static MySqlCommand cmd;
        static MySqlConnection conn;
        static MySqlDataReader reader;
        string line1_OnOff, line1_Fault = "";
        string line2_OnOff, line2_Fault = "";
        string line3_OnOff, line3_Fault = "";
        string line4_OnOff, line4_Fault = "";
        string inputDataFromArduino;
        string[] inputDataFromArduinoArray;
        public frmPOP()
        {
            InitializeComponent();
            timer1.Interval = 2000;
        }
        private void frmPOP_Load(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = "COM6";
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
                timer1.Start();
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
            btn_Line1_ON.Enabled = true;
            btn_Line2_ON.Enabled = true;
            btn_Line3_ON.Enabled = true;
            btn_Line4_ON.Enabled = true;
            btn_Line1_OFF.Enabled = false;
            btn_Line2_OFF.Enabled = false;
            btn_Line3_OFF.Enabled = false;
            btn_Line4_OFF.Enabled = false;
            pbx_Line1_ON.Visible = false;
            pbx_Line2_ON.Visible = false;
            pbx_Line3_ON.Visible = false;
            pbx_Line4_ON.Visible = false;
            pbx_Line1_OFF.Visible = true;
            pbx_Line2_OFF.Visible = true;
            pbx_Line3_OFF.Visible = true;
            pbx_Line4_OFF.Visible = true;
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // [LINE1 ON]:Y\n[LINE1 FAULT]:0\n[LINE1 PROGRESS]:10\n[LINE1 PROGRESS]:20\n...
            inputDataFromArduino = serialPort1.ReadLine(); // \n 만날 때까지 읽음
            this.Invoke(new EventHandler(showDataFromArduino));
        }
        private void showDataFromArduino(object sender, EventArgs e)
        {
            line1_OnOff = line2_OnOff = line3_OnOff = line4_OnOff = "";
            line1_Fault = line2_Fault = line3_Fault = line4_Fault = "";
            // LINE1 ONOFF STATUS
            if (inputDataFromArduino.Contains("[LINE1 ON]:") == true)
            {
                inputDataFromArduinoArray = inputDataFromArduino.Split(':');
                int exline1_OnOff;
                bool isNum = int.TryParse(inputDataFromArduinoArray[1], out exline1_OnOff);
                if (isNum != true)
                    return;
                line1_OnOff = inputDataFromArduinoArray[1].ToString();
            }
            // LINE1 FAULT TYPE
            if (inputDataFromArduino.Contains("[LINE1 FAULT]:") == true)
            {
                inputDataFromArduinoArray = inputDataFromArduino.Split(':');
                int exline1_Fault;
                bool isNum = int.TryParse(inputDataFromArduinoArray[1], out exline1_Fault);
                if (isNum != true)
                    return;
                line1_Fault = inputDataFromArduinoArray[1].ToString();
            }
            // LINE2 ONOFF STATUS
            if (inputDataFromArduino.Contains("[LINE2 ON]:") == true)
            {
                inputDataFromArduinoArray = inputDataFromArduino.Split(':');
                int exline2_OnOff;
                bool isNum = int.TryParse(inputDataFromArduinoArray[1], out exline2_OnOff);
                if (isNum != true)
                    return;
                line2_OnOff = inputDataFromArduinoArray[1].ToString();
            }
            // LINE2 FAULT TYPE
            if (inputDataFromArduino.Contains("[LINE2 FAULT]:") == true)
            {
                inputDataFromArduinoArray = inputDataFromArduino.Split(':');
                int exline2_Fault;
                bool isNum = int.TryParse(inputDataFromArduinoArray[1], out exline2_Fault);
                if (isNum != true)
                    return;
                line2_Fault = inputDataFromArduinoArray[1].ToString();
            }
            // LINE3 ONOFF STATUS
            if (inputDataFromArduino.Contains("[LINE3 ON]:") == true)
            {
                inputDataFromArduinoArray = inputDataFromArduino.Split(':');
                int exline3_OnOff;
                bool isNum = int.TryParse(inputDataFromArduinoArray[1], out exline3_OnOff);
                if (isNum != true)
                    return;
                line3_OnOff = inputDataFromArduinoArray[1].ToString();
            }
            // LINE3 FAULT TYPE
            if (inputDataFromArduino.Contains("[LINE3 FAULT]:") == true)
            {
                inputDataFromArduinoArray = inputDataFromArduino.Split(':');
                int exline3_Fault;
                bool isNum = int.TryParse(inputDataFromArduinoArray[1], out exline3_Fault);
                if (isNum != true)
                    return;
                line3_Fault = inputDataFromArduinoArray[1].ToString();
            }
            // LINE4 ONOFF STATUS
            if (inputDataFromArduino.Contains("[LINE4 ON]:") == true)
            {
                inputDataFromArduinoArray = inputDataFromArduino.Split(':');
                int exline4_OnOff;
                bool isNum = int.TryParse(inputDataFromArduinoArray[1], out exline4_OnOff);
                if (isNum != true)
                    return;
                line4_OnOff = inputDataFromArduinoArray[1].ToString();
            }
            // LINE4 FAULT TYPE
            if (inputDataFromArduino.Contains("[LINE4 FAULT]:") == true)
            {
                inputDataFromArduinoArray = inputDataFromArduino.Split(':');
                int exline4_Fault;
                bool isNum = int.TryParse(inputDataFromArduinoArray[1], out exline4_Fault);
                if (isNum != true)
                    return;
                line4_Fault = inputDataFromArduinoArray[1].ToString();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            selectLine1ToDB();
            selectLine2ToDB();
            selectLine3ToDB();
            selectLine4ToDB();
            progressBar_Line1.Value = 0;
            progressBar_Line2.Value = 0;
            progressBar_Line3.Value = 0;
            progressBar_Line4.Value = 0;
            if (line1_Fault != "")
            {
                string nowDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ListViewItem item = new ListViewItem(line1_Fault);
                item.SubItems.Add(nowDate);
                listView_Line1_WORK.Items.Add(item);
                listView_Line1_WORK.EnsureVisible(listView_Line1_WORK.Items.Count - 1);
                line1_Fault = "";
                progressBar_Line1.Value = 100;
            }
            if (line2_Fault != "")
            {
                string nowDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ListViewItem item = new ListViewItem(line2_Fault);
                item.SubItems.Add(nowDate);
                listView_Line2_WORK.Items.Add(item);
                listView_Line2_WORK.EnsureVisible(listView_Line2_WORK.Items.Count - 1);
                line2_Fault = "";
                progressBar_Line2.Value = 100;
            }
            if (line3_Fault != "")
            {
                string nowDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ListViewItem item = new ListViewItem(line3_Fault);
                item.SubItems.Add(nowDate);
                listView_Line3_WORK.Items.Add(item);
                listView_Line3_WORK.EnsureVisible(listView_Line3_WORK.Items.Count - 1);
                line3_Fault = "";
                progressBar_Line3.Value = 100;
            }
            if (line4_Fault != "")
            {
                string nowDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ListViewItem item = new ListViewItem(line4_Fault);
                item.SubItems.Add(nowDate);
                listView_Line4_WORK.Items.Add(item);
                listView_Line4_WORK.EnsureVisible(listView_Line4_WORK.Items.Count - 1);
                line4_Fault = "";
                progressBar_Line4.Value = 100;
            }
        }
        void selectLine1ToDB()
        {
            string name, num, use;
            listView_Line1_ORDER.Items.Clear();
            conn = new MySqlConnection(connStr);
            conn.Open();
            cmd = new MySqlCommand("", conn);
            sql = "SELECT a.proNAME, b.ordNAME, b.ordAMT FROM ProTBL AS a INNER JOIN OrdTBL b ON a.proID = b.proID WHERE 1 = 1;";
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                name = reader["proNAME"].ToString();
                num = reader["ordNAME"].ToString();
                use = reader["ordAMT"].ToString();
                ListViewItem item = new ListViewItem(name.ToString());
                item.SubItems.Add(num);
                item.SubItems.Add(use);
                listView_Line1_ORDER.Items.Add(item);
            }
            reader.Close();
            conn.Close();
        }
        void selectLine2ToDB()
        {
            string name, num, use;
            listView_Line2_ORDER.Items.Clear();
            conn = new MySqlConnection(connStr);
            conn.Open();
            cmd = new MySqlCommand("", conn);
            sql = "SELECT a.proNAME, b.ordNAME, b.ordAMT FROM ProTBL AS a INNER JOIN OrdTBL b ON a.proID = b.proID WHERE 1 = 1;";
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                name = reader["proNAME"].ToString();
                num = reader["ordNAME"].ToString();
                use = reader["ordAMT"].ToString();
                ListViewItem item = new ListViewItem(name.ToString());
                item.SubItems.Add(num);
                item.SubItems.Add(use);
                listView_Line2_ORDER.Items.Add(item);
            }
            reader.Close();
            conn.Close();
        }
        void selectLine3ToDB()
        {
            string name, num, use;
            listView_Line3_ORDER.Items.Clear();
            conn = new MySqlConnection(connStr);
            conn.Open();
            cmd = new MySqlCommand("", conn);
            sql = "SELECT a.proNAME, b.ordNAME, b.ordAMT FROM ProTBL AS a INNER JOIN OrdTBL b ON a.proID = b.proID WHERE 1 = 1;";
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                name = reader["proNAME"].ToString();
                num = reader["ordNAME"].ToString();
                use = reader["ordAMT"].ToString();
                ListViewItem item = new ListViewItem(name.ToString());
                item.SubItems.Add(num);
                item.SubItems.Add(use);
                listView_Line3_ORDER.Items.Add(item);
            }
            reader.Close();
            conn.Close();
        }
        void selectLine4ToDB()
        {
            string name, num, use;
            listView_Line4_ORDER.Items.Clear();
            conn = new MySqlConnection(connStr);
            conn.Open();
            cmd = new MySqlCommand("", conn);
            sql = "SELECT a.proNAME, b.ordNAME, b.ordAMT FROM ProTBL AS a INNER JOIN OrdTBL b ON a.proID = b.proID WHERE 1 = 1;";
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                name = reader["proNAME"].ToString();
                num = reader["ordNAME"].ToString();
                use = reader["ordAMT"].ToString();
                ListViewItem item = new ListViewItem(name.ToString());
                item.SubItems.Add(num);
                item.SubItems.Add(use);
                listView_Line4_ORDER.Items.Add(item);
            }
            reader.Close();
            conn.Close();
        }
        private void btn_Line1_ON_Click(object sender, EventArgs e)
        {
            serialPort1.Write("1");
            btn_Line1_ON.Enabled = false;
            btn_Line1_OFF.Enabled = true;
            pbx_Line1_ON.Visible = true;
            pbx_Line1_OFF.Visible = false;
        }
        private void btn_Line2_ON_Click(object sender, EventArgs e)
        {
            serialPort1.Write("3");
            btn_Line2_ON.Enabled = false;
            btn_Line2_OFF.Enabled = true;
            pbx_Line2_ON.Visible = true;
            pbx_Line2_OFF.Visible = false;
        }
        private void btn_Line3_ON_Click(object sender, EventArgs e)
        {
            serialPort1.Write("5");
            btn_Line3_ON.Enabled = false;
            btn_Line3_OFF.Enabled = true;
            pbx_Line3_ON.Visible = true;
            pbx_Line3_OFF.Visible = false;
        }
        private void btn_Line4_ON_Click(object sender, EventArgs e)
        {
            serialPort1.Write("7");
            btn_Line4_ON.Enabled = false;
            btn_Line4_OFF.Enabled = true;
            pbx_Line4_ON.Visible = true;
            pbx_Line4_OFF.Visible = false;
        }
        // LINE OFF BUTTON
        private void btn_Line1_OFF_Click(object sender, EventArgs e)
        {
            serialPort1.Write("2");
            btn_Line1_ON.Enabled = true;
            btn_Line1_OFF.Enabled = false;
            pbx_Line1_ON.Visible = false;
            pbx_Line1_OFF.Visible = true;
        }
        private void btn_Line2_OFF_Click(object sender, EventArgs e)
        {
            serialPort1.Write("4");
            btn_Line2_ON.Enabled = true;
            btn_Line2_OFF.Enabled = false;
            pbx_Line2_ON.Visible = false;
            pbx_Line2_OFF.Visible = true;
        }
        private void btn_Line3_OFF_Click(object sender, EventArgs e)
        {
            serialPort1.Write("6");
            btn_Line3_ON.Enabled = true;
            btn_Line3_OFF.Enabled = false;
            pbx_Line3_ON.Visible = false;
            pbx_Line3_OFF.Visible = true;
        }
        private void btn_Line4_OFF_Click(object sender, EventArgs e)
        {
            serialPort1.Write("8");
            btn_Line4_ON.Enabled = true;
            btn_Line4_OFF.Enabled = false;
            pbx_Line4_ON.Visible = false;
            pbx_Line4_OFF.Visible = true;
        }
    }
}