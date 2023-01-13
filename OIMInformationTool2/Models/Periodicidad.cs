
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OIMInformationTool2.Models;

public partial class Periodicidad
{
    public int IdPeriodo { get; set; }

    [DisplayName("Periodicidad")]
    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Indicador> Indicadors { get; } = new List<Indicador>();
}
