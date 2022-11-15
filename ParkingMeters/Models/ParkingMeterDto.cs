using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ParkingMeters.Models
{
    public class ParkingMeterDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
        public int Usages { get; set; }
    }
}
