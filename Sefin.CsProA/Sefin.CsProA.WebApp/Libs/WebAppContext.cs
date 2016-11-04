using Sefin.CsProA.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;

namespace Sefin.CsProA.WebApp.Libs
{
    public class WebAppContext : IAppContext
    {
        public int UserId
        {
            get { return 1; }
        }

        public string UserMail
        {
            get { return "pippo@pippo.it"; }
        }

        public T ResolveObject<T>()
        {
            var kernel = (IKernel)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IKernel));
            return kernel.Get<T>();
        }
    }
}