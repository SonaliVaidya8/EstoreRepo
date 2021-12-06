using EStoreProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStoreProject.DataAccess.Interfaces
{
    public interface IProductCategoryContextDb
    {
        List<ProductCategory> GetAllProductCategory();

        ProductCategory GetProductCategoryById(int ProductCategoryId);
        void CreateProductCategory(ProductCategory productCategory);

        void DeleteProductCategory(int productCategory);
        ProductCategory UpdateProductCategory(ProductCategory productCategory);
    }
}
