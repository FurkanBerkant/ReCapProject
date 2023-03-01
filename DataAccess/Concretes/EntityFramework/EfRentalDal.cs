using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase
        <Rental,ReCapDbContext>,IRentalDal
    {
    }
}
