using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BandPromotionPlatform.Models
{
    public class CartItem
    {
        [Key]
        [Display(Name = "Cart Item ID")]
        public int CartItemID { get; set; }
        [Display(Name = "Cart Item Price")]
        public double CartItemPrice { get; set; }
        [Display(Name = "Product Quantity")]
        public int ProductQuantity { get; set; }
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
