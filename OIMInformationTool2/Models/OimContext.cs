using InformationToolOIM2.Models;
using Microsoft.EntityFrameworkCore;

namespace OIMInformationTool2.Models;

public partial class OimContext : DbContext
{
    public OimContext()
    {
    }

    public OimContext(DbContextOptions<OimContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividad> Actividads { get; set; }

    public virtual DbSet<AreaOim> AreaOims { get; set; }

    public virtual DbSet<Canton> Cantons { get; set; }

    public virtual DbSet<CondicionEsp> CondicionEsps { get; set; }

    public virtual DbSet<CriterioMovi> CriterioMovis { get; set; }

    public virtual DbSet<Donante> Donantes { get; set; }

    public virtual DbSet<Fondo> Fondos { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<IdentSexual> IdentSexuals { get; set; }

    public virtual DbSet<Implementador> Implementadors { get; set; }

    public virtual DbSet<Indicador> Indicadors { get; set; }

    public virtual DbSet<Nacionalidad> Nacionalidads { get; set; }

    public virtual DbSet<Nominal> Nominals { get; set; }

    public virtual DbSet<Objetivo> Objetivos { get; set; }

    public virtual DbSet<Outcome> Outcomes { get; set; }

    public virtual DbSet<Output> Outputs { get; set; }

    public virtual DbSet<Parentezco> Parentezcos { get; set; }

    public virtual DbSet<Periodicidad> Periodicidads { get; set; }

    public virtual DbSet<Periodo> Periodos { get; set; }

    public virtual DbSet<Provincium> Provincia { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Sector> Sectors { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    public virtual DbSet<TipoUa> TipoUas { get; set; }

    public virtual DbSet<UnidadAnalisi> UnidadAnalises { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioCanton> UsuarioCantons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ec2-44-201-32-255.compute-1.amazonaws.com;Initial Catalog=oim;Persist Security Info=True;User ID=SA;Password=Datalat2022*;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividad>(entity =>
        {
            entity.HasKey(e => e.IdActividad).HasName("XPKIndicador");

            entity.ToTable("Actividad");

            entity.Property(e => e.IdActividad)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("ID_actividad");
            entity.Property(e => e.AreaOimId).HasColumnName("AreaOim_id");
            entity.Property(e => e.CampoReferencia)
                .HasMaxLength(200)
                .IsFixedLength()
                .HasColumnName("Campo_referencia");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.FondoId)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("Fondo_id");
            entity.Property(e => e.FormulaCalculo)
                .HasMaxLength(200)
                .IsFixedLength()
                .HasColumnName("Formula_calculo");
            entity.Property(e => e.ImplementadorId).HasColumnName("Implementador_id");
            entity.Property(e => e.IndicadorId)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("Indicador_Id");
            entity.Property(e => e.Meta)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.NumeroTotal)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Numero_total");
            entity.Property(e => e.PeriodicidadId).HasColumnName("Periodicidad_id");
            entity.Property(e => e.SectorId).HasColumnName("Sector_id");
            entity.Property(e => e.UaId).HasColumnName("Ua_id");

            entity.HasOne(d => d.AreaOim).WithMany(p => p.Actividads)
                .HasForeignKey(d => d.AreaOimId)
                .HasConstraintName("R_73");

            entity.HasOne(d => d.Fondo).WithMany(p => p.Actividads)
                .HasForeignKey(d => d.FondoId)
                .HasConstraintName("R_68");

            entity.HasOne(d => d.Implementador).WithMany(p => p.Actividads)
                .HasForeignKey(d => d.ImplementadorId)
                .HasConstraintName("R_70");

            entity.HasOne(d => d.Indicador).WithMany(p => p.Actividads)
                .HasForeignKey(d => d.IndicadorId)
                .HasConstraintName("R_66");

            entity.HasOne(d => d.Periodicidad).WithMany(p => p.Actividads)
                .HasForeignKey(d => d.PeriodicidadId)
                .HasConstraintName("R_69");

            entity.HasOne(d => d.Sector).WithMany(p => p.Actividads)
                .HasForeignKey(d => d.SectorId)
                .HasConstraintName("R_72");

            entity.HasOne(d => d.Ua).WithMany(p => p.Actividads)
                .HasForeignKey(d => d.UaId)
                .HasConstraintName("R_71");
        });

        modelBuilder.Entity<AreaOim>(entity =>
        {
            entity.HasKey(e => e.IdAreaOim).HasName("XPKArea_OIM");

            entity.ToTable("Area_OIM");

            entity.Property(e => e.IdAreaOim)
                .ValueGeneratedNever()
                .HasColumnName("ID_area_oim");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Canton>(entity =>
        {
            entity.HasKey(e => new { e.IdCanton, e.ProvinciaId }).HasName("XPKCanton");

            entity.ToTable("Canton");

            entity.Property(e => e.IdCanton).HasColumnName("ID_canton");
            entity.Property(e => e.ProvinciaId).HasColumnName("Provincia_id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Latitud).HasColumnName("latitud");
            entity.Property(e => e.Longitud).HasColumnName("longitud");

            entity.HasOne(d => d.Provincia).WithMany(p => p.Cantons)
                .HasForeignKey(d => d.ProvinciaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R_9");
        });

        modelBuilder.Entity<CondicionEsp>(entity =>
        {
            entity.HasKey(e => e.IdCondicionEsp);

            entity.ToTable("CondicionEsp");

            entity.Property(e => e.IdCondicionEsp)
                .ValueGeneratedNever()
                .HasColumnName("ID_condicionEsp");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsFixedLength();
        });

        modelBuilder.Entity<CriterioMovi>(entity =>
        {
            entity.HasKey(e => e.IdCriterioMovi).HasName("XPKCriterio_movi");

            entity.ToTable("Criterio_movi");

            entity.Property(e => e.IdCriterioMovi)
                .ValueGeneratedNever()
                .HasColumnName("ID_criterio_movi");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Donante>(entity =>
        {
            entity.HasKey(e => e.IdDonante);

            entity.ToTable("Donante");

            entity.Property(e => e.IdDonante)
                .ValueGeneratedNever()
                .HasColumnName("ID_donante");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsFixedLength();
        });

        modelBuilder.Entity<Fondo>(entity =>
        {
            entity.HasKey(e => e.IdFondo).HasName("XPKProyecto");

            entity.ToTable("Fondo");

            entity.Property(e => e.IdFondo)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("ID_fondo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DonanteId).HasColumnName("Donante_id");
            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_inicio");

            entity.HasOne(d => d.Donante).WithMany(p => p.Fondos)
                .HasForeignKey(d => d.DonanteId)
                .HasConstraintName("R_59");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.IdGenero);

            entity.ToTable("Genero");

            entity.Property(e => e.IdGenero)
                .ValueGeneratedNever()
                .HasColumnName("ID_genero");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<IdentSexual>(entity =>
        {
            entity.HasKey(e => e.IdIdentSexual);

            entity.ToTable("IdentSexual");

            entity.Property(e => e.IdIdentSexual)
                .ValueGeneratedNever()
                .HasColumnName("ID_identSexual");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsFixedLength();
        });

        modelBuilder.Entity<Implementador>(entity =>
        {
            entity.HasKey(e => e.IdImplementador).HasName("XPKImplementador");

            entity.ToTable("Implementador");

            entity.Property(e => e.IdImplementador)
                .ValueGeneratedNever()
                .HasColumnName("ID_implementador");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Indicador>(entity =>
        {
            entity.HasKey(e => e.IdIndicador);

            entity.ToTable("Indicador");

            entity.Property(e => e.IdIndicador)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("ID_Indicador");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.OutputId)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("Output_id");

            entity.HasOne(d => d.Output).WithMany(p => p.Indicadors)
                .HasForeignKey(d => d.OutputId)
                .HasConstraintName("R_67");
        });

        modelBuilder.Entity<Nacionalidad>(entity =>
        {
            entity.HasKey(e => e.IdNacionalidad).HasName("XPKNacionalidad");

            entity.ToTable("Nacionalidad");

            entity.Property(e => e.IdNacionalidad)
                .ValueGeneratedNever()
                .HasColumnName("ID_nacionalidad");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Nominal>(entity =>
        {
            entity.HasKey(e => e.IdNominal).HasName("XPKNominal");

            entity.ToTable("Nominal");

            entity.Property(e => e.IdNominal)
                .ValueGeneratedNever()
                .HasColumnName("ID_nominal");
            entity.Property(e => e.ActividadId)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("Actividad_id");
            entity.Property(e => e.CantonId).HasColumnName("Canton_id");
            entity.Property(e => e.CondicionEspId).HasColumnName("CondicionEsp_id");
            entity.Property(e => e.CriterioMoviId).HasColumnName("Criterio_movi_id");
            entity.Property(e => e.FechaAsistencia)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_asistencia");
            entity.Property(e => e.FechaCorte)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_corte");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_registro");
            entity.Property(e => e.GeneroId).HasColumnName("Genero_id");
            entity.Property(e => e.IdentSexualId).HasColumnName("IdentSexual_id");
            entity.Property(e => e.Monto).HasColumnType("money");
            entity.Property(e => e.NacionalidadId).HasColumnName("Nacionalidad_id");
            entity.Property(e => e.ParentezcoId).HasColumnName("Parentezco_id");
            entity.Property(e => e.PeriodoId).HasColumnName("Periodo_id");
            entity.Property(e => e.ProvinciaId).HasColumnName("Provincia_id");
            entity.Property(e => e.SexoId).HasColumnName("Sexo_id");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");

            entity.HasOne(d => d.Actividad).WithMany(p => p.Nominals)
                .HasForeignKey(d => d.ActividadId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("R_42");

            entity.HasOne(d => d.CondicionEsp).WithMany(p => p.Nominals)
                .HasForeignKey(d => d.CondicionEspId)
                .HasConstraintName("R_65");

            entity.HasOne(d => d.CriterioMovi).WithMany(p => p.Nominals)
                .HasForeignKey(d => d.CriterioMoviId)
                .HasConstraintName("R_12");

            entity.HasOne(d => d.Genero).WithMany(p => p.Nominals)
                .HasForeignKey(d => d.GeneroId)
                .HasConstraintName("R_52");

            entity.HasOne(d => d.IdentSexual).WithMany(p => p.Nominals)
                .HasForeignKey(d => d.IdentSexualId)
                .HasConstraintName("R_64");

            entity.HasOne(d => d.Nacionalidad).WithMany(p => p.Nominals)
                .HasForeignKey(d => d.NacionalidadId)
                .HasConstraintName("R_74");

            entity.HasOne(d => d.Parentezco).WithMany(p => p.Nominals)
                .HasForeignKey(d => d.ParentezcoId)
                .HasConstraintName("R_11");

            entity.HasOne(d => d.Periodo).WithMany(p => p.Nominals)
                .HasForeignKey(d => d.PeriodoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R_43");

            entity.HasOne(d => d.Sexo).WithMany(p => p.Nominals)
                .HasForeignKey(d => d.SexoId)
                .HasConstraintName("R_7");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Nominals)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("R_14");
        });

        modelBuilder.Entity<Objetivo>(entity =>
        {
            entity.HasKey(e => e.IdObjetivo);

            entity.ToTable("Objetivo");

            entity.Property(e => e.IdObjetivo)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ID_objetivo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1000)
                .IsFixedLength();
        });

        modelBuilder.Entity<Outcome>(entity =>
        {
            entity.HasKey(e => e.IdOutcome);

            entity.ToTable("Outcome");

            entity.Property(e => e.IdOutcome)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("ID_outcome");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(800)
                .IsFixedLength()
                .HasColumnName("descripcion");
            entity.Property(e => e.ObjetivoId)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Objetivo_id");

            entity.HasOne(d => d.Objetivo).WithMany(p => p.Outcomes)
                .HasForeignKey(d => d.ObjetivoId)
                .HasConstraintName("R_57");
        });

        modelBuilder.Entity<Output>(entity =>
        {
            entity.HasKey(e => e.IdOutput);

            entity.ToTable("Output");

            entity.Property(e => e.IdOutput)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("ID_output");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1000)
                .IsFixedLength()
                .HasColumnName("descripcion");
            entity.Property(e => e.OutcomeId)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("Outcome_id");

            entity.HasOne(d => d.Outcome).WithMany(p => p.Outputs)
                .HasForeignKey(d => d.OutcomeId)
                .HasConstraintName("R_26");
        });

        modelBuilder.Entity<Parentezco>(entity =>
        {
            entity.HasKey(e => e.IdParentezco).HasName("XPKParentezco");

            entity.ToTable("Parentezco");

            entity.Property(e => e.IdParentezco)
                .ValueGeneratedNever()
                .HasColumnName("ID_parentezco");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Periodicidad>(entity =>
        {
            entity.HasKey(e => e.IdPeriodo);

            entity.ToTable("Periodicidad");

            entity.Property(e => e.IdPeriodo).HasColumnName("ID_periodo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsFixedLength();
        });

        modelBuilder.Entity<Periodo>(entity =>
        {
            entity.HasKey(e => e.IdPeriodo);

            entity.ToTable("Periodo");

            entity.Property(e => e.IdPeriodo).HasColumnName("ID_periodo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.FechaFin)
                .HasColumnType("date")
                .HasColumnName("Fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("Fecha_inicio");
        });

        modelBuilder.Entity<Provincium>(entity =>
        {
            entity.HasKey(e => e.IdProvincia).HasName("XPKProvincia");

            entity.Property(e => e.IdProvincia)
                .ValueGeneratedNever()
                .HasColumnName("ID_provincia");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("XPKRol");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol)
                .ValueGeneratedNever()
                .HasColumnName("ID_rol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sector>(entity =>
        {
            entity.HasKey(e => e.IdSector).HasName("XPKSector");

            entity.ToTable("Sector");

            entity.Property(e => e.IdSector)
                .ValueGeneratedNever()
                .HasColumnName("ID_sector");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sexo>(entity =>
        {
            entity.HasKey(e => e.IdSexo).HasName("XPKSexo");

            entity.ToTable("Sexo");

            entity.Property(e => e.IdSexo)
                .ValueGeneratedNever()
                .HasColumnName("ID_sexo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoUa>(entity =>
        {
            entity.HasKey(e => e.IdTipoUa);

            entity.ToTable("Tipo_ua");

            entity.Property(e => e.IdTipoUa)
                .ValueGeneratedNever()
                .HasColumnName("ID_tipo_ua");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsFixedLength();
        });

        modelBuilder.Entity<UnidadAnalisi>(entity =>
        {
            entity.HasKey(e => e.IdUa);

            entity.ToTable("Unidad_analisis");

            entity.Property(e => e.IdUa)
                .ValueGeneratedNever()
                .HasColumnName("ID_ua");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.TipoUaId).HasColumnName("Tipo_ua_id");

            entity.HasOne(d => d.TipoUa).WithMany(p => p.UnidadAnalisis)
                .HasForeignKey(d => d.TipoUaId)
                .HasConstraintName("R_62");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("XPKUsuario");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("ID_usuario");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Passwrd)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.RolId).HasColumnName("Rol_id");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("R_13");
        });

        modelBuilder.Entity<UsuarioCanton>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioCanto);

            entity.ToTable("Usuario-Canton");

            entity.Property(e => e.IdUsuarioCanto)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ID_usuario-canto");
            entity.Property(e => e.CantonId).HasColumnName("Canton_id");
            entity.Property(e => e.ProvinciaId).HasColumnName("Provincia_id");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioCantons)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("R_39");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
