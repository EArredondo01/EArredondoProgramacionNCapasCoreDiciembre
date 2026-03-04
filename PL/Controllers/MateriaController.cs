using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class MateriaController : Controller
    {
        public IActionResult GetAll()
        {
            return View();
        }
    }
}
