using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Part1_RazorPages_Laptop.Models;
using Part1_RazorPages_Laptop.Data;

namespace Part1_RazorPages_Laptop.Pages
{
    public class IndexModel : PageModel
    {
        public List<Laptop> Laptops { get; private set; }

        public void OnGet()
        {
            Laptops = LaptopStore.Laptops;
        }
    }

}

