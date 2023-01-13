﻿using OIMInformationTool2.Models;
using System;
using System.Collections.Generic;

namespace InformationToolOIM2.Models;

public partial class AreaOim
{
    public int IdAreaOim { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Outcome> Outcomes { get; } = new List<Outcome>();
}
