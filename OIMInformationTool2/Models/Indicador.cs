using OIMInformationTool2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OIMInformationTool2.Models;

public partial class Indicador
{
    public string IdIndicador { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? FondoId { get; set; }

    public string? Meta { get; set; }

    public string? OutputId { get; set; }

    public string? NumeroTotal { get; set; }

    public string? CampoReferencia { get; set; }

    public string? FormulaCalculo { get; set; }

    public int? ImplementadorId { get; set; }

    public int? UaId { get; set; }

    public int? PeriodicidadId { get; set; }

    public virtual Fondo? Fondo { get; set; }

    public virtual Implementador? Implementador { get; set; }

    public virtual ICollection<Nominal> Nominals { get; } = new List<Nominal>();

    public virtual Output? Output { get; set; }

    public virtual Periodicidad? Periodicidad { get; set; }

    public virtual UnidadAnalisi? Ua { get; set; }
}
