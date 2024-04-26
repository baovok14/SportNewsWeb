using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SportNews.Models
{
    public partial class NewsContext : DbContext
    {
        public NewsContext()
        {
        }

        public NewsContext(DbContextOptions<NewsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCategory> TblCategory { get; set; }
        public virtual DbSet<TblPosts> TblPosts { get; set; }
        public virtual DbSet<TblUsers> TblUsers { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=VIETBAO\\SQL2014;Database=News;User ID=vietbao;Password=123456;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.CateId)
                    .HasName("PK__tbl_Cate__34EAD1736FD7C8FD");

                entity.ToTable("tbl_Category");

                entity.Property(e => e.CateId)
                    .HasColumnName("cate_id")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CateName)
                    .HasColumnName("cate_name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TblPosts>(entity =>
            {
                entity.HasKey(e => e.IdPost)
                    .HasName("PK__tbl_Post__3840C79D417019E7");

                entity.ToTable("tbl_Posts");

                entity.Property(e => e.IdPost).HasColumnName("id_post");

                entity.Property(e => e.Body)
                    .HasColumnName("body")
                    .HasColumnType("text");

                entity.Property(e => e.CateId)
                    .HasColumnName("cate_id")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(255);
                entity.Property(e => e.img)
                    .HasColumnName("img")
                    .HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Cate)
                    .WithMany(p => p.TblPosts)
                    .HasForeignKey(d => d.CateId)
                    .HasConstraintName("FK__tbl_Posts__cate___2E1BDC42");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblPosts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__tbl_Posts__user___2D27B809");
            });

            modelBuilder.Entity<TblUsers>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__tbl_User__B9BE370FE50CE67D");

                entity.ToTable("tbl_Users");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
