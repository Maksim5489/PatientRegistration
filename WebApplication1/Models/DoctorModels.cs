using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DoctorModels
    {
        public string Idr { get; set; }
        public string DocFIO { get; set; }
        public string Cabinet { get; set; }
        public string Qualification { get; set; }
        public string Work_experience { get; set; }
        public string EmailD { get; set; }

        public int Delete(int Idr)
        {
            SqlConnection Connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApplication1-20201104082923.mdf;Initial Catalog=aspnet-WebApplication1-20201104082923;Integrated Security=True");
            Connection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Doctors WHERE Idr=" + this.Idr, Connection);
            return cmd.ExecuteNonQuery();
        }

    }
}