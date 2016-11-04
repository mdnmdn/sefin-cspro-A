using Sefin.CsProA.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace Sefin.CsProA.WebApp.Controllers
{
    public class HomeController : ControllerBase
    {
        private CategoryServices _categoryService;
        private ProductServices _productService;

        public HomeController(CategoryServices categoryService, ProductServices productService) {
            _categoryService = categoryService;
            _productService = productService;

        }

        public ActionResult Index()
        {
            ViewBag.NumCategories = _categoryService.CountCategories();

            var prodService = Kernel.Get<ProductServices>();

            var prodService2 = this.ResolveObject<ProductServices>();

            prodService.CountProducts();

            //prodService.UpdateStock(23);
            //_categoryService.Rename("pippo");

            //prodService.Commit();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}