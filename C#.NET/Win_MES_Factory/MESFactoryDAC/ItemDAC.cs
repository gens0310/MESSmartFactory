using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MESFactoryVO;
using MySql.Data.MySqlClient;
using System.Data;

namespace MESFactoryDAC
{
    public class ItemDAC : SqlHelper
    {
        public DataTable GetAllItem()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    string sql = @"SELECT ItemID, ItemNAME, ItemNUM, ItemUSE, FirstTIME, FirstUSER, LastTIME, LastUSER, ItemADD
			    				from Itemtbl 
                                Order by ItemNUM asc";

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

        public DataTable SearchName(ItemVO vo)
        {
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    string sql = @"SELECT ItemID, ItemNAME, ItemNUM, ItemUSE, FirstTIME, FirstUSER, LastTIME, LastUSER, ItemADD
			    				from Itemtbl 
                                Order by ItemNUM asc";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {


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

        public bool UseItemID(List<int> itemIDList, List<string> useList)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    string sql = "";

                    conn.Open();

                    if (itemIDList?.Count > 0)
                    {
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                        {
                            for (int i = 0; i < itemIDList.Count; i++)
                            {
                                if (useList[i] == "사용")
                                {
                                    sql = @"UPDATE Itemtbl SET ItemUSE = 'N'where ItemID in (" + itemIDList[i] + ");"; //여러개의 값을 바꾸고온다.
                                }
                                else
                                {
                                    sql = @"UPDATE Itemtbl SET ItemUSE = 'Y'where ItemID in  (" + itemIDList[i] + ");";
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

        public bool SaveItem(ItemVO vo)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string sql = "SP_SAVE_Item"; /// 저장 프로시저 Stored Procedure 일련의 쿼리를 하나의 함수처럼 실행

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@P_ItemID", vo.ItemID);
                        cmd.Parameters.AddWithValue("@P_ItemNAME", vo.ItemNAME);
                        cmd.Parameters.AddWithValue("@P_ItemNUM", vo.ItemNUM);
                        cmd.Parameters.AddWithValue("@P_ItemUSE", vo.ItemUSE);
                        cmd.Parameters.AddWithValue("@P_ItemADD", vo.ItemADD);
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

        public bool DeleteItem(List<int> item_IDList)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string selNum = string.Join(",", item_IDList);

                    string sql = "Delete From Itemtbl where ItemID in (" + selNum + ") ;"; //여러개의 값을 삭제하고온다.

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



    }
}
