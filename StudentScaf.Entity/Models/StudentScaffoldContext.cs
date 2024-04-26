using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentScaf.Entity.Models;

public partial class StudentScaffoldContext : DbContext
{
    public StudentScaffoldContext()
    {
    }

    public StudentScaffoldContext(DbContextOptions<StudentScaffoldContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StudentScaff> StudentScaffs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=STARLORD_7;Initial Catalog=StudentScaffold;User Id=sa; password=root;Persist Security Info=False;Integrated Security=false;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentScaff>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("StudentScaff");

            entity.Property(e => e.Sclass).HasColumnName("SClass");
            entity.Property(e => e.Sname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SName");
            entity.Property(e => e.StotalMarksObtained).HasColumnName("STotalMarksObtained");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
