using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace LearnSpace.Models
{
    public class Accomplishment
    {
        [Key]
        public int AccomplishmentId {get;set;}

        [Required(ErrorMessage=" Accomplishment cannot be empty ")]
        public string SmallWin {get;set;}

        [Required(ErrorMessage=" Accomplishment cannot be empty ")]
        public string BigWin {get;set;}
        public int UserId {get;set;}
        
    }
}