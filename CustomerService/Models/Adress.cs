using System.ComponentModel.DataAnnotations;

namespace CustomerService.Models
{
    public class Adress
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        
        public string Country { get; set; }
        
        [Required]
        public int ZipCode { get; internal set; }

    }
}