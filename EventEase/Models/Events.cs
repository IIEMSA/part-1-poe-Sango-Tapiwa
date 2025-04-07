using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Events
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string? Description { get; set; }

        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        public List<Bookings> Bookings { get; set; } = new();
    }
}
