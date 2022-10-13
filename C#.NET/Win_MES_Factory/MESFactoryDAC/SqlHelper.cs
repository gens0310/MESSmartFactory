using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MESFactoryDAC
{
    public class SqlHelper : ConnectionAccess, IDisposable
    {
        protected MySqlConnection conn;

        public SqlHelper()
        {
            conn = new MySqlConnection(this.ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            if (conn?.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

        public List<T> SqlExecution<T>(string sql, int ParameterCount = 0, string[] ParameterName = null, object[] value = null)
        {
            // sql문, 파라미터 수, parameter이름 배열, object 이름 배열
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                Parameters(cmd, ParameterCount, ParameterName, value);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    return DataReaderMapToList<T>(reader);
                }
            }
        }


        public void Parameters(MySqlCommand cmd, int ParameterCount, string[] ParameterName, object[] value)
        {
            for (int i = 0; i < ParameterCount; i++)
                cmd.Parameters.AddWithValue(ParameterName[i], value[i]);
        }

        public object SqlExecutionScalar(string sql, int ParameterCount, string[] ParameterName = null, object[] value = null)
        {
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                Parameters(cmd, ParameterCount, ParameterName, value);
                return cmd.ExecuteScalar();
            }
        }


        public bool NotSelectSqlExecution(string sql, int ParameterCount = 0, string[] ParameterName = null, object[] value = null)
        {
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                Parameters(cmd, ParameterCount, ParameterName, value);
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                    return true;
                else
                    return false;
            }
        }

        public List<T> SqlExecutionJ<T>(string sql, T vo = null) where T : class, new()
        {
            // sql문, object
            using (MySqlCommand cmd = new MySqlCommand(sql, this.conn))
            {
                ParametersJ<T>(cmd, vo);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    return DataReaderMapToList<T>(reader);
                }
            }
        }

        // 모든 프로퍼티를 다 파라매터로 넘긴다.
        // 이렇게 쓸 경우 파라매터 네임은 모두 대문자로 하여야 한다.
        public void ParametersJ<T>(MySqlCommand cmd, T vo) where T : class, new()
        {
            if (vo != null)
            {
                foreach (PropertyInfo prop in vo.GetType().GetProperties())
                {
                    string name = "@" + prop.Name.ToUpper();

                    if (cmd.CommandText.Contains(name))
                        cmd.Parameters.AddWithValue(name, prop.GetValue(vo));
                }
            }
        }

        public void SpParametersJ<T>(MySqlCommand cmd, T vo, params string[] names) where T : class, new()
        {
            if (vo != null)
            {
                Type type = vo.GetType();

                foreach (string name in names)
                {
                    PropertyInfo prop = type.GetProperty(name);

                    if (prop != null)
                        cmd.Parameters.AddWithValue("@P_" + name, prop.GetValue(vo));
                }

                //foreach (PropertyInfo prop in vo.GetType().GetProperties())
                //{
                //	if (names.Contains(prop.Name))
                //		cmd.Parameters.AddWithValue("@P_" + prop.Name, prop.GetValue(vo));
                //}
            }
        }

        public bool NotSelectSqlExecutionJ<T>(string sql, T vo = null) where T : class, new()
        {
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                ParametersJ<T>(cmd, vo);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool NotSelectSPJ<T>(string sql, T vo, params string[] names) where T : class, new()
        {
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SpParametersJ<T>(cmd, vo, names);
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            try
            {
                List<T> list = new List<T>();
                T obj = default(T);
                while (dr.Read())
                {
                    obj = Activator.CreateInstance<T>();
                    DataTable dt = dr.GetSchemaTable();

                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        if (IsUseName(dt, prop.Name) && !object.Equals(dr[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, dr[prop.Name], null);
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public static List<T> ConvertDataTableToList<T>(DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();
                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public static List<Dictionary<string, string>> DataReaderMapToDicList(IDataReader dr)
        {
            try
            {
                List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();

                while (dr.Read())
                {
                    DataTable dt = dr.GetSchemaTable();
                    Dictionary<string, string> dic = new Dictionary<string, string>();

                    foreach (DataRow dataRow in dt.Rows)
                    {
                        string columnName = dataRow["ColumnName"].ToString();

                        dic[columnName.ToUpper()] = dr[columnName].ToString();
                    }

                    list.Add(dic);
                }
                return list;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        /// <summary>
        /// 읽어 온 데이터에 있는 컬럼인지 확인 하는 메서드
        /// </summary>
        /// <param name="dt">스키마 데이터테이블</param>
        /// <param name="name">VO프로퍼티 이름</param>
        /// <returns></returns>
        private static bool IsUseName(DataTable dt, string name)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["ColumnName"].ToString().ToUpper() == name.ToUpper())
                    return true;
            }

            return false;
        }

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }

            return table;
        }
    }
}
