using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OIMInformationTool2.Models;

public partial class Parentezco
{
    public int IdParentezco { get; set; }

    [DisplayName("Parentezco")]
    public string? Descripcion { get; set; }

    public virtual ICollection<Nominal> Nominals { get; } = new List<Nominal>();
}
