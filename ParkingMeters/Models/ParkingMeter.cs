using NpgsqlTypes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingMeters.Models
{
    public class ParkingMeter
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("status")]
        [DefaultValue(false)]
        public bool Status { get; set; }

        [Column("usages")]
        [DefaultValue(0)]
        public int Usages { get; set; }
    }
}
