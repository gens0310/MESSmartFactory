//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Windows.Forms.VisualStyles;
//using System.Xml.Linq;
//using VO;


//namespace Win_MES_Factory.Utility
//{
//    public static class Static_Utility
//    {
//        ///////////////////////////////////////////////////////////////
//        /* STATIC UTILITY METHOD */
//        #region StaticUtilityMethod

//        // OBJECT -> INT
//        public static int ObjectToInt(this object obj)
//        {
//            return Convert.ToString(obj).ObjectToInt();
//        }

//        // STRING -> INT
//        public static int StringToInt(this string str)
//        {
//            int n;
//            if (!int.TryParse(str, out n)) n = 0;
//            return n;
//        }

//        // OBJECT -> BOOL
//        public static bool ObjectToBool(this object obj)
//        {
//            return Convert.ToString(obj).ObjectToBool();
//        }

//        // STRING -> BOOL
//        public static bool StringToBool(this string str)
//        {
//            bool flag;
//            return bool.TryParse(str, out flag) && flag;
//        }

//        // STRING -> DATE
//        public static DateTime StringToDate(this string str)
//        {
//            DateTime dt = DateTime.Now;
//            if (!string.IsNullOrEmpty(str))
//            {
//                if (str.Split(' ').Length > 1)
//                {
//                    string DateWord = str.Split(' ')[0];
//                    string TimeWord = str.Split(' ')[1];
//                    string[] DateString = DateWord.Split('-');
//                    string[] TimeString = TimeWord.Split(':');
//                    dt = new DateTime(DateString[0].StringToInt(),
//                                      DateString[1].StringToInt(),
//                                      DateString[2].StringToInt(),
//                                      TimeString[0].StringToInt(),
//                                      TimeString[1].StringToInt(),
//                                      TimeString[2].StringToInt());
//                }
//                else if (str.Contains("-"))
//                {
//                    string[] DateString = str.Split('-');
//                    dt = new DateTime(DateString[0].StringToInt(),
//                                      DateString[1].StringToInt(),
//                                      DateString[2].StringToInt());
//                }
//            }
//            return dt;
//        }

//        // DATE -> STRING
//        public static string DateToString(this DateTime dt, string format = "yyyy-MM-dd")
//        {
//            return dt.ToString(format);
//        }

//        #endregion
//        ///////////////////////////////////////////////////////////////
//        /* FORM UTILITY METHOD */
//        #region DataGridView

//        // INITIAL DATA GRID VIEW
//        public static void InitialDataGridView(this DataGridView dgv)
//        {
//            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
//            dgv.AutoGenerateColumns = false;
//            dgv.AllowUserToAddRows = false;
//            dgv.MultiSelect = false;
//            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
//            dgv.BackgroundColor = Color.White;
//            dgv.BorderStyle = BorderStyle.None;
//        }

//        // INITIAL IMAGE DATA GRID VIEW
//        public static void InitialImageDataGridView(this DataGridView dgv)
//        {
//            dgv.RowTemplate.Height = 100;
//            InitialDataGridView(dgv);
//        }

//        // ADD NEW COLUMN
//        public static void AddNewColumn(this DataGridView dgv, string headerText,
//                                        string dataPropertyName, bool visibility = true,
//                                        int colWidth = 100,
//                                        DataGridViewContentAlignment textAlign
//                                        = DataGridViewContentAlignment.MiddleLeft)
//        {
//            DataGridViewTextBoxColumn gridCol = new DataGridViewTextBoxColumn();
//            gridCol.HeaderText = headerText;
//            gridCol.DataPropertyName = dataPropertyName;
//            gridCol.Width = colWidth;
//            gridCol.Visible = visibility;
//            gridCol.ValueType = typeof(string);
//            gridCol.ReadOnly = true;
//            gridCol.DefaultCellStyle.Alignment = textAlign;
//            dgv.Columns.Add(gridCol);
//        }

//        // ADD NEW BUTTON
//        public static void AddNewButton(this DataGridView dgv, string text, Padding padding)
//        {
//            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
//            btn.Text = text;
//            btn.Width = 50;
//            btn.DefaultCellStyle.Padding = padding;
//            btn.UseColumnTextForButtonValue = true;
//            dgv.Columns.Add(btn);
//        }

//        // ADD NEW BUTTON DELETE COLUMN
//        public static void AddNewButtonDeleteColumn(this DataGridView dgv)
//        {
//            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
//            btn.Text = "X";
//            btn.Width = 50;
//            btn.FlatStyle = FlatStyle.Flat;
//            btn.DefaultCellStyle.ForeColor = Color.Red;
//            btn.DefaultCellStyle.Padding = new Padding(5);
//            btn.UseColumnTextForButtonValue = true;
//            dgv.Columns.Add(btn);
//        }

//        // ADD NEW CHECK COLUMN
//        public static void AddNewCheckColumn(this DataGridView dgv, string propertyName)
//        {
//            AddNewCheckColumn(dgv, propertyName, null);
//        }
//        public static void AddNewCheckColumn(this DataGridView dgv, string propertyName,
//                                             EventHandler HeaderCheck_Clicked)
//        {
//            // CHECKBOX LOCATION HEADER OF DATA GRID VIEW
//            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
//            chk.Width = 30;
//            chk.Name = "chk";
//            chk.HeaderText = "";
//            chk.DataPropertyName = propertyName;
//            dgv.Columns.Add(chk);
//            if (HeaderCheck_Clicked != null)
//            {
//                Point headerCell = dgv.GetCellDisplayRectangle(0, -1, true).Location;
//                CheckBox headerCheck = new CheckBox();
//                headerCheck.Name = "headerCheck";
//                headerCheck.Location = new Point(headerCell.X + 8, headerCell.Y + 4);
//                headerCheck.Size = new Size(15, 15);
//                headerCheck.BackColor = Color.White;
//                headerCheck.Click += HeaderCheck_Clicked;
//                dgv.Controls.Add(headerCheck);
//            }
//        }

//        // ADD NEW IMAGE COLUMN
//        public static void AddNewImageColumn(this DataGridView dgv, string headerText,
//                                             DataGridViewImageCellLayout imgLayout = DataGridViewImageCellLayout.Zoom)
//        {
//            DataGridViewImageColumn img = GetDataGridViewImageColumn(headerText, imgLayout);
//            dgv.Columns.Add(img);
//            dgv.CellFormatting += Utility.DataGridView_CellFormatting;
//        }

//        // ADD NEW IMAGE BLOB COLUMN
//        public static void AddNewImageBlobColumn(this DataGridView dgv, string headerText, string propertyName,
//                                                DataGridViewImageCellLayout imgLayout = DataGridViewImageCellLayout.Zoom)
//        {
//            DataGridViewImageColumn img = GetDataGridViewImageColumn(headerText, imgLayout, propertyName);
//            dgv.Columns.Add(img);
//        }

//        // GET DATA GRID VIEW IMAGE COLUMN
//        private static DataGridViewImageColumn GetDataGridViewImageColumn(string headerText, DataGridViewImageCellLayout imgLayout)
//        {
//            DataGridViewImageColumn img = new DataGridViewImageColumn();
//            img.HeaderText = headerText;
//            img.ImageLayout = DataGridViewImageCellLayout.Stretch;
//            return img;
//        }

//        // GET DATA GRID VIEW IMAGE COLUMN
//        private static DataGridViewImageColumn GetDataGridViewImageColumn(string headerText, DataGridViewImageCellLayout imgLayout, string propertyName)
//        {
//            DataGridViewImageColumn img = GetDataGridViewImageColumn(headerText, imgLayout);
//            img.DataPropertyName = propertyName;
//            return img;
//        }
//        #endregion

//        #region Form

//        // MULTIPLE DOCUMENT INTERFACE 
//        public static T MDIChildrenShow<T>(this MainForm MDIParent, bool bSearch = true, bool bSave = true,
//                                           bool bDelete = true, bool bNew = true) where T : Form, new()
//        {
//            foreach (Form frm in Application.OpenForms)
//            {
//                if (frm is T)
//                {
//                    frm.Activate();
//                    return (T)frm;
//                }
//            }
//            T f = new T();
//            f.MDIParent = MDIParent;
//            f.WindowState = FormWindowState.Maximized;
//            new Utility().CommonEvent<T>(f, bSearch, bSave, bDelete, bNew);
//            f.Show();
//            return f;
//        }
//        public static Form MDIChildrenShow(this MainForm MDIParent, string formName,
//                                           IEnumerable<MethodVO> methods)
//        {
//            Type type = Type.GetType("FactoryMES." + formName);
//            if (type != null)
//            {
//                foreach (Form frm in Application.OpenForms)
//                {
//                    if (frm.GetType() == type && frm.IsMdiChild)
//                    {
//                        frm.Activate();
//                        return frm;
//                    }
//                }
//                Form f = (Form)Activator.CreateInstance(type);
//                f.MDIParent = MDIParent;
//                f.WindowState = FormWindowState.Maximized;
//                new Utility().CommonEvent(f, methods);
//                f.Show();
//                return f;
//            }
//            return null;
//        }

//        // 
//        public static bool HasEmptyTxt(this Form frm)
//        {
//            TextBox txt = GetEmptyTxt(frm.Controls, null);
//            if (txt != null)
//            {
//                MessageBox.Show(txt.Tag.ToString());
//                txt.Focus();
//                return true;
//            }
//            return false;
//        }
//        // 
//        public static TextBox GetEmptyTxt(Control.ControlCollection controls, TextBox txt)
//        {
//            if (txt == null)
//            {
//                foreach (Control contorl in controls)
//                {
//                    if (contorl is TextBox)
//                    {
//                        if (!string.IsNullOrEmpty(contorl.Tag?.ToString()?.Trim()) && string.IsNullOrEmpty(contorl.Text.Trim()))
//                            return (TextBox)contorl;
//                    }
//                    else
//                    {
//                        if (contorl.Controls.Count > 0)
//                            txt = GetEmptyTxt(contorl.Controls, txt);
//                    }
//                }
//            }
//            return txt;
//        }

//        // CLEAR FORM
//        public static void Clear(this Form frm)
//        {
//            Clear(frm.Controls);
//        }

//        // CLEAR CONTROL
//        public static void Clear(Control.ControlCollection controls)
//        {
//            foreach (Control contorl in controls)
//            {
//                if (!contorl.Name.Contains("Search"))
//                {
//                    if (contorl is NumericUpDown)
//                        ((NumericUpDown)contorl).Value = 0;
//                    else if (contorl is TextBox)
//                    {
//                        contorl.Text = "";
//                        contorl.Enabled = true;
//                    }
//                    else if (contorl is ComboBox)
//                        ((ComboBox)contorl).SelectedIndex = 0;
//                    else if (contorl is DataGridView)
//                        ((DataGridView)contorl).ClearSelection();
//                    else if (contorl is CheckBox)
//                        ((CheckBox)contorl).Checked = false;
//                    else if (contorl is RadioButton)
//                        ((RadioButton)contorl).Checked = false;
//                    else if (contorl is DateTimePicker)
//                        ((DateTimePicker)contorl).Value = DateTime.Now;
//                    else if (contorl.Controls.Count > 0)
//                        Clear(contorl.Controls);
//                }
//            }
//        }

//        // 
//        public static MainForm GetMDIParent(this Form frm)
//        {
//            return frm.MDIParent as MainForm;
//        }

//        // 
//        public static FactoryVO GetLoginVO(this Form frm)
//        {
//            FactoryVO loginVO = null;
//            MainForm mainForm = GetMDIParent(frm);
//            if (mainForm != null)
//                loginVO = mainForm.LoginVO;
//            return loginVO;
//        }

//        #endregion

//    }
//}
