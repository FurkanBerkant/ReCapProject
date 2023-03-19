using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilites.Business;
using Core.Utilites.Results;
using DataAccess.Abstract;
using DataAccess.Concretes.EntityFramework;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        readonly ICarImageDal _carImage;
        readonly IUploadService uploadService;
        public CarImageManager(ICarImageDal carImage, IUploadService uploadService)
        {
            this._carImage = carImage;
            this.uploadService = uploadService;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImages carImage)
        {
            var businessRuleResults = BusinessRules.Run(CheckIfCarImageLimitExceeded(carImage.CarId));
            if (businessRuleResults != null)
                return businessRuleResults;

            carImage.ImagePath= uploadService.Add(file);
            carImage.Date = DateTime.Now;
            _carImage.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImages carImage)
        {
            uploadService.Remove(_carImage.Get(c => c.Id == carImage.Id).ImagePath);
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
            var result = BusinessRules.Run(CheckIfCarHasImage(carId));
            if (result != null)
            {
                return new SuccessDataResult<List<CarImages>>
                    (new List<CarImages>() { new CarImages { ImagePath = "default.png" } });

            }
            return new SuccessDataResult<List<CarImages>>(_carImage.GetAll(c=>c.Id==carId).ToList());
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImages carImage)
        {
            string newPath = uploadService.Update
                (_carImage.Get(c => c.Id == carImage.Id).ImagePath, file);
            carImage.ImagePath = newPath;
            carImage.Date = DateTime.Now;
            _carImage.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }
        public IResult CheckIfCarImageLimitExceeded(int carId)
        {
            var result = _carImage.GetAll(c => c.CarId == carId);
            if (result.Count >= 5)
                return new ErrorResult(Messages.CarImageLimitExceeded);
            return new SuccessResult();
        }

        public IResult CheckIfCarHasImage(int carId)
        {
            var result = _carImage.GetAll(c => c.CarId == carId);
            if (result.Count <= 0)
                return new ErrorResult();
            return new SuccessResult();
        }
    }
}
