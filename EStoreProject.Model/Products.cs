using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EStoreProject.Model
{
    public class Products
    {
        [Display(Name="Product Id")]
        public int ProductId { get; set; }


        [Display(Name = "Product Name")]
        public string ProductName { get; set; }


        [Display(Name = "Product Price")]
        public float ProductPrice { get; set; }


        [Display(Name = "Product Category")]
        public string ProductCategoryName { get; set; }


        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }


        [Display(Name = "Product Size")]
        public string ProductSize { get; set; }


        [Display(Name = "Product Image")]
        public string ProductImage { get; set; }


        [Display(Name = "Product Rating")]
        public string ProductRating { get; set; }

    }
}
