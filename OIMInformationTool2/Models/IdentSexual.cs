using System;
using System.Collections.Generic;

namespace OIMInformationTool2.Models;

public partial class IdentSexual
{
    public int IdIdentSexual { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Nominal> Nominals { get; } = new List<Nominal>();
}
