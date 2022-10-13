//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Win_MES_Factory.Utility
//{
//    internal class Utility
//    {
//        ///////////////////////////////////////////////////////////////
//        /* FILE UTILITY METHOD */
//        #region File Utility

//        // 
//        private static readonly string ROOT_PATH = ConfigurationManager.AppSettings["root_path"];
//        // 
//        public static Dictionary<string, string> SaveFilePath(string filePath, string category)
//        {
//            try
//            {
//                Dictionary<string, string> dic = new Dictionary<string, string>();
//                string sExp = filePath.Substring(filePath.LastIndexOf("."));
//                string sFilePath = GetFilePath(category);
//                string sFileName = Guid.NewGuid().ToString() + sExp;
//                DirectoryInfo dir = new DirectoryInfo(sFilePath);
//                if (!dir.Exists)
//                    dir.Create();
//                File.Copy(filePath, Path.Combine(dir.FullName, sFileName));
//                dic["imgPath"] = sFilePath;
//                dic["imgSysName"] = sFileName;
//                return dic;
//            }
//            catch (Exception err)
//            {
//                throw err;
//            }
//        }

//        // 
//        public static void OverwriteFilePath(string existingFilePath, string sysFilePath)
//        {
//            try
//            {
//                File.Copy(existingFilePath, sysFilePath, true);
//            }
//            catch (Exception err)
//            {
//                throw err;
//            }
//        }

//        // 
//        public static byte[] SaveFileBytes(string filePath)
//        {
//            try
//            {
//                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
//                {
//                    using (BinaryReader br = new BinaryReader(fs))
//                    {
//                        byte[] imageData = br.ReadBytes((int)fs.Length);

//                        return imageData;
//                    }
//                }
//            }
//            catch (Exception err)
//            {
//                throw err;
//            }
//        }

//        // 
//        public static string GetFileName(string filePath)
//        {
//            string fileName = "";

//            if (!string.IsNullOrEmpty(filePath))
//                fileName = filePath.Substring(filePath.LastIndexOf(GetSeparator()) + 1);

//            return fileName;
//        }

//        // 
//        private static string GetFilePath(string category)
//        {
//            string filePath = Path.Combine(ROOT_PATH, category, DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("dd"));

//            return filePath + GetSeparator();
//        }

//        // 
//        private static char GetSeparator()
//        {
//            char separatorChar = Path.DirectorySeparatorChar; ;

//            if (ROOT_PATH.Contains(Path.AltDirectorySeparatorChar))
//                separatorChar = Path.AltDirectorySeparatorChar;

//            return separatorChar;
//        }
//        #endregion

//        ///////////////////////////////////////////////////////////////
//        /* EVENT UTILITY METHOD */
//        #region Event Utility

//        // 
//        private readonly string[] EVENT_NAMES = { "Search", "Save", "Delete", "New" };
//        private List<MethodInfo> mInfoList;
//        private bool tsbSearchVisible;
//        private bool tsbSaveVisible;
//        private bool tsbDeleteVisible;
//        private bool tsbNewVisible;

//        // 
//        public void CommonEvent<T>(T frm, bool bSearch = true, bool bSave = true, bool bDelete = true, bool bNew = true) where T : Form
//        {
//            this.mInfoList = new List<MethodInfo>();
//            this.tsbSearchVisible = bSearch;
//            this.tsbSaveVisible = bSave;
//            this.tsbDeleteVisible = bDelete;
//            this.tsbNewVisible = bNew;
//            Type type = frm.GetType();
//            foreach (string eventName in EVENT_NAMES)
//            {
//                MethodInfo mInfo = type.GetMethod(eventName, BindingFlags.NonPublic | BindingFlags.Instance);

//                if (mInfo != null && mInfo.ReturnType == typeof(void) && IsBtnEventParameters(mInfo))
//                    mInfoList.Add(mInfo);
//            }
//            frm.Load += Form_load;
//            frm.FormClosing += Form_FormClosing;
//            frm.Activated += Form_Activated;
//            frm.Deactivate += Form_Deactivate;
//            frm.Shown += Form_Shown_dgvClearSelection;
//        }

//        // 
//        public void CommonEvent(Form frm, IEnumerable<MethodVO> methods)
//        {
//            this.mInfoList = new List<MethodInfo>();
//            Type type = frm.GetType();
//            Type thisType = this.GetType();
//            foreach (var method in methods)
//            {
//                string methodID = method.Method_id;
//                FieldInfo fieldInfo = thisType.GetField("tsb" + methodID + "Visible", BindingFlags.NonPublic | BindingFlags.Instance);
//                if (fieldInfo != null)
//                {
//                    if (method.Method_usable == "Y")
//                    {
//                        MethodInfo mInfo = type.GetMethod(methodID, BindingFlags.NonPublic | BindingFlags.Instance);

//                        if (mInfo != null && mInfo.ReturnType == typeof(void) && IsBtnEventParameters(mInfo))
//                        {
//                            mInfoList.Add(mInfo);
//                        }

//                        fieldInfo.SetValue(this, true);
//                    }
//                    else
//                        fieldInfo.SetValue(this, false);
//                }
//            }
//            frm.Load += Form_load;
//            frm.FormClosing += Form_FormClosing;
//            frm.Activated += Form_Activated;
//            frm.Deactivate += Form_Deactivate;
//            frm.Shown += Form_Shown_dgvClearSelection;
//        }

//        // 
//        private bool IsBtnEventParameters(MethodInfo mInfo)
//        {
//            ParameterInfo[] pInfos = mInfo.GetParameters();
//            Type[] parameterTypes = { typeof(object), typeof(EventArgs) };
//            foreach (ParameterInfo pInfo in pInfos)
//            {
//                bool flag = false;
//                foreach (Type parameterType in parameterTypes)
//                {
//                    if (pInfo.ParameterType == parameterType)
//                    {
//                        flag = true;
//                        break;
//                    }
//                }
//                if (!flag)
//                    return false;
//            }
//            return true;
//        }

//        // 
//        private void Form_load(object sender, EventArgs e)
//        {
//            MainForm mainFrm = GetMdiParent(sender);
//            Type type = mainFrm.GetType();
//            foreach (MethodInfo mInfo in mInfoList)
//            {
//                EventInfo eInfo = type.GetEvent(mInfo.Name);
//                eInfo.AddEventHandler(mainFrm, Delegate.CreateDelegate(eInfo.EventHandlerType, sender, mInfo));
//            }
//        }

//        // 
//        private void Form_FormClosing(object sender, EventArgs e)
//        {
//            MainForm mainFrm = GetMdiParent(sender);
//            Type type = mainFrm.GetType();

//            foreach (MethodInfo mInfo in mInfoList)
//            {
//                EventInfo eInfo = type.GetEvent(mInfo.Name);
//                eInfo.RemoveEventHandler(mainFrm, Delegate.CreateDelegate(eInfo.EventHandlerType, sender, mInfo));
//            }
//        }

//        // 
//        private void Form_Activated(object sender, EventArgs e)
//        {
//            MainForm mainFrm = GetMdiParent(sender);
//            mainFrm.TsbSearchVisible = tsbSearchVisible;
//            mainFrm.TsbSaveVisible = tsbSaveVisible;
//            mainFrm.TsbDeleteVisible = tsbDeleteVisible;
//            mainFrm.TsbNewVisible = tsbNewVisible;
//        }

//        // 
//        private void Form_Deactivate(object sender, EventArgs e)
//        {
//            MainForm mainFrm = GetMdiParent(sender);

//            mainFrm.TsbSearchVisible = false;
//            mainFrm.TsbSaveVisible = false;
//            mainFrm.TsbDeleteVisible = false;
//            mainFrm.TsbNewVisible = false;
//        }

//        // 
//        private MainForm GetMdiParent(object sender)
//        {
//            return (MainForm)((Form)sender).MdiParent;
//        }

//        // 
//        public static void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
//        {
//            if (e.ColumnIndex == 0)
//            {
//                // 수정해야 함
//                DataTable dt = (DataTable)((DataGridView)sender).DataSource;
//                DataRow dr = dt.Rows[e.RowIndex];
//                string path = string.Concat(dr["IMG_PATH"], dr["IMG_SYS_NAME"]);

//                if (File.Exists(path))
//                {
//                    using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(path)))
//                    {
//                        Image image = Image.FromStream(ms);
//                        e.Value = image;
//                    }
//                }
//            }
//        }

//        // 
//        public static void Form_Shown_dgvClearSelection(object sender, EventArgs e)
//        {
//            Form frm = (Form)sender;

//            foreach (Control ctr in frm.Controls)
//            {
//                if (ctr is DataGridView)
//                    ((DataGridView)ctr).ClearSelection();
//            }
//        }

//        // 
//        public static void MaterialBinding(object sender, DataGridViewBindingCompleteEventArgs e)
//        {
//            DataGridView dgv = (DataGridView)sender;
//            List<MaterialVO> list = (List<MaterialVO>)dgv.DataSource;

//            foreach (DataGridViewRow curRow in dgv.Rows)
//            {
//                var material = list.Find(item => item.Material_no == curRow.Cells[0].Value.ToInt());

//                if (material != null && material.Material_type != "MTR99" && material.Material_save >= material.Material_quantity_total)
//                    curRow.DefaultCellStyle.BackColor = Color.AntiqueWhite;
//            }
//        }

//        // 
//        public static void ComMaterialBinding(object sender, DataGridViewBindingCompleteEventArgs e)
//        {
//            DataGridView dgv = (DataGridView)sender;
//            List<CompanyMaterialVO> list = (List<CompanyMaterialVO>)dgv.DataSource;

//            foreach (DataGridViewRow curRow in dgv.Rows)
//            {
//                var material = list.Find(item => item.Material_no == curRow.Cells[0].Value.ToInt());

//                if (material != null && material.Material_type != "MTR99" && material.Material_save >= material.Material_quantity_total)
//                    curRow.DefaultCellStyle.BackColor = Color.AntiqueWhite;
//            }
//        }

//        #endregion

//    }
//}