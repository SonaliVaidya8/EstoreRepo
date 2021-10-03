using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using EStoreProject.Model;

namespace EStoreProject.DataAccess
{
    public class AdminContextDb 
    {
        string connectionString = "Data Source=DESKTOP-M6TVEB0\\SQLEXPRESS;Database=EstoreDb;Integrated Security=True";
        public void AddAdmin(Admin ad)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("Sp_Admin", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AdFirstName", ad.AdFirstName);
                command.Parameters.AddWithValue("@AdLastName", ad.AdLastName);
                command.Parameters.AddWithValue("@AdEmai_id", ad.AdEmail_id);
                command.Parameters.AddWithValue("AdContactNumber", ad.AdContactNumber);
                command.Parameters.AddWithValue("@AdPassword", ad.AdPassword);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }

        }
        public Admin GetByEmail_id(string AdEmail_id)
        {
            var adminList = new List<Admin>();
            var admin = new Admin();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("Sp_Admin", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AdEmai_id",AdEmail_id);
                con.Open();
                    SqlDataReader dr = command.ExecuteReader();
                while(dr.Read())
                {
                    admin.AdFirstName = dr["AdFirstName"].ToString();
                    admin.AdLastName = dr["AdLastName"].ToString();
                    admin.AdEmail_id = dr["AdEmail_id"].ToString();
                    admin.AdContactNumber = dr["AdContactNumber"].ToString();
                    admin.AdPassword = dr["AdPassword"].ToString();
                    adminList.Add(admin);

                }
                con.Close();
            }
            return admin;
        }
    }
}