using Microsoft.AspNetCore.Mvc;

namespace SerTerraQueijaria.Controllers
{
    public class Bebidas : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
