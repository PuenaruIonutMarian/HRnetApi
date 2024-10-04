using System.ComponentModel.DataAnnotations;

namespace HRnetApi.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="First Name is required.")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [MinLength(10)]
        public required string Phone { get; set; }

        [Required(ErrorMessage = "Position is required.")]
        public required string Position { get; set; }

    }
}
