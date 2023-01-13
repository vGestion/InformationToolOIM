using OIMInformationTool2.Models;
using System;
using System.Collections.Generic;

namespace OIMInformationTool2.Models;

public partial class Donante
{
    public int IdDonante { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Fondo> Fondos { get; } = new List<Fondo>();
}
