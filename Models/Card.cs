using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace LearnSpace.Models
{
    public class Card
    {
        [Key]
        public int CardId {get;set;}

        [Required(ErrorMessage=" Card cannot be empty ")]
        public string CardQuestion {get;set;}

        [Required(ErrorMessage=" Card cannot be empty ")]
        public string CardAnswer {get;set;}

        public int DeckId {get;set;}
        
    }
}