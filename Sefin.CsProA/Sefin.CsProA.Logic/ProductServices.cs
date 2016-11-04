using Sefin.CsProA.Library;
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
        private IAppContext _appContext;

        public ProductServices(NorthwindContext ctx, IAppContext appContext) : base(ctx) {
            _appContext = appContext;
        }

        public int CountProducts() {
            return DataContext.Products.Count();
        }

        public void ProcessProdInCategory() {
            //var categService = new CategoryServices()
            var svc = _appContext.ResolveObject<CategoryServices>();
            svc.ListCategories();

            var mail = _appContext.UserMail;
        }
    }
}
