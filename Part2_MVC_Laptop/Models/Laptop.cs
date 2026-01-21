using System.ComponentModel.DataAnnotations;

namespace Part2_MVC_Laptop.Models
{
    public class Laptop
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "What's the name of the Model?")]
        [StringLength(100, ErrorMessage = "Model cannot exceed 50 characters")]
        public string Model { get; set; } = string.Empty;

        [Required(ErrorMessage = "What's the name of the Brand?")]
        [StringLength(50, ErrorMessage = "Brand cannot exceed 50 characters")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "When was it released?")]
        [RegularExpression("^[0-9]{4}$", ErrorMessage = "Year must be a 4-digit number")]
        public int Year { get; set; }

    }
}