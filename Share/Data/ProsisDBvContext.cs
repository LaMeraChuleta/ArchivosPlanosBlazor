using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Share.Models.Context;

namespace Share.Data
{
    public partial class ProsisDBvContext : DbContext
    {
        public ProsisDBvContext()
        {
        }

        public ProsisDBvContext(DbContextOptions<ProsisDBvContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; } = null!;
        public virtual DbSet<PnImportacionWsIndra> PnImportacionWsIndras { get; set; } = null!;
        public virtual DbSet<TypeCarril> TypeCarrils { get; set; } = null!;
        public virtual DbSet<TypeDelegacion> TypeDelegacions { get; set; } = null!;
        public virtual DbSet<TypeOperadore> TypeOperadores { get; set; } = null!;
        public virtual DbSet<TypePlaza> TypePlazas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=10.1.1.125;Database=ProsisDBv;User=PROSIS_DEV;Password=Pr0$1$D3v;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.Name, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.UserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId").HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId").HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("PK_dbo.AspNetUserRoles");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_RoleId");

                            j.HasIndex(new[] { "UserId" }, "IX_UserId");

                            j.IndexerProperty<string>("UserId").HasMaxLength(128);

                            j.IndexerProperty<string>("RoleId").HasMaxLength(128);
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<PnImportacionWsIndra>(entity =>
            {
                entity.HasKey(e => e.IdExp);

                entity.ToTable("pn_importacion_wsIndra");

                entity.Property(e => e.IdExp).HasColumnName("id_exp");

                entity.Property(e => e.AcdClass).HasColumnName("ACD_CLASS");

                entity.Property(e => e.ClaseDetectada)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CLASE_DETECTADA");

                entity.Property(e => e.ClaseMarcada)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CLASE_MARCADA");

                entity.Property(e => e.CodeGrilleTarif).HasColumnName("CODE_GRILLE_TARIF");

                entity.Property(e => e.ContenuIso)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONTENU_ISO");

                entity.Property(e => e.DateTransaction)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_TRANSACTION");

                entity.Property(e => e.EventNumber).HasColumnName("EVENT_NUMBER");

                entity.Property(e => e.FechaExt)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_ext");

                entity.Property(e => e.FolioEct).HasColumnName("FOLIO_ECT");

                entity.Property(e => e.IdObsMp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID_OBS_MP");

                entity.Property(e => e.IdPaiement).HasColumnName("ID_PAIEMENT");

                entity.Property(e => e.MontoDetectado)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("MONTO_DETECTADO");

                entity.Property(e => e.MontoMarcado)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("MONTO_MARCADO");

                entity.Property(e => e.Plaza).HasColumnName("PLAZA");

                entity.Property(e => e.ShiftNumber).HasColumnName("Shift_number");

                entity.Property(e => e.TabIdClasse).HasColumnName("TAB_ID_CLASSE");

                entity.Property(e => e.VersionTarif).HasColumnName("Version_Tarif");

                entity.Property(e => e.Voie)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VOIE");
            });

            modelBuilder.Entity<TypeCarril>(entity =>
            {
                entity.HasKey(e => e.IdCarril)
                    .HasName("PK__Type_Car__FB01E99DECB8FDB3");

                entity.ToTable("Type_Carril");

                entity.Property(e => e.IdCarril).HasColumnName("Id_Carril");

                entity.Property(e => e.NumCapufe)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Num_Capufe");

                entity.Property(e => e.NumGea)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Num_Gea");

                entity.Property(e => e.NumTramo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Num_Tramo");

                entity.Property(e => e.PlazaId).HasColumnName("Plaza_Id");

                entity.HasOne(d => d.Plaza)
                    .WithMany(p => p.TypeCarrils)
                    .HasForeignKey(d => d.PlazaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Type_Carr__Plaza__3F466844");
            });

            modelBuilder.Entity<TypeDelegacion>(entity =>
            {
                entity.HasKey(e => e.IdDelegacion)
                    .HasName("PK__Type_Del__FCDAF8178FE212BC");

                entity.ToTable("Type_Delegacion");

                entity.Property(e => e.IdDelegacion).HasColumnName("Id_Delegacion");

                entity.Property(e => e.NomDelegacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nom_Delegacion");

                entity.Property(e => e.NumDelegacion)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Num_Delegacion");
            });

            modelBuilder.Entity<TypeOperadore>(entity =>
            {
                entity.HasKey(e => e.IdOperador)
                    .HasName("PK__Type_Ope__9DF402CDC688C9BB");

                entity.ToTable("Type_Operadores");

                entity.Property(e => e.IdOperador).HasColumnName("Id_Operador");

                entity.Property(e => e.NomOperador)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Nom_Operador");

                entity.Property(e => e.NumCapufe)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Num_Capufe");

                entity.Property(e => e.NumGea)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Num_Gea");

                entity.Property(e => e.PlazaId).HasColumnName("Plaza_Id");

                entity.HasOne(d => d.Plaza)
                    .WithMany(p => p.TypeOperadores)
                    .HasForeignKey(d => d.PlazaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Type_Oper__Plaza__403A8C7D");
            });

            modelBuilder.Entity<TypePlaza>(entity =>
            {
                entity.HasKey(e => e.IdPlaza)
                    .HasName("PK__Type_Pla__75054AE91D31F8F5");

                entity.ToTable("Type_Plaza");

                entity.Property(e => e.IdPlaza).HasColumnName("Id_Plaza");

                entity.Property(e => e.DelegacionId).HasColumnName("Delegacion_Id");

                entity.Property(e => e.NomPlaza)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nom_Plaza");

                entity.Property(e => e.NumPlaza)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Num_Plaza");

                entity.HasOne(d => d.Delegacion)
                    .WithMany(p => p.TypePlazas)
                    .HasForeignKey(d => d.DelegacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Type_Plaz__Deleg__412EB0B6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
