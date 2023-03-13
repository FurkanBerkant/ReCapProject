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
        public List<CarDetailDto> GetByFilters(int brandId, int colorId)
        {
            using (ReCapDbContext context = new())
            {
                var result = from c in context.Cars
                             join br in context.Brands
                             on c.BrandId equals br.BrandId
                             join col in context.Colors
                             on c.ColorId equals col.ColorId
                             where (c.BrandId == brandId & c.ColorId == colorId)
                             select new CarDetailDto
                             {
                                 Id = c.CarId,
                                 BrandName = br.Name,
                                 CarName = c.Description,
                                 ColorName = col.Name,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 CarImages = (from cimg in context.CarImages
                                              where cimg.CarId == c.CarId
                                              select new CarImages
                                              {
                                                  Id = cimg.Id,
                                                  ImagePath = cimg.ImagePath,
                                                  CarId = c.CarId,
                                                  Date = cimg.Date
                                              }).ToList()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDbContext context = new())
            {
                var result = from c in context.Cars
                             join br in context.Brands
                             on c.BrandId equals br.BrandId
                             join col in context.Colors
                             on c.ColorId equals col.ColorId
                             select new CarDetailDto
                             {
                                 Id = c.CarId,
                                 BrandName = br.Name,
                                 CarName = c.Description,
                                 ColorName = col.Name,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 CarImages = (from cimg in context.CarImages
                                              where cimg.CarId == c.CarId
                                              select new CarImages
                                              {
                                                  Id = cimg.Id,
                                                  ImagePath = cimg.ImagePath,
                                                  CarId = c.CarId,
                                                  Date = cimg.Date
                                              }).ToList()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetDetailsByBrandId(int brandId)
        {
            using (ReCapDbContext context = new())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join col in context.Colors
                             on c.ColorId equals col.ColorId
                             where c.BrandId == brandId
                             select new CarDetailDto
                             {
                                 Id = c.CarId,
                                 BrandName = b.Name,
                                 CarName = c.Description,
                                 ColorName = col.Name,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 CarImages = (from cimg in context.CarImages
                                              where cimg.CarId == c.CarId
                                              select new CarImages
                                              {
                                                  Id = cimg.Id,
                                                  ImagePath = cimg.ImagePath,
                                                  CarId = c.CarId,
                                                  Date = cimg.Date
                                              }).ToList()
                             };
                return result.ToList();
            }
        }

        public CarDetailDto GetDetailsById(int carId)
        {
            using (ReCapDbContext context = new())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join col in context.Colors
                             on c.ColorId equals col.ColorId
                             where c.CarId == carId
                             select new CarDetailDto
                             {
                                 Id = c.CarId,
                                 BrandName = b.Name,
                                 CarName = c.Description,
                                 ColorName = col.Name,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 CarImages = (from cimg in context.CarImages
                                              where cimg.CarId == c.CarId
                                              select new CarImages
                                              {
                                                  Id = cimg.Id,
                                                  ImagePath = cimg.ImagePath,
                                                  CarId = c.CarId,
                                                  Date = cimg.Date
                                              }).ToList()
                             };
                return result.FirstOrDefault();
            }
        }
    }

}
