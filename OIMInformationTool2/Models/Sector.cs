using OIMInformationTool2;
using OIMInformationTool2.Models;
using System;
using System.Collections.Generic;

namespace InformationToolOIM2.Models;

public partial class Sector
{
    public int IdSector { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Actividad> Actividads { get; } = new List<Actividad>();
}
