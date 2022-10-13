using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
namespace MESFactoryDAC
{
    public class LinMonitoringDAC : SqlHelper
    {
        public DataTable GetLinMonitoring()
        {
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                conn.Open();
                string sql = @"SELECT a.linNAME, b.itemNAME, a.linUSE, a.linADD, c.empNAME, a.linID
					       	   FROM LinTBL AS a 
							   INNER JOIN ItemTBL b on a.linNUM = b.itemNUM
							   INNER JOIN EmpTBL c on a.empID = c.empID
							   WHERE 1 = 1";
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(dt);
                return dt;
            }
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
                                if (useList[i] == "Y")
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
    }
}