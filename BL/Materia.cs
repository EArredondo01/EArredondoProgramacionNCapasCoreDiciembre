using System.Runtime.InteropServices.Marshalling;

namespace BL
{
    public class Materia
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.EarredondoProductoDiciembreContext context = new DL.EarredondoProductoDiciembreContext())
                {

                    //ComObject ejecutar los SPs con EF Core
                    // Consultas SELECT
                    // DML

                    //var listaMateria = context.
                }
            } catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

    }
}
