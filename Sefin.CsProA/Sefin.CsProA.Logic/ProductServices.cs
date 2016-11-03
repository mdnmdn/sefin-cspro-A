using Sefin.CsProA.Logic.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProA.Logic
{
    public class ProductServices:BaseServices
    {

        public ProductServices(NorthwindContext ctx) : base(ctx) {

        }

        public int CountProducts() {
            return DataContext.Products.Count();
        }
    }
}
