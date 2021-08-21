using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;


namespace LearnSpace.Models
{
    public class User
    {
        [Key]
        public int UserID {get;set;}
        [Required(ErrorMessage=" First Name is required ")]
        [MinLength(2, ErrorMessage=" First Name should contain at least 3 characters ")]
        public string FirstName{get;set;}

        [Required(ErrorMessage=" Username is required ")]
        [MinLength(2, ErrorMessage=" Username should contain at least 3 characters ")]

        public string Username{get;set;}

        [Required(ErrorMessage=" Email is required ")]
        [EmailAddress(ErrorMessage = " Enter a valid Email ")]
        public string Email {get;set;}


        [Required(ErrorMessage=" Password is required ")]
        [MinLength(8, ErrorMessage = " Password must contain at least 8 characters ")]
        [DataType(DataType.Password, ErrorMessage = " Invalid Password ")]
        public string Password {get;set;}

        [NotMapped]
        [Required(ErrorMessage=" Password confirmation is required ")]
        [Compare("Password", ErrorMessage=" Password doest match ")]
        [DataType(DataType.Password, ErrorMessage = " Invalid Password ")]
        public string ConfirmPassword {get;set;}
       
        public DateTime CreatedAt {get;set;} = DateTime.Now;
       
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        // public List<Euthusiasts> Euthusiasts {get;set;}

        
    }
}