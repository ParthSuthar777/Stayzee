using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stayzee.Domain.Entities
{
    public class Villa
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(0,double.MaxValue,ErrorMessage = "Minimum Price should be greater than 0")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Sqft is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Minimum Sqft should be greater than 0")]
        public int Sqft { get; set; }
        [Required(ErrorMessage = "Occupancy is required")]
        [Range(0, 10, ErrorMessage = "Minimum and Maximum Occupancy should be 0-10")]
        public int Occupancy { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

    }
}
