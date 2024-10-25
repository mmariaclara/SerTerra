using Microsoft.AspNetCore.Mvc;

namespace SerTerraQueijaria.Controllers
{
    public class Doces : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
