using OIMInformationTool2;
using OIMInformationTool2.Models;

namespace InformationToolOIM2.Models;

public partial class AreaOim
{
    public int IdAreaOim { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Actividad> Actividads { get; } = new List<Actividad>();
}
