﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GameWebApi.Models.DB
{
    public partial class GameDBContext : DbContext
    {
        public GameDBContext()
        {
        }

        public GameDBContext(DbContextOptions<GameDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClanMembers> ClanMembers { get; set; }
        public virtual DbSet<ClanStatistics> ClanStatistics { get; set; }
        public virtual DbSet<Clans> Clans { get; set; }
        public virtual DbSet<Friends> Friends { get; set; }
        public virtual DbSet<InvationsPlayerToClan> InvationsPlayerToClan { get; set; }
        public virtual DbSet<PlayerBans> PlayerBans { get; set; }
        public virtual DbSet<PlayerDates> PlayerDates { get; set; }
        public virtual DbSet<PlayerIdentity> PlayerIdentity { get; set; }
        public virtual DbSet<PlayerSalt> PlayerSalt { get; set; }
        public virtual DbSet<PlayerStatistics> PlayerStatistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClanMembers>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.ToTable("ClanMembers", "Common");

                entity.Property(e => e.PlayerId).ValueGeneratedNever();

                entity.Property(e => e.DateOfJoin).HasColumnType("date");

                entity.HasOne(d => d.Clan)
                    .WithMany(p => p.ClanMembers)
                    .HasForeignKey(d => d.ClanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClanMembers_Clans");

                entity.HasOne(d => d.Player)
                    .WithOne(p => p.ClanMembers)
                    .HasForeignKey<ClanMembers>(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClanMembers_PlayerIdentity");
            });

            modelBuilder.Entity<ClanStatistics>(entity =>
            {
                entity.HasKey(e => e.ClanId);

                entity.ToTable("ClanStatistics", "Common");

                entity.Property(e => e.ClanId).ValueGeneratedNever();

                entity.HasOne(d => d.Clan)
                    .WithOne(p => p.ClanStatistics)
                    .HasForeignKey<ClanStatistics>(d => d.ClanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClanStatistics_Clans");
            });

            modelBuilder.Entity<Clans>(entity =>
            {
                entity.ToTable("Clans", "Common");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Acronym)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.AvatarUrl)
                    .HasColumnName("AvatarURL")
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Friends>(entity =>
            {
                entity.ToTable("Friends", "Common");

                entity.HasOne(d => d.OwnerPlayer)
                    .WithMany(p => p.Friends)
                    .HasForeignKey(d => d.OwnerPlayerId)
                    .HasConstraintName("FK_Friends_PlayerIdentity");
            });

            modelBuilder.Entity<InvationsPlayerToClan>(entity =>
            {
                entity.ToTable("InvationsPlayerToClan", "Common");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.Clan)
                    .WithMany(p => p.InvationsPlayerToClan)
                    .HasForeignKey(d => d.ClanId)
                    .HasConstraintName("FK_InvationsPlayerToClan_Clans");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.InvationsPlayerToClan)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_InvationsPlayerToClan_PlayerIdentity");
            });

            modelBuilder.Entity<PlayerBans>(entity =>
            {
                entity.ToTable("PlayerBans", "Common");

                entity.Property(e => e.BanMessage)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.BeginBanDate).HasColumnType("date");

                entity.Property(e => e.EndBanDate).HasColumnType("date");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerBans)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayerBans_PlayerIdentity");
            });

            modelBuilder.Entity<PlayerDates>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.ToTable("PlayerDates", "Common");

                entity.Property(e => e.PlayerId).ValueGeneratedNever();

                entity.Property(e => e.BanDate).HasColumnType("date");

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.LastPasswordChangeDate).HasColumnType("date");

                entity.Property(e => e.ModificationDate).HasColumnType("date");

                entity.HasOne(d => d.Player)
                    .WithOne(p => p.PlayerDates)
                    .HasForeignKey<PlayerDates>(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayerDates_PlayerIdentity");
            });

            modelBuilder.Entity<PlayerIdentity>(entity =>
            {
                entity.ToTable("PlayerIdentity", "Common");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.EmailConfirmed).HasDefaultValueSql("((0))");

                entity.Property(e => e.GameToken)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Nick)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PlayerHash).HasMaxLength(255);
            });

            modelBuilder.Entity<PlayerSalt>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.ToTable("PlayerSalt", "Common");

                entity.Property(e => e.PlayerId).ValueGeneratedNever();

                entity.Property(e => e.Salt).IsRequired();

                entity.HasOne(d => d.Player)
                    .WithOne(p => p.PlayerSalt)
                    .HasForeignKey<PlayerSalt>(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Salt_PlayerIdentity1");
            });

            modelBuilder.Entity<PlayerStatistics>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.ToTable("PlayerStatistics", "Common");

                entity.Property(e => e.PlayerId).ValueGeneratedNever();

                entity.HasOne(d => d.Player)
                    .WithOne(p => p.PlayerStatistics)
                    .HasForeignKey<PlayerStatistics>(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayerStatistics_PlayerIdentity");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
