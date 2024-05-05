using System;
using System.Collections.Generic;

namespace VueApp_API.Models;

public partial class Publicacion
{
    public int IdPublicacion { get; set; }

    public string? TipoPropiedad { get; set; }

    public string? TipoOperacion { get; set; }

    public string? Descripcion { get; set; }

    public int? Ambientes { get; set; }

    public int? MetrosCuadrados { get; set; }

    public decimal? Antiguedad { get; set; }

    public string? CoordenadasUbicacion { get; set; }

    public string? Imagenes { get; set; }
}
