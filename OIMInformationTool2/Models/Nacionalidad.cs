using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OIMInformationTool2.Models;

public partial class Nacionalidad
{
    public int IdNacionalidad { get; set; }

    [DisplayName("Nacionalidad")]
    public string? Descripcion { get; set; }

    public virtual ICollection<Nominal> Nominals { get; } = new List<Nominal>();
}
