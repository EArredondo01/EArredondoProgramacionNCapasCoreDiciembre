using System;
using System.Collections.Generic;

namespace DL;

public partial class ProductoVwGetAll
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Costo { get; set; }

    public byte[]? Imagen { get; set; }
}
