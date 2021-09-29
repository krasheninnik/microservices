using System.ComponentModel.DataAnnotations;

namespace PlatformService.Dtos
{
    // Data annotation stay there cause:
    // Out of box .net does some nice data validation stuff
    // with our controller actions
    public class PlatformCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Cost { get; set; }
    }
}