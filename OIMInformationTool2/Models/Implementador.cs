using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OIMInformationTool2.Models;

public partial class Implementador
{
    public string IdImplementador { get; set; } = null!;
    [DisplayName("Implementador")]
    public string? Descripcion { get; set; }

    public virtual ICollection<Fondo> Fondos { get; } = new List<Fondo>();
}
