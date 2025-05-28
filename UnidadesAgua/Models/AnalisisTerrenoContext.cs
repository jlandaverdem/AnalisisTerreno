using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UnidadesAgua.Models;

public partial class AnalisisTerrenoContext : DbContext
{
    public AnalisisTerrenoContext()
    {
    }

    public AnalisisTerrenoContext(DbContextOptions<AnalisisTerrenoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlturaTerreno> AlturaTerrenos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MXLAGIL8057\\SQLEXPRESS;Initial Catalog=AnalisisTerreno;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlturaTerreno>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
