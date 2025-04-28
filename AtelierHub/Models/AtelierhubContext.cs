using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AtelierHub.Models;

public partial class AtelierhubContext : DbContext
{
    public AtelierhubContext()
    {
    }

    public AtelierhubContext(DbContextOptions<AtelierhubContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=atelierhub;Username=postgres;Password=87024344076darhan");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
