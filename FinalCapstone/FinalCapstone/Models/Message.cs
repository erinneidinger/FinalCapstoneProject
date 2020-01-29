using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalCapstone.Models
{
    public class Message
    {
        [Key]
        public int MessageId {get; set;}
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Subject { get; set; }
        public string MessageToPost { get; set; }
        public DateTime DatePosted { get; set; }

    }
}