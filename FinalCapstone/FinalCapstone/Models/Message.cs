using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalCapstone.Models
{
    public class Request
    {
        [Key]
        public int MessageId {get; set;}
        public string Subject { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Message")]
        public string MessageToPost { get; set; }
        [Display(Name = "Date Posted")]
        public string DatePosted { get; set; }

       
        
        [ForeignKey ("teammember")]
        public int TeammemberId { get; set; }
        public TeamMember teammember { get; set; }
       
    }
}