using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OIMInformationTool2.Models;

public partial class AreaOim
{
    public int IdAreaOim { get; set; }

    [DisplayName("Área Programática")]
    public string? Descripcion { get; set; }

    public virtual ICollection<Indicador> Indicadors { get; } = new List<Indicador>();
}
