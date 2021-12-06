using EStoreProject.BusinessLogic.Interfaces;
using EStoreProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EStoreProject.BusinessLogic
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly IProductCategoryRepository _context;
        public ProductCategoryRepository(IProductCategoryRepository context)
        {
            _context = context;
        }

        public void CreateProductCategory(ProductCategory productCategory)
        {
            _context.CreateProductCategory(productCategory);

        }

        public void DeleteProductCategory(int productCategory)
        {
            _context.DeleteProductCategory(productCategory);
        }

        public List<ProductCategory> GetAllProductCategory()
        {
           return _context.GetAllProductCategory().ToList();
        }

        public ProductCategory GetProductByCategoryId(int ProductCategoryId)
        {
            var productCategory= _context.GetProductByCategoryId(ProductCategoryId);
            return productCategory;
        }

        public ProductCategory UpdateProductCategory(ProductCategory productCategory)
        {
            var existingProductCategory = _context.UpdateProductCategory(productCategory);
            if (existingProductCategory != null)
            {
                existingProductCategory.ProductCategoryName = productCategory.ProductCategoryName;
                existingProductCategory.ProductCategoryImage = productCategory.ProductCategoryImage;
                _context.UpdateProductCategory(existingProductCategory);
            }
            return productCategory;

            }

        }
    }

