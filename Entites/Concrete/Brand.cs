using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    public class Brand:IEntity
    {
        public int id;

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
