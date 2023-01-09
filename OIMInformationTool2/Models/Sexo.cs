using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OIMInformationTool2.Models;

public partial class Sexo
{
    public int IdSexo { get; set; }

    [DisplayName("Sexo")]
    public string? Descripcion { get; set; }

    public virtual ICollection<Nominal> Nominals { get; } = new List<Nominal>();
}
