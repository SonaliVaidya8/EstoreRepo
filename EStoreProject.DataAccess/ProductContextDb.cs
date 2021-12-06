using EStoreProject.DataAccess.Interfaces;
using EStoreProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EStoreProject.DataAccess
{
    public class ProductContextDb : IProductContextDb
    {
         string connectionString = "Data Source=DESKTOP-M6TVEB0\\SQLEXPRESS; Initial Catalog=EstoreDb; Integrated Security=SSPI; User ID=sa; Password=Sonali*811;";
        public void CreateNewProduct(Products product)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_CreateNewProduct12", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductdId", product.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                cmd.Parameters.AddWithValue("@ProductCategoryName", product.ProductCategoryName);
                cmd.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                cmd.Parameters.AddWithValue("@ProductSize", product.ProductSize);
                cmd.Parameters.AddWithValue("@ProductImage", product.ProductImage);
                cmd.Parameters.AddWithValue("@ProductRating", product.ProductRating);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteProduct(int product)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteProduct1", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductId", product);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<Products> GetAllProduct()
        {
            var productList = new List<Products>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllProduct1", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                // SqlDataAdapter dr = new SqlDataAdapter(cmd);
                while (dr.Read())
                {
                    var product = new Products();
                    product.ProductId = Convert.ToInt32(dr["ProductId"].ToString());
                    product.ProductName = dr["ProductName"].ToString();
                    product.ProductPrice = Convert.ToInt32(dr["ProductPrice"].ToString());
                    product.ProductCategoryName = dr["ProductCategoryName"].ToString();
                    product.ProductDescription = dr["ProductDescription"].ToString();
                    product.ProductSize = dr["ProductSize"].ToString();
                    product.ProductImage = dr["ProductImage"].ToString();
                    product.ProductRating = dr["ProductRating"].ToString();



                    //product.ListPrice = (int)Convert.ToDecimal(dr["ListPrice"].ToString());


                    productList.Add(product);

                }
                con.Close();
            }
            return productList;
        }

        public Products GetProductById(int ProductId)
        {
            var productList = new List<Products>();
            var product = new Products();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetProductById1", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductId", ProductId);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    product.ProductId = Convert.ToInt32(dr["ProductId"].ToString());
                    product.ProductName = dr["ProductName"].ToString();
                    product.ProductPrice = float.Parse(dr["ProductPrice"].ToString());
                    // product.ProductPrice = Convert.ToInt32(dr["ProductPrice"].ToString());
                    product.ProductCategoryName = dr["ProductCategoryName"].ToString();
                    product.ProductDescription = dr["ProductDescription"].ToString();
                    product.ProductSize = dr["ProductSize"].ToString();
                    product.ProductImage = dr["ProductImage"].ToString();
                    product.ProductRating = dr["ProductRating"].ToString();



                }
                con.Close();
            }
            return product;
        }

        public Products UpdateProduct(Products product)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateProduct1", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                cmd.Parameters.AddWithValue("@ProductCategoryName", product.ProductCategoryName);
                cmd.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                cmd.Parameters.AddWithValue("@ProductSize", product.ProductSize);
                cmd.Parameters.AddWithValue("@ProductImage", product.ProductImage);
                cmd.Parameters.AddWithValue("@ProductRating", product.ProductRating);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return product;
        }
    }
}
