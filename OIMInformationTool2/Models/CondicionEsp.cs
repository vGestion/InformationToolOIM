using System;
using System.Collections.Generic;

namespace OIMInformationTool2.Models;

public partial class CondicionEsp
{
    public int IdCondicionEsp { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Nominal> Nominals { get; } = new List<Nominal>();
}
