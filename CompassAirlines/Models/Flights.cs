using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompassAirlines.Models
{
    public class Flights
    {
        [Key]
        public int FlightID { get; set; }

        /*Linking to Staff Model*/
        [Required, Display(Name = "Staff")]
        public int StaffID { get; set; }
        [ForeignKey("StaffID")]
        public Staff Staff { get; set; }


        /*Linking to Plane Model*/
        [Required, Display(Name = "Planes")]
        public int PlaneID { get; set; }
        [ForeignKey("PlaneID")]
        public Planes Planes { get; set; }


        /* Cannot have more then 1000 passengers */
        [Required]
        [Range(1, 1000, ErrorMessage = "Cannot have more then 1000 passengers or less then 1")]
        public int Passengers { get; set; }

        /* Cannot have more then 100,000 kgs weight */
        [Required]
        [Range(1, 100000, ErrorMessage = "Cannot have more then 100,000 kgs or less then 1 kgs")]
        public int Weight { get; set; }


        /* Departure Date */
        [Required]
        [Display(Name = "Departure Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DepartDate { get; set; }

        /* Departure Time */
        [Required]
        [Display(Name = "Departure Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime DepartTime { get; set; }


        /* Arrival Date */
        [Required]
        [Display(Name = "Arrival Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

        /* Arrival Time */
        [Required]
        [Display(Name = "Arrival Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime ArrivalTime { get; set; }

        /* Flight Status Enum */
        [Required, Display(Name = "Flight Status")]
        public Status FlightStatus { get; set; }
    }

    public enum Status
    {
        On_Time,
        Delayed,
        Cancelled
    }
}
