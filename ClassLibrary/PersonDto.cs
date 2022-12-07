using WebApplication2Controller.Dtos;

namespace ClassLibrary
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Unknown";
        public string City { get; set; } = "Unknown";
    }
}
