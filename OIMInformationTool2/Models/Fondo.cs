﻿using System;
using System.Collections.Generic;

namespace OIMInformationTool2.Models;

public partial class Fondo
{
    public string IdFondo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public int? DonanteId { get; set; }

    public DateTime? FechaFin { get; set; }

    public virtual ICollection<Actividad> Actividads { get; } = new List<Actividad>();

    public virtual Donante? Donante { get; set; }
}
