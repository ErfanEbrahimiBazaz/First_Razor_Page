using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.Models
{
    // to add a new class: Shift+Alt+C
    public class Country
    {
        [Key]
        public int Id { get; set; }
        // by default it detects Id as key

        [Required]
        [Display(Name ="Country")]
        public string CountryName { get; set; }


    }
}
