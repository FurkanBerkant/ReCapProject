using Core.Utilites.Results;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBaseService<T>where T : class
    {
        IDataResult<List<T>> GetAll();
        IResult Add(T tEntity);
        IResult GetById(int TentityId);
        IResult Update(T tEntity);
        IResult Delete(T tEntity);
    }
}
