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

        public object TestEx2()
        {
            Products prodValue;

            using (var ctx = new NorthwindContext())
            {
                /*
                    * Stampa Id, Nome del prodotto 11
                    * Stampa Id, Nome,CategoryName del prodotto 11
                    * Id, Nome di Tutti i prodotti della categoria 2
                    * Id, Nome, CategoryName di Tutti i prodotti della categoria 2
                    * Id, Nome, CategoryName di Tutti i prodotti delle categorie che iniziano per C
                    * Id, Nome delle categoria che hanno prodotti in riordino (flag reorder?)
                    * Id, Nome, CategoryName di Tutti i prodotti da riordinare (unitinstock e reorder level)
                    * Id, Nome delle categoria che hanno prodotti da riordinare (unitinstock e reorder level)
                    * Id, Nome e num prodotti di tutte le categorie
                */

                //var prod = ctx.Products.Where(p => p.ProductID == 11).Single();
                var prod = ctx.Products.Single(p => p.ProductID == 11);

                var prodOut = ctx.Products.Select(p => new { p.ProductID, p.ProductName })
                            .Where(p => p.ProductID == 11)
                            .Single();

                prodValue = ctx.Products
                        .Include(p => p.Categories)
                        .Single(p => p.ProductID == 11);

                Trace.WriteLine($" prod: {prod.ProductID}. {prod.ProductName} ");
                //Trace.WriteLine($" prod: {prod.ProductID}. {prod.ProductName} { prod.Categories.CategoryName}");

                var catName = prod.Categories.CategoryName;

                // *Stampa Id, Nome,CategoryName del prodotto 11

                var prodCat = ctx.Products
                                .Select(p => new {
                                        p.ProductID,
                                        p.ProductName,
                                        p.Categories.CategoryName
                                })
                                .Single(p => p.ProductID == 11);

                Trace.WriteLine($" prodCat: {prodCat.ProductID}. {prodCat.ProductName} ({prodCat.CategoryName}) ");


                //*Id, Nome di Tutti i prodotti della categoria 2
                var prodCats = ctx.Products.Where(p => p.CategoryID == 2)
                    .Select(p => new
                        {
                            p.ProductID,
                            p.ProductName,
                        });

                Trace.WriteLine("Prod on cat 2");
                foreach (var p in prodCats) {
                    Trace.WriteLine($" prodCat: {prodCat.ProductID}. {prodCat.ProductName}");
                }

                // * Id, Nome, CategoryName di Tutti i prodotti della categoria 2

                var prodCatsWithName = ctx.Products.Where(p => p.CategoryID == 2)
                        .Select(p => new
                        {
                            p.ProductID,
                            p.ProductName,
                            p.Categories.CategoryName
                        });

                Trace.WriteLine("Prod on cat 2 with cat name");
                foreach (var p in prodCatsWithName)
                {
                    Trace.WriteLine($" prodCat: {prodCat.ProductID}. {prodCat.ProductName}");
                }

                // Id, Nome, CategoryName di Tutti i prodotti delle categorie
                // che iniziano per C

                var prodCatsC = ctx.Products
                            .Where(p => p.Categories.CategoryName.StartsWith("c") )
                            .Select(p => new
                            {
                                p.ProductID,
                                p.ProductName,
                                p.Categories.CategoryName
                            });

                Trace.WriteLine("Prod on cat 2 with cat name start wiht C");
                foreach (var p in prodCatsC)
                {
                    Trace.WriteLine($"{p.ProductID}. {p.ProductName} ({p.CategoryName})");
                }

                // *Id, Nome delle categoria che hanno prodotti in riordino(flag reorder ?)

                var catRiorder = ctx.Categories
                        .Where(c => c.Products.Any(p => p.UnitsOnOrder > 0));

                Trace.WriteLine("Cat with catRiorder");
                foreach (var c in catRiorder)
                {
                    Trace.WriteLine($"{c.CategoryID}. {c.CategoryName}");
                }

                // ---

                var catRiorder2 = ctx.Products.Where(p => p.UnitsOnOrder > 0)
                        .Select(p => new
                        {
                            p.Categories.CategoryID,
                            p.Categories.CategoryName
                        })
                        .Distinct();

                Trace.WriteLine("-- Cat with catRiorder 2");
                foreach (var c in catRiorder2)
                {
                    Trace.WriteLine($"{c.CategoryID}. {c.CategoryName}");
                }

                // *Id, Nome e num prodotti di tutte le categorie

                var catSummary = ctx.Categories
                        .Select(p => new {
                            p.CategoryID,
                            p.CategoryName,
                            NumProds = p.Products.Count()
                        });
                Trace.WriteLine("-- Cat with num prods");
                foreach (var c in catSummary)
                {
                    Trace.WriteLine($"{c.CategoryID}. {c.CategoryName} {c.NumProds}");
                }
            }


            //Trace.WriteLine($" prod: {prodValue.ProductID}. {prodValue.ProductName} ");

            return null;
        }

    }


    

   
}
