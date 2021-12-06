using EStoreProject.DataAccess.Interfaces;
using EStoreProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EStoreProject.DataAccess
{
    public class AdminContextDb : IAdminContextDb
    {
        readonly string connectionString = "Data Source=DESKTOP-M6TVEB0\\SQLEXPRESS; Initial Catalog=EstoreDb; Integrated Security=SSPI; User ID=sa; Password=Sonali*811;";

        //string connectionString = "Data Source=DESKTOP-M6TVEB0\\SQLEXPRESS;Database=EstoreDb;Integrated Security=True";

        public void AddAdmin(Admin objAdmin)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("Sp_Admin", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AdFirstName", objAdmin.AdFirstName);
                command.Parameters.AddWithValue("@AdLastName", objAdmin.AdLastName);
                command.Parameters.AddWithValue("@AdEmail_id", objAdmin.AdEmail_id);
                command.Parameters.AddWithValue("@AdContactNumber", objAdmin.AdContactNumber);
                command.Parameters.AddWithValue("@AdPassword", objAdmin.AdPassword);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        /*
        public void DeleteAdmin(int admin)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteAdmin", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AdEmail_id", admin);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        */

        List<Admin> IAdminContextDb.GetAllAdmin()
        {
            var adminList = new List<Admin>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_AdminList", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                // SqlDataAdapter dr = new SqlDataAdapter(cmd);
                while (dr.Read())
                {
                    var admin = new Admin();
                    admin.AdFirstName = dr["AdFirstName"].ToString();
                    admin.AdLastName = dr["AdLastName"].ToString();
                    admin.AdContactNumber = dr["AdContactNumber"].ToString();
                    admin.AdEmail_id = dr["AdEmail_id"].ToString();
                    admin.AdPassword = dr["AdPassword"].ToString();

                    adminList.Add(admin);

                }
                con.Close();
            }
            return adminList;
        }


        /*
        public int GetByAdEmail_id(string AdEmail_id, string AdPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetByAdEmail_id", connection); 
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AdEmail_id", AdEmail_id);
                command.Parameters.AddWithValue("@AdPassword", AdPassword);
                SqlParameter AdminLogin = new SqlParameter();
                AdminLogin.ParameterName = "@IsValid";
                AdminLogin.SqlDbType = SqlDbType.Bit;
                AdminLogin.Direction = ParameterDirection.Output;
                command.Parameters.Add(AdminLogin);
                connection.Open();
                command.ExecuteNonQuery();
                int result = Convert.ToInt32(AdminLogin.Value);
                connection.Close();

                return result;

            }
        }
        */
    }
}
