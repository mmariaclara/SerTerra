using Microsoft.AspNetCore.Mvc;

namespace SerTerraQueijaria.Controllers
{
    public class Carrinho : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
