using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OIMInformationTool2.Models;

public partial class Outcome
{
    public string IdOutcome { get; set; } = null!;

    [DisplayName("Outcome")]
    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Output> Outputs { get; } = new List<Output>();
}
