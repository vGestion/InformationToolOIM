
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OIMInformationTool2.Models;

public partial class Nominal
{
    public int IdNominal { get; set; }

    public DateTime? FechaAsistencia { get; set; }

    public DateTime? FechaCorte { get; set; }

    public int Edad { get; set; }

    public bool Discapacidad { get; set; }

    public decimal Monto { get; set; }

    public DateTime FechaRegistro { get; set; }

    public string? IndicadorId { get; set; }

    public int? SexoId { get; set; }

    public int? NacionalidadId { get; set; }

    public int? CantonId { get; set; }

    public int? ProvinciaId { get; set; }

    public int? ParentezcoId { get; set; }

    public int? CriterioMoviId { get; set; }

    public int PeriodoId { get; set; }

    public int? UsuarioId { get; set; }

    public int? IdentSexualId { get; set; }

    public int? CondicionEspId { get; set; }

    public int? GeneroId { get; set; }

    public virtual CondicionEsp? CondicionEsp { get; set; }

    public virtual CriterioMovi? CriterioMovi { get; set; }

    public virtual Genero? Genero { get; set; }

    public virtual IdentSexual? IdentSexual { get; set; }

    public virtual Indicador? Indicador { get; set; }

    public virtual Nacionalidad? Nacionalidad { get; set; }

    public virtual Parentezco? Parentezco { get; set; }

    public virtual Periodo Periodo { get; set; } = null!;

    public virtual Sexo? Sexo { get; set; }

    public virtual Usuario? Usuario { get; set; }
}