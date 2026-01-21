using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Part1_RazorPages_Laptop.Models;
using Part1_RazorPages_Laptop.Data;

namespace Part1_RazorPages_Laptop.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Laptop NewLaptop { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            LaptopStore.AddLaptop(NewLaptop);
            return RedirectToPage("/Index");
        }
    }

}

