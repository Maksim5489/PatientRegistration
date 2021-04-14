using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public class DoctorDAO : DAO
    {
        public bool Edit(DoctorModels DoctorModel)
        {
            bool result = true;
            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApplication1-20201104082923.mdf;Initial Catalog=aspnet-WebApplication1-20201104082923;Integrated Security=True";
            string sqlExpression = "UPDATE Doctors SET DocFIO=@DocFIO, Cabinet=@Cabinet, Qualification=@Qualification, Work_experience=@Work_experience WHERE Idr=@Idr";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(sqlExpression, connection);
                sql.Parameters.Add("@Idr", SqlDbType.NVarChar);
                sql.Parameters["@Idr"].Value = DoctorModel.Idr;
                sql.Parameters.Add("@DocFIO", SqlDbType.NVarChar);
                sql.Parameters["@DocFIO"].Value = DoctorModel.DocFIO;
                sql.Parameters.Add("@Cabinet", SqlDbType.NVarChar);
                sql.Parameters["@Cabinet"].Value = DoctorModel.Cabinet;
                sql.Parameters.Add("@Qualification", SqlDbType.NVarChar);
                sql.Parameters["@Qualification"].Value = DoctorModel.Qualification;
                sql.Parameters.Add("@Work_experience", SqlDbType.NVarChar);
                sql.Parameters["@Work_experience"].Value = DoctorModel.Work_experience;
                try
                {
                    connection.Open();
                    Int32 rowsAffected = sql.ExecuteNonQuery();
                    Console.WriteLine("RowsAffected: {0}", rowsAffected);
                }
                catch (Exception)
                {
                    result = false;
                }
                return result;
            }
        }

        public bool Create(DoctorModels DoctorModel)
        {
            bool result = true;
            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApplication1-20201104082923.mdf;Initial Catalog=aspnet-WebApplication1-20201104082923;Integrated Security=True";
            string sqlExpression = "INSERT INTO Doctors ([Idr], [DocFIO], [Cabinet], [Qualification], [Work_experience], [EmailD]) VALUES (@Idr, @DocFIO, @Cabinet, @Qualification, @Work_experience, @EmailD)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(sqlExpression, connection);
                sql.Parameters.Add("@Idr", SqlDbType.NVarChar);
                sql.Parameters["@Idr"].Value = DoctorModel.Idr;
                sql.Parameters.Add("@DocFIO", SqlDbType.NVarChar);
                sql.Parameters["@DocFIO"].Value = DoctorModel.DocFIO;
                sql.Parameters.Add("@Cabinet", SqlDbType.NVarChar);
                sql.Parameters["@Cabinet"].Value = DoctorModel.Cabinet;
                sql.Parameters.Add("@Qualification", SqlDbType.NVarChar);
                sql.Parameters["@Qualification"].Value = DoctorModel.Qualification;
                sql.Parameters.Add("@Work_experience", SqlDbType.NVarChar);
                sql.Parameters["@Work_experience"].Value = DoctorModel.Work_experience;
                sql.Parameters.Add("@EmailD", SqlDbType.NVarChar);
                sql.Parameters["@EmailD"].Value = DoctorModel.EmailD;
                try
                {
                    connection.Open();
                    Int32 rowsAffected = sql.ExecuteNonQuery();
                    Console.WriteLine("RowsAffected: {0}", rowsAffected);
                }
                catch (Exception)
                {
                    result = false;
                }
                return result;
            }
        }
    }
}