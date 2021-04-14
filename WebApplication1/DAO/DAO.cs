using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplication1.DAO
{
    public class DAO
    {
        private const string ConnectionString = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=MyDateBase; Integrated Security=True";
        public SqlConnection Connection { get; set; }
        public void Connect()
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }
        public void Disconnect()
        {
            Connection.Close();
        }
    }
}