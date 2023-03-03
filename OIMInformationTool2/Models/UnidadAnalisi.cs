using System;
using System.Collections.Generic;

namespace OIMInformationTool2.Models;

public partial class UnidadAnalisi
{
    public int IdUa { get; set; }

    public string? Descripcion { get; set; }

    public int? TipoUaId { get; set; }

    public virtual ICollection<Actividad> Actividads { get; } = new List<Actividad>();

    public virtual TipoUa? TipoUa { get; set; }
}

