using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Database
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Unknown";
        public string City { get; set; } = "Unknown";

    }
}
