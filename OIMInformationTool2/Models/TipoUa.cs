using System;
using System.Collections.Generic;

namespace OIMInformationTool2.Models;

public partial class TipoUa
{
    public int IdTipoUa { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<UnidadAnalisi> UnidadAnalisis { get; } = new List<UnidadAnalisi>();
}
