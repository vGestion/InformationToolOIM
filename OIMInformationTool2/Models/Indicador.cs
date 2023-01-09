using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OIMInformationTool2.Models;

public partial class Indicador
{
    public string IdIndicador { get; set; } = null!;

    [DisplayName("Indicador")]
    public string? Descripcion { get; set; }

    [DisplayName("Fondo")]
    public string? FondoId { get; set; }

    [DisplayName("Meta")]
    public string? Meta { get; set; }

    [DisplayName("Output")]
    public string? OutputId { get; set; }

    [DisplayName("Total")]
    public string? NumeroTotal { get; set; }

    [DisplayName("Campo de referencia")]
    public string? CampoReferencia { get; set; }

    [DisplayName("Fórmula de cálculo")]
    public string? FormulaCalculo { get; set; }

    [DisplayName("Sector")]
    public int? SectorId { get; set; }

    [DisplayName("Periodicidad")]
    public int? PeriodicidadId { get; set; }

    [DisplayName("Área Programática")]
    public int? AreaOimId { get; set; }

    [DisplayName("Área Programática")]
    public virtual AreaOim? AreaOim { get; set; }

    [DisplayName("Fondo")]
    public virtual Fondo? Fondo { get; set; }

    public virtual ICollection<Nominal> Nominals { get; } = new List<Nominal>();

    [DisplayName("Output")]
    public virtual Output? Output { get; set; }

    [DisplayName("Periodicidad")]
    public virtual Periodicidad? Periodicidad { get; set; }

    [DisplayName("Sector")]
    public virtual Sector? Sector { get; set; }
}
