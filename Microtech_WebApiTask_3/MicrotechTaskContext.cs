using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Microtech_WebApiTask_3
{
    public partial class MicrotechTaskContext : DbContext
    {
        public MicrotechTaskContext()
        {
        }

        public MicrotechTaskContext(DbContextOptions<MicrotechTaskContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MicrotechTask;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccNumber);

                entity.Property(e => e.AccNumber)
                    .HasMaxLength(10)
                    .HasColumnName("Acc_Number")
                    .IsFixedLength(true);

                entity.Property(e => e.AccParent)
                    .HasMaxLength(10)
                    .HasColumnName("ACC_Parent")
                    .IsFixedLength(true);

                entity.Property(e => e.Balance).HasColumnType("decimal(20, 9)");

                entity.HasOne(d => d.AccParentNavigation)
                    .WithMany(p => p.InverseAccParentNavigation)
                    .HasForeignKey(d => d.AccParent)
                    .HasConstraintName("FK_Accounts_Accounts");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
