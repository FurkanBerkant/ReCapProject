using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Core.Aspects.Autofac.Validation;
using DataAccess.Concretes.EntityFramework;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilites.Business;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(IsCarReturned(rental.CarId));
            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
           
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll().ToList());
        }

        public IResult GetById(int id)
        {
            _rentalDal.Get(c => c.Id == id);
            return new SuccessResult();
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
        private IResult IsCarReturned(int carId)
        {
            var result = _rentalDal.Get(c => c.CarId == carId && c.ReturnDate == null);
            if (result != null)
            {
                return new ErrorResult(Messages.RentalCarMissing);
            }
            return new SuccessResult();

        }
    }
}
