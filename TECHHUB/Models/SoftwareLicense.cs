using System.ComponentModel.DataAnnotations;

namespace TECHHUB.Models
{
    public class SoftwareLicense
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name of the software: ")]
        public required string SoftwareName { get; set; }

        [Required(ErrorMessage = "Enter the license key: ")]
        public required string LicenseKey { get; set; }

        public int TotalSeats { get; set; }

        [Required(ErrorMessage = "The start of the next billing cycle: ")]
        public required DateTime RenewalDate { get; set; }
    }
}
