using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public partial class RaCaGakContext : DbContext
    {
        public RaCaGakContext()
        {
        }

        public RaCaGakContext(DbContextOptions<RaCaGakContext> options) : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Msg> Msgs { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<PostReaction> PostReactions { get; set; } = null!;
        public virtual DbSet<Template> Templates { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(
                    "Server=localhost\\MSSQLSERVER02;Database=RaCaGak;TrustServerCertificate=True;User Id=sa;Password=P@ssw0rdsenac;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Msg)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments__PostId__37A5467C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments__UserId__36B12243");
            });

            modelBuilder.Entity<Msg>(entity =>
            {
                entity.Property(e => e.Msg1)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Msg");

                entity.Property(e => e.SentDate).HasColumnType("datetime");

                entity.HasOne(d => d.FromUserNavigation)
                    .WithMany(p => p.MsgFromUserNavigations)
                    .HasForeignKey(d => d.FromUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Msgs__FromUser__3A81B327");

                entity.HasOne(d => d.ToUserNavigation)
                    .WithMany(p => p.MsgToUserNavigations)
                    .HasForeignKey(d => d.ToUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Msgs__ToUser__3B75D760");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PostDescription)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Posts__UserId__2F10007B");
            });

            modelBuilder.Entity<PostReaction>(entity =>
            {
                entity.HasIndex(e => new {e.UserId, e.PostId}, "UQ__PostReac__8D29EA4CCA2039C5")
                    .IsUnique();

                entity.Property(e => e.ReactionType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostReactions)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PostReact__PostI__33D4B598");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PostReactions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PostReact__UserI__32E0915F");
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PostDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.NickName, "UQ__Users__01E67C8BAD4AC5F0")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NickName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Passwd)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
