using InformationToolOIM2.Models;
using OIMInformationTool2.Models;
using System;
using System.Collections.Generic;

namespace OIMInformationTool2.Models;

public partial class Outcome
{
    public string IdOutcome { get; set; } = null!;

    public int? AreaOimId { get; set; }

    public int? SectorId { get; set; }

    public string? ObjetivoId { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual AreaOim? AreaOim { get; set; }

    public virtual Objetivo? Objetivo { get; set; }

    public virtual ICollection<Output> Outputs { get; } = new List<Output>();

    public virtual Sector? Sector { get; set; }
}
