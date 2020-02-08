using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalCapstone.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Display(Name = "Team Name")]
        public string Name { get; set; }

        public string Members { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public int Counter { get; set; }

        public string APITeamCall = SecretKeys.MapURL;

        [ForeignKey ("Organization")]
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}