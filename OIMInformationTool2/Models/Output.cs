using OIMInformationTool2.Models;

using System;
using System.Collections.Generic;

namespace OIMInformationTool2.Models;

public partial class Output
{
    public string IdOutput { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string OutcomeId { get; set; } = null!;

    public virtual ICollection<Indicador> Indicadors { get; } = new List<Indicador>();

    public virtual Outcome Outcome { get; set; } = null!;
}
