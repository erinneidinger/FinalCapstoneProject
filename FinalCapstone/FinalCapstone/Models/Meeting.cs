using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalCapstone.Models
{
    public class Meeting 
    {
        [Key]
        public int MeetingId { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public string APICall = KeyPrivate.GeoMapURL;
        
        [ForeignKey ("team")]
        public int TeamId { get; set; }
        public Team team { get; set; }
    }
}