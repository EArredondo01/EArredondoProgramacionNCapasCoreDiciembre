using DL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace BL
{
    public class Materia
    {
        private readonly DL.JguevaraDiciembreContext _context;

        public Materia(DL.JguevaraDiciembreContext context)
        {
            this._context = context;
        }

        public ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                
                    //ComObject ejecutar los SPs con EF Core
                    // Consultas SELECT                  
                    // context.TABLENAME.FromSQLRaw('id')

                    var listaMaterias = _context.MateriaGetAllDTO.FromSqlRaw("EXECUTE MateriaGetAll").ToList();

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
                            var listaGrupos = _context.Grupos.FromSqlRaw($"EXECUTE GrupoGetByIdMateria {materiaDB.IdMateria}").ToList();

                            if (listaGrupos.Count > 0)
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
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {              
                    var IdMateriaOutput = new SqlParameter("@IdMateria", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output                    
                    };

                    var imagenParam = new SqlParameter("@Imagen", SqlDbType.VarBinary)
                    {
                        Value = materia.Imagen == null ? DBNull.Value : materia.Imagen
                    };

                    var filasAfectadas = _context.Database.ExecuteSqlRaw("MateriaAdd @Nombre, @Promedio, @FechaRegistro, @Costo, @UserName, @IdSemestre, @Imagen, @IdMateria OUTPUT",
                        new SqlParameter("@Nombre", materia.Nombre),
                        new SqlParameter("@Promedio", materia.Promedio),
                        new SqlParameter("@FechaRegistro", materia.FechaRegistro),
                        new SqlParameter("@Costo", materia.Costo),
                        new SqlParameter("@UserName", materia.UserName),
                        new SqlParameter("@IdSemestre", materia.Semestre.IdSemestre),
                        imagenParam,
                        IdMateriaOutput);


                    if(filasAfectadas > 0)
                    {                       
                        result.Correct = true;
                        result.Object = (int)IdMateriaOutput.Value;
                    }              

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }


    }
}
