using Sefin.CsProA.Logic.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProA.Logic
{
    public class CategoryServices : BaseServices
    {

        public CategoryServices(NorthwindContext ctx):base(ctx) {
        }

        public int CountCategories() {
            return DataContext.Categories.Count();
        }

        public List<Categories> ListCategories()
        {
            return DataContext.Categories.ToList();
        }

        public Categories GetCategory(int id)
        {
            return DataContext.Categories.Find(id);
        }

        
    }
}
