using Core.Entities;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DTOs
{
    public class CarDetailDto : IDto
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public int ModelYear { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public List<CarImages> CarImages { get; set; }
    }
}
