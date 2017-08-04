using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;

namespace LTP.Common
{
    public class Lucene_Path
    {
        public static string connectionString = ConfigurationManager.AppSettings["ConnectionString2"];
        string pathA = ConfigurationManager.AppSettings["indexpathA"];
        string pathB = ConfigurationManager.AppSettings["indexpathB"];
        string path = ConfigurationManager.AppSettings["indexpath"];
        /// <summary>
        /// 当S1、S2服务器都处于空闲状态（即State为0）时，则取后创建完成的地址；当一个忙一个闲时，取闲置服务器地址；如果两个都忙，则返回备选方案的地址。
        /// </summary>
        /// <returns></returns>
        public string returnPath()
        {
            return path;

            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from State where State='finish' order by startTime desc ", con))
                    {
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);

                        sda.Fill(ds);

                        cmd.Dispose();
                    }
                    con.Dispose();
                    con.Close();
                }
                string ID = "";
                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    switch (dr["ID"].ToString())
                    {
                        case "171":
                            ID = pathA;
                            break;
                        case "172":
                            ID = pathB;
                            break;
                        default:
                            ID = path;
                            break;
                    }
                }
                else
                {
                    ID = path;
                }
                return ID;
            }
            catch
            {
                return path;
            }
        }
    }
}
