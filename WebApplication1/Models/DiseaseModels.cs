using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DiseaseModels
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string FIO { get; set; }
        public string DocFIO { get; set; }

        [DisplayName("Doctor")]
        public string Qualification { get; set; }
        public string Doctor { get; set; }
        public string Recept { get; set; }
        public string Policy_number { get; set; }
        public string EmailZ { get; set; }
        public string Disease { get; set; }
        public int Delete(int Id)
        {
            SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApplication1-20201104082923.mdf;Initial Catalog=aspnet-WebApplication1-20201104082923;Integrated Security=True");
            Connection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Disease WHERE Id=" + this.Id, Connection);
            return cmd.ExecuteNonQuery();
        }
    }
}