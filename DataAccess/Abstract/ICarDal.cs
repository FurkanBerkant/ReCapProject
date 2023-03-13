using Core.DataAccess;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
        List<CarDetailDto> GetDetailsByBrandId(int brandId);
        CarDetailDto GetDetailsById(int carId);
        List<CarDetailDto> GetByFilters(int brandId, int colorId);

    }
}
