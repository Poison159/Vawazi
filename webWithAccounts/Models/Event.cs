using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace webWithAccounts.Models
{
    public class Event
    {
        public int id { get; set; }
        [Required]
        public int indawoId { get; set; }
        [Required]
        [DisplayName("Description")]
        public string description { get; set; }
        [Required]
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        [Required]
        [DisplayName("Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:H:mm}", ApplyFormatInEditMode = true)]
        public DateTime stratTime { get; set; }
        [Required]
        [DisplayName("Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:H:mm}", ApplyFormatInEditMode = true)]
        public DateTime endTime { get; set; }
    }
}