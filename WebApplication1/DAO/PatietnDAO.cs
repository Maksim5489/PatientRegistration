using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebApplication1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace WebApplication1.DAO
{
    public class PatietnDAO : DAO
    {
        public bool Edit(PatientModels PatientModel)
        {
            bool result = true;
            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApplication1-20201104082923.mdf;Initial Catalog=aspnet-WebApplication1-20201104082923;Integrated Security=True";
            string sqlExpression = "UPDATE Patient SET FIO=@FIO, FIO=@FIO, Gender=@Gender, Date_of_Birth=@Date_of_Birth, Policy_number=@Policy_number, PassportID=@PassportID, Job=@Job, Disability=@Disability, Chronic_diseases=@Chronic_diseases WHERE Id=@Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(sqlExpression, connection);
                sql.Parameters.Add("@Id", SqlDbType.Int);
                sql.Parameters["@Id"].Value = PatientModel.Id;
                sql.Parameters.Add("@Gender", SqlDbType.NVarChar);
                sql.Parameters["@Gender"].Value = PatientModel.Gender;
                sql.Parameters.Add("@FIO", SqlDbType.NVarChar);
                sql.Parameters["@FIO"].Value = PatientModel.FIO;
                sql.Parameters.Add("@Date_of_Birth", SqlDbType.Date);
                sql.Parameters["@Date_of_Birth"].Value = PatientModel.Date_of_Birth;
                sql.Parameters.Add("@Policy_number", SqlDbType.NVarChar);
                sql.Parameters["@Policy_number"].Value = PatientModel.Policy_number;
                sql.Parameters.Add("@PassportID", SqlDbType.NVarChar);
                sql.Parameters["@PassportID"].Value = PatientModel.PassportID;
                sql.Parameters.Add("@Job", SqlDbType.NVarChar);
                sql.Parameters["@Job"].Value = PatientModel.Job;
                sql.Parameters.Add("@Disability", SqlDbType.NVarChar);
                sql.Parameters["@Disability"].Value = PatientModel.Disability;
                sql.Parameters.Add("@Chronic_diseases", SqlDbType.NVarChar);
                sql.Parameters["@Chronic_diseases"].Value = PatientModel.Chronic_diseases;
                try
                {
                    connection.Open();
                    int rowsAffected = sql.ExecuteNonQuery();
                    Console.WriteLine("RowsAffected: {0}", rowsAffected);
                }
                catch (Exception)
                {
                    result = false;
                }
                return result;
            }
        }
        public bool Create(PatientModels PatientModel)
        {
            bool result = true;
            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApplication1-20201104082923.mdf;Initial Catalog=aspnet-WebApplication1-20201104082923;Integrated Security=True";
            string sqlExpression = "INSERT INTO Patient ([Gender], [FIO], [Date_of_Birth], [Policy_number], [PassportID], [Job], [Disability], [Chronic_diseases], [Email]) VALUES (@Gender, @FIO, @Date_of_Birth, @Policy_number, @PassportID, @Job, @Disability, @Chronic_diseases, @Email)"; //AND Update AspNetUsers SET Policy_number=@Policy_number WHERE Email=@Email";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(sqlExpression, connection);
                sql.Parameters.Add("@Gender", SqlDbType.NVarChar);
                sql.Parameters["@Gender"].Value = PatientModel.Gender;
                sql.Parameters.Add("@FIO", SqlDbType.NVarChar);
                sql.Parameters["@FIO"].Value = PatientModel.FIO;
                sql.Parameters.Add("@Date_of_Birth", SqlDbType.Date);
                sql.Parameters["@Date_of_Birth"].Value = PatientModel.Date_of_Birth;
                sql.Parameters.Add("@Policy_number", SqlDbType.NVarChar);
                sql.Parameters["@Policy_number"].Value = PatientModel.Policy_number;
                sql.Parameters.Add("@PassportID", SqlDbType.NVarChar);
                sql.Parameters["@PassportID"].Value = PatientModel.PassportID;
                sql.Parameters.Add("@Job", SqlDbType.NVarChar);
                sql.Parameters["@Job"].Value = PatientModel.Job;
                sql.Parameters.Add("@Disability", SqlDbType.NVarChar);
                sql.Parameters["@Disability"].Value = PatientModel.Disability;
                sql.Parameters.Add("@Chronic_diseases", SqlDbType.NVarChar);
                sql.Parameters["@Chronic_diseases"].Value = PatientModel.Chronic_diseases;
                sql.Parameters.Add("@Email", SqlDbType.NVarChar);
                sql.Parameters["@Email"].Value = PatientModel.Email;
                try
                {
                    connection.Open();
                    int rowsAffected = sql.ExecuteNonQuery();
                    Console.WriteLine("RowsAffected: {0}", rowsAffected);
                }
                catch (Exception)
                {
                    result = false;
                }
                return result;
            }
        }

       
        public bool Detali(PatientModels PatientModel)
        {
            bool result = true;
            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApplication1-20201104082923.mdf;Initial Catalog=aspnet-WebApplication1-20201104082923;Integrated Security=True";
            string sqlExpression = "SELECT * From Patient";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(sqlExpression, connection);
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
