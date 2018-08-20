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
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string ThemeColor { get; set; }
        public bool IsFullDay { get; set; }
    }
}
