using System.ComponentModel.DataAnnotations;

namespace CommandsService.Dtos
{
    public class CommandCreateDto
    {
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string CommandLine { get; set; }

        // platform id is part of url,
        // we dont wanna duplicate it in the Dto object
        //  public int PlatformId { get; set; }
    }
}