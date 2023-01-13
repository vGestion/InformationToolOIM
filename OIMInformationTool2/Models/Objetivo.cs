using OIMInformationTool2.Models;
using System;
using System.Collections.Generic;

namespace OIMInformationTool2.Models;

public partial class Objetivo
{
    public string IdObjetivo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Outcome> Outcomes { get; } = new List<Outcome>();
}
