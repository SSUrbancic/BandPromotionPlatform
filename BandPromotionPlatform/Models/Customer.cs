using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BandPromotionPlatform.Models
{
    public class Customer
    {
        [Key]
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }
        [Display(Name = "Shipping Address Line 1")]
        public string ShippingAddressLine1 { get; set; }
        [Display(Name = "Shipping Address Line 2")]
        public string ShippingAddressLine2 { get; set; }
        [Display(Name = "City")]
        public string ShippingCity { get; set; }
        [Display(Name = "State")]
        public string ShippingState { get; set; }
        [Display(Name = "Zip Code")]
        public string ShippingZipCode { get; set; }
        [Display(Name = "Shipping Address Line 1")]
        public string BillingAddressLine1 { get; set; }
        [Display(Name = "Shipping Address Line 2")]
        public string BillingAddressLine2 { get; set; }
        [Display(Name = "City")]
        public string BillingCity { get; set; }
        [Display(Name = "State")]
        public string BillingState { get; set; }
        [Display(Name = "Zip Code")]
        public string BillingZipCode { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string user { get; set; }
    }
}
