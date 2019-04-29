using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackingTheWeb.Models
{
    public class LevelFour
    {
        [Key]
        [Display(Name = "Password")]
        public string passForLevelFour { get; set; }
    }
}
