using MySql.Data.MySqlClient;
using System.Data;
namespace MESFactoryDAC
{
    public class ItemMonitoringDAC : SqlHelper
    {
        public DataTable GetItemMonitoring()
        {
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                conn.Open();
                string sql = @"SELECT a.faultID, b.ordNAME, b.ordAMT, c.faulttypeNAME, d.itemNAME
					       	   FROM FaultTBL AS a 
							   INNER JOIN OrdTBL b ON a.ordID = b.ordID
							   INNER JOIN FaultTypeTBL c ON a.faulttypeID = c.faulttypeID
                               INNER JOIN ItemTBL d ON b.itemID = d.itemID
							   WHERE 1 = 1";
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(dt);
                return dt;
            }
        }
    }
}