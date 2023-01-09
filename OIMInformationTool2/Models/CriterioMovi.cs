using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OIMInformationTool2.Models;

public partial class CriterioMovi
{
    public int IdCriterioMovi { get; set; }
    [DisplayName("Criterio de Movilidad")]
    public string? Descripcion { get; set; }

    public virtual ICollection<Nominal> Nominals { get; } = new List<Nominal>();
}
