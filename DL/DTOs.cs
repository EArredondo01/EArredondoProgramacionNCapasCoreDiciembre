using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class MateriaGetAllDTO
    {
        public int IdMateria { get; set; }
        public string? MateriaNombre { get; set; }
        public decimal? Promedio { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public decimal Costo { get; set; }
        public string? UserName { get; set; }
        public byte[]? Imagen { get; set; }
        public string? SemestreNombre { get; set; }
    }


    // todo los DTOs necesarios
}
