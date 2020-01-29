using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalCapstone.Models
{
    public class TripleJunctionTable
    {
        
        [Key, Column(Order = 0)]
        [ForeignKey ("Organization")]
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Teammember")]
        public int TeammemberId { get; set; }
        public TeamMember Teammember{ get; set; }

        
        [ForeignKey("Team")]
        public int? TeamId { get; set; }
        public Team Team { get; set; }

    }
}