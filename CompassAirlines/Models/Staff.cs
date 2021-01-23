using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompassAirlines.Models
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }

        /* First Name is between 2-20 characters */
        [Required, Display(Name = "First Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First name must be between 2-20 characters")]
        public string FirstName { get; set; }

        /* Last Name is between 2-20 characters */
        [Required, Display(Name = "Last Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last name must be between 2-20 characters")]
        public string LastName { get; set; }

        /* First + Last = FullName */
        [Required, Display(Name = "Full Name")]
        [StringLength(41)] //41 to ensure of the spacing
        public string FullName
        {
            get
            {
                return (FirstName + " " + LastName);
            }
        }

        /* Role Enum */
        [Required]
        public StaffRoles Role { get; set; }

        /* Defining Phone */
        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Phone number must be between 6-15 characters")]
        public string Phone { get; set; }

        /* Defining Email */
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Email must be between 6-30 characters")]
        public string Email { get; set; }
    }
    public enum StaffRoles
    {
        First_Officer,
        Second_Officer,
        Third_Officer,
        Flight_Attendant,
        Flight_Engineer
    }
}
