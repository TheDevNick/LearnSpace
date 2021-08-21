using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace LearnSpace.Models
{
    public class Topic
    {
        [Key]
        public int TopicId {get;set;}

        [Required(ErrorMessage=" Topic name is required ")]
        [MinLength(3, ErrorMessage = " Topic Name Must Be At least 3 characters ")]
        public string TopicName {get;set;}

        [Required(ErrorMessage=" Topic feedback is required ")]
        [MinLength(3, ErrorMessage = " Topic feedback Must Be At least 3 characters ")]
        public string TopicFeedback {get;set;}

        [Required(ErrorMessage=" Topic difficulty is required ")]
        public string TopicDifficulty {get;set;}
        public int UserId {get;set;}
        
        
        
    }
}