using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OIMInformationTool2.Models;

public partial class Sector
{
    public int IdSector { get; set; }

    [DisplayName("Sector")]
    public string? Descripcion { get; set; }

    public virtual ICollection<Indicador> Indicadors { get; } = new List<Indicador>();
}
