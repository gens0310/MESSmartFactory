using MESFactoryVO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMSFactory
{
	/// <summary>
	// 확장 메서드
	/// </summary>
	public static class CommonUtil
	{
		// Convert.To~ 대신 사용

		public static int ToInt(this object obj)
		{
			return Convert.ToString(obj).ToInt();
		}

		public static int ToInt(this string str)
		{
			int n;

			if (!int.TryParse(str, out n))
				n = 0;

			return n;
		}

		public static bool ToBool(this object obj)
		{
			return Convert.ToString(obj).ToBool();
		}

		public static bool ToBool(this string str)
		{
			bool flag;

			return bool.TryParse(str, out flag) && flag;
		}

		public static string GetSHA256(this string str)
		{
			StringBuilder builder = new StringBuilder();

			if (!string.IsNullOrEmpty(str.Trim()))
			{
				using (System.Security.Cryptography.SHA256 mySHA256 = System.Security.Cryptography.SHA256.Create())
				{
					try
					{
						// ComputeHash - returns byte array  
						byte[] bytes = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(str));

						// Convert byte array to a string   
						for (int i = 0; i < bytes.Length; i++)
						{
							builder.Append(bytes[i].ToString("x2"));
						}
					}
					catch (UnauthorizedAccessException err)
					{
						throw err;
					}
				}
			}

			return builder.ToString();
		}

		public static Dictionary<string, string> ToDic(this DataRow dr)
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();

			if (dr != null)
			{

				foreach (DataColumn dc in dr.Table.Columns)
				{
					string columnName = dc.ColumnName;
					dic[columnName] = dr[columnName].ToString();
				}
			}

			return dic;
		}

		public static int GetCorporationID(this EmpVO employee)
		{
			// 관리자 그룹일 경우 모든 공장을 다 보여주도록 설정
			return employee.RankID.ToInt() == 2 ? 0 : employee.FacID.ToInt();  //return employee.Ath_grp_id == 2 ? 0 : employee.Corporation_id;
        }
	}
}
