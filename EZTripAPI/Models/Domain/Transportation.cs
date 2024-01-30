using System.ComponentModel.DataAnnotations;

namespace EZTripAPI.Models.Domain
{
    public class Transportation
    {
        public int Id { get; set; }
        [Required]
        public string? Transportation_Name { get; set; }
        [Required]
        public string? Transportation_Type { get; set; }
        [Required]
        public double? Price_Per_Person { get; set; }
        [Required]
        public string? Transportation_Image { get; set; }
    }
}
