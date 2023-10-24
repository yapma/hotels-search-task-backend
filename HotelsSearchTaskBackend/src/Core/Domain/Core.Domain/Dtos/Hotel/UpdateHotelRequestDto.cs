namespace Core.Domain.Dtos.Hotel
{
    public class UpdateHotelRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int StarsCount { get; set; }
    }
}
