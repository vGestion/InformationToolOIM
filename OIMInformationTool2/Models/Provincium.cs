using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OIMInformationTool2.Models;

public partial class Provincium
{
    public int IdProvincia { get; set; }

    [DisplayName("Provincia")]
    public string? Descripcion { get; set; }

    public virtual ICollection<Canton> Cantons { get; } = new List<Canton>();
}
