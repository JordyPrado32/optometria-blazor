using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using optometria.Models.Optica;

namespace optometria.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Abono> Abonos => Set<Abono>();
    public DbSet<ArchivoConsulta> ArchivosConsulta => Set<ArchivoConsulta>();
    public DbSet<CategoriaProducto> CategoriasProducto => Set<CategoriaProducto>();
    public DbSet<Comprobante> Comprobantes => Set<Comprobante>();
    public DbSet<Comunicacion> Comunicaciones => Set<Comunicacion>();
    public DbSet<ConfiguracionOptica> ConfiguracionesOptica => Set<ConfiguracionOptica>();
    public DbSet<Consulta> Consultas => Set<Consulta>();
    public DbSet<DetalleVenta> DetallesVenta => Set<DetalleVenta>();
    public DbSet<EnvioLaboratorio> EnviosLaboratorio => Set<EnvioLaboratorio>();
    public DbSet<Laboratorio> Laboratorios => Set<Laboratorio>();
    public DbSet<LogAuditoria> LogsAuditoria => Set<LogAuditoria>();
    public DbSet<MetodoPago> MetodosPago => Set<MetodoPago>();
    public DbSet<MovimientoInventario> MovimientosInventario => Set<MovimientoInventario>();
    public DbSet<OrdenRx> OrdenesRx => Set<OrdenRx>();
    public DbSet<Paciente> Pacientes => Set<Paciente>();
    public DbSet<PlantillaMensaje> PlantillasMensaje => Set<PlantillaMensaje>();
    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<Proveedor> Proveedores => Set<Proveedor>();
    public DbSet<Rol> RolesOptica => Set<Rol>();
    public DbSet<RxContactologia> RxContactologias => Set<RxContactologia>();
    public DbSet<RxLente> RxLentes => Set<RxLente>();
    public DbSet<Sesion> Sesiones => Set<Sesion>();
    public DbSet<Usuario> UsuariosOptica => Set<Usuario>();
    public DbSet<Venta> Ventas => Set<Venta>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureRol(modelBuilder);
        ConfigureUsuario(modelBuilder);
        ConfigurePaciente(modelBuilder);
        ConfigureConsulta(modelBuilder);
        ConfigureRxContactologia(modelBuilder);
        ConfigureRxLente(modelBuilder);
        ConfigureLaboratorio(modelBuilder);
        ConfigureProveedor(modelBuilder);
        ConfigureCategoriaProducto(modelBuilder);
        ConfigureProducto(modelBuilder);
        ConfigureVenta(modelBuilder);
        ConfigureDetalleVenta(modelBuilder);
        ConfigureMetodoPago(modelBuilder);
        ConfigureAbono(modelBuilder);
        ConfigureComprobante(modelBuilder);
        ConfigureOrdenRx(modelBuilder);
        ConfigureEnvioLaboratorio(modelBuilder);
        ConfigurePlantillaMensaje(modelBuilder);
        ConfigureComunicacion(modelBuilder);
        ConfigureArchivoConsulta(modelBuilder);
        ConfigureMovimientoInventario(modelBuilder);
        ConfigureConfiguracionOptica(modelBuilder);
        ConfigureSesion(modelBuilder);
        ConfigureLogAuditoria(modelBuilder);
    }

    private static void ConfigureRol(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rol>(entity =>
        {
            entity.ToTable("tbl_rol");

            entity.HasKey(e => e.IdRol);
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.Descripcion).HasColumnName("descripcion").HasMaxLength(255).IsUnicode(false);
        });
    }

    private static void ConfigureUsuario(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("tbl_usuario");

            entity.HasKey(e => e.IdUsuario);
            entity.HasIndex(e => e.Email).IsUnique();
            entity.HasIndex(e => e.UsuarioLogin).IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Nombres).HasColumnName("nombres").HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.Apellidos).HasColumnName("apellidos").HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.Email).HasColumnName("email").HasMaxLength(150).IsUnicode(false);
            entity.Property(e => e.UsuarioLogin).HasColumnName("usuario").HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash").HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Telefono).HasColumnName("telefono").HasMaxLength(20).IsUnicode(false);
            entity.Property(e => e.Activo).HasColumnName("activo").HasDefaultValue(true);
            entity.Property(e => e.IntentosFallidos).HasColumnName("intentos_fallidos").HasDefaultValue(0);
            entity.Property(e => e.Bloqueado).HasColumnName("bloqueado").HasDefaultValue(true);
            entity.Property(e => e.UltimoCambioPassword).HasColumnName("ultimo_cambio_password").HasColumnType("date");
            entity.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion").HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");

            entity.HasOne(e => e.Rol)
                .WithMany(e => e.Usuarios)
                .HasForeignKey(e => e.IdRol)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_usuario_rol");
        });
    }

    private static void ConfigurePaciente(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.ToTable("tbl_paciente");

            entity.HasKey(e => e.IdPaciente);
            entity.HasIndex(e => e.CodigoPaciente).IsUnique();
            entity.HasIndex(e => e.Cedula).IsUnique().HasDatabaseName("idx_paciente_cedula");
            entity.HasIndex(e => new { e.Apellidos, e.Nombres }).HasDatabaseName("idx_paciente_nombre");

            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            entity.Property(e => e.CodigoPaciente).HasColumnName("codigo_paciente").HasMaxLength(30).IsUnicode(false);
            entity.Property(e => e.Cedula).HasColumnName("cedula").HasMaxLength(20).IsUnicode(false);
            entity.Property(e => e.Nombres).HasColumnName("nombres").HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.Apellidos).HasColumnName("apellidos").HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento").HasColumnType("date");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Genero).HasColumnName("genero").HasMaxLength(20).IsUnicode(false);
            entity.Property(e => e.EstadoCivil).HasColumnName("estado_civil").HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.Ocupacion).HasColumnName("ocupacion").HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.Direccion).HasColumnName("direccion").HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Telefono).HasColumnName("telefono").HasMaxLength(20).IsUnicode(false);
            entity.Property(e => e.Email).HasColumnName("email").HasMaxLength(150).IsUnicode(false);
            entity.Property(e => e.Observaciones).HasColumnName("observaciones").HasColumnType("varchar(max)").IsUnicode(false);
            entity.Property(e => e.Activo).HasColumnName("activo").HasDefaultValue(true);
            entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro").HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.IdUsuarioRegistro).HasColumnName("id_usuario_registro");

            entity.HasOne(e => e.UsuarioRegistro)
                .WithMany(e => e.PacientesRegistrados)
                .HasForeignKey(e => e.IdUsuarioRegistro)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_paciente_usuario");
        });
    }

    private static void ConfigureConsulta(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Consulta>(entity =>
        {
            entity.ToTable("tbl_consulta");

            entity.HasKey(e => e.IdConsulta);
            entity.HasIndex(e => e.FechaConsulta).HasDatabaseName("idx_consulta_fecha");

            entity.Property(e => e.IdConsulta).HasColumnName("id_consulta");
            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            entity.Property(e => e.IdOptometra).HasColumnName("id_optometra");
            entity.Property(e => e.FechaConsulta).HasColumnName("fecha_consulta").HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.MotivoConsulta).HasColumnName("motivo_consulta").HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.AntecedentesPersonales).HasColumnName("antecedentes_personales").HasColumnType("varchar(max)").IsUnicode(false);
            entity.Property(e => e.AntecedentesFamiliares).HasColumnName("antecedentes_familiares").HasColumnType("varchar(max)").IsUnicode(false);
            entity.Property(e => e.AntecedentesOculares).HasColumnName("antecedentes_oculares").HasColumnType("varchar(max)").IsUnicode(false);
            entity.Property(e => e.EnfermedadesPrevias).HasColumnName("enfermedades_previas").HasColumnType("varchar(max)").IsUnicode(false);
            entity.Property(e => e.Alergias).HasColumnName("alergias").HasColumnType("varchar(max)").IsUnicode(false);
            entity.Property(e => e.Medicamentos).HasColumnName("medicamentos").HasColumnType("varchar(max)").IsUnicode(false);
            entity.Property(e => e.UsaLentes).HasColumnName("usa_lentes").HasDefaultValue(true);
            entity.Property(e => e.DetalleUsaLentes).HasColumnName("detalle_usa_lentes").HasColumnType("varchar(max)").IsUnicode(false);
            entity.Property(e => e.HistoriaClinica).HasColumnName("historia_clinica").HasColumnType("varchar(max)").IsUnicode(false);
            entity.Property(e => e.ExamenesPreliminares).HasColumnName("examenes_preliminares").HasColumnType("varchar(max)").IsUnicode(false);
            entity.Property(e => e.Evaluaciones).HasColumnName("evaluaciones").HasColumnType("varchar(max)").IsUnicode(false);
            entity.Property(e => e.ExamenesVarios).HasColumnName("examenes_varios").HasColumnType("varchar(max)").IsUnicode(false);
            entity.Property(e => e.Notas).HasColumnName("notas").HasColumnType("varchar(max)").IsUnicode(false);

            entity.HasOne(e => e.Paciente)
                .WithMany(e => e.Consultas)
                .HasForeignKey(e => e.IdPaciente)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_consulta_paciente");

            entity.HasOne(e => e.Optometra)
                .WithMany(e => e.ConsultasComoOptometra)
                .HasForeignKey(e => e.IdOptometra)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_consulta_usuario");
        });
    }

    private static void ConfigureRxContactologia(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RxContactologia>(entity =>
        {
            entity.ToTable("tbl_rx_contactologia");

            entity.HasKey(e => e.IdRxContactologia);
            entity.Property(e => e.IdRxContactologia).HasColumnName("id_rx_contactologia");
            entity.Property(e => e.IdConsulta).HasColumnName("id_consulta");
            ConfigureGraduacionContactologia(entity);
            entity.Property(e => e.TipoLente).HasColumnName("tipo_lente").HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.Observaciones).HasColumnName("observaciones").HasColumnType("varchar(max)").IsUnicode(false);

            entity.HasOne(e => e.Consulta)
                .WithMany(e => e.RxContactologias)
                .HasForeignKey(e => e.IdConsulta)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_rx_contactologia_consulta");
        });
    }

    private static void ConfigureRxLente(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RxLente>(entity =>
        {
            entity.ToTable("tbl_rx_lente");

            entity.HasKey(e => e.IdRxLente);
            entity.Property(e => e.IdRxLente).HasColumnName("id_rx_lente");
            entity.Property(e => e.IdConsulta).HasColumnName("id_consulta");
            ConfigureGraduacionLente(entity);
            entity.Property(e => e.DisenoLente).HasColumnName("diseno_lente").HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.Material).HasColumnName("material").HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.Tratamiento).HasColumnName("tratamiento").HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.Observaciones).HasColumnName("observaciones").HasColumnType("varchar(max)").IsUnicode(false);

            entity.HasOne(e => e.Consulta)
                .WithMany(e => e.RxLentes)
                .HasForeignKey(e => e.IdConsulta)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_rx_lente_consulta");
        });
    }

    private static void ConfigureLaboratorio(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Laboratorio>(entity =>
        {
            entity.ToTable("tbl_laboratorio");

            entity.HasKey(e => e.IdLaboratorio);
            entity.Property(e => e.IdLaboratorio).HasColumnName("id_laboratorio");
            entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(150).IsUnicode(false);
            entity.Property(e => e.Correo).HasColumnName("correo").HasMaxLength(150).IsUnicode(false);
            entity.Property(e => e.Whatsapp).HasColumnName("whatsapp").HasMaxLength(30).IsUnicode(false);
            entity.Property(e => e.PersonaContacto).HasColumnName("persona_contacto").HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.Direccion).HasColumnName("direccion").HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Activo).HasColumnName("activo").HasDefaultValue(true);
        });
    }

    private static void ConfigureProveedor(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.ToTable("tbl_proveedor");

            entity.HasKey(e => e.IdProveedor);
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(150).IsUnicode(false);
            entity.Property(e => e.Telefono).HasColumnName("telefono").HasMaxLength(30).IsUnicode(false);
            entity.Property(e => e.Email).HasColumnName("email").HasMaxLength(150).IsUnicode(false);
            entity.Property(e => e.Direccion).HasColumnName("direccion").HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Observaciones).HasColumnName("observaciones").HasColumnType("varchar(max)").IsUnicode(false);
        });
    }

    private static void ConfigureCategoriaProducto(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriaProducto>(entity =>
        {
            entity.ToTable("tbl_categoria_producto");

            entity.HasKey(e => e.IdCategoria);
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.Descripcion).HasColumnName("descripcion").HasColumnType("varchar(max)").IsUnicode(false);
        });
    }

    private static void ConfigureProducto(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.ToTable("tbl_producto");

            entity.HasKey(e => e.IdProducto);
            entity.HasIndex(e => e.CodigoProducto).IsUnique().HasDatabaseName("idx_producto_codigo");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.CodigoProducto).HasColumnName("codigo_producto").HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.NombreProducto).HasColumnName("nombre_producto").HasMaxLength(150).IsUnicode(false);
            entity.Property(e => e.Descripcion).HasColumnName("descripcion").HasColumnType("varchar(max)").IsUnicode(false);
            entity.Property(e => e.PrecioCosto).HasColumnName("precio_costo").HasPrecision(10, 2);
            entity.Property(e => e.PrecioVenta).HasColumnName("precio_venta").HasPrecision(10, 2);
            entity.Property(e => e.StockActual).HasColumnName("stock_actual").HasDefaultValue(0);
            entity.Property(e => e.StockMinimo).HasColumnName("stock_minimo").HasDefaultValue(0);
            entity.Property(e => e.Activo).HasColumnName("activo").HasDefaultValue(true);

            entity.HasOne(e => e.Proveedor)
                .WithMany(e => e.Productos)
                .HasForeignKey(e => e.IdProveedor)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_producto_proveedor");

            entity.HasOne(e => e.Categoria)
                .WithMany(e => e.Productos)
                .HasForeignKey(e => e.IdCategoria)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_producto_categoria");
        });
    }

    private static void ConfigureVenta(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Venta>(entity =>
        {
            entity.ToTable("tbl_venta", tb =>
            {
                tb.HasCheckConstraint("chk_venta_estado", "[estado] IN ('Pendiente', 'Completada', 'Anulada')");
            });

            entity.HasKey(e => e.IdVenta);
            entity.HasIndex(e => e.FechaVenta).HasDatabaseName("idx_venta_fecha");
            entity.HasIndex(e => e.Estado).HasDatabaseName("idx_venta_estado");

            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.FechaVenta).HasColumnName("fecha_venta").HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.Subtotal).HasColumnName("subtotal").HasPrecision(10, 2);
            entity.Property(e => e.ImpuestoTotal).HasColumnName("impuesto_total").HasPrecision(10, 2);
            entity.Property(e => e.DescuentoTotal).HasColumnName("descuento_total").HasPrecision(10, 2);
            entity.Property(e => e.Total).HasColumnName("total").HasPrecision(10, 2);
            entity.Property(e => e.ValorCobrado).HasColumnName("valor_cobrado").HasPrecision(10, 2);
            entity.Property(e => e.SaldoPendiente).HasColumnName("saldo_pendiente").HasPrecision(10, 2);
            entity.Property(e => e.Estado).HasColumnName("estado").HasMaxLength(20).IsUnicode(false).HasDefaultValue("Pendiente");
            entity.Property(e => e.Concepto).HasColumnName("concepto").HasColumnType("varchar(max)").IsUnicode(false);

            entity.HasOne(e => e.Paciente)
                .WithMany(e => e.Ventas)
                .HasForeignKey(e => e.IdPaciente)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_venta_paciente");

            entity.HasOne(e => e.Usuario)
                .WithMany(e => e.Ventas)
                .HasForeignKey(e => e.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_venta_usuario");
        });
    }

    private static void ConfigureDetalleVenta(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.ToTable("tbl_detalle_venta");

            entity.HasKey(e => e.IdDetalleVenta);
            entity.Property(e => e.IdDetalleVenta).HasColumnName("id_detalle_venta");
            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.PrecioUnitario).HasColumnName("precio_unitario").HasPrecision(10, 2);
            entity.Property(e => e.Descuento).HasColumnName("descuento").HasPrecision(10, 2);
            entity.Property(e => e.MotivoDescuento).HasColumnName("motivo_descuento").HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.ConceptoItem).HasColumnName("concepto_item").HasColumnType("varchar(max)").IsUnicode(false);
            entity.Property(e => e.TotalItem).HasColumnName("total_item").HasPrecision(10, 2);

            entity.HasOne(e => e.Venta)
                .WithMany(e => e.DetallesVenta)
                .HasForeignKey(e => e.IdVenta)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_detalle_venta");

            entity.HasOne(e => e.Producto)
                .WithMany(e => e.DetallesVenta)
                .HasForeignKey(e => e.IdProducto)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_detalle_producto");
        });
    }

    private static void ConfigureMetodoPago(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MetodoPago>(entity =>
        {
            entity.ToTable("tbl_metodo_pago");

            entity.HasKey(e => e.IdMetodoPago);
            entity.Property(e => e.IdMetodoPago).HasColumnName("id_metodo_pago");
            entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(100).IsUnicode(false);
        });
    }

    private static void ConfigureAbono(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Abono>(entity =>
        {
            entity.ToTable("tbl_abono");

            entity.HasKey(e => e.IdAbono);
            entity.Property(e => e.IdAbono).HasColumnName("id_abono");
            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.IdMetodoPago).HasColumnName("id_metodo_pago");
            entity.Property(e => e.Monto).HasColumnName("monto").HasPrecision(10, 2);
            entity.Property(e => e.FechaAbono).HasColumnName("fecha_abono").HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.Concepto).HasColumnName("concepto").HasColumnType("varchar(max)").IsUnicode(false);

            entity.HasOne(e => e.Venta)
                .WithMany(e => e.Abonos)
                .HasForeignKey(e => e.IdVenta)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_abono_venta");

            entity.HasOne(e => e.Usuario)
                .WithMany(e => e.Abonos)
                .HasForeignKey(e => e.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_abono_usuario");

            entity.HasOne(e => e.MetodoPago)
                .WithMany(e => e.Abonos)
                .HasForeignKey(e => e.IdMetodoPago)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_abono_metodo");
        });
    }

    private static void ConfigureComprobante(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comprobante>(entity =>
        {
            entity.ToTable("tbl_comprobante");

            entity.HasKey(e => e.IdComprobante);
            entity.HasIndex(e => e.NumeroComprobante).IsUnique();

            entity.Property(e => e.IdComprobante).HasColumnName("id_comprobante");
            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.NumeroComprobante).HasColumnName("numero_comprobante").HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.RutaPdf).HasColumnName("ruta_pdf").HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.FechaEmision).HasColumnName("fecha_emision").HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");

            entity.HasOne(e => e.Venta)
                .WithMany(e => e.Comprobantes)
                .HasForeignKey(e => e.IdVenta)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_comprobante_venta");
        });
    }

    private static void ConfigureOrdenRx(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrdenRx>(entity =>
        {
            entity.ToTable("tbl_orden_rx", tb =>
            {
                tb.HasCheckConstraint("chk_orden_tipo_rx", "[tipo_rx] IN ('Contactologia', 'Lente Convencional')");
                tb.HasCheckConstraint("chk_orden_estado", "[estado] IN ('Enviado a laboratorio', 'Listo para entrega', 'Entregado al paciente')");
            });

            entity.HasKey(e => e.IdOrdenRx);
            entity.HasIndex(e => e.NumeroOrden).IsUnique();
            entity.HasIndex(e => e.Estado).HasDatabaseName("idx_orden_estado");

            entity.Property(e => e.IdOrdenRx).HasColumnName("id_orden_rx");
            entity.Property(e => e.IdConsulta).HasColumnName("id_consulta");
            entity.Property(e => e.IdLaboratorio).HasColumnName("id_laboratorio");
            entity.Property(e => e.IdRxContactologia).HasColumnName("id_rx_contactologia");
            entity.Property(e => e.IdRxLente).HasColumnName("id_rx_lente");
            entity.Property(e => e.NumeroOrden).HasColumnName("numero_orden").HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.TipoRx).HasColumnName("tipo_rx").HasMaxLength(30).IsUnicode(false);
            entity.Property(e => e.Estado).HasColumnName("estado").HasMaxLength(30).IsUnicode(false).HasDefaultValue("Enviado a laboratorio");
            entity.Property(e => e.FechaCreacion).HasColumnName("fecha_creacion").HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.Observaciones).HasColumnName("observaciones").HasColumnType("varchar(max)").IsUnicode(false);

            entity.HasOne(e => e.Consulta)
                .WithMany(e => e.OrdenesRx)
                .HasForeignKey(e => e.IdConsulta)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_orden_consulta");

            entity.HasOne(e => e.Laboratorio)
                .WithMany(e => e.OrdenesRx)
                .HasForeignKey(e => e.IdLaboratorio)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_orden_laboratorio");

            entity.HasOne(e => e.RxContactologia)
                .WithMany(e => e.OrdenesRx)
                .HasForeignKey(e => e.IdRxContactologia)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_orden_rx_contactologia");

            entity.HasOne(e => e.RxLente)
                .WithMany(e => e.OrdenesRx)
                .HasForeignKey(e => e.IdRxLente)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_orden_rx_lente");
        });
    }

    private static void ConfigureEnvioLaboratorio(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EnvioLaboratorio>(entity =>
        {
            entity.ToTable("tbl_envio_laboratorio", tb =>
            {
                tb.HasCheckConstraint("chk_envio_canal", "[canal] IN ('WhatsApp', 'Email')");
                tb.HasCheckConstraint("chk_envio_estado", "[estado] IN ('Enviado a laboratorio', 'Listo para entrega', 'Entregado al paciente')");
            });

            entity.HasKey(e => e.IdEnvioLaboratorio);
            entity.Property(e => e.IdEnvioLaboratorio).HasColumnName("id_envio_laboratorio");
            entity.Property(e => e.IdOrdenRx).HasColumnName("id_orden_rx");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Canal).HasColumnName("canal").HasMaxLength(20).IsUnicode(false);
            entity.Property(e => e.Estado).HasColumnName("estado").HasMaxLength(30).IsUnicode(false);
            entity.Property(e => e.FechaEnvio).HasColumnName("fecha_envio").HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.FechaCambioEstado).HasColumnName("fecha_cambio_estado").HasColumnType("datetime2");
            entity.Property(e => e.IdUsuarioEntrega).HasColumnName("id_usuario_entrega");

            entity.HasOne(e => e.OrdenRx)
                .WithMany(e => e.EnviosLaboratorio)
                .HasForeignKey(e => e.IdOrdenRx)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_envio_orden");

            entity.HasOne(e => e.Usuario)
                .WithMany(e => e.EnviosLaboratorio)
                .HasForeignKey(e => e.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_envio_usuario");

            entity.HasOne(e => e.UsuarioEntrega)
                .WithMany(e => e.EnviosEntregados)
                .HasForeignKey(e => e.IdUsuarioEntrega)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_envio_usuario_entrega");
        });
    }

    private static void ConfigurePlantillaMensaje(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlantillaMensaje>(entity =>
        {
            entity.ToTable("tbl_plantilla_mensaje", tb =>
            {
                tb.HasCheckConstraint("chk_plantilla_canal", "[canal] IN ('WhatsApp', 'Email')");
            });

            entity.HasKey(e => e.IdPlantillaMensaje);
            entity.Property(e => e.IdPlantillaMensaje).HasColumnName("id_plantilla_mensaje");
            entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(150).IsUnicode(false);
            entity.Property(e => e.Canal).HasColumnName("canal").HasMaxLength(20).IsUnicode(false);
            entity.Property(e => e.Tipo).HasColumnName("tipo").HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.Contenido).HasColumnName("contenido").HasColumnType("varchar(max)").IsUnicode(false);
        });
    }

    private static void ConfigureComunicacion(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comunicacion>(entity =>
        {
            entity.ToTable("tbl_comunicacion", tb =>
            {
                tb.HasCheckConstraint("chk_comunicacion_canal", "[canal] IN ('WhatsApp', 'Email')");
            });

            entity.HasKey(e => e.IdComunicacion);
            entity.Property(e => e.IdComunicacion).HasColumnName("id_comunicacion");
            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            entity.Property(e => e.IdOrdenRx).HasColumnName("id_orden_rx");
            entity.Property(e => e.IdPlantillaMensaje).HasColumnName("id_plantilla_mensaje");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Canal).HasColumnName("canal").HasMaxLength(20).IsUnicode(false);
            entity.Property(e => e.Destinatario).HasColumnName("destinatario").HasMaxLength(150).IsUnicode(false);
            entity.Property(e => e.FechaEnvio).HasColumnName("fecha_envio").HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.ContenidoResumen).HasColumnName("contenido_resumen").HasColumnType("varchar(max)").IsUnicode(false);

            entity.HasOne(e => e.Paciente)
                .WithMany(e => e.Comunicaciones)
                .HasForeignKey(e => e.IdPaciente)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_comunicacion_paciente");

            entity.HasOne(e => e.OrdenRx)
                .WithMany(e => e.Comunicaciones)
                .HasForeignKey(e => e.IdOrdenRx)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_comunicacion_orden");

            entity.HasOne(e => e.PlantillaMensaje)
                .WithMany(e => e.Comunicaciones)
                .HasForeignKey(e => e.IdPlantillaMensaje)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_comunicacion_plantilla");

            entity.HasOne(e => e.Usuario)
                .WithMany(e => e.Comunicaciones)
                .HasForeignKey(e => e.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_comunicacion_usuario");
        });
    }

    private static void ConfigureArchivoConsulta(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArchivoConsulta>(entity =>
        {
            entity.ToTable("tbl_archivo_consulta");

            entity.HasKey(e => e.IdArchivoConsulta);
            entity.Property(e => e.IdArchivoConsulta).HasColumnName("id_archivo_consulta");
            entity.Property(e => e.IdConsulta).HasColumnName("id_consulta");
            entity.Property(e => e.RutaArchivo).HasColumnName("ruta_archivo").HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.NombreOriginal).HasColumnName("nombre_original").HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.TipoArchivo).HasColumnName("tipo_archivo").HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.FechaSubida).HasColumnName("fecha_subida").HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");

            entity.HasOne(e => e.Consulta)
                .WithMany(e => e.ArchivosConsulta)
                .HasForeignKey(e => e.IdConsulta)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_archivo_consulta");
        });
    }

    private static void ConfigureMovimientoInventario(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MovimientoInventario>(entity =>
        {
            entity.ToTable("tbl_movimiento_inventario", tb =>
            {
                tb.HasCheckConstraint("chk_movimiento_tipo", "[tipo_movimiento] IN ('Entrada', 'Salida', 'Ajuste')");
            });

            entity.HasKey(e => e.IdMovimientoInventario);
            entity.Property(e => e.IdMovimientoInventario).HasColumnName("id_movimiento_inventario");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.TipoMovimiento).HasColumnName("tipo_movimiento").HasMaxLength(20).IsUnicode(false);
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.StockAnterior).HasColumnName("stock_anterior");
            entity.Property(e => e.StockResultante).HasColumnName("stock_resultante");
            entity.Property(e => e.FechaMovimiento).HasColumnName("fecha_movimiento").HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.Observaciones).HasColumnName("observaciones").HasColumnType("varchar(max)").IsUnicode(false);

            entity.HasOne(e => e.Producto)
                .WithMany(e => e.MovimientosInventario)
                .HasForeignKey(e => e.IdProducto)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_movimiento_producto");

            entity.HasOne(e => e.Usuario)
                .WithMany(e => e.MovimientosInventario)
                .HasForeignKey(e => e.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_movimiento_usuario");
        });
    }

    private static void ConfigureConfiguracionOptica(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConfiguracionOptica>(entity =>
        {
            entity.ToTable("tbl_configuracion_optica");

            entity.HasKey(e => e.IdConfiguracion);
            entity.Property(e => e.IdConfiguracion).HasColumnName("id_configuracion");
            entity.Property(e => e.NombreComercial).HasColumnName("nombre_comercial").HasMaxLength(150).IsUnicode(false);
            entity.Property(e => e.Ruc).HasColumnName("ruc").HasMaxLength(20).IsUnicode(false);
            entity.Property(e => e.Direccion).HasColumnName("direccion").HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Telefono).HasColumnName("telefono").HasMaxLength(30).IsUnicode(false);
            entity.Property(e => e.PrefijoPais).HasColumnName("prefijo_pais").HasMaxLength(10).IsUnicode(false);
            entity.Property(e => e.PorcentajeImpuesto).HasColumnName("porcentaje_impuesto").HasPrecision(5, 2).HasDefaultValue(0.00m);
            entity.Property(e => e.CarpetaRx).HasColumnName("carpeta_rx").HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.RutaLogo).HasColumnName("ruta_logo").HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.RutaFondo).HasColumnName("ruta_fondo").HasMaxLength(255).IsUnicode(false);
        });
    }

    private static void ConfigureSesion(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sesion>(entity =>
        {
            entity.ToTable("tbl_sesion");

            entity.HasKey(e => e.IdSesion);
            entity.Property(e => e.IdSesion).HasColumnName("id_sesion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio").HasColumnType("datetime2");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin").HasColumnType("datetime2");
            entity.Property(e => e.Ip).HasColumnName("ip").HasMaxLength(100).IsUnicode(false);

            entity.HasOne(e => e.Usuario)
                .WithMany(e => e.Sesiones)
                .HasForeignKey(e => e.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_sesion_usuario");
        });
    }

    private static void ConfigureLogAuditoria(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LogAuditoria>(entity =>
        {
            entity.ToTable("tbl_log_auditoria");

            entity.HasKey(e => e.IdLogAuditoria);
            entity.Property(e => e.IdLogAuditoria).HasColumnName("id_log_auditoria");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Accion).HasColumnName("accion").HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.Modulo).HasColumnName("modulo").HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnName("fecha").HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.Detalle).HasColumnName("detalle").HasColumnType("varchar(max)").IsUnicode(false);

            entity.HasOne(e => e.Usuario)
                .WithMany(e => e.LogsAuditoria)
                .HasForeignKey(e => e.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_log_usuario");
        });
    }

    private static void ConfigureGraduacionContactologia(EntityTypeBuilder<RxContactologia> entity)
    {
        entity.Property(e => e.OdEsfera).HasColumnName("od_esfera").HasPrecision(5, 2);
        entity.Property(e => e.OdCilindro).HasColumnName("od_cilindro").HasPrecision(5, 2);
        entity.Property(e => e.OdEje).HasColumnName("od_eje").HasPrecision(5, 2);
        entity.Property(e => e.OdDiametro).HasColumnName("od_diametro").HasPrecision(5, 2);
        entity.Property(e => e.OdCurvaBase).HasColumnName("od_curva_base").HasPrecision(5, 2);
        entity.Property(e => e.OdAv).HasColumnName("od_av").HasMaxLength(20).IsUnicode(false);
        entity.Property(e => e.OdAvccLejos).HasColumnName("od_avcc_lejos").HasMaxLength(20).IsUnicode(false);
        entity.Property(e => e.OdAvccCerca).HasColumnName("od_avcc_cerca").HasMaxLength(20).IsUnicode(false);
        entity.Property(e => e.OiEsfera).HasColumnName("oi_esfera").HasPrecision(5, 2);
        entity.Property(e => e.OiCilindro).HasColumnName("oi_cilindro").HasPrecision(5, 2);
        entity.Property(e => e.OiEje).HasColumnName("oi_eje").HasPrecision(5, 2);
        entity.Property(e => e.OiDiametro).HasColumnName("oi_diametro").HasPrecision(5, 2);
        entity.Property(e => e.OiCurvaBase).HasColumnName("oi_curva_base").HasPrecision(5, 2);
        entity.Property(e => e.OiAv).HasColumnName("oi_av").HasMaxLength(20).IsUnicode(false);
        entity.Property(e => e.OiAvccLejos).HasColumnName("oi_avcc_lejos").HasMaxLength(20).IsUnicode(false);
        entity.Property(e => e.OiAvccCerca).HasColumnName("oi_avcc_cerca").HasMaxLength(20).IsUnicode(false);
    }

    private static void ConfigureGraduacionLente(EntityTypeBuilder<RxLente> entity)
    {
        entity.Property(e => e.OdEsfera).HasColumnName("od_esfera").HasPrecision(5, 2);
        entity.Property(e => e.OdCilindro).HasColumnName("od_cilindro").HasPrecision(5, 2);
        entity.Property(e => e.OdEje).HasColumnName("od_eje").HasPrecision(5, 2);
        entity.Property(e => e.OdAddicion).HasColumnName("od_addicion").HasPrecision(5, 2);
        entity.Property(e => e.OdPrisma).HasColumnName("od_prisma").HasPrecision(5, 2);
        entity.Property(e => e.OdDnp).HasColumnName("od_dnp").HasPrecision(5, 2);
        entity.Property(e => e.OdDp).HasColumnName("od_dp").HasPrecision(5, 2);
        entity.Property(e => e.OdAltura).HasColumnName("od_altura").HasPrecision(5, 2);
        entity.Property(e => e.OiEsfera).HasColumnName("oi_esfera").HasPrecision(5, 2);
        entity.Property(e => e.OiCilindro).HasColumnName("oi_cilindro").HasPrecision(5, 2);
        entity.Property(e => e.OiEje).HasColumnName("oi_eje").HasPrecision(5, 2);
        entity.Property(e => e.OiAddicion).HasColumnName("oi_addicion").HasPrecision(5, 2);
        entity.Property(e => e.OiPrisma).HasColumnName("oi_prisma").HasPrecision(5, 2);
        entity.Property(e => e.OiDnp).HasColumnName("oi_dnp").HasPrecision(5, 2);
        entity.Property(e => e.OiDp).HasColumnName("oi_dp").HasPrecision(5, 2);
        entity.Property(e => e.OiAltura).HasColumnName("oi_altura").HasPrecision(5, 2);
    }
}
