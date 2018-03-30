using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Podaj adres email.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}