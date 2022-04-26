using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SurveySystem.Data.Entities;
using SurveySystem.Data.Interfaces;

#nullable disable

namespace SurveySystem.Data
{
    public partial class SurveyContext : DbContext, ISurveyContext
    {
        public SurveyContext()
        {
        }

        public SurveyContext(DbContextOptions<SurveyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryEntity> Categories { get; set; }
        public virtual DbSet<ElementEntity> Elements { get; set; }

        public virtual DbSet<AnswerEntity> Answers { get; set; }

        public void AddRange<TEntity>(TEntity[] entity) where TEntity : class
        {
            base.AddRange(entity);
        }

        public void AutoDetectChangesDisabled()
        {
            base.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

       public new void SaveChanges()
        {
            base.SaveChanges();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectsV13;Database=Survey;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AnswerEntity>(entity =>
            {
                entity.Property(e => e.AnswerElement)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.QuestionElement)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionElementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Answers__Questio__34C8D9D1");
            });

            modelBuilder.Entity<CategoryEntity>(entity =>
            {
                entity.Property(e => e.AvatarUrl)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("AvatarURL");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ElementEntity>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ElementType)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Elements)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Elements__Catego__286302EC");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

      
    }
}
