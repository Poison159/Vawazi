using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webWithAccounts.Models
{
    public class OperatingHours
    {
        public int id { get; set; }
        [Required]
        public int indawoId { get; set; }
        [Required]
        public string day { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime openingHour { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime closingHour { get; set; }
    }
}