using Business.Abstract;
using Business.Constants;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImage;

        public CarImageManager(ICarImageDal carImage)
        {
            _carImage = carImage;
        }

        public IResult Add(CarImages carImage)
        {
            _carImage.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImages carImage)
        {
            _carImage?.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImage.GetAll().ToList());
        }

        public IResult GetById(int carImageId)
        {
            _carImage.Get(c=>c.Id==carImageId);
            return new SuccessResult();
        }

        public IDataResult<List<CarImages>> GetCarImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImages>>(_carImage.GetAll(c=>c.Id==carId).ToList());
        }

        public IResult Update(CarImages carImage)
        {
            _carImage.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }
    }
}
