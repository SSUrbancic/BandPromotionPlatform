using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BandPromotionPlatform.Models
{
    public class Order
    {
        [Key]
        [Display(Name = "Order ID")]
        public int OrderID { get; set; }
        [ForeignKey("OrderDetails")]
        public int OrderDetailsID { get; set; }
        public OrderDetails OrderDetails { get; set; }

    }
}
