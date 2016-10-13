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

            // Elenco di prodotti la cui nome categoria contiene 'bev' (da gestire come parametro)

            // Valore totale di prodotti che ho a magazzino

            // Valore totale di prodotti per categoria

            // Elenco dei client che ho in USA
            
            // Elenco delle categorie ordinate per quantità di prodotto

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
