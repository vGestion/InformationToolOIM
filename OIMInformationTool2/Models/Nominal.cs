using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OIMInformationTool2.Models;

public partial class Nominal
{
    public int IdNominal { get; set; }

    [DisplayName("Fecha de asistencia")]
    public DateTime? FechaAsistencia { get; set; }

    [DisplayName("Fecha de corte")]
    public DateTime? FechaCorte { get; set; }


    public int Edad { get; set; }

    public bool Discapacidad { get; set; }

    public decimal Monto { get; set; }

    [DisplayName("Fecha de registro")]
    public DateTime FechaRegistro { get; set; }

    [DisplayName("Indicador")]
    public string? IndicadorId { get; set; }

    [DisplayName("Sexo")]
    public int? SexoId { get; set; }

    [DisplayName("Nacionalidad")]
    public int? NacionalidadId { get; set; }

    [DisplayName("Cantón")]
    public int? CantonId { get; set; }

    [DisplayName("Provincia")]
    public int? ProvinciaId { get; set; }

    [DisplayName("Parentezco")]
    public int? ParentezcoId { get; set; }

    [DisplayName("Criterio de Movilidad")]
    public int? CriterioMoviId { get; set; }

    [DisplayName("Periodo")]
    public int PeriodoId { get; set; }

    [DisplayName("Usuario")]
    public int? UsuarioId { get; set; }

    [DisplayName("Género")]
    public int? GeneroId { get; set; }

    [DisplayName("Criterio de Movilidad")]
    public virtual CriterioMovi? CriterioMovi { get; set; }

    [DisplayName("Género")]
    public virtual Genero? Genero { get; set; }

    [DisplayName("Indicador")]
    public virtual Indicador? Indicador { get; set; }

    [DisplayName("Nacionalidad")]
    public virtual Nacionalidad? Nacionalidad { get; set; }

    [DisplayName("Parentezco")]
    public virtual Parentezco? Parentezco { get; set; }

    [DisplayName("Periodo")]
    public virtual Periodo Periodo { get; set; } = null!;

    [DisplayName("Sexo")]
    public virtual Sexo? Sexo { get; set; }

    [DisplayName("Usuario")]
    public virtual Usuario? Usuario { get; set; }
}
