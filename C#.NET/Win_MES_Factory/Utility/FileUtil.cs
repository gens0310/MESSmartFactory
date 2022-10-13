using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory
{
	public class FileUtil
	{
		private static readonly string ROOT_PATH = ConfigurationManager.AppSettings["root_path"];

		public static Dictionary<string, string> SaveFilePath(string filePath, string category)
		{
			try
			{
				Dictionary<string, string> dic = new Dictionary<string, string>();
				string sExp = filePath.Substring(filePath.LastIndexOf("."));
				string sFilePath = GetFilePath(category);
				string sFileName = Guid.NewGuid().ToString() + sExp;
				DirectoryInfo dir = new DirectoryInfo(sFilePath);

				if (!dir.Exists)
					dir.Create();

				File.Copy(filePath, Path.Combine(dir.FullName, sFileName));

				dic["imgPath"] = sFilePath;
				dic["imgSysName"] = sFileName;

				return dic;
			}
			catch (Exception err)
			{
				throw err;
			}
		}

		public static void OverwriteFilePath(string existingFilePath, string sysFilePath)
		{
			try
			{
				File.Copy(existingFilePath, sysFilePath, true);
			}
			catch (Exception err)
			{
				throw err;
			}
		}

		public static byte[] SaveFileBytes(string filePath)
		{
			try
			{
				using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
				{
					using (BinaryReader br = new BinaryReader(fs))
					{
						byte[] imageData = br.ReadBytes((int)fs.Length);

						return imageData;
					}
				}
			}
			catch (Exception err)
			{
				throw err;
			}
		}

		public static string GetFileName(string filePath)
		{
			string fileName = "";

			if (!string.IsNullOrEmpty(filePath))
				fileName = filePath.Substring(filePath.LastIndexOf(GetSeparator()) + 1);

			return fileName;
		}

		private static string GetFilePath(string category)
		{
			string filePath = Path.Combine(ROOT_PATH, category, DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("dd"));

			return filePath + GetSeparator();
		}

		private static char GetSeparator()
		{
			char separatorChar = Path.DirectorySeparatorChar; ;

			if (ROOT_PATH.Contains(Path.AltDirectorySeparatorChar))
				separatorChar = Path.AltDirectorySeparatorChar;

			return separatorChar;
		}
	}
}
