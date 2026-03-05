using System;
using System.Collections.Generic;

namespace DL;

public partial class Materium
{
    public int IdMateria { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal? Promedio { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public decimal Costo { get; set; }

    public string UserName { get; set; } = null!;

    public int? IdSemestre { get; set; }

    public byte[]? Imagen { get; set; }

    public virtual ICollection<Grupo> Grupos { get; set; } = new List<Grupo>();

    public virtual Semestre? IdSemestreNavigation { get; set; }
}
