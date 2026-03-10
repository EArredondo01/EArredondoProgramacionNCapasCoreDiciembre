using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class MateriaController : Controller
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAll();

            return View();
        }


        [HttpGet]
        public IActionResult Formulario(int? IdMateria)
        {
            ML.Materia materia = new ML.Materia();

            // DDL Estado, Rol

            if(IdMateria > 0)
            {
                // GetById

                // DDL Estado, Rol
            }

            return View(materia);
        }


        [HttpPost]
        public IActionResult Formulario(ML.Materia materia)
        {
            if(materia.IdMateria > 0)
            {
                // Update

                // ML.Result result = BL.Materia.Update(materia);

                //if (resultMateria.Correct && usuario.Direccion.Colonia.IdColonia > 0)
                //{
                //    // Agregar mi Grupo

                //    // materia.IdMateria = (int)resultMateria.Object;
                //    // BL.Grupo.Add(materia);
                //}

            }
            else
            {
                // Add  (Materia y Grupo)

                ML.Result resultMateria = BL.Materia.Add(materia);

                if (resultMateria.Correct && (int)resultMateria.Object > 0)
                {
                    // Agregar mi Grupo

                    // materia.IdMateria = (int)resultMateria.Object;
                    // BL.Grupo.Add(materia);
                }


            }

            return View(materia);
        }
    }
}
