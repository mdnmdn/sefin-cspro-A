using Sefin.CsProA.Logic.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProA.Logic
{
    public abstract class BaseServices :IDisposable
    {

        #region datacontext
        NorthwindContext _dataContext;
        protected NorthwindContext DataContext
        {
            get { return _dataContext ?? (_dataContext = new NorthwindContext()); }
        }
        #endregion

        #region Disposable
        public void Dispose()
        {
            if (_dataContext != null)
            {
                _dataContext.Dispose();
                _dataContext = null;
            }
        }
        #endregion
    }
}
