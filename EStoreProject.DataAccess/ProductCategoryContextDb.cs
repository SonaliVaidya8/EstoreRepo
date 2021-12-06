using EStoreProject.DataAccess.Interfaces;
using EStoreProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EStoreProject.DataAccess
{
    public class ProductCategoryContextDb : IProductCategoryContextDb
    {
         string connectionString = "Data Source=DESKTOP-M6TVEB0\\SQLEXPRESS; Initial Catalog=EstoreDb; Integrated Security=SSPI; User ID=sa; Password=Sonali*811;";

        public void CreateProductCategory(ProductCategory productCategory)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_CreateProductCategory", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductCategoryId", productCategory.ProductCategoryId);
                cmd.Parameters.AddWithValue("@ProductCategoryName", productCategory.ProductCategoryName);
                cmd.Parameters.AddWithValue("@ProductCategoryImage", productCategory.ProductCategoryImage);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


            }

        }

        public void DeleteProductCategory(int productCategory)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteProductCategory", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductCategoryId", productCategory);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }

        }

        public List<ProductCategory> GetAllProductCategory()
        {
            var productCategoryList = new List<ProductCategory>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllProductCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                // SqlDataAdapter dr = new SqlDataAdapter(cmd);
                while (dr.Read())
                {
                    var productCategory = new ProductCategory();
                    productCategory.ProductCategoryId = Convert.ToInt32(dr["ProductCategoryId"].ToString());
                    productCategory.ProductCategoryName = dr["ProductCategoryName"].ToString();
                    productCategory.ProductCategoryImage = dr["ProductCategoryImage"].ToString();
                    productCategoryList.Add(productCategory);

                }
                con.Close();
            }
            return productCategoryList;

        }
    

    public ProductCategory GetProductCategoryById(int ProductCategoryId)
    {
        var productCategoryList = new List<ProductCategory>();
        var productCategory = new ProductCategory();
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("GetProductCategoryById", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductCategoryId", ProductCategoryId);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                productCategory.ProductCategoryId = Convert.ToInt32(dr["ProductCategoryId"].ToString());
                productCategory.ProductCategoryName = dr["ProductCategoryName"].ToString();
                productCategory.ProductCategoryImage = dr["ProductCategoryImage"].ToString();
                productCategoryList.Add(productCategory);

            }
            con.Close();
        }
        return productCategory;


    }

    public ProductCategory UpdateProductCategory(ProductCategory productCategory)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SP_UpdateProductCategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductCategoryId", productCategory.ProductCategoryId);
            cmd.Parameters.AddWithValue("@ProductCategoryName", productCategory.ProductCategoryName);
            cmd.Parameters.AddWithValue("@ProductCategoryImage", productCategory.ProductCategoryImage);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
        return productCategory;
     }
    }
}

