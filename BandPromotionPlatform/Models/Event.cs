using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandPromotionPlatform.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        [Display(Name = "Start Time")]
        public DateTime Start { get; set; }
        [Display(Name = "End Time")]
        public DateTime End { get; set; }
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string AddessLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        [Display(Name = "Theme Color")]
        public string ThemeColor { get; set; }
        [Display(Name = "Full Day")]
        public bool IsFullDay { get; set; }
    }
}
