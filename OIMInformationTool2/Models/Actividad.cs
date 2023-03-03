using InformationToolOIM2.Models;
using OIMInformationTool2.Models;
using System;
using System.Collections.Generic;

namespace OIMInformationTool2;

public partial class Actividad
{
    public string IdActividad { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? FondoId { get; set; }

    public string? Meta { get; set; }

    public string? IndicadorId { get; set; }

    public string? NumeroTotal { get; set; }

    public string? CampoReferencia { get; set; }

    public string? FormulaCalculo { get; set; }

    public int? ImplementadorId { get; set; }

    public int? UaId { get; set; }

    public int? SectorId { get; set; }

    public int? AreaOimId { get; set; }

    public int? PeriodicidadId { get; set; }

    public virtual AreaOim? AreaOim { get; set; }

    public virtual Fondo? Fondo { get; set; }

    public virtual Implementador? Implementador { get; set; }

    public virtual Indicador? Indicador { get; set; }

    public virtual ICollection<Nominal> Nominals { get; } = new List<Nominal>();

    public virtual Periodicidad? Periodicidad { get; set; }

    public virtual Sector? Sector { get; set; }

    public virtual UnidadAnalisi? Ua { get; set; }
}
