using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventEase.Models
{
    public class Bookings
    {
        public int Id { get; set; }

        [Required]
        public int EventId { get; set; }
        public Events Event { get; set; }

        [Required]
        public int VenueId { get; set; }
        public Venues Venue { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }
    }
}
