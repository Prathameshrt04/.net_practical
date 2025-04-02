using Microsoft.AspNetCore.Mvc;

namespace PortfolioWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(string name, string email, string message)
        {
            ViewBag.Message = $"Thank you, {name}! Your message has been received.";
            return View();
        }

        public IActionResult DownloadResume()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", "Resume.pdf");
            if (System.IO.File.Exists(filePath))
            {
                return PhysicalFile(filePath, "application/pdf", "Prathamesh_Thorat_Resume.pdf");
            }
            return NotFound("Resume file not found.");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}