
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OIMInformationTool2.Models;

public partial class Periodicidad
{
    public int IdPeriodo { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Actividad> Actividads { get; } = new List<Actividad>();
}
