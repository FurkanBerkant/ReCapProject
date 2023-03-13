using Core.Utilites.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUploadService
    {
        string Add(IFormFile file);
        IResult Remove(string path);
        string Update(string oldPath, IFormFile file);

    }
}
