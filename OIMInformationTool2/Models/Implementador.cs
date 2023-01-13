using System;
using System.Collections.Generic;

namespace OIMInformationTool2.Models;

public partial class Implementador
{
    public int IdImplementador { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Indicador> Indicadors { get; } = new List<Indicador>();
}
