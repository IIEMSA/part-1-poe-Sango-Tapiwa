using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Venues
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public int Capacity { get; set; }

        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        public List<Bookings> Bookings { get; set; } = new();
    }
}

