using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace LearnSpace.Models
{
    public class Association
    {
        [Key]
        public int AssociationId { get; set; }

        public int UserId { get; set; }
        public int AccomplishmentId { get; set; }
        public User User { get; set; }
        public Accomplishment Accomplishments { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}