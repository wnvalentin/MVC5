using SportsStore.Domain.Abstraction;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepo : IProductRepo
    {
        private EFDbContext context = new EFDbContext();

        public EFProductRepo()
        {

        }


        public IEnumerable<Product> Products => context.Products;
    }
}
