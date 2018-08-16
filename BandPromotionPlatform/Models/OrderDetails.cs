using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BandPromotionPlatform.Models
{
    public class OrderDetails
    {
        [Key]
        [Display(Name = "Order Details ID")]
        public int OrderDetailsID { get; set; }
        [Display(Name = "Order Price")]
        public double OrderPrice { get; set; }
        [Display(Name = "Payment Received")]
        public bool PaymentReceived { get; set; }
        [Display(Name = "Payment Date")]
        public string PaymentDate { get; set; }
        [Display(Name = "Order Date")]
        public string OrderDate { get; set; }
        [Display(Name = "Order Delivered")]
        public bool OrderDelivered { get; set; }
        [Display(Name = "Date Delivered")]
        public string DateDelivered { get; set; }
        [ForeignKey("Cart")]
        public int CartID { get; set; }
        public Cart Cart { get; set; }

    }
}
