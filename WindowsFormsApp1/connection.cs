using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    class connection
    {
        static string host = @"NPK1U5PC";
        static string database = "Users";
        public string strProvider = "Data Source=" + host + ";Initial Catalog=" + database + ";Integrated Security=True";
        public SqlConnection conn;
        string myConnectionString;

        public bool Open()
        {
            try
            {
                conn = new SqlConnection(strProvider);
                conn.Open();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SqlDataReader ExecuteReader(string sql)
        {
            try
            {
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
