using Microsoft.Identity.Client;

namespace Kolokwium_1.DTOs;

public class DTOs
{
    public class AnimalDto
    {
       public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime AdmissionDate { get; set; }
        public string AnimalClass { get; set; } = null!;
        public OwnerDto Owner { get; set; } = null!;
    }

    public class OwnerDto
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}