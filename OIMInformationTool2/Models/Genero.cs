using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OIMInformationTool2.Models;

public partial class Genero
{
    public int IdGenero { get; set; }

    [DisplayName("Género")]
    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Nominal> Nominals { get; } = new List<Nominal>();
}
