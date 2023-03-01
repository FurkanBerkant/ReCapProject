using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Results
{
    public class Result : IResult
    {
        public Result(bool succes)
        {
            Succes = succes;
        }

        public Result(bool succes, string message) : this(succes)
        {
            Message = message;
        }
        public bool Succes { get; }

        public string Message { get; }
    }
}
