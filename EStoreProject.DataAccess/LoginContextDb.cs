using EStoreProject.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EStoreProject.DataAccess
{
    public class LoginContextDb : ILoginContextDb
    {
        readonly string connectionString = "Data Source=DESKTOP-M6TVEB0\\SQLEXPRESS; Initial Catalog=EstoreDb; Integrated Security=SSPI; User ID=sa; Password=Sonali*811;";

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
    }
}

