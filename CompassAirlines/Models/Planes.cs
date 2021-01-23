using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompassAirlines.Models
{
    public class Planes
    {
        [Key]
        public int PlaneID { get; set; }

        /* Model is between 1-30 characters */
        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Plane model must be between 1-30 characters")]
        public string Model { get; set; }

        /* Plane Number is between 6-12 characters */
        [Required, Display(Name = "Plane Number")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Plane number must be between 6-12 characters")]

        public string PlaneNum { get; set; }

        /* Ensures Plane is Fit for Flight */
        [Required]
        [Display(Name = "Passed WOF")]
        public bool Fit4Flight { get; set; }

        /* Cannot have more then 1000 passengers */
        [Required]
        [Range(1, 1000, ErrorMessage = "Cannot have more then 1000 passengers or less then 1")]
        [Display(Name = "Max Passengers")]
        public int MaxPassengers { get; set; }

        /* Cannot have more then 100,000 kgs weight */
        [Required]
        [Range(1, 100000, ErrorMessage = "Cannot have more then 100,000 kgs or less then 1kg")]
        [Display(Name = "Max Weight")]
        public int MaxWeight { get; set; }
    }
}
