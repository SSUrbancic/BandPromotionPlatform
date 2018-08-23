using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandPromotionPlatform.Models
{
    public class YouTubeVideo
    {
        [Key]
        public int VideoID {get;set;}
        public string youtubeId { get; set; }
    }
}
