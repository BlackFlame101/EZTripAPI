using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EZTripAPI.Models.Domain
{
    public class Trips
    {
        public int Id { get; set; }
        [Required]
        public string? Trip_Name { get; set; }
        [Required]
        public string? Destination_Name { get; set; }
        [Required]
        public int Nights_Stay { get; set; }
        [Required]
        public int HotelId { get; set; }
        [Required]
        public int TransportationId { get; set; }
        [NotMapped]
        public string? Hotel_Name { get; set; }
        [NotMapped]
        public string? Transportation_Type { get; set; }
        [Required]
        public double Price_Per_Person { get; set; }
        [Required]
        public DateTime Department_Date { get; set; }
        [Required]
        public string? Overview { get; set; }
        [Required]
        public string? Trip_Image { get; set; }
    }
}
