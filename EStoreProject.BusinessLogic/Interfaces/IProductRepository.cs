using EStoreProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStoreProject.BusinessLogic.Interfaces
{
   public interface IProductRepository
    {
        void CreateNewProduct(Products product);
        void DeleteProduct(int product);
        List<Products> GetAllProduct();
        Products GetProductById(int ProductId);
        Products UpdateProduct(Products product);
    }
}
