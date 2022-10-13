using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win_MES_Factory;

namespace WinMSFactory
{
	public class EventUtil
	{
		List<MethodInfo> mInfoList;
		bool btnSearchVisible;
		bool btnAddVisible;
		bool btnSaveVisible;
		bool btnDeleteVisible;
		bool btnExcelVisible;
		bool btnPrintVisible;
		bool btnBarcodeVisible;
		bool btnClearVisible;

		//private void Search(object sender, EventArgs e)
		//{
		//	if (((MainForm)this.MdiParent).ActiveMdiChild == this)
		//	{

		//	}
		//}

		public void CommonEvent(Form frm, Dictionary<string, string> dic)
		{
			this.mInfoList = new List<MethodInfo>();
			Type type = frm.GetType();
			Type thisType = this.GetType();

			foreach (string key in dic.Keys)
			{                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
				string methodName = GetMethodName(key);
				FieldInfo fieldInfo = thisType.GetField("btn" + methodName + "Visible", BindingFlags.NonPublic | BindingFlags.Instance);

				if (fieldInfo != null)
				{
					if (dic[key].ToString() == "Y")
					{
						MethodInfo mInfo = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

						AddMethod(type, methodName);
						fieldInfo.SetValue(this, true);
					}
					else
						fieldInfo.SetValue(this, false);
				}
			}

			AddMethod(type, "Readed");

			frm.Load += Form_load;
			frm.FormClosing += Form_FormClosing;
			frm.Activated += Form_Activated;
			frm.Deactivate += Form_Deactivate;
			frm.Shown += Form_Shown_dgvClearSelection;
		}

		private void AddMethod(Type type, string methodName)
		{
			MethodInfo mInfo = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

			if (mInfo != null && mInfo.ReturnType == typeof(void) && IsBtnEventParameters(mInfo))
				mInfoList.Add(mInfo);
		}

		private bool IsBtnEventParameters(MethodInfo mInfo)
		{
			ParameterInfo[] pInfos = mInfo.GetParameters();
			Type[] parameterTypes = { typeof(object), typeof(EventArgs), typeof(ReadEventArgs) };

			foreach (ParameterInfo pInfo in pInfos)
			{
				bool flag = false;

				foreach (Type parameterType in parameterTypes)
				{
					if (pInfo.ParameterType == parameterType)
					{
						flag = true;
						break;
					}
				}

				if (!flag)
					return false;
			}

			return true;
		}

		private void Form_load(object sender, EventArgs e)
		{
			MainForm mainFrm = GetMdiParent(sender);
			Type type = mainFrm.GetType();

			foreach (MethodInfo mInfo in mInfoList)
			{
				EventInfo eInfo = type.GetEvent(mInfo.Name);
				eInfo.AddEventHandler(mainFrm, Delegate.CreateDelegate(eInfo.EventHandlerType, sender, mInfo));
			}
		}

		private void Form_FormClosing(object sender, EventArgs e)
		{
			MainForm mainFrm = GetMdiParent(sender);
			Type type = mainFrm.GetType();

			foreach (MethodInfo mInfo in mInfoList)
			{
				EventInfo eInfo = type.GetEvent(mInfo.Name);
				eInfo.RemoveEventHandler(mainFrm, Delegate.CreateDelegate(eInfo.EventHandlerType, sender, mInfo));
			}
		}

		private void Form_Activated(object sender, EventArgs e)
		{
			MainForm mainFrm = GetMdiParent(sender);

			mainFrm.TsbSearchVisible = btnSearchVisible;
			mainFrm.TsbAddVisible = btnAddVisible;
			mainFrm.TsbSaveVisible = btnSaveVisible;
			mainFrm.TsbDeleteVisible = btnDeleteVisible;
			mainFrm.TsbExcelVisible = btnExcelVisible;
			mainFrm.TsbPrintVisible = btnPrintVisible;
			mainFrm.TsbClearVisible = btnClearVisible;
		}

		private void Form_Deactivate(object sender, EventArgs e)
		{
			MainForm mainFrm = GetMdiParent(sender);

            mainFrm.TsbSearchVisible = false;
            mainFrm.TsbAddVisible = false;
            mainFrm.TsbSaveVisible = false;
            mainFrm.TsbDeleteVisible = false;
            mainFrm.TsbExcelVisible = false;
            mainFrm.TsbPrintVisible = false;
            mainFrm.TsbClearVisible = false;
        }

		private MainForm GetMdiParent(object sender)
		{
			return (MainForm)((Form)sender).MdiParent;
		}

		public static void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				// 수정해야 함
				DataTable dt = (DataTable)((DataGridView)sender).DataSource;
				DataRow dr = dt.Rows[e.RowIndex];
				string path = string.Concat(dr["IMG_PATH"], dr["IMG_SYS_NAME"]);

				if (File.Exists(path))
				{
					using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(path)))
					{
						Image image = Image.FromStream(ms);
						e.Value = image;
					}
				}
			}
		}

		public static void Form_Shown_dgvClearSelection(object sender, EventArgs e)
		{
			Form frm = (Form)sender;
			DgvClearSelection(frm.Controls);
		}

		private string GetMethodName(string methodName)
		{
			if (!string.IsNullOrEmpty(methodName) && methodName.Length > 1)
			{
				methodName = methodName.ToLower();
				methodName = methodName.Replace("prog_", "");
				methodName = methodName.Substring(0, 1).ToUpper() + methodName.Substring(1, methodName.Length - 1);
			}

			return methodName;
		}

		private static void DgvClearSelection(System.Windows.Forms.Control.ControlCollection controls)
		{
			foreach (System.Windows.Forms.Control contorl in controls)
			{
				if (contorl is DataGridView)
					((DataGridView)contorl).ClearSelection();
				else if (contorl.Controls.Count > 0)
					DgvClearSelection(contorl.Controls);
			}
		}
	}
}
