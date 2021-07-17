using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfCore.Domain.productAgg;

namespace EfCore.Domain.ProductAgg
{
    public interface IProductRepository
    {
        Product Get(int id);
        void Creat(Product product);
    }
}
