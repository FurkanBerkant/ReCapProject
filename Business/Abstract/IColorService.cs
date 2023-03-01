using Core.Utilites.Results;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IResult GetById(int colorId);
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
    }
}
