using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DAO;
using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class Records
    {
        public IndexViewModel IndexViewModel { get; set; }
        //public int ID { get; set; }
        //public string Title { get; set; }
        //public string Author { get; set; }
        //public DateTime PublicationDate { get; set; }
        //public int Delete(int ID)
        //{
        //    SqlConnection Connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS; Initial Catalog=MyDateBase; Integrated Security=True");
        //    Connection.Open();
        //    SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Case] WHERE ID=" + this.ID, Connection);
        //    return cmd.ExecuteNonQuery();
        //}
        //public List<Records> RecordsList { get; set; }

        
    }
}