using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EZTripAPI.Models.Domain
{
    public class Booking
    {
        public int Id { get; set; }
        [Required]
        public string? Full_Name { get; set; }
        [Required]
        public int Nbr_people { get; set; }
        [Required]
        public DateTime Booked_at { get; set; }
        [Required]
        public int TripId { get; set; }
        [NotMapped]
        public string? Trip_Name { get; set; }
        [Required]
        public double Full_Price { get; set; }
    }
}
