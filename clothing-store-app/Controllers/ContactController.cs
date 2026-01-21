using Microsoft.AspNetCore.Mvc;

namespace Midterm_9031031.Controllers
{
    //This controller was created manually
    public class ContactController : Controller
    {
        // Show the contact form page
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Handle form submission
        [HttpPost]
        public IActionResult Index(string name, string email, string subject, string message)
        {
            // To Print submitted data to the console for a developer
            Console.WriteLine($"[CONTACT] Name: {name}, Email: {email}, Subject: {subject} Message: {message}");
            // Show a confirmation message on the page for a user
            ViewBag.Confirmation = "Thank you for your message!";
            return View();
        }
    }
}