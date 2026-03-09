using DL;
using Microsoft.Data.SqlClient;
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
                using (DL.JguevaraDiciembreContext context = new DL.JguevaraDiciembreContext())
                {

                    //ComObject ejecutar los SPs con EF Core
                    // Consultas SELECT                  
                    // context.TABLENAME.FromSQLRaw('id')

                    var listaMaterias = context.MateriaGetAllDTO.FromSqlRaw("EXECUTE MateriaGetAll").ToList();

                    // clase DTO, como funciona, como se configura en NETCore

                    // context.Database.ExecuteSQLRaw
                    // DML (INSERT, UPDATE, DELETE) = filas afecatdas
                    //int filasAfecadas = context.Database.ExecuteSqlRaw("EXECUTE spName");

                    if (listaMaterias.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var materiaDB in listaMaterias)
                        {
                            ML.Materia materia = new ML.Materia();
                            
                            materia.IdMateria = materiaDB.IdMateria;
                            materia.Nombre = materiaDB.MateriaNombre;
                            materia.Promedio = materiaDB.Promedio;

                            // resto de informacion....

                            // Sacar las direcciones (Grupos):
                            var listaGrupos = context.Grupos.FromSqlRaw($"EXECUTE GrupoGetByIdMateria {materiaDB.IdMateria}").ToList();

                            if(listaGrupos.Count > 0)
                            {
                                materia.Grupo = new ML.Grupo();
                                materia.Grupo.Grupos = new List<object>();

                                foreach (var grupoDB in listaGrupos)
                                {
                                    ML.Grupo grupo = new ML.Grupo();
                                    grupo.IdGrupo = grupoDB.IdGrupo;
                                    grupo.Nombre = grupoDB.Nombre;

                                    grupo.Plantel = new ML.Plantel();
                                    grupo.Plantel.IdPlantel = grupoDB.IdPlantel.Value;

                                    materia.Grupo.Grupos.Add(grupo);
                                }                               
                            }
                            result.Objects.Add(materia);
                        }
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
