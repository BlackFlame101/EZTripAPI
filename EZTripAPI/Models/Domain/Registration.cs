using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EZTripAPI.Models.Domain
{
    public class Registration
    {
       
            public int Id { get; set; }
            [Required]
            public string? UserName { get; set; }
            [Required]
            public string? Password { get; set; }
            [Required]
            public string? Email { get; set; }
            [Required]
            public int IsActive { get; set; }


    }
}
