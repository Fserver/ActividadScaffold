using Microsoft.EntityFrameworkCore;

namespace ActividadScaffold.Entities
{
    public partial class ACT01Context : DbContext
    {
        public ACT01Context()
        {
        }

        public ACT01Context(DbContextOptions<ACT01Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Conductor> Conductors { get; set; } = null!;
        public virtual DbSet<Matricula> Matriculas { get; set; } = null!;
        public virtual DbSet<Sancione> Sanciones { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=P553D28;user=yo;password=123;database=ACT01");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conductor>(entity =>
            {
                entity.ToTable("CONDUCTOR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activo).HasColumnName("ACTIVO");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDO");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_NACIMIENTO");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("IDENTIFICACION");

                entity.Property(e => e.MatriculaId).HasColumnName("MATRICULA_ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONO");

                entity.HasOne(d => d.Matricula)
                    .WithMany(p => p.Conductors)
                    .HasForeignKey(d => d.MatriculaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__CONDUCTOR__MATRI__2F10007B");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.ToTable("MATRICULA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activo).HasColumnName("ACTIVO");

                entity.Property(e => e.FechaExpedicion)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_EXPEDICION");

                entity.Property(e => e.Numero)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NUMERO");

                entity.Property(e => e.ValidaHasta)
                    .HasColumnType("date")
                    .HasColumnName("VALIDA_HASTA");
            });

            modelBuilder.Entity<Sancione>(entity =>
            {
                entity.ToTable("SANCIONES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ConductorId).HasColumnName("CONDUCTOR_ID");

                entity.Property(e => e.FechaActual)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_ACTUAL")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Observacion)
                    .IsUnicode(false)
                    .HasColumnName("OBSERVACION");

                entity.Property(e => e.Sancion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SANCION");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("VALOR");

                entity.HasOne(d => d.Conductor)
                    .WithMany(p => p.Sanciones)
                    .HasForeignKey(d => d.ConductorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__SANCIONES__CONDU__32E0915F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
