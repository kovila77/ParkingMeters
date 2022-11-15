using System.ComponentModel.DataAnnotations;

namespace ParkingMeters.Models
{
    public class ParkingMeterCreateDto
    {
        [MinLength(1, ErrorMessage = "Address of parking meter must at least have 1 symbol")]
        public string Address { get; set; }
    }
}
