﻿using Core.Utilites.Results;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IResult GetById(int id);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}