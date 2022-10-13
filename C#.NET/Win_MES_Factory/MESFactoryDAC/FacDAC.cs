using MESFactoryVO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Protobuf.Reflection.FieldOptions.Types;

namespace MESFactoryDAC
{
    public class FacDAC:SqlHelper
    {
        public DataTable GetAllFactorys()
        {
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                conn.Open();
                string sql = @"SELECT facID, facNAME, facNUM, facUSE, firstTIME, firstUSER, lastTIME, lastUSER, facADD
							from FacTBL
                            ORDER BY facNUM ASC";
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
        public DataTable SearchName(FactoryVO vo)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                string sql = @"SELECT facID, facName,facNUM,facUSE, firstTIME, firstUSER, lastTIME, lastUSER, facADD
							from FacTBL 
                            WHERE 1=1
                            ORDER BY facNUM ASC";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                   // cmd.Parameters.AddWithValue("@facNAME", vo.FacName);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    cmd.Connection.Open();
                    da.Fill(dt);
                    cmd.Connection.Close();
                }
            }
            return dt;
        }

        public bool UseFacID(List<int> facIDList, List<string> useList)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    string sql = "";

                    conn.Open();

                    if (facIDList?.Count > 0)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            for (int i = 0; i < facIDList.Count; i++)
                            {
                                if (useList[i] == "사용")
                                {
                                    sql = @"UPDATE Factbl SET FacUSE = 'N'where FacID in  (" + facIDList[i] + ");"; //여러개의 값을 바꾸고온다.
                                }
                                else
                                {
                                    sql = @"UPDATE Factbl SET FacUSE = 'Y'where FacID in (" + facIDList[i] + ");";
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
        public bool FacDelete(List<int> emp_idList)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string selNum = string.Join(",", emp_idList);

                    string sql = "Delete From Factbl where FacID in (" + selNum + ") ;"; //여러개의 값을 삭제하고온다.

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
      
        #endregion
        public bool InsertFac(FactoryVO vo)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"INSERT INTO FacTBL(FacID, FacNAME, FacNUM, FacUSE, FirstTIME, FirstUSER, LastTIME, LastUSER, FacADD) 
                                   VALUES(@FacID, @FacNAME, @FacNUM, @FacUSE, now(), @FirstUSER, now(), @LastUSER, @FacADD);";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
 
                        cmd.Parameters.AddWithValue("@FacID", vo.FacID);
                        cmd.Parameters.AddWithValue("@FacNAME", vo.FacNAME);
                        cmd.Parameters.AddWithValue("@FacNUM", vo.FacNUM);
                        cmd.Parameters.AddWithValue("@FacUSE", vo.FacUSE);
                        //cmd.Parameters.AddWithValue("@FirstTIME", "now()");
                        cmd.Parameters.AddWithValue("@FirstUSER", vo.FirstUSER);
                        //cmd.Parameters.AddWithValue("@LastTIME", "now()");
                        cmd.Parameters.AddWithValue("@LastUSER", vo.LastUSER);
                        cmd.Parameters.AddWithValue("@FacADD", vo.FacADD);

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

        public bool UpdateFac(FactoryVO vo)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = @"UPDATE Factbl 
                                    SET FacNAME = @FacNAME,
                                        FacNUM  = @FacNUM,
                                        FacUSE  = @FacUSE, 
                                        LastTIME = now(),
                                        LastUSER = @LastUSER,
                                        FacADD = @FacADD
                                  where FacID = @FacID;";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {

                        cmd.Parameters.AddWithValue("@FacID", vo.FacID);
                        cmd.Parameters.AddWithValue("@FacNAME", vo.FacNAME);
                        cmd.Parameters.AddWithValue("@FacNUM", vo.FacNUM);
                        cmd.Parameters.AddWithValue("@FacUSE", vo.FacUSE);
                        //cmd.Parameters.AddWithValue("@LastTIME", "now()");
                        cmd.Parameters.AddWithValue("@LastUSER", vo.LastUSER);
                        cmd.Parameters.AddWithValue("@FacADD", vo.FacADD);

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

        public List<FactoryVO> ComboFacGet()
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = new MySqlConnection(this.ConnectionString);
                    cmd.CommandText = @"SELECT FacID, FacNAME  FROM Factbl ORDER BY facNUM ASC";

                    cmd.Connection.Open();
                    return SqlHelper.DataReaderMapToList<FactoryVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
