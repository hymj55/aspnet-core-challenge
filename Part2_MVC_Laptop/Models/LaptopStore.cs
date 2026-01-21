using Part2_MVC_Laptop.Models;

namespace Part2_MVC_Laptop.Models
{
    public static class LaptopStore
    {
        public static List<Laptop> Laptops =
        [
            new Laptop { Id = 1001, Brand = "Apple", Model = "MacBook Air", Year = 2022},
            new Laptop { Id = 1002, Brand = "Dell", Model = "XPS 13 Plus", Year = 2022},
            new Laptop { Id = 1003, Brand = "Microsoft", Model = "Surface Laptop 5", Year = 2022},
            new Laptop { Id = 1004, Brand = "HP", Model = "Spectre x360 14", Year = 2023},
            new Laptop { Id = 1005, Brand = "Apple", Model = "MacBook Pro", Year = 2023}
        ];

        public static void AddLaptop(Laptop laptop)
        {
            laptop.Id = Laptops.Any() ? Laptops.Max(l => l.Id) + 1 : 1001;
            Laptops.Add(laptop);
        }
    }
}