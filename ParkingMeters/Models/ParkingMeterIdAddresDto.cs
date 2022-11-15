namespace ParkingMeters.Models
{
    public record ParkingMeterIdAddresDto()
    {
        public int Id { get; init; }
        public string Address { get; init; }
    }
}