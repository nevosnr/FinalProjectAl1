using System;
using System.Collections.Generic;
using FinalProjectAl1.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectAl1.Data;

public partial class RequestDbContext : DbContext
{
    public RequestDbContext()
    {
    }

    public RequestDbContext(DbContextOptions<RequestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LookupRank> LookupRanks { get; set; }

    public virtual DbSet<LookupStatus> LookupStatuses { get; set; }

    public virtual DbSet<LookupTeam> LookupTeams { get; set; }

    public virtual DbSet<LookupUnitId> LookupUnitIds { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestUpdate> RequestUpdates { get; set; }

    public virtual DbSet<ViewRequestAudit> ViewRequestAudits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=TMSCFrontDoor");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LookupRank>(entity =>
        {
            entity.HasKey(e => e.RankId).HasName("PK__LOOKUP_R__25BE3A45731C23EA");

            entity.ToTable("LOOKUP_Rank");

            entity.Property(e => e.RankId).HasColumnName("Rank_Id");
            entity.Property(e => e.RankNameLong)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Rank_NameLong");
            entity.Property(e => e.RankNameShort)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Rank_NameShort");
            entity.Property(e => e.RankNatoequiv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Rank_NATOEquiv");
        });

        modelBuilder.Entity<LookupStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__LOOKUP_S__5190094C66459382");

            entity.ToTable("LOOKUP_Status");

            entity.Property(e => e.StatusId).HasColumnName("Status_Id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Status_Name");
        });

        modelBuilder.Entity<LookupTeam>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__LOOKUP_T__02215C6A27DDC5BD");

            entity.ToTable("LOOKUP_Team");

            entity.Property(e => e.TeamId).HasColumnName("Team_Id");
            entity.Property(e => e.TeamNameLong)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Team_NameLong");
            entity.Property(e => e.TeamNameShort)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Team_NameShort");
        });

        modelBuilder.Entity<LookupUnitId>(entity =>
        {
            entity.HasKey(e => e.UnitId).HasName("PK__LOOKUP_U__27556B785F961835");

            entity.ToTable("LOOKUP_UnitID");

            entity.Property(e => e.UnitId).HasColumnName("Unit_Id");
            entity.Property(e => e.UnitNameLong)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Unit_NameLong");
            entity.Property(e => e.UnitNameShort)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Unit_NameShort");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestTaskId).HasName("PK__Requests__369BD5A5EB0365E7");

            entity.Property(e => e.RequestTaskId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Request_TaskId");
            entity.Property(e => e.RequestArchive).HasColumnName("Request_Archive");
            entity.Property(e => e.RequestAssignedTo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Request_AssignedTo");
            entity.Property(e => e.RequestContactPhone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Request_ContactPhone");
            entity.Property(e => e.RequestCreated)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("Request_Created");
            entity.Property(e => e.RequestEmailAdd)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Request_EmailAdd");
            entity.Property(e => e.RequestFirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Request_FirstName");
            entity.Property(e => e.RequestLastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Request_LastName");
            entity.Property(e => e.RequestRank)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Request_Rank");
            entity.Property(e => e.RequestShortId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Request_ShortId");
            entity.Property(e => e.RequestStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Request_Status");
            entity.Property(e => e.RequestTaskDescription)
                .IsUnicode(false)
                .HasColumnName("Request_TaskDescription");
            entity.Property(e => e.RequestTitle)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Request_Title");
            entity.Property(e => e.RequestUnitIdentifier)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Request_UnitIdentifier");
        });

        modelBuilder.Entity<RequestUpdate>(entity =>
        {
            entity.HasKey(e => e.UpdateId).HasName("PK__RequestU__C11655E413FC0769");

            entity.Property(e => e.UpdateId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Update_Id");
            entity.Property(e => e.RequestTaskId).HasColumnName("Request_TaskId");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Update_By");
            entity.Property(e => e.UpdateDescription)
                .IsUnicode(false)
                .HasColumnName("Update_Description");
            entity.Property(e => e.UpdateStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Update_Status");
            entity.Property(e => e.UpdateTimeStamp)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("Update_TimeStamp");
        });

        modelBuilder.Entity<ViewRequestAudit>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VIEW_RequestAudit");

            entity.Property(e => e.RequestCreated).HasColumnName("Request_Created");
            entity.Property(e => e.RequestEmailAdd)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Request_EmailAdd");
            entity.Property(e => e.RequestStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Request_Status");
            entity.Property(e => e.RequestTaskDescription)
                .IsUnicode(false)
                .HasColumnName("Request_TaskDescription");
            entity.Property(e => e.RequestTaskId).HasColumnName("Request_TaskId");
            entity.Property(e => e.RequestTitle)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Request_Title");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Update_By");
            entity.Property(e => e.UpdateDescription)
                .IsUnicode(false)
                .HasColumnName("Update_Description");
            entity.Property(e => e.UpdateId).HasColumnName("Update_Id");
            entity.Property(e => e.UpdateTimeStamp).HasColumnName("Update_TimeStamp");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
