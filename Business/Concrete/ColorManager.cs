using Business.Abstract;
using Business.Constants;
using Core.Utilites.Business;
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
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            var result = BusinessRules.Run(ColorExists(color.Name));
            if (result != null) return result;

            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);

        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll().ToList());
        }

        public IResult GetById(int colorId)
        {
            _colorDal.Get(c => c.ColorId == colorId);
            return new SuccessResult();

        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
        public IResult ColorExists(string colorName)
        {
            var result = _colorDal.Get(c => c.Name == colorName);
            if (result != null)
                return new ErrorResult(Messages.ColorExists);
            return new SuccessResult();
        }
    }
}
