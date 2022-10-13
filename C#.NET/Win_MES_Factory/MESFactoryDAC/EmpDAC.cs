using Google.Protobuf.WellKnownTypes;
using MESFactoryVO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESFactoryDAC
{
    public class EmpDAC: SqlHelper 
    {

        public List<RankVO> ComboRankGet()
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = new MySqlConnection(this.ConnectionString);
                    cmd.CommandText = @"SELECT RankID, RankNAME FROM Ranktbl";

                    cmd.Connection.Open();
                    return SqlHelper.DataReaderMapToList<RankVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public DataTable GetAllEmployees()
		{
			using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
			{
                conn.Open();
                string sql = @"SELECT a.empID, a.empRFID,a.empNAME,c.facNAME, b.rankName, a.empUSE, a.firstTIME, a.firstUSER, a.lastTIME, a.lastUSER, a.empADD, a.rankID, a.facID, a.empPW
							from emptbl as a 
							inner join ranktbl b on a.rankID = b.rankID
							inner join factbl c on a.facID = c.facID"
                             ;
				DataTable dt = new DataTable();
				MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
				da.Fill(dt);

				return dt;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="vo"></param>
		/// <returns></returns>
        public DataTable SearchName(EmpVO vo)
        {
			DataTable dt = new DataTable();

			using(MySqlConnection conn = new MySqlConnection(this.ConnectionString))
			{
                string sql = @"SELECT a.empID, a.empRFID,a.empNAME,c.facNAME, b.rankName, a.empUSE, a.firstTIME, a.firstUSER, a.lastTIME, a.lastUSER, a.empADD, IFNULL(a.rankID, ''), IFNULL(a.facID, ''), a.empPW
							from emptbl as a 
							inner join ranktbl b on a.rankID = b.rankID
							inner join factbl c on a.facID = c.facID
                            Where 1=1
                              AND (@RankID = '' or a.RankID =@RankID)
                              AND (@FacID = ''  or a.FacID = @FacID);";

				using (MySqlCommand cmd = new MySqlCommand(sql, conn))
				{
                    cmd.Parameters.AddWithValue("@FacID", vo.FacID);
                    cmd.Parameters.AddWithValue("@RankID", vo.RankID);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

					cmd.Connection.Open();
					da.Fill(dt);
					cmd.Connection.Close();
				}
            }
			return dt;
        }

        public bool UseEmpID(List<int> empIDList, List<string> useList)
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    string sql = "";

                    conn.Open();

                    if (empIDList?.Count > 0)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            for (int i = 0; i < empIDList.Count; i++)
                            {
                                if (useList[i] == "사용")
                                {
                                    sql = @"UPDATE emptbl SET empUSE = 'N' where empID in (" + empIDList[i] + ");"; //여러개의 값을 바꾸고온다.
                                }
                                else
                                {
                                    sql = @"UPDATE emptbl SET empUSE = 'Y' where empID in (" + empIDList[i] + ");";
                                }

                                cmd.CommandText = sql;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    return true;
                }
            }
            catch (Exception err)
            {
                throw err;
            }

        }

        #region 데이터 삭제
        /// <summary>
        ///  데이터 삭제시 체크된 항목 리스트로 전달하여 삭제
        /// </summary>
        /// <param name="emp_idList"></param>
        /// <returns></returns>
        public bool EmpDelete(List<int> emp_idList)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string selNum = string.Join(",", emp_idList);

                    string sql = "Delete From emptbl where empID in (" + selNum + ") ;"; //여러개의 값을 삭제하고온다.

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public EmpVO GetLoginEmployee(string employee_id, string employee_pwd)
        {
            EmpVO user = null;
            using (MySqlCommand cmd = new MySqlCommand())//로그인해서 필요한조건과 데이터
            {
                cmd.Connection = new MySqlConnection(this.ConnectionString);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT EmpID, EmpPW, EmpNAME, FacID, RankID, EmpUSE, FirstTIME, FirstUSER, LastTIME, LastUSER
						              FROM Emptbl
						             WHERE EmpID = @EmpID
						               AND EmpPW = @EmpPW";

                cmd.Parameters.AddWithValue("@EMPID", employee_id);
                cmd.Parameters.AddWithValue("@EMPPW", employee_pwd);

                cmd.Connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<EmpVO> list = SqlHelper.DataReaderMapToList<EmpVO>(reader);
                cmd.Connection.Close();

                if (list != null && list.Count > 0)
                    user = list[0];

                return user;
            }
        }
        #endregion
        public bool SaveEmp(EmpVO vo)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = "SP_SAVE_EMP";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@P_EmpID", vo.EmpID);
                        cmd.Parameters.AddWithValue("@P_EmpNAME", vo.EmpNAME);
                        cmd.Parameters.AddWithValue("@P_EmpRFID", vo.EmpRFID);
                        cmd.Parameters.AddWithValue("@P_EmpPW", vo.EmpPW);
                        cmd.Parameters.AddWithValue("@P_FacID", vo.FacID);
                        cmd.Parameters.AddWithValue("@P_RankID", vo.RankID);
                        cmd.Parameters.AddWithValue("@P_EmpUSE", vo.EmpUSE);
                        cmd.Parameters.AddWithValue("@P_EmpADD", vo.EmpADD);
                        cmd.Parameters.AddWithValue("@P_FirstUSER", vo.FirstUSER);
                        cmd.Parameters.AddWithValue("@P_LastUSER", vo.LastUSER);

                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception err)
            {
                return false;
                throw err;
            }

        }



    }
}
