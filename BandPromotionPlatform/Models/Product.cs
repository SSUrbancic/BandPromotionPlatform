using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandPromotionPlatform.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }
        [Display(Name = "Product Size")]
        public string ProductSize { get; set; }
        [Display(Name = "Product Color")]
        public string ProductColor { get; set; }
        [Display(Name = "Unit Price")]
        public double UnitPrice { get; set; }
       
    }
}
