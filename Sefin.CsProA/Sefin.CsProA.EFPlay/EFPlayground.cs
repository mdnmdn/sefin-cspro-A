using Sefin.CsProA.EFPlay.NW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Data.Entity;

namespace Sefin.CsProA.EFPlay
{
    [Category("test")]
    public class EFPlayground
    {
        public object Intro() {

            var ctx = new NorthwindContext();

            //Action<string> logger = (txt) => Trace.WriteLine(txt);
            //ctx.Database.Log = logger;

            var categs = ctx.Categories.Select(c => new {
                c.CategoryID,
                c.CategoryName
            });

            //return categs;

            //return ctx.Categories.Select(c => new { c.CategoryID,c.CategoryName,c.Description });


            //var id = 2;
            //var cat = ctx.Categories.FirstOrDefault(c => c.CategoryID == id);

            //Trace.WriteLine($" {cat.CategoryID} - {cat.CategoryName}");

            //var numProds = cat.Products.Count();

            //Trace.WriteLine($"   > prods: {numProds}");

            //foreach (var prod in cat.Products) {
            //    Trace.WriteLine($"   >  {prod.ProductID} - {prod.ProductName}");
            //}

            //  ------------------

            //var prods = ctx.Products.Where(p => p.UnitsInStock > 0)
            //                        .Select(p => new
            //                        {
            //                            p.ProductID,
            //                            p.ProductName,
            //                            p.Categories.CategoryName
            //                        });

            //foreach (var prod in prods)
            //{
            //    Trace.WriteLine($"{prod.ProductID} - {prod.ProductName}  ({prod.CategoryName})");
            //}

            //  ------------------

            //var prods2 = ctx.Products.Include(p => p.Categories)
            //                .Where(p => p.UnitsInStock > 0);
                                    
            //foreach (var prod in prods2)
            //{
            //    Trace.WriteLine($"{prod.ProductID} - {prod.ProductName}  ({prod.Categories.CategoryName})");
            //}

            // --------------

            var filter = "bev";

            return ctx.Categories.ToList()
                .Where(c => c.CategoryName.Contains(filter))
                .Select(c => new { c.CategoryID, c.CategoryName, c.Description });

            return null;
        }

        string Raddoppia(string txt) {
            return txt + txt;
        }



        public object Test2() {
            using (var ctx = new NorthwindContext()) {

                var catNames = ctx.Categories
                        .Where(c => c.CategoryName.StartsWith("C"))
                        .Select(c => new
                        {
                            c.CategoryID,
                            c.CategoryName
                        });

                //return catNames.ToList();

                var prods1 = ctx.Products.Where(pr => pr.UnitsInStock < pr.ReorderLevel)
                         .Select(p => new {
                             p.ProductID,
                             p.ProductName,
                             p.UnitsInStock,
                             p.ReorderLevel,
                             p.Categories.CategoryName,
                         });

                //return prods1.ToList();


                var prods2 = ctx.Products.Where(pr => pr.UnitsInStock < pr.ReorderLevel)
                             .Select(p => new {
                                 p.ProductID,
                                 p.ProductName,
                                 p.UnitsInStock,
                                 p.ReorderLevel,
                                 CategoryName = ctx.Categories
                                                    .FirstOrDefault(c => c.CategoryID == p.CategoryID)
                                                    .CategoryName
                             });

                //return prods2.ToList();

                var prods3 = from pr in ctx.Products
                             join c in ctx.Categories
                                on pr.CategoryID equals c.CategoryID
                             where pr.UnitsInStock < pr.ReorderLevel
                             select new
                             {
                                 pr.ProductID,
                                 pr.ProductName,
                                 pr.UnitsInStock,
                                 pr.ReorderLevel,
                                 c.CategoryName
                             };

                //return prods3.ToList();


                var prods4 = ctx.Products
                        //.Include(p => p.Categories)
                        .Where(pr => pr.UnitsInStock < pr.ReorderLevel);

                //return prods4.ToList();
                //foreach (var prod in prods4)
                //{
                //    Trace.WriteLine($"{prod.ProductID}. {prod.ProductName} ({prod.Categories.CategoryName})");
                //}

                var prods5 = ctx.Products
                        .Select(p => new
                        {
                            p.ProductID,
                            p.ProductName,
                            NumOrdini = p.Order_Details.Count(),
                            NumProdOrdinati = p.Order_Details.Sum(od => od.Quantity),
                            Orders = p.Order_Details.ToList()
                        });

                var pro = prods5.First();

                return prods5.ToList();

            }

            return null;
        }
    }

    
}
