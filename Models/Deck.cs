using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace LearnSpace.Models
{
    public class Deck
    {
        [Key]
        public int DeckId {get;set;}

        [Required(ErrorMessage=" Deck name is required ")]
        [MinLength(3, ErrorMessage = " Deck Name Must Be At least 3 characters ")]
        public string DeckName {get;set;}

        public bool IsFav {get;set;}
        public int UserId {get;set;}
        
    }
}