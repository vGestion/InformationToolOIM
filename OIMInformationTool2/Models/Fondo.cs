using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OIMInformationTool2.Models;

public partial class Fondo
{
    public string IdFondo { get; set; } = null!;
    [DisplayName("Fondo")]
    public string? Descripcion { get; set; }

    [DisplayName("Fecha de Inicio")]
    public DateTime? FechaInicio { get; set; }

    [DisplayName("Implementador")]
    public string? ImplementadorId { get; set; }

    [DisplayName("Fecha de finalización")]
    public DateTime? FechaFin { get; set; }

    [DisplayName("Implementador")]
    public virtual Implementador? Implementador { get; set; }

    public virtual ICollection<Indicador> Indicadors { get; } = new List<Indicador>();
}
