using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using ReCapDbContext reCapDbContext = new();
            var result = from p in reCapDbContext.Cars
                         join c in reCapDbContext.Colors on p.ColorId equals c.ColorId
                         join b in reCapDbContext.Brands on p.BrandId equals b.BrandId
                         select new CarDetailDto
                         {
                             BrandName = b.Name,
                             ColorName = c.Name,
                             DailyPrice = p.DailyPrice,
                             CarName = p.Description
                         };
            return result.ToList();
        }
    }

}
