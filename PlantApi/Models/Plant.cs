using System.ComponentModel.DataAnnotations;

namespace PlantApi.Models
{
    public class Plant
    {
        public int PlantId { get; set; }          // Primary Key
        [Required]
        public string Name { get; set; } = string.Empty;    // Required field
        public string? PlantType { get; set; }          // Type of plant: ex.houseplant, herb, cactus etc.
        public int WaterCycle { get; set; }       // How often to water the plant (in days)
        public int Height { get; set; }           // Plant height(cm)
    }
}