using Sefin.CsProA.Logic.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProA.Logic
{
    public abstract class BaseServices 
    {

        public BaseServices(NorthwindContext ctx) {
            _dataContext = ctx;
        }

        #region datacontext
        NorthwindContext _dataContext;
        protected NorthwindContext DataContext
        {
            get { return _dataContext ?? (_dataContext = new NorthwindContext()); }
        }
        #endregion

        public void Commit() {
            _dataContext.SaveChanges();
        }

    }
}
