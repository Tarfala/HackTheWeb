using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HackingTheWeb.Models
{
    public class LevelThree
    {
        [Key]
        [Display(Name = "Password")]
        public string PassWord { get; set; }
    }
}
