using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess
{
    public class Message : BaseEntity
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public int TopicId { get; set; }
        public DateTime CreateOn { get; set; }
        public User User { get; set; }
    }
}
