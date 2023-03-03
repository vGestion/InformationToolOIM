
namespace OIMInformationTool2.Models;

public partial class Indicador
{
    public string IdIndicador { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? OutputId { get; set; }

    public virtual ICollection<Actividad> Actividads { get; } = new List<Actividad>();

    public virtual Output? Output { get; set; }
}
