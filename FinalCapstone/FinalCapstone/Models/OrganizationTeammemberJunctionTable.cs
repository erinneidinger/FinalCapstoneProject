using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalCapstone.Models
{
    public class OrganizationToTeamMembers
    {
        [ForeignKey("OrganizationId")]
        public int OrganizationId { get; set; }
    }
    public class TeamMemberToOrganizations
    {
        [ForeignKey("MemberId")]
        public int MemberId { get; set; }
        
    }
}