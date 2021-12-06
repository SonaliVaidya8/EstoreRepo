using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EStoreProject.Model
{
    
    public class ProductCategory
    {
        //[Key]
        //[ScaffoldColumn(false)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        //[Column(TypeName = "int")]
        [Display(Name = "Product Category Id")]
        public int ProductCategoryId { get; set; }


        // [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Product Category")]
        public string ProductCategoryName { get; set; }


        //[Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Product Image")]
        public string ProductCategoryImage { get; set; }


    }
}
