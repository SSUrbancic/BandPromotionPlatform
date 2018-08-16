using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BandPromotionPlatform.Models
{
    public class Cart
    {
        [Key]
        [Display(Name = "Cart ID")]
        public int CartID { get; set; }
        [ForeignKey("CartItem1")]
        public int? CartItemID1 { get; set; }
        public CartItem CartItem1 { get; set; }
        [ForeignKey("CartItem2")]
        public int? CartItemID2 { get; set; }
        public CartItem CartItem2 { get; set; }
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

    }
}
