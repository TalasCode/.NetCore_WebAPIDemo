namespace WebAPIDemo.Request
{
    public class EventRequest
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public DateOnly? EventDate { get; set; }

        public int? CategoryId { get; set; }

        public string? Destination { get; set; }

        public decimal? Cost { get; set; }

        public string? Status { get; set; }

        public int? UserId { get; set; }

        
    }
}
