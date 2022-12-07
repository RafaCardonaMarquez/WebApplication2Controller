using ClassLibrary;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2Controller.Dtos
{
    public class NewPersonDto : PersonDto
    {
        [Required]
        public string Name { get; set; } = "Unknown";
        [MinLength(4)]
        [MaxLength(10)]

        public string City { get; set; } = "Unknown";
    }
}
