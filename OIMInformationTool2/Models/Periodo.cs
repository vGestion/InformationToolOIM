using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OIMInformationTool2.Models;

public partial class Periodo
{
    public int IdPeriodo { get; set; }

    [DisplayName("Periodo")]
    public string Descripcion { get; set; } = null!;

    [DisplayName("Fecha de inicio")]
    public DateTime FechaInicio { get; set; }

    [DisplayName("Fecha de fin")]
    public DateTime FechaFin { get; set; }

    [DisplayName("Activo")]
    public bool Activo { get; set; }

    public virtual ICollection<Nominal> Nominals { get; } = new List<Nominal>();
}
