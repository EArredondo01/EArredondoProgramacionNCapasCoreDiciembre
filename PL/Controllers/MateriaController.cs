using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class MateriaController : Controller
    {
        public IActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAll();

            return View();
        }
    }
}
