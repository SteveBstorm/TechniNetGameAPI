using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechniNetGameAPI.Models
{
    public class UserRegister
    {
        [Required]
        [MinLength(3, ErrorMessage = "Taille minimale : 3 Caratères")]
        public string Nickname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$")]
        public string Password { get; set; }
    }
}
