using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SurveySystem.Data.Entities;

namespace SurveySystem.Data.Interfaces
{
    public interface ISurveyContext
    {
        void SaveChanges();

        Task<int> SaveChangesAsync();

        EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
        void AddRange<TEntity>(TEntity[] entity) where TEntity : class;
        void AutoDetectChangesDisabled();
        public  DbSet<CategoryEntity> Categories { get; set; }
        public  DbSet<ElementEntity> Elements { get; set; }
        public  DbSet<AnswerEntity> Answers { get; set; }
    }
}
