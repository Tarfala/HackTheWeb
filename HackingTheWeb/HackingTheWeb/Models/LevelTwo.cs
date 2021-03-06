using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackingTheWeb.Models
{
    public class LevelTwo
    {
        [Key]
        [Display(Name = "Guess the number")]
        [RegularExpression("[^0-9]", ErrorMessage = "You can only enter numbers")]
        public int numberInput { get; set; }
    }
}
