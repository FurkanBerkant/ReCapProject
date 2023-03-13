using Business.Abstract;
using Core.Utilites.Helpers;
using Core.Utilites.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UploadManager : IUploadService
    {
        public string Add(IFormFile file)
        {
            return FileHelper.Add(file);
        }

        public IResult Remove(string path)
        {
            return FileHelper.Remove(path);
        }
        public string Update(string oldPath, IFormFile file)
        {
            return FileHelper.Update(oldPath, file);
        }
    }
}
