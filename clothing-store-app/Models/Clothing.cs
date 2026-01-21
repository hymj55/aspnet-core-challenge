namespace Midterm_9031031.Models
{
    public class Clothing
    {
        // Primary key for the Clothing table
        public int ClothingId { get; set; }

        // Name of the clothing item
        public string? Name { get; set; }

        // Brand of the clothing item
        public string? Brand { get; set; }

        // Price of the clothing item
        public double Price { get; set; }

        // Size of the clothing item (S, M, L, XL, etc.)
        public string? Size { get; set; }
    }
}