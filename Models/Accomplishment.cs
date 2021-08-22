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

        [Required(ErrorMessage=" Accomplishment name is required ")]
        [MinLength(3, ErrorMessage = " Accomplishment Name Must Be At least 3 characters ")]
        public string AccomplishmentName {get;set;}

        [Required(ErrorMessage=" Topic feedback is required ")]
        [MinLength(3, ErrorMessage = " Topic feedback Must Be At least 3 characters ")]
        public string AccomplishmentDescription {get;set;}

        [Required(ErrorMessage=" Accomplishment type is required ")]
        public string AccomplishmentType {get;set;}
        public int UserId {get;set;}
        
    }
}