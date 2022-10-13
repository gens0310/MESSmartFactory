using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using MESFactoryVO;
using MySql.Data.MySqlClient;


namespace MESFactoryDAC
{
    public class OrderDAC : SqlHelper
    {

        public List<FactoryVO> ComboFacGet() // EmpDAC에 존재 이해하기 위해 넣었음.
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

        public List<EmpVO> ComboEmpGet() // EmpDAC에 존재 이해하기 위해 넣었음.
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = new MySqlConnection(this.ConnectionString);
                    cmd.CommandText = @"SELECT EmpID, EmpNAME  FROM Emptbl";

                    cmd.Connection.Open();
                    return SqlHelper.DataReaderMapToList<EmpVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<LineVO> ComboLineGet()
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = new MySqlConnection(this.ConnectionString);
                    cmd.CommandText = @"SELECT LinID, LinNAME  FROM Lintbl ORDER BY LinNUM ASC";

                    cmd.Connection.Open();
                    return SqlHelper.DataReaderMapToList<LineVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<ProVO> ComboProGet()  // 콤보 공정
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = new MySqlConnection(this.ConnectionString);
                    cmd.CommandText = @"SELECT ProID, ProNAME  FROM Protbl ORDER BY ProNUM ASC";

                    cmd.Connection.Open();
                    return SqlHelper.DataReaderMapToList<ProVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<ItemVO> ComboItemGet()  // 제품 공정
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = new MySqlConnection(this.ConnectionString);
                    cmd.CommandText = @"SELECT ItemID, ItemNAME  FROM Itemtbl ORDER BY ItemNUM ASC";

                    cmd.Connection.Open();
                    return SqlHelper.DataReaderMapToList<ItemVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }

       


        public DataTable GetAllOrders(OrderVO orderVO = null)  // 흠
        {
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                conn.Open();
                string sql = @"SELECT O.OrdID, PR.ProID, PR.ProNAME, EM.EmpID, EM.EmpNAME, IT.ItemID, IT.itemNAME, O.OrdNAME, O.OrdDATE, O.OrdAMT, O.OrdCPLT
                                    , O.OrdFLT, O.WorkDATE, O.StartTIME, O.EndTIME, c.commonNAME, O.OrdSTATUS, O.FirstTIME, O.FirstUSER, O.LastTIME, O.LastUSER, O.OrdADD
                                    , L.LinID, L.LinNAME, F.FacID, F.FacNAME

                                     FROM Ordtbl O
                                    INNER JOIN Protbl PR
                                    	ON O.ProID = PR.ProID
                                    INNER JOIN Emptbl EM
                                    	ON O.EmpID = EM.EmpID
                                    INNER JOIN Itemtbl IT
                                    	ON O.ItemID = IT.ItemID
                                    INNER JOIN Lintbl L
                                    	ON PR.LinID = L.LinID
                                    INNER JOIN Factbl F
                                    	ON L.FacID = F.FacID
									Inner join commontbl c
                                    ON c.commonID = o.OrdSTATUS
                                    WHERE 1=1";  

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                ParametersJ(da.SelectCommand, orderVO);

                da.Fill(dt);

                return dt;
            }
        }


        public DataTable GetExcelOrders(OrderVO orderVO = null)  // 흠
        {
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                conn.Open();
                string sql = @"SELECT O.OrdID, PR.ProNAME, EM.EmpNAME, IT.itemNAME, O.OrdNAME, O.OrdDATE, O.OrdAMT, O.OrdCPLT
                                    , O.OrdFLT, O.WorkDATE, c.commonNAME, O.OrdSTATUS, O.FirstTIME, O.FirstUSER, O.LastTIME, O.LastUSER, O.OrdADD
                                    , L.LinNAME, F.FacNAME

                                     FROM Ordtbl O
                                    INNER JOIN Protbl PR
                                    	ON O.ProID = PR.ProID
                                    INNER JOIN Emptbl EM
                                    	ON O.EmpID = EM.EmpID
                                    INNER JOIN Itemtbl IT
                                    	ON O.ItemID = IT.ItemID
                                    INNER JOIN Lintbl L
                                    	ON PR.LinID = L.LinID
                                    INNER JOIN Factbl F
                                    	ON L.FacID = F.FacID
									Inner join commontbl c
                                    ON c.commonID = o.OrdSTATUS
                                    WHERE 1=1";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                ParametersJ(da.SelectCommand, orderVO);

                da.Fill(dt);

                return dt;
            }
        }


        // 위에 GetALL과 무슨 차이? 용도?

        public OrderVO GetWorkOrder(string OrdID)
        {
            string sql = @"SELECT O.OrdID, PR.ProID, PR.ProNAME, EM.EmpID, EM.EmpNAME, IT.ItemID, IT.itemNAME, O.OrdNAME, O.OrdDATE, O.OrdAMT, O.OrdCPLT
                                    , O.OrdFLT, O.WorkDATE, O.StartTIME, O.EndTIME, c.commonNAME, O.OrdSTATUS, O.FirstTIME, O.FirstUSER, O.LastTIME, O.LastUSER, O.OrdADD
                                    , L.LinID, L.LinNAME, F.FacID, F.FacNAME

                                     FROM Ordtbl O
                                    INNER JOIN Protbl PR
                                    	ON O.ProID = PR.ProID
                                    INNER JOIN Emptbl EM
                                    	ON O.EmpID = EM.EmpID
                                    INNER JOIN Itemtbl IT
                                    	ON O.ItemID = IT.ItemID
                                    INNER JOIN Lintbl L
                                    	ON PR.LinID = L.LinID
                                    INNER JOIN Factbl F
                                    	ON L.FacID = F.FacID
                                    Inner join commontbl c
                                    ON c.commonID = o.OrdSTATUS
                                     WHERE 1 = 1";

            return SqlExecutionJ<OrderVO>(sql, new OrderVO { OrdID = OrdID })?[0];
        }


        

        public DataTable GetToDoes()  //이건 뭐죠?
        {
            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                string sql = @"SELECT  c.ConID, c.ItemID, i.itemNAME, c.conDATE, c.conUSE, c.conADD
                                 FROM Contracttbl c
                                 INNER JOIN Itemtbl i
                                 ON c.ItemID = i.ItemID
                                 WHERE 1 = 1 
                                 AND c.ConUSE = 'N'
                                 ORDER BY ConDATE ASC";

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);

                da.Fill(dt);

                return dt;
            }
        }


        public DataTable SearchName(OrderVO vo)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                string sql = @"SELECT O.OrdID, PR.ProID, PR.ProNAME, EM.EmpID, EM.EmpNAME, IT.ItemID, IT.itemNAME, O.OrdNAME, O.OrdDATE, O.OrdAMT, O.OrdCPLT
                                    , O.OrdFLT, O.WorkDATE, O.StartTIME, O.EndTIME, c.commonNAME, O.OrdSTATUS, O.FirstTIME, O.FirstUSER, O.LastTIME, O.LastUSER, O.OrdADD
                                    , L.LinID, L.LinNAME, F.FacID, F.FacNAME

                                     FROM Ordtbl O
                                    INNER JOIN Protbl PR
                                    	ON O.ProID = PR.ProID
                                    INNER JOIN Emptbl EM
                                    	ON O.EmpID = EM.EmpID
                                    INNER JOIN Itemtbl IT
                                    	ON O.ItemID = IT.ItemID
                                    INNER JOIN Lintbl L
                                    	ON PR.LinID = L.LinID
                                    INNER JOIN Factbl F
                                    	ON L.FacID = F.FacID
                                    Inner join commontbl c
                                    ON c.commonID = o.OrdSTATUS
						   WHERE 1 = 1

                              AND (@FacID = '' or F.FacID =@FacID)
                              AND (@LinID = '' or L.LinID =@LinID)
                              AND (@ProID = '' or PR.ProID =@ProID)
                              AND (@ItemID = ''  or IT.ItemID = @ItemID);";// 검색조건

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FacID", vo.FacID);
                    cmd.Parameters.AddWithValue("@LinID", vo.LinID);
                    cmd.Parameters.AddWithValue("@ProID", vo.ProID);
                    cmd.Parameters.AddWithValue("@ItemID", vo.ItemID);


                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    cmd.Connection.Open();
                    da.Fill(dt);
                    cmd.Connection.Close();
                }
            }
            return dt;
        }

        public DataTable SearchOrderItem(OrderVO vo)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                string sql = @"SELECT O.OrdID, PR.ProID, PR.ProNAME, EM.EmpID, EM.EmpNAME, IT.ItemID, IT.itemNAME, O.OrdNAME, O.OrdDATE, O.OrdAMT, O.OrdCPLT
                                    , O.OrdFLT, O.WorkDATE, O.StartTIME, O.EndTIME, c.commonNAME, O.OrdSTATUS, O.FirstTIME, O.FirstUSER, O.LastTIME, O.LastUSER, O.OrdADD
                                    , L.LinID, L.LinNAME, F.FacID, F.FacNAME

                                     FROM Ordtbl O
                                    INNER JOIN Protbl PR
                                    	ON O.ProID = PR.ProID
                                    INNER JOIN Emptbl EM
                                    	ON O.EmpID = EM.EmpID
                                    INNER JOIN Itemtbl IT
                                    	ON O.ItemID = IT.ItemID
                                    INNER JOIN Lintbl L
                                    	ON PR.LinID = L.LinID
                                    INNER JOIN Factbl F
                                    	ON L.FacID = F.FacID
                                    Inner join commontbl c
                                    ON c.commonID = o.OrdSTATUS
						   WHERE 1 = 1

                              AND (@FacID = '' or F.FacID =@FacID)
                              AND (@ItemID = ''  or IT.ItemID = @ItemID);";// 검색조건

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FacID", vo.FacID);
                    cmd.Parameters.AddWithValue("@ItemID", vo.ItemID);


                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    cmd.Connection.Open();
                    da.Fill(dt);
                    cmd.Connection.Close();
                }
            }
            return dt;
        }



        public bool OrderDelete(List<int> order_idList)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    string selNum = string.Join(",", order_idList);

                    string sql = "Delete From Ordtbl where OrdID in (" + selNum + ") ;"; //여러개의 값을 삭제하고온다.

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

        public bool SaveOrder(List<OrderVO> olist)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    foreach (OrderVO vo in olist)
                    {
                        string sql = @"INSERT INTO ordtbl(proID , empID , itemID , ordNAME , ordDATE , ordAMT , ordCPLT , ordFLT , workDATE , startTIME , endTIME , ordSTATUS , firstTIME , firstUSER , lastTIME , lastUSER , ordADD )
                                    VALUES(@ProID, @EmpID, @ItemID, @OrdNAME, @OrdDATE, @OrdAMT, 0, 0, @WorkDATE, null, null, '1000', now(), @FirstUSER, now(), @LastUSER, @OrdADD);";
                        string sql2 = @"update contracttbl
                                        SET conUSE = 'Y'
                                        WHERE conID = @ConID;";


                        using (MySqlCommand cmd = new MySqlCommand(sql+ sql2, conn))
                        {

                            cmd.Parameters.AddWithValue("@EmpID", vo.EmpID);// 직원 아이디
                            cmd.Parameters.AddWithValue("@ItemID", vo.ItemID);// 품목 아이디
                            cmd.Parameters.AddWithValue("@ProID", vo.ProID);// 공정 아이디
                            cmd.Parameters.AddWithValue("@ProNAME", vo.ProNAME);// 공정 이름
                            cmd.Parameters.AddWithValue("@OrdNAME", vo.OrdNAME);// 작업 지시 이름
                            cmd.Parameters.AddWithValue("@OrdDATE", vo.OrdDATE);// 작업 지시 일자
                            cmd.Parameters.AddWithValue("@OrdAMT", vo.OrdAMT);// 작업 지시 수량
                            cmd.Parameters.AddWithValue("@WorkDATE", vo.WorkDATE);// 작업 일자
                            cmd.Parameters.AddWithValue("@FirstUSER", vo.FirstUSER);
                            cmd.Parameters.AddWithValue("@LastUSER", vo.LastUSER);
                            cmd.Parameters.AddWithValue("@OrdADD", vo.OrdADD);// 작업 지시 비고
                            cmd.Parameters.AddWithValue("@ConID", vo.ConID);

                            cmd.ExecuteNonQuery();
                        }
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
        public List<LineVO> LineEmpCombo(string facID)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string addString = string.Empty;
                    if (!String.IsNullOrEmpty(facID))
                    {
                        addString = " and f.FacID = " + facID.ToString();

                        cmd.Connection = new MySqlConnection(this.ConnectionString);
                        cmd.CommandText = @"select e.EmpID, e.EmpNAME
                                          from lintbl l
                                          INNER JOIN Emptbl e ON l.EmpID = e.EmpID 
                                          INNER JOIN factbl f ON f.FacID = l.FacID
                                         where 1 = 1 "
                                            + addString + ";";
                    }
                    else
                    {
                        cmd.Connection = new MySqlConnection(this.ConnectionString);
                        cmd.CommandText = @"select e.EmpID, e.EmpNAME
                                          from lintbl l
                                          INNER JOIN Emptbl e ON l.EmpID = e.EmpID
                                          INNER JOIN factbl f ON f.FacID = l.FacID";
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


        
        public List<ProVO> LineProcessCombo(string linID)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    string addString = string.Empty;
                    if (!String.IsNullOrEmpty(linID))
                    {
                        addString = " and p.LinID = " + linID.ToString();

                        cmd.Connection = new MySqlConnection(this.ConnectionString);
                        cmd.CommandText = @"select p.ProID, p.ProNAME
                                          from protbl p 
                                          INNER JOIN lintbl l ON p.LinID = l.LinID
                                          INNER JOIN factbl f ON f.FacID = l.FacID
                                         where 1 = 1 "
                                            + addString + ";";
                    }
                    else
                    {
                        cmd.Connection = new MySqlConnection(this.ConnectionString);
                        cmd.CommandText = @"select p.ProID, p.ProNAME
                                          from protbl p 
                                          INNER JOIN lintbl l ON p.LinID = l.LinID
                                          INNER JOIN factbl f ON f.FacID = l.FacID";
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

        public DataTable GetOrderListByDate(string fromDate, string toDate, string facID, string linID, string proID, string itemID)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                string sql = @"SELECT O.OrdID, PR.ProID, PR.ProNAME, EM.EmpID, EM.EmpNAME, IT.ItemID, IT.itemNAME, O.OrdNAME, O.OrdDATE, O.OrdAMT, O.OrdCPLT
                                    , O.OrdFLT, O.WorkDATE, O.StartTIME, O.EndTIME, c.commonNAME, O.OrdSTATUS, O.FirstTIME, O.FirstUSER, O.LastTIME, O.LastUSER, O.OrdADD
                                    , L.LinID, L.LinNAME, F.FacID, F.FacNAME

                                     FROM Ordtbl O
                                    INNER JOIN Protbl PR
                                    	ON O.ProID = PR.ProID
                                    INNER JOIN Emptbl EM
                                    	ON O.EmpID = EM.EmpID
                                    INNER JOIN Itemtbl IT
                                    	ON O.ItemID = IT.ItemID
                                    INNER JOIN Lintbl L
                                    	ON PR.LinID = L.LinID
                                    INNER JOIN Factbl F
                                    	ON L.FacID = F.FacID
                                    Inner join commontbl c
                                    ON c.commonID = o.OrdSTATUS
						   WHERE 1 = 1
                              AND (@FacID = '' or F.FacID =@FacID)
                              AND (@LinID = '' or L.LinID =@LinID)
                              AND (@ProID = '' or PR.ProID =@ProID)
                              AND (@ItemID = ''  or IT.ItemID = @ItemID)
                                
                              AND ordDATE  BETWEEN @FromDate AND @ToDate";


                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate); 
                    cmd.Parameters.AddWithValue("@ToDate", toDate);
                    cmd.Parameters.AddWithValue("@FacID", facID);
                    cmd.Parameters.AddWithValue("@LinID", linID);
                    cmd.Parameters.AddWithValue("@ProID", proID);
                    cmd.Parameters.AddWithValue("@ItemID", itemID);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    cmd.Connection.Open();
                    da.Fill(dt);
                    cmd.Connection.Close();
                }
            }
            return dt;
        }

        public List<OrderVO> GetSellsChart(string from, string to, string facID, string itemID)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = new MySqlConnection(this.ConnectionString);
                    cmd.CommandText = @"Select cast(sum(o.ordFLT) as SIGNED) as SumOrdFLT, cast(sum(o.ordCPLT) as SIGNED) as SumOrdCPLT, date(o.workDATE) AS 'WorkDATE'
                                        FROM ordtbl O
                                        INNER JOIN itemtbl I
                                        on O.itemID = I.itemID
                                        INNER JOIN protbl p
                                        on o.proID = p.proID
                                        inner join lintbl l
                                        on l.linID = p.linID
                                        inner join factbl f
                                        on f.facID = l.facID
                                        where 1=1
                                        and workDATE >= @From and workDATE <= @TO
                                        and (@ItemID = ''  or I.ItemID = @ItemID)
                                        and (@FacID = '' or F.FacID =@FacID)
                                        group by workDATE;";

                    cmd.Parameters.AddWithValue("@From", from);
                    cmd.Parameters.AddWithValue("@TO", to);
                    cmd.Parameters.AddWithValue("@FacID", facID);
                    cmd.Parameters.AddWithValue("@ItemID", itemID);

                    cmd.Connection.Open();


                    return SqlHelper.DataReaderMapToList<OrderVO>(cmd.ExecuteReader());
                }

            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public List<OrderVO> SearchOrderItem2(OrderVO vo)
        {

            using (MySqlConnection conn = new MySqlConnection(this.ConnectionString))
            {
                string sql = @"SELECT O.OrdID, PR.ProID, PR.ProNAME, EM.EmpID, EM.EmpNAME, IT.ItemID, IT.itemNAME, O.OrdNAME, O.OrdDATE, O.OrdAMT, O.OrdCPLT
                                    , O.OrdFLT, O.WorkDATE, O.StartTIME, O.EndTIME, c.commonNAME, O.OrdSTATUS, O.FirstTIME, O.FirstUSER, O.LastTIME, O.LastUSER, O.OrdADD
                                    , L.LinID, L.LinNAME, F.FacID, F.FacNAME

                                     FROM Ordtbl O
                                    INNER JOIN Protbl PR
                                    	ON O.ProID = PR.ProID
                                    INNER JOIN Emptbl EM
                                    	ON O.EmpID = EM.EmpID
                                    INNER JOIN Itemtbl IT
                                    	ON O.ItemID = IT.ItemID
                                    INNER JOIN Lintbl L
                                    	ON PR.LinID = L.LinID
                                    INNER JOIN Factbl F
                                    	ON L.FacID = F.FacID
                                    Inner join commontbl c
                                    ON c.commonID = o.OrdSTATUS
						   WHERE 1 = 1

                              AND (@FacID = '' or F.FacID =@FacID)
                              AND (@ItemID = ''  or IT.ItemID = @ItemID);";// 검색조건

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@FacID", vo.FacID);
                cmd.Parameters.AddWithValue("@ItemID", vo.ItemID);

                cmd.Connection.Open();

                return SqlHelper.DataReaderMapToList<OrderVO>(cmd.ExecuteReader());
            }
        }
    }
}
