using System.ComponentModel.DataAnnotations;

namespace CustomerService.Dtos
{
    public class AdressDto
    {
        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
