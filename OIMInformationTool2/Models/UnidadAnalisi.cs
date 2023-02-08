using System;
using System.Collections.Generic;

namespace OIMInformationTool2.Models;

public partial class UnidadAnalisi
{
    public int IdUa { get; set; }

    public string Descripcion { get; set; } = null!;

    public int TipoUaId { get; set; }

    public virtual ICollection<Indicador> Indicadors { get; } = new List<Indicador>();

    public virtual TipoUa TipoUa { get; set; } = null!;
}
