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

            prodService.CountProducts();
            
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