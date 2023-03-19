﻿using Core.DataAccess.EntityFramework;
using Core.Entites;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase
        <User,ReCapDbContext>,IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using ReCapDbContext context = new();
            var result = from operationClaim in context.OperationClaims
                         join userOperationClaim in context.UserOperationClaims
                         on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
        }
    }
}
