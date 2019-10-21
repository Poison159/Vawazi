using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webWithAccounts.Models
{
    public class ArtistEvent
    {
        public int id { get; set; }
        public int artistId { get; set; }
        public int eventId { get; set; }
    }
}