using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalCapstone.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public DateTime Time { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        
        [ForeignKey ("team")]
        public int TeamId { get; set; }
        public Team team { get; set; }
    }
}