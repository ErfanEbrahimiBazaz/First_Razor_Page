using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApp.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "City")]
        public string CityName { get; set; }

        public int CountryId { get; set; }

        // virtual objects don't map in DB.
        [ForeignKey("CountryId")]
        public virtual Country Country  { get; set; }
    }
}
