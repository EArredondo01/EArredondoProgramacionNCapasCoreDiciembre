using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices.Marshalling;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                    // context.TABLENAME.FromSQLRaw('id')
                    
                    var listaMateria = context.Productos.FromSqlRaw("EXECUTE ProductoGetAll").ToList();

                    // clase DTO, como funciona, como se configura en NETCore

                    // context.Database.ExecuteSQLRaw
                    // DML (INSERT, UPDATE, DELETE) = filas afecatdas
                    int filasAfecadas = context.Database.ExecuteSqlRaw("EXECUTE spName");

                    if(listaMateria.Count > 0)
                    {

                    }
                    else
                    {

                    }

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
