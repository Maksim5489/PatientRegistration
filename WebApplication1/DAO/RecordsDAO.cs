using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using System.Data.SqlClient;


namespace WebApplication1.DAO
{

    public class RecordsDAO : DAO
    {
        public List<Records> GetAllRecords()
        {
            Connect();
            List<Records> recordList = new List<Records>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[Case] ", Connection);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Records record = new Records
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Author = Convert.ToString(reader["Author"]),
                        Title = Convert.ToString(reader["Title"]),
                        PublicationDate = Convert.ToDateTime(reader["PublicationDate"])
                    };
                    recordList.Add(record);
                }
                reader.Close();
            }
            catch (Exception)
            {
                
            }
            finally
            {
                Disconnect();
            }
            return recordList;
        }

        public bool AddRecord(Records records)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Case] (Title, Author, PublicationDate) " + "VALUES (@Title, @Author, @PublicationDate)", Connection);
                cmd.Parameters.Add(new SqlParameter("@Title", records.Title));
                cmd.Parameters.Add(new SqlParameter("@Author", records.Author));
                cmd.Parameters.Add(new SqlParameter("@PublicationDate", records.PublicationDate));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }


        public bool EditRecord(Records records)
        {
            bool result = true;
            Connect();
            try
            {
                string A = "@ID";
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Case] SET Title=@Title, Author=@Author, PublicationDate=@PublicationDate WHERE ID=" + A, Connection);
                cmd.Parameters.Add(new SqlParameter("@ID", records.ID));
                cmd.Parameters.Add(new SqlParameter("@Title", records.Title));
                cmd.Parameters.Add(new SqlParameter("@Author", records.Author));
                cmd.Parameters.Add(new SqlParameter("@PublicationDate", records.PublicationDate));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }

    }

}