using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sefin.CsProA.WebApp.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected IKernel Kernel
        {
            get { return (IKernel)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IKernel)); }
        }
    }
}