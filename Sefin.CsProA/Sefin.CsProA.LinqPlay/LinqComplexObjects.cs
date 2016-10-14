using Sefin.CsPro.Commons;
using Sefin.CsPro.Commons.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sefin.CsProA.LinqPlay
{
    [System.ComponentModel.Category("test")]
    public class LinqComplexObjects
    {
        public object ComplexObjectIntro()
        {
            var db = new NorthwindDatabase();

            var cat1 = db.Categories.Select(c =>
                new {
                    c.Id,
                    c.CategoryName
                });

            cat1.LogValues();

            //db.Categories.LogValues();

            var prods1 = db.Products.Where(x => x.Category.Id == 1);

            var prod = new Product();
            prod.Id = 23;
            prod.UnitsInStock = 213;
            prod.Category = new Category();
            prod.Category.Id = 11;
            prod.Category.Description = "asljfhasldjfhasldfj";

            var prods2 = db.Products.Where(x => x.Category.Id == 1)
                                    .Select(x => new {
                                        x.Id,
                                        x.ProductName,
                                        //Categ = x.Category,
                                        CategoryId = x.Category.Id,
                                        x.Category.CategoryName
                                    });

            //return prods2;


            var prodCat1 = db.Products.Where(p => p.Category.Id == 1);
            var numProds = prodCat1.Count();


            var prodCatList = prodCat1.ToList();
            var a = prodCatList.Count;
            var b = prodCatList.Count();




            var numProdsInStock = prodCat1.Sum(p => p.UnitsInStock );

            //numProdsInStock = prodCat1.Select(p => p.UnitsInStock).Sum();

            var avgPrice = prodCat1.Average(p => p.UnitPrice);

            var ac = prodCat1.Min(p => p.UnitPrice);
            var bc = prodCat1.Max(p => p.UnitPrice);

            var prod1 = prodCat1.First();  // almeno 1 elemento
            var prod2 = prodCat1.FirstOrDefault();  // 0 + 
            //var prod3 = prodCat1.Single(); // 1 di 1
            //var prod4 = prodCat1.SingleOrDefault(); // 1 o 0


            // -----
            var categs = db.Categories.Select(c => new
            {
                c.Id,
                c.CategoryName
            });

            foreach (var cat in categs)
            {
                var numProdCateg = db.Products.Count(p => p.Category.Id == cat.Id);

                Trace.WriteLine($"{cat.CategoryName}: {numProdCateg} products");
            }

            // -----------

            var categsWithProds = db.Categories.Select(c => new
            {
                c.Id,
                c.CategoryName,
                NumProducts = c.Products == null ? 0 : c.Products.Count()
            });


            var categsWithProds1 = db.Categories.Select(c => new
            {
                c.Id,
                c.CategoryName,
                //NumProducts = db.Products.Where(p => p.Category.Id == c.Id).Count()
                NumProducts = db.Products.Count(p => p.Category.Id == c.Id)
            });

            return categsWithProds1;
            //categsWithProds.ToList();

            //return null;
        }


        public object LinqExercises1()
        {
            var db = new NorthwindDatabase();

            // Elenco di prodotti che hanno elementi a magazzino
            var prod1 = db.Products.Where(p => p.UnitsInStock > 0)
                                .Select(p => new { p.ProductName, p.UnitsInStock});
            //return prod1;

            // Elenco di prodotti la cui nome categoria contiene 'bev' (da gestire come parametro)
            string filter = "bev";
            //filter = filter.ToLower();
            //var prod2 = db.Products.Where(p => p.Category.CategoryName.ToLower().Contains(filter))
            //                .Select(p => new { p.ProductName, p.Category.CategoryName });

            var prod2 = db.Products.Where(p =>  p.Category.CategoryName
                                   .IndexOf(filter,StringComparison.CurrentCultureIgnoreCase) >= 0  )
                                  .Select(p => new { p.ProductName, p.Category.CategoryName });


            //prod2 = db.Products.Where(p =>
            //                p.Category.CategoryName.ToLower().Contains(filter)
            //                || p.ProductName.ToLower().Contains(filter)
            //                || p.Category.Description.ToLower().Contains(filter))
            //        .Select(p => new { p.ProductName, p.Category.CategoryName});

            //prod2 = db.Products.Where(p =>
            //                ( p.Category.CategoryName + p.Category.Description
            //                 + p.ProductName).ToLower().Contains(filter))
            //        .Select(p => new { p.ProductName, p.Category.CategoryName });

            Trace.WriteLine($"prods: {prod2.Count()}");

            //return prod2;

            // Valore totale di prodotti che ho a magazzino
            var totalValue = db.Products.Sum(p => p.UnitPrice * p.UnitsInStock);
            var totalValue2 = db.Products.Select(p => p.UnitPrice * p.UnitsInStock).Sum();

            Trace.WriteLine($"Total prod value: {totalValue} - {totalValue2}");

            // Valore totale di prodotti per categoria
            var categ1 = db.Categories.Select(c => new {
                    c.CategoryName ,
                    TotalValue = db.Products.Where(p => p.Category.Id == c.Id)
                                            .Sum(p => p.UnitPrice * p.UnitsInStock)
                });

            categ1 = (from c in db.Categories
                     select new
                     {
                         c.CategoryName,
                         TotalValue = db.Products
                                            .Where(p => p.Category.Id == c.Id)
                                            .Sum(p => p.UnitPrice * p.UnitsInStock)
                     });

            //return categ1;

            // Elenco dei client che ho in USA
            var customers = from c in db.Customers
                            where c.Country == "USA"
                            select new
                            {
                                c.Id,
                                c.CompanyName,
                                c.Country
                            };

            //return customers;

            // Elenco delle categorie ordinate per quantità di prodotto

            var categ2 = db.Categories.Select(c => new
            {
                c.CategoryName,
                ProdQty = db.Products.Where(p => p.Category.Id == c.Id)
                                                  .Sum(p => p.UnitsInStock)
            }).OrderBy(c => c.ProdQty).ThenBy(c => c.CategoryName);

            return categ2;

            return null;
        }
    }


    public static class MyHelpers
    {
        public static void LogValues<T>(this IEnumerable<T> data)
        {
            Trace.WriteLine("[" + String.Join(", ", data) + "]");
        }

    }
}
