using Core.Utilites.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (IResult logic in logics)
            {
                if (!logic.Success) return logic;
            }
            return null;
        }
    }
}
