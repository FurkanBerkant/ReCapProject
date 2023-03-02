﻿using Core.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>
        :IEntityRepository<TEntity>
        where TEntity : class,IEntity,new()
        where TContext : DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using var reCapDbContext = new TContext();
            var addedEntity = reCapDbContext.Entry(entity);
            addedEntity.State = EntityState.Added;
            reCapDbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using TContext reCapDbContext = new();
            var deletedEntity = reCapDbContext.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            reCapDbContext.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using TContext context = new TContext();
#pragma warning disable CS8603 // Possible null reference return.
            return context.Set<TEntity>().SingleOrDefault(filter);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using TContext reCapDbContext = new();
            return filter == null ? reCapDbContext.Set<TEntity>().ToList()
                : reCapDbContext.Set<TEntity>().Where(filter).ToList();
        }

        public void Update(TEntity entity)
        {
            using var context = new TContext();
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    } 
}
