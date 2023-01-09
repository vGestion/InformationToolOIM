using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OIMInformationTool2.Models;

public partial class UsuarioCanton
{
    public string IdUsuarioCanto { get; set; } = null!;

    [DisplayName("Usuario")]
    public int UsuarioId { get; set; }

    [DisplayName("Cantón")]
    public int CantonId { get; set; }

    [DisplayName("Provincia")]
    public int ProvinciaId { get; set; }

    [DisplayName("Usuario")]
    public virtual Usuario Usuario { get; set; } = null!;
}
