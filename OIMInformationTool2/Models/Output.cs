using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OIMInformationTool2.Models;

public partial class Output
{
    public string IdOutput { get; set; } = null!;

    [DisplayName("Output")]
    public string Descripcion { get; set; } = null!;

    [DisplayName("Outcome")]
    public string OutcomeId { get; set; } = null!;

    public virtual ICollection<Indicador> Indicadors { get; } = new List<Indicador>();

    [DisplayName("Outcome")]
    public virtual Outcome Outcome { get; set; } = null!;
}
