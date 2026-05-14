using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace optometria.Models;

public partial class BdOpticaModeloEstrellaContext : DbContext
{
    public BdOpticaModeloEstrellaContext()
    {
    }

    public BdOpticaModeloEstrellaContext(DbContextOptions<BdOpticaModeloEstrellaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAbono> TblAbonos { get; set; }

    public virtual DbSet<TblArchivoConsultum> TblArchivoConsulta { get; set; }

    public virtual DbSet<TblCategoriaProducto> TblCategoriaProductos { get; set; }

    public virtual DbSet<TblComprobante> TblComprobantes { get; set; }

    public virtual DbSet<TblComunicacion> TblComunicacions { get; set; }

    public virtual DbSet<TblConfiguracionOptica> TblConfiguracionOpticas { get; set; }

    public virtual DbSet<TblConsulta> TblConsulta { get; set; }

    public virtual DbSet<TblDetalleVentum> TblDetalleVenta { get; set; }

    public virtual DbSet<TblEnvioLaboratorio> TblEnvioLaboratorios { get; set; }

    public virtual DbSet<TblLaboratorio> TblLaboratorios { get; set; }

    public virtual DbSet<TblLogAuditoria> TblLogAuditoria { get; set; }

    public virtual DbSet<TblMetodoPago> TblMetodoPagos { get; set; }

    public virtual DbSet<TblMovimientoInventario> TblMovimientoInventarios { get; set; }

    public virtual DbSet<TblOrdenRx> TblOrdenRxes { get; set; }

    public virtual DbSet<TblPaciente> TblPacientes { get; set; }

    public virtual DbSet<TblPlantillaMensaje> TblPlantillaMensajes { get; set; }

    public virtual DbSet<TblProducto> TblProductos { get; set; }

    public virtual DbSet<TblProveedor> TblProveedors { get; set; }

    public virtual DbSet<TblRol> TblRols { get; set; }

    public virtual DbSet<TblRxContactologia> TblRxContactologia { get; set; }

    public virtual DbSet<TblRxLente> TblRxLentes { get; set; }

    public virtual DbSet<TblSesion> TblSesions { get; set; }

    public virtual DbSet<TblUsuario> TblUsuarios { get; set; }

    public virtual DbSet<TblVenta> TblVenta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=bd_optica_modelo_estrella;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAbono>(entity =>
        {
            entity.HasKey(e => e.IdAbono).HasName("PK__tbl_abon__1E6B958340D1E4B9");

            entity.ToTable("tbl_abono");

            entity.Property(e => e.IdAbono).HasColumnName("id_abono");
            entity.Property(e => e.Concepto)
                .IsUnicode(false)
                .HasColumnName("concepto");
            entity.Property(e => e.FechaAbono)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_abono");
            entity.Property(e => e.IdMetodoPago).HasColumnName("id_metodo_pago");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("monto");

            entity.HasOne(d => d.IdMetodoPagoNavigation).WithMany(p => p.TblAbonos)
                .HasForeignKey(d => d.IdMetodoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_abono_metodo");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TblAbonos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_abono_usuario");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.TblAbonos)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_abono_venta");
        });

        modelBuilder.Entity<TblArchivoConsultum>(entity =>
        {
            entity.HasKey(e => e.IdArchivoConsulta).HasName("PK__tbl_arch__5E1572429D883D79");

            entity.ToTable("tbl_archivo_consulta");

            entity.Property(e => e.IdArchivoConsulta).HasColumnName("id_archivo_consulta");
            entity.Property(e => e.FechaSubida)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_subida");
            entity.Property(e => e.IdConsulta).HasColumnName("id_consulta");
            entity.Property(e => e.NombreOriginal)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_original");
            entity.Property(e => e.RutaArchivo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ruta_archivo");
            entity.Property(e => e.TipoArchivo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_archivo");

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.TblArchivoConsulta)
                .HasForeignKey(d => d.IdConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_archivo_consulta");
        });

        modelBuilder.Entity<TblCategoriaProducto>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__tbl_cate__CD54BC5AD7D0A38B");

            entity.ToTable("tbl_categoria_producto");

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TblComprobante>(entity =>
        {
            entity.HasKey(e => e.IdComprobante).HasName("PK__tbl_comp__55E5E240429C96FF");

            entity.ToTable("tbl_comprobante");

            entity.HasIndex(e => e.NumeroComprobante, "UQ__tbl_comp__1850D80D58238795").IsUnique();

            entity.Property(e => e.IdComprobante).HasColumnName("id_comprobante");
            entity.Property(e => e.FechaEmision)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_emision");
            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.NumeroComprobante)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numero_comprobante");
            entity.Property(e => e.RutaPdf)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ruta_pdf");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.TblComprobantes)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_comprobante_venta");
        });

        modelBuilder.Entity<TblComunicacion>(entity =>
        {
            entity.HasKey(e => e.IdComunicacion).HasName("PK__tbl_comu__D76C507105C0737B");

            entity.ToTable("tbl_comunicacion");

            entity.Property(e => e.IdComunicacion).HasColumnName("id_comunicacion");
            entity.Property(e => e.Canal)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("canal");
            entity.Property(e => e.ContenidoResumen)
                .IsUnicode(false)
                .HasColumnName("contenido_resumen");
            entity.Property(e => e.Destinatario)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("destinatario");
            entity.Property(e => e.FechaEnvio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_envio");
            entity.Property(e => e.IdOrdenRx).HasColumnName("id_orden_rx");
            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            entity.Property(e => e.IdPlantillaMensaje).HasColumnName("id_plantilla_mensaje");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdOrdenRxNavigation).WithMany(p => p.TblComunicacions)
                .HasForeignKey(d => d.IdOrdenRx)
                .HasConstraintName("fk_comunicacion_orden");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.TblComunicacions)
                .HasForeignKey(d => d.IdPaciente)
                .HasConstraintName("fk_comunicacion_paciente");

            entity.HasOne(d => d.IdPlantillaMensajeNavigation).WithMany(p => p.TblComunicacions)
                .HasForeignKey(d => d.IdPlantillaMensaje)
                .HasConstraintName("fk_comunicacion_plantilla");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TblComunicacions)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("fk_comunicacion_usuario");
        });

        modelBuilder.Entity<TblConfiguracionOptica>(entity =>
        {
            entity.HasKey(e => e.IdConfiguracion).HasName("PK__tbl_conf__16A13EBDF44ECBFE");

            entity.ToTable("tbl_configuracion_optica");

            entity.Property(e => e.IdConfiguracion).HasColumnName("id_configuracion");
            entity.Property(e => e.CarpetaRx)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("carpeta_rx");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.NombreComercial)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre_comercial");
            entity.Property(e => e.PorcentajeImpuesto)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("porcentaje_impuesto");
            entity.Property(e => e.PrefijoPais)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("prefijo_pais");
            entity.Property(e => e.Ruc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ruc");
            entity.Property(e => e.RutaFondo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ruta_fondo");
            entity.Property(e => e.RutaLogo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ruta_logo");
            entity.Property(e => e.Telefono)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<TblConsulta>(entity =>
        {
            entity.HasKey(e => e.IdConsulta).HasName("PK__tbl_cons__6F53588B217EE3BC");

            entity.ToTable("tbl_consulta");

            entity.HasIndex(e => e.FechaConsulta, "idx_consulta_fecha");

            entity.Property(e => e.IdConsulta).HasColumnName("id_consulta");
            entity.Property(e => e.Alergias)
                .IsUnicode(false)
                .HasColumnName("alergias");
            entity.Property(e => e.AntecedentesFamiliares)
                .IsUnicode(false)
                .HasColumnName("antecedentes_familiares");
            entity.Property(e => e.AntecedentesOculares)
                .IsUnicode(false)
                .HasColumnName("antecedentes_oculares");
            entity.Property(e => e.AntecedentesPersonales)
                .IsUnicode(false)
                .HasColumnName("antecedentes_personales");
            entity.Property(e => e.DetalleUsaLentes)
                .IsUnicode(false)
                .HasColumnName("detalle_usa_lentes");
            entity.Property(e => e.EnfermedadesPrevias)
                .IsUnicode(false)
                .HasColumnName("enfermedades_previas");
            entity.Property(e => e.Evaluaciones)
                .IsUnicode(false)
                .HasColumnName("evaluaciones");
            entity.Property(e => e.ExamenesPreliminares)
                .IsUnicode(false)
                .HasColumnName("examenes_preliminares");
            entity.Property(e => e.ExamenesVarios)
                .IsUnicode(false)
                .HasColumnName("examenes_varios");
            entity.Property(e => e.FechaConsulta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_consulta");
            entity.Property(e => e.HistoriaClinica)
                .IsUnicode(false)
                .HasColumnName("historia_clinica");
            entity.Property(e => e.IdOptometra).HasColumnName("id_optometra");
            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            entity.Property(e => e.Medicamentos)
                .IsUnicode(false)
                .HasColumnName("medicamentos");
            entity.Property(e => e.MotivoConsulta)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("motivo_consulta");
            entity.Property(e => e.Notas)
                .IsUnicode(false)
                .HasColumnName("notas");
            entity.Property(e => e.UsaLentes)
                .HasDefaultValue(true)
                .HasColumnName("usa_lentes");

            entity.HasOne(d => d.IdOptometraNavigation).WithMany(p => p.TblConsulta)
                .HasForeignKey(d => d.IdOptometra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_consulta_usuario");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.TblConsulta)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_consulta_paciente");
        });

        modelBuilder.Entity<TblDetalleVentum>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("PK__tbl_deta__5B265D474E76981D");

            entity.ToTable("tbl_detalle_venta");

            entity.Property(e => e.IdDetalleVenta).HasColumnName("id_detalle_venta");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.ConceptoItem)
                .IsUnicode(false)
                .HasColumnName("concepto_item");
            entity.Property(e => e.Descuento)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("descuento");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.MotivoDescuento)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("motivo_descuento");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_unitario");
            entity.Property(e => e.TotalItem)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_item");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.TblDetalleVenta)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle_producto");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.TblDetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle_venta");
        });

        modelBuilder.Entity<TblEnvioLaboratorio>(entity =>
        {
            entity.HasKey(e => e.IdEnvioLaboratorio).HasName("PK__tbl_envi__BF4AEA25C263BDF5");

            entity.ToTable("tbl_envio_laboratorio");

            entity.Property(e => e.IdEnvioLaboratorio).HasColumnName("id_envio_laboratorio");
            entity.Property(e => e.Canal)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("canal");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCambioEstado).HasColumnName("fecha_cambio_estado");
            entity.Property(e => e.FechaEnvio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_envio");
            entity.Property(e => e.IdOrdenRx).HasColumnName("id_orden_rx");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.IdUsuarioEntrega).HasColumnName("id_usuario_entrega");

            entity.HasOne(d => d.IdOrdenRxNavigation).WithMany(p => p.TblEnvioLaboratorios)
                .HasForeignKey(d => d.IdOrdenRx)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_envio_orden");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TblEnvioLaboratorioIdUsuarioNavigations)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_envio_usuario");

            entity.HasOne(d => d.IdUsuarioEntregaNavigation).WithMany(p => p.TblEnvioLaboratorioIdUsuarioEntregaNavigations)
                .HasForeignKey(d => d.IdUsuarioEntrega)
                .HasConstraintName("fk_envio_usuario_entrega");
        });

        modelBuilder.Entity<TblLaboratorio>(entity =>
        {
            entity.HasKey(e => e.IdLaboratorio).HasName("PK__tbl_labo__781B42E28411F1C8");

            entity.ToTable("tbl_laboratorio");

            entity.Property(e => e.IdLaboratorio).HasColumnName("id_laboratorio");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PersonaContacto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("persona_contacto");
            entity.Property(e => e.Whatsapp)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("whatsapp");
        });

        modelBuilder.Entity<TblLogAuditoria>(entity =>
        {
            entity.HasKey(e => e.IdLogAuditoria).HasName("PK__tbl_log___CF188A05B770E02E");

            entity.ToTable("tbl_log_auditoria");

            entity.Property(e => e.IdLogAuditoria).HasColumnName("id_log_auditoria");
            entity.Property(e => e.Accion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("accion");
            entity.Property(e => e.Detalle)
                .IsUnicode(false)
                .HasColumnName("detalle");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Modulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modulo");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TblLogAuditoria)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("fk_log_usuario");
        });

        modelBuilder.Entity<TblMetodoPago>(entity =>
        {
            entity.HasKey(e => e.IdMetodoPago).HasName("PK__tbl_meto__85BE0EBC7C55A7BC");

            entity.ToTable("tbl_metodo_pago");

            entity.Property(e => e.IdMetodoPago).HasColumnName("id_metodo_pago");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TblMovimientoInventario>(entity =>
        {
            entity.HasKey(e => e.IdMovimientoInventario).HasName("PK__tbl_movi__95610EAE94740B84");

            entity.ToTable("tbl_movimiento_inventario");

            entity.Property(e => e.IdMovimientoInventario).HasColumnName("id_movimiento_inventario");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.FechaMovimiento)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_movimiento");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Observaciones)
                .IsUnicode(false)
                .HasColumnName("observaciones");
            entity.Property(e => e.StockAnterior).HasColumnName("stock_anterior");
            entity.Property(e => e.StockResultante).HasColumnName("stock_resultante");
            entity.Property(e => e.TipoMovimiento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo_movimiento");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.TblMovimientoInventarios)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_movimiento_producto");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TblMovimientoInventarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_movimiento_usuario");
        });

        modelBuilder.Entity<TblOrdenRx>(entity =>
        {
            entity.HasKey(e => e.IdOrdenRx).HasName("PK__tbl_orde__FA23F3B4501E66F3");

            entity.ToTable("tbl_orden_rx");

            entity.HasIndex(e => e.NumeroOrden, "UQ__tbl_orde__37067115C2E49AC0").IsUnique();

            entity.HasIndex(e => e.Estado, "idx_orden_estado");

            entity.Property(e => e.IdOrdenRx).HasColumnName("id_orden_rx");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("Enviado a laboratorio")
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdConsulta).HasColumnName("id_consulta");
            entity.Property(e => e.IdLaboratorio).HasColumnName("id_laboratorio");
            entity.Property(e => e.IdRxContactologia).HasColumnName("id_rx_contactologia");
            entity.Property(e => e.IdRxLente).HasColumnName("id_rx_lente");
            entity.Property(e => e.NumeroOrden)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numero_orden");
            entity.Property(e => e.Observaciones)
                .IsUnicode(false)
                .HasColumnName("observaciones");
            entity.Property(e => e.TipoRx)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("tipo_rx");

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.TblOrdenRxes)
                .HasForeignKey(d => d.IdConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_orden_consulta");

            entity.HasOne(d => d.IdLaboratorioNavigation).WithMany(p => p.TblOrdenRxes)
                .HasForeignKey(d => d.IdLaboratorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_orden_laboratorio");

            entity.HasOne(d => d.IdRxContactologiaNavigation).WithMany(p => p.TblOrdenRxes)
                .HasForeignKey(d => d.IdRxContactologia)
                .HasConstraintName("fk_orden_rx_contactologia");

            entity.HasOne(d => d.IdRxLenteNavigation).WithMany(p => p.TblOrdenRxes)
                .HasForeignKey(d => d.IdRxLente)
                .HasConstraintName("fk_orden_rx_lente");
        });

        modelBuilder.Entity<TblPaciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__tbl_paci__2C2C72BB9F4DAC7E");

            entity.ToTable("tbl_paciente");

            entity.HasIndex(e => e.Cedula, "UQ__tbl_paci__415B7BE5D61B9852").IsUnique();

            entity.HasIndex(e => e.CodigoPaciente, "UQ__tbl_paci__94DC8C4D9285B096").IsUnique();

            entity.HasIndex(e => e.Cedula, "idx_paciente_cedula");

            entity.HasIndex(e => new { e.Apellidos, e.Nombres }, "idx_paciente_nombre");

            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Cedula)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cedula");
            entity.Property(e => e.CodigoPaciente)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("codigo_paciente");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EstadoCivil)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado_civil");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Genero)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.IdUsuarioRegistro).HasColumnName("id_usuario_registro");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Observaciones)
                .IsUnicode(false)
                .HasColumnName("observaciones");
            entity.Property(e => e.Ocupacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ocupacion");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdUsuarioRegistroNavigation).WithMany(p => p.TblPacientes)
                .HasForeignKey(d => d.IdUsuarioRegistro)
                .HasConstraintName("fk_paciente_usuario");
        });

        modelBuilder.Entity<TblPlantillaMensaje>(entity =>
        {
            entity.HasKey(e => e.IdPlantillaMensaje).HasName("PK__tbl_plan__FABE8524D220C42C");

            entity.ToTable("tbl_plantilla_mensaje");

            entity.Property(e => e.IdPlantillaMensaje).HasColumnName("id_plantilla_mensaje");
            entity.Property(e => e.Canal)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("canal");
            entity.Property(e => e.Contenido)
                .IsUnicode(false)
                .HasColumnName("contenido");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<TblProducto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__tbl_prod__FF341C0DD2D32297");

            entity.ToTable("tbl_producto");

            entity.HasIndex(e => e.CodigoProducto, "UQ__tbl_prod__105107A8124A631A").IsUnique();

            entity.HasIndex(e => e.CodigoProducto, "idx_producto_codigo");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.CodigoProducto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigo_producto");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre_producto");
            entity.Property(e => e.PrecioCosto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_costo");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_venta");
            entity.Property(e => e.StockActual)
                .HasDefaultValue(0)
                .HasColumnName("stock_actual");
            entity.Property(e => e.StockMinimo)
                .HasDefaultValue(0)
                .HasColumnName("stock_minimo");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.TblProductos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("fk_producto_categoria");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.TblProductos)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("fk_producto_proveedor");
        });

        modelBuilder.Entity<TblProveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__tbl_prov__8D3DFE28F17EAE7F");

            entity.ToTable("tbl_proveedor");

            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Observaciones)
                .IsUnicode(false)
                .HasColumnName("observaciones");
            entity.Property(e => e.Telefono)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<TblRol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__tbl_rol__6ABCB5E0C9CAB04F");

            entity.ToTable("tbl_rol");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TblRxContactologia>(entity =>
        {
            entity.HasKey(e => e.IdRxContactologia).HasName("PK__tbl_rx_c__976E489E0939F373");

            entity.ToTable("tbl_rx_contactologia");

            entity.Property(e => e.IdRxContactologia).HasColumnName("id_rx_contactologia");
            entity.Property(e => e.IdConsulta).HasColumnName("id_consulta");
            entity.Property(e => e.Observaciones)
                .IsUnicode(false)
                .HasColumnName("observaciones");
            entity.Property(e => e.OdAv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("od_av");
            entity.Property(e => e.OdAvccCerca)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("od_avcc_cerca");
            entity.Property(e => e.OdAvccLejos)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("od_avcc_lejos");
            entity.Property(e => e.OdCilindro)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("od_cilindro");
            entity.Property(e => e.OdCurvaBase)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("od_curva_base");
            entity.Property(e => e.OdDiametro)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("od_diametro");
            entity.Property(e => e.OdEje)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("od_eje");
            entity.Property(e => e.OdEsfera)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("od_esfera");
            entity.Property(e => e.OiAv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("oi_av");
            entity.Property(e => e.OiAvccCerca)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("oi_avcc_cerca");
            entity.Property(e => e.OiAvccLejos)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("oi_avcc_lejos");
            entity.Property(e => e.OiCilindro)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("oi_cilindro");
            entity.Property(e => e.OiCurvaBase)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("oi_curva_base");
            entity.Property(e => e.OiDiametro)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("oi_diametro");
            entity.Property(e => e.OiEje)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("oi_eje");
            entity.Property(e => e.OiEsfera)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("oi_esfera");
            entity.Property(e => e.TipoLente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipo_lente");

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.TblRxContactologia)
                .HasForeignKey(d => d.IdConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rx_contactologia_consulta");
        });

        modelBuilder.Entity<TblRxLente>(entity =>
        {
            entity.HasKey(e => e.IdRxLente).HasName("PK__tbl_rx_l__79164068B84525CC");

            entity.ToTable("tbl_rx_lente");

            entity.Property(e => e.IdRxLente).HasColumnName("id_rx_lente");
            entity.Property(e => e.DisenoLente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("diseno_lente");
            entity.Property(e => e.IdConsulta).HasColumnName("id_consulta");
            entity.Property(e => e.Material)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("material");
            entity.Property(e => e.Observaciones)
                .IsUnicode(false)
                .HasColumnName("observaciones");
            entity.Property(e => e.OdAddicion)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("od_addicion");
            entity.Property(e => e.OdAltura)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("od_altura");
            entity.Property(e => e.OdCilindro)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("od_cilindro");
            entity.Property(e => e.OdDnp)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("od_dnp");
            entity.Property(e => e.OdDp)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("od_dp");
            entity.Property(e => e.OdEje)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("od_eje");
            entity.Property(e => e.OdEsfera)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("od_esfera");
            entity.Property(e => e.OdPrisma)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("od_prisma");
            entity.Property(e => e.OiAddicion)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("oi_addicion");
            entity.Property(e => e.OiAltura)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("oi_altura");
            entity.Property(e => e.OiCilindro)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("oi_cilindro");
            entity.Property(e => e.OiDnp)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("oi_dnp");
            entity.Property(e => e.OiDp)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("oi_dp");
            entity.Property(e => e.OiEje)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("oi_eje");
            entity.Property(e => e.OiEsfera)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("oi_esfera");
            entity.Property(e => e.OiPrisma)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("oi_prisma");
            entity.Property(e => e.Tratamiento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tratamiento");

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.TblRxLentes)
                .HasForeignKey(d => d.IdConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rx_lente_consulta");
        });

        modelBuilder.Entity<TblSesion>(entity =>
        {
            entity.HasKey(e => e.IdSesion).HasName("PK__tbl_sesi__8D3F9DFE8823BBC0");

            entity.ToTable("tbl_sesion");

            entity.Property(e => e.IdSesion).HasColumnName("id_sesion");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Ip)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ip");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TblSesions)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sesion_usuario");
        });

        modelBuilder.Entity<TblUsuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__tbl_usua__4E3E04AD04F9EB75");

            entity.ToTable("tbl_usuario");

            entity.HasIndex(e => e.Usuario, "UQ__tbl_usua__9AFF8FC6AD86ADCC").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__tbl_usua__AB6E6164452C2F0F").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Bloqueado)
                .HasDefaultValue(true)
                .HasColumnName("bloqueado");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.IntentosFallidos)
                .HasDefaultValue(0)
                .HasColumnName("intentos_fallidos");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.UltimoCambioPassword).HasColumnName("ultimo_cambio_password");
            entity.Property(e => e.Usuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("usuario");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.TblUsuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_usuario_rol");
        });

        modelBuilder.Entity<TblVenta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__tbl_vent__459533BF685FA7CC");

            entity.ToTable("tbl_venta");

            entity.HasIndex(e => e.Estado, "idx_venta_estado");

            entity.HasIndex(e => e.FechaVenta, "idx_venta_fecha");

            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.Concepto)
                .IsUnicode(false)
                .HasColumnName("concepto");
            entity.Property(e => e.DescuentoTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("descuento_total");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pendiente")
                .HasColumnName("estado");
            entity.Property(e => e.FechaVenta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fecha_venta");
            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.ImpuestoTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("impuesto_total");
            entity.Property(e => e.SaldoPendiente)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("saldo_pendiente");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.ValorCobrado)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valor_cobrado");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.TblVenta)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_venta_paciente");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TblVenta)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_venta_usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
