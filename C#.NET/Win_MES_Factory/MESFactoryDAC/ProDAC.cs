using MESFactoryVO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Google.Protobuf.WellKnownTypes.Field.Types;

namespace MESFactoryDAC
{
    public class ProDAC: SqlHelper
    {
        public DataTable GetAllPro()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT f.FacID, f.FacNAME, p.LinID, l.LinNAME, p.ProID, p.ProNAME, p.ProNUM, p.ProUSE, p.FirstTIME, p.FirstUSER, p.LastTIME, p.LastUSER, p.ProAdd
                                   FROM Protbl p
                                  INNER JOIN Lintbl l on p.LinID = l.LinID
                                  INNER JOIN Factbl f On l.FacID = f.FacID
                                  Order by p.ProNUM asc;";

                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    da.Fill(dt);

                    return dt;
                }

            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public DataTable SearchName(ProVO vo)
        {
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    string sql = @"SELECT f.FacID, f.FacNAME, p.LinID, l.LinNAME, p.ProID, p.ProNAME, p.ProNUM, p.ProUSE, p.FirstTIME, p.FirstUSER, p.LastTIME, p.LastUSER, p.ProAdd
                                    FROM Protbl p
                                  INNER JOIN Lintbl l on p.LinID = l.LinID
                                  INNER JOIN Factbl f On l.FacID = f.FacID
                                    WHERE 1=1
                                      and (@FacID = '' or  f.FacID = @FacID)
                                      and (@LinID = '' or  l.LinID = @LinID)
                                  Order by p.ProNUM asc";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FacID", vo.FacID);
                        cmd.Parameters.AddWithValue("@LinID", vo.LinID);

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                        cmd.Connection.Open();
                        da.Fill(dt);
                        cmd.Connection.Close();

                    }
                }
            }
            catch (Exception err)
            {
                throw err;
            }

            return dt;
        }

        public bool UseProID(List<int> empIDList, List<string> useList)
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
                                    sql = @"UPDATE Protbl SET ProUSE = 'N'where ProID in (" + empIDList[i] + ");"; //여러개의 값을 바꾸고온다.
                                }
                                else
                                {
                                    sql = @"UPDATE Protbl SET ProUSE = 'Y'where ProID in (" + empIDList[i] + ");";
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

        public bool SavePro(ProVO vo)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = "SP_SAVE_PROCESS"; 

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@P_ProID", vo.ProID);
                        cmd.Parameters.AddWithValue("@P_ProNAME", vo.ProNAME);
                        cmd.Parameters.AddWithValue("@P_LinID", vo.LinID);
                        cmd.Parameters.AddWithValue("@P_ProNUM", vo.ProNUM);
                        cmd.Parameters.AddWithValue("@P_ProUSE", vo.ProUSE);
                        cmd.Parameters.AddWithValue("@P_ProADD", vo.ProADD);
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

        public bool DeletePro(List<int> line_IDList)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string selNum = string.Join(",", line_IDList);

                    string sql = "Delete From Protbl where ProID in (" + selNum + ") ;"; //여러개의 값을 삭제하고온다.

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

        public List<ProVO> FactoryLinCombo(string facID)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string addString = string.Empty;
                    if (!String.IsNullOrEmpty(facID))
                    {
                        addString = " and l.FacID = " + facID.ToString();

                        cmd.Connection = new MySqlConnection(this.ConnectionString);
                        cmd.CommandText = @"select l.LinID, l.LinNAME
                                          from lintbl l INNER JOIN Factbl f ON l.FacID = f.FacID
                                         where 1 = 1 "
                                            + addString + ";";
                    }
                    else
                    {
                        cmd.Connection = new MySqlConnection(this.ConnectionString);
                        cmd.CommandText = @"select l.LinID, l.LinNAME
                                          from lintbl l INNER JOIN Factbl f ON l.FacID = f.FacID";
                    }

                    cmd.Connection.Open();


                    return SqlHelper.DataReaderMapToList<ProVO>(cmd.ExecuteReader());

                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<ProVO> ComboFacGetPro()  // 새로만듦
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = new MySqlConnection(this.ConnectionString);
                    cmd.CommandText = @"SELECT F.FacID, F.FacNAME  
                    FROM Factbl F 

                    ORDER BY facNUM ASC";

                    cmd.Connection.Open();
                    return SqlHelper.DataReaderMapToList<ProVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
