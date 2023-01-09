using System;
using System.Collections.Generic;

namespace OIMInformationTool2.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public int? RolId { get; set; }

    public string? Passwrd { get; set; }

    public virtual ICollection<Nominal> Nominals { get; } = new List<Nominal>();

    public virtual Rol? Rol { get; set; }

    public virtual ICollection<UsuarioCanton> UsuarioCantons { get; } = new List<UsuarioCanton>();
}
