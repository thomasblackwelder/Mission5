using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class Rating
    {
        [Key]
        [Required]
        public int RatingId { get; set; }
        public string RatingName { get; set; }
    }
}
