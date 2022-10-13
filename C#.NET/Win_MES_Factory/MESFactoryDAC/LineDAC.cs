using MESFactoryVO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MESFactoryDAC
{
    public class LineDAC:SqlHelper
    {
        public DataTable GetAllLine()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT c.facNAME, a.linID, a.linNUM, a.linNAME, b.empNAME, a.linUSE, a.firstTIME, a.firstUSER, a.lastTIME, a.lastUSER, a.linADD, a.empID, a.facID
			    				from lintbl as a 
			    				inner join emptbl b on a.empID = b.empID
			    				inner join factbl c on a.facID = c.facID
                                Order by linNUM asc";

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


        public DataTable SearchName(LineVO vo)
        {
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    string sql = @"select c.facNAME, a.linID, a.linNUM, a.linNAME, b.empNAME, a.linUSE, a.firstTIME, a.firstUSER, a.lastTIME, a.lastUSER, a.linADD, a.empID, a.facID
                                     from lintbl as a 
			    				     inner join emptbl b on a.empID = b.empID
			    				       inner join factbl c on a.facID = c.facID
                                    WHERE 1=1
                                      and (@FacID = '' or  c.FacID = @FacID)
                                    Order by a.linNUM asc;"; 
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FacID", vo.FacID);

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

        public bool UseLinID(List<int> empIDList, List<string> useList)
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
                                    sql = @"UPDATE lintbl SET linUSE = 'N' where linID in (" + empIDList[i] + ");"; //여러개의 값을 바꾸고온다.
                                }
                                else
                                {
                                    sql = @"UPDATE lintbl SET linUSE = 'Y' where linID in (" + empIDList[i] + ");";
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

        public bool SaveLine(LineVO vo)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = "SP_SAVE_Line"; /// 저장 프로시저 Stored Procedure 일련의 쿼리를 하나의 함수처럼 실행

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@P_LinID", vo.LinID);
                        cmd.Parameters.AddWithValue("@P_LinNAME", vo.LinNAME);
                        cmd.Parameters.AddWithValue("@P_FacID", vo.FacID);
                        cmd.Parameters.AddWithValue("@P_EmpID", vo.EmpID);
                        cmd.Parameters.AddWithValue("@P_LinNUM", vo.LinNUM);
                        cmd.Parameters.AddWithValue("@P_LinUSE", vo.LinUSE);
                        cmd.Parameters.AddWithValue("@P_LinADD", vo.LinADD);
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

        public bool DeleteLine(List<int> line_IDList)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string selNum = string.Join(",", line_IDList);

                    string sql = "Delete From Lintbl where LinID in (" + selNum + ") ;"; //여러개의 값을 삭제하고온다.

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

        public List<LineVO> FactoryEMPCombo(string facID)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string addString = string.Empty;
                    if (!String.IsNullOrEmpty(facID))
                    {
                        addString = " and e.FacID = " + facID.ToString();

                        cmd.Connection = new MySqlConnection(this.ConnectionString);
                        cmd.CommandText = @"select e.EmpID, e.EmpNAME
                                          from Emptbl e  INNER JOIN Factbl f ON e.FacID = f.FacID
                                         where 1 = 1 "
                                            + addString + ";";
                    }
                    else
                    {
                        cmd.Connection = new MySqlConnection(this.ConnectionString);
                        cmd.CommandText = @"select e.EmpID, e.EmpNAME
                                          from Emptbl e  INNER JOIN Factbl f ON e.FacID = f.FacID";
                    }                    

                    cmd.Connection.Open();


                    return SqlHelper.DataReaderMapToList<LineVO>(cmd.ExecuteReader());

                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
       
    }
}
