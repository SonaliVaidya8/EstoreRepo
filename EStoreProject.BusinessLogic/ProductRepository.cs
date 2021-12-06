using EStoreProject.BusinessLogic.Interfaces;
using EStoreProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EStoreProject.BusinessLogic
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductRepository _context;
        public ProductRepository(IProductRepository context)
        {
            _context = context;
        }
        public void CreateNewProduct(Products product)
        {
            _context.CreateNewProduct(product);
        }

        public void DeleteProduct(int product)
        {
            _context.DeleteProduct(product);
        }

         public List<Products> GetAllProduct()
        {

            return _context.GetAllProduct().ToList();
        }

        public Products GetProductById(int ProductId)
        {
            var product = _context.GetProductById(ProductId);
            return product;
        }

        public Products UpdateProduct(Products product)
        {
            //var product = _context.UpdateProduct(Product);
            //return (Products)product;
            var existingProducts = _context.UpdateProduct(product);
            if (existingProducts != null)
            {
                existingProducts.ProductName = product.ProductName;
                existingProducts.ProductPrice = product.ProductPrice;
                existingProducts.ProductCategoryName = product.ProductCategoryName;
                existingProducts.ProductDescription = product.ProductDescription;
                existingProducts.ProductSize = product.ProductSize;
                existingProducts.ProductImage = product.ProductImage;
                existingProducts.ProductRating = product.ProductRating;

                _context.UpdateProduct(existingProducts);
            }
            return product;

        }
    }
}