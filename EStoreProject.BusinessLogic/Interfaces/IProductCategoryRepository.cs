using EStoreProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStoreProject.BusinessLogic.Interfaces
{
    public interface IProductCategoryRepository
    {
        List<ProductCategory> GetAllProductCategory();

        ProductCategory GetProductByCategoryId(int ProductCategoryId );
        void CreateProductCategory(ProductCategory productCategory);

        void DeleteProductCategory(int productCategory);
        ProductCategory UpdateProductCategory(ProductCategory productCategory);


    }
}
