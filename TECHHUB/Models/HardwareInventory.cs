using System.ComponentModel.DataAnnotations;

namespace TECHHUB.Models
{
    public class HardwareInventory
    {
        [Key]
        public int Id { get; set; }

        public string? DeviceType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter the serial # of the device: ")]
        public required string SerialNumber { get; set; }

        [Required(ErrorMessage = "When the device was purchased: ")]
        public required DateTime PurchaseDate { get; set; }

        [Required(ErrorMessage = "When the coverage expires: ")]
        public required DateTime WarrantyExpiration { get; set; }

    }
}




