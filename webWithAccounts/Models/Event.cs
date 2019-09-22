using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace webWithAccounts.Models
{
    public class Event
    {
        public int id { get; set; }
        
        public int indawoId { get; set; }
        [Required]
        [DisplayName("latitude")]
        public string lat { get; set; }
        [Required]
        [DisplayName("longitude")]
        public string lon { get; set; }
        [Required]
        [DisplayName("title")]
        public string title { get; set; }
        
        [DisplayName("description")]
        public string description { get; set; }
        [Required]
        [DisplayName("address")]
        public string address { get; set; }
        [Required]
        [DisplayName("price")]
        public double price { get; set; }
        [Required]
        [DisplayName("date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        [Required]
        [DisplayName("start time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:H:mm}", ApplyFormatInEditMode = true)]
        public DateTime stratTime { get; set; }
        [Required]
        [DisplayName("end time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:H:mm}", ApplyFormatInEditMode = true)]
        public DateTime endTime { get; set; }
        [Required]
        public string imgPath { get; set; }
        public TimeSpan timeLeft { get; set; }
        public List<Artist> artists { get; set; }
        public string artistIds { get; set; }
        [NotMapped]
        public HttpPostedFileBase imageUpload { get; set; }
        [DisplayName("website url")]
        public string url { get; set; }
        public double distance { get; set; }
    }
}
