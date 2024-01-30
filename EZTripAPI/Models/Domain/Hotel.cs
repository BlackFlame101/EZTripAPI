using System.ComponentModel.DataAnnotations;

namespace EZTripAPI.Models.Domain
{
    public class Hotel
    {
        public int Id { get; set; }
        [Required]
        public string? Hotel_Name { get; set; }
        [Required]
        public string? City_Hotel { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public int? Nbr_Rooms { get; set; }
        [Required]
        public double? Price_Per_Person { get; set; }
        [Required]
        public string? Hotel_Image { get; set; }
    }
}
