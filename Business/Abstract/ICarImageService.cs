using Core.Utilites.Results;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImages>> GetAll();
        IResult GetById(int carImageId);
        IDataResult<List<CarImages>> GetCarImagesByCarId(int carId);
        IResult Add(IFormFile file ,CarImages carImage);
        IResult Update(IFormFile file, CarImages carImage);
        IResult Delete(CarImages carImage);
    }
}
