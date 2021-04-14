using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApplication1.DAO
{
    public class ZayavkiDAO
    {
        
        public bool Edit(ZayavkiModels ZayavkiModel)
        {
            bool result = true;
            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApplication1-20201104082923.mdf;Initial Catalog=aspnet-WebApplication1-20201104082923;Integrated Security=True";
            string sqlExpression = "UPDATE Zayavki SET Recept=@Recept, Disease=@Disease WHERE Zayavki.EmailZ=Zayavki.EmailZ and Zayavki.Doctor=Zayavki.Doctor";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(sqlExpression, connection);
                sql.Parameters.Add("@Recept", SqlDbType.NVarChar);
                sql.Parameters["@Recept"].Value = ZayavkiModel.Recept;
                sql.Parameters.Add("@Disease", SqlDbType.NVarChar);
                sql.Parameters["@Disease"].Value = ZayavkiModel.Disease;
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

        public bool CreateDoctors(ZayavkiModels ZayavkiModel)
        {
            //ZayavkiModels zayavki = db.FIO.Find();
            bool result = true;
            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApplication1-20201104082923.mdf;Initial Catalog=aspnet-WebApplication1-20201104082923;Integrated Security=True";
            string sqlExpression = "INSERT INTO Zayavki ([Date], [Doctor], [FIOp], [EmailZ]) VALUES (@Date, @Doctor, @FIOp, @EmailZ) Select Patient.Email FROM Patient WHERE Patient.Email=@EmailZ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(sqlExpression, connection);
                sql.Parameters.Add("@Date", SqlDbType.DateTime);
                sql.Parameters["@Date"].Value = ZayavkiModel.Date;
                sql.Parameters.Add("@Doctor", SqlDbType.NVarChar);
                sql.Parameters["@Doctor"].Value = ZayavkiModel.Doctor;
                sql.Parameters.Add("@FIOp", SqlDbType.NVarChar);
                sql.Parameters["@FIOp"].Value = ZayavkiModel.FIO;
                sql.Parameters.Add("@EmailZ", SqlDbType.NVarChar);
                sql.Parameters["@EmailZ"].Value = ZayavkiModel.EmailZ;
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

        public bool Check(PatientModels PatientModel)
        {
            bool result = true;
            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApplication1-20201104082923.mdf;Initial Catalog=aspnet-WebApplication1-20201104082923;Integrated Security=True";
            string sqlExpression = "UPDATE Zayavki SET Status=@Status WHERE Email=@Email";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(sqlExpression, connection);
                sql.Parameters.Add("@Email", SqlDbType.NVarChar);
                sql.Parameters["@Email"].Value = PatientModel.Email;
                sql.Parameters.Add("@Status", SqlDbType.NVarChar);
                sql.Parameters["@Status"].Value = "Check out";
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