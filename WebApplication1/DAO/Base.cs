using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1.DAO
{
    public class Base : DAO
    {
        public bool Edited(UsersWithRoles UsersWithRole)
        {
            bool result = true;
            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApplication1-20201104082923.mdf;Initial Catalog=aspnet-WebApplication1-20201104082923;Integrated Security=True";
            string sqlExpression = "UPDATE AspNetUsers SET PhoneNumber=@PhoneNumber WHERE Id=@Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(sqlExpression, connection);
                sql.Parameters.Add("@Id", SqlDbType.NVarChar);
                sql.Parameters["@Id"].Value = UsersWithRole.Id;
                sql.Parameters.Add("@PhoneNumber", SqlDbType.Int);
                sql.Parameters["@PhoneNumber"].Value = UsersWithRole.PhoneNumber;
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

        public bool AddRole(UsersWithRoles UsersWithRole)
        {
            bool result = true;
            string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-WebApplication1-20201104082923.mdf;Initial Catalog=aspnet-WebApplication1-20201104082923;Integrated Security=True";
            string sqlExpression = "UPDATE AspNetUserRoles SET RoleId=@RoleId WHERE UserId=@UserId"; 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sql = new SqlCommand(sqlExpression, connection);
                sql.Parameters.Add("@UserId", SqlDbType.NVarChar);
                sql.Parameters["@UserId"].Value = UsersWithRole.UserId;
                sql.Parameters.Add("@RoleId", SqlDbType.NVarChar);
                sql.Parameters["@RoleId"].Value = UsersWithRole.RoleId;
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