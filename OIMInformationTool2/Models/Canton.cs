using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OIMInformationTool2.Models;

public partial class Canton
{
    public int IdCanton { get; set; }

    [DisplayName("Cantón")]
    public string? Descripcion { get; set; }

    [DisplayName("Provincia")]
    public int ProvinciaId { get; set; }

    public double? Latitud { get; set; }

    public double? Longitud { get; set; }

    public virtual Provincium Provincia { get; set; } = null!;
}
