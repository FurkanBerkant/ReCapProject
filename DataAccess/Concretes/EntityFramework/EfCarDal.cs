﻿using DataAccess.Abstract;
using Entites.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfCarDal : CarDal
    {

        public void Add(Car entity)
        {
            using ReCapDbContext reCapDbContext = new();
            var addedEntity=reCapDbContext.Add(entity);
            addedEntity.State = EntityState.Added;
            reCapDbContext.SaveChanges();
        }

        public void Delete(Car entity)
        {
            using ReCapDbContext reCapDbContext = new();
            var deletedEntity=reCapDbContext.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            reCapDbContext.SaveChanges();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using ReCapDbContext reCapDbContext = new();
#pragma warning disable CS8603 // Possible null reference return.
            return reCapDbContext.Set<Car>()
                .SingleOrDefault(filter);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using ReCapDbContext reCapDbContext = new();
            return filter == null ? reCapDbContext.Set<Car>().ToList()
                : reCapDbContext.Set<Car>().Where(filter).ToList();
        }

        public void Update(Car entity)
        {
            using ReCapDbContext reCapDbContext = new();
            var updateEntity = EntityState.Modified;
            reCapDbContext.SaveChanges();
        }
    }
}
