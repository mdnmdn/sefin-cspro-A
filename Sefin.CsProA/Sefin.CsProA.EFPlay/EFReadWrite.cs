using Sefin.CsProA.EFPlay.NW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProA.EFPlay
{
    [Category("test")]
    public class EFReadWrite
    {
        public object TestInsert() {

            using (var ctx = new NorthwindContext()) {

                var newCategory = new Categories() {
                    CategoryName = "extra dolci",
                    Description = "indovina...",
                };


                Trace.WriteLine($"Sto per aggiungere: {newCategory.CategoryID}. {newCategory.CategoryName}");
                ctx.Categories.Add(newCategory);

                ctx.SaveChanges();
                Trace.WriteLine($"Fatto");

                Trace.WriteLine($"Ho aggiunto: {newCategory.CategoryID}. {newCategory.CategoryName}");
            }

            return null;
        }

        public object TestInsertWithChilds()
        {

            using (var ctx = new NorthwindContext())
            {

                var newCategory = new Categories()
                {
                    CategoryName = "extra dolci",
                    Description = "indovina...",
                };


                Trace.WriteLine($"Sto per aggiungere: {newCategory.CategoryID}. {newCategory.CategoryName}");
                ctx.Categories.Add(newCategory);


                var newProd1 = new Products
                {
                    ProductName = "Torta arcobaleno",
                };

                var newProd2 = new Products
                {
                    ProductName = "Torta extradark",
                };

                newCategory.Products.Add(newProd1);
                newCategory.Products.Add(newProd2);

                ctx.SaveChanges();
                Trace.WriteLine($"Fatto");

                Trace.WriteLine($"Ho aggiunto: {newCategory.CategoryID}. {newCategory.CategoryName}");
            }

            return null;
        }

        public object TestInsertWithChilds2()
        {

            using (var ctx = new NorthwindContext())
            {

                var newCategory = new Categories()
                {
                    CategoryName = "extra dolci",
                    Description = "indovina...",
                };


                Trace.WriteLine($"Sto per aggiungere: {newCategory.CategoryID}. {newCategory.CategoryName}");
                ctx.Categories.Add(newCategory);

                var newProd1 = new Products
                {
                    ProductName = "Torta arcobaleno",
                    //CategoryID = 13
                    Categories = newCategory
                };

                var newProd2 = new Products
                {
                    ProductName = "Torta extradark",
                    //CategoryID = 13
                    Categories = newCategory
                };

                ctx.Products.Add(newProd1);
                ctx.Products.Add(newProd2);

                ctx.SaveChanges();
                Trace.WriteLine($"Fatto");

                Trace.WriteLine($"Ho aggiunto: {newCategory.CategoryID}. {newCategory.CategoryName}");
            }

            return null;
        }

        public object TestInsertWithErrors()
        {

            using (var ctx = new NorthwindContext())
            {

                var newCategory = new Categories()
                {
                    CategoryName = "extra dolci",
                    Description = "indovina...",
                };

                Trace.WriteLine($"Sto per aggiungere: {newCategory.CategoryID}. {newCategory.CategoryName}");
                ctx.Categories.Add(newCategory);

                var newProd1 = new Products
                {
                    ProductName = "Torta arcobaleno",
                    //CategoryID = 99
                    Categories = newCategory
                };
                Trace.WriteLine($"Sto per aggiungere: {newProd1.ProductID}. {newProd1.ProductName}");

                var newProd2 = new Products
                {
                    //ProductName = "Torta extradark",
                    //CategoryID = 13
                    Categories = newCategory
                };
                Trace.WriteLine($"Sto per aggiungere: {newProd2.ProductID}. {newProd2.ProductName}");

                ctx.Products.Add(newProd1);
                ctx.Products.Add(newProd2);

                ctx.SaveChanges();
                Trace.WriteLine($"Fatto");
                Trace.WriteLine($"Ho aggiunto: {newCategory.CategoryID}. {newCategory.CategoryName}");
                Trace.WriteLine($"Ho aggiunto: {newProd1.ProductID}. {newProd1.ProductName}");
                Trace.WriteLine($"Ho aggiunto: {newProd2.ProductID}. {newProd2.ProductName}");
            }

            return null;
        }

        public void TestUpdate()
        {
            using (var ctx = new NorthwindContext())
            {
                //var cat = ctx.Categories.FirstOrDefault(c => c.CategoryID == 12);
                var cat = ctx.Categories.Find(12);

                cat.Description = $"extra extra dolce ({DateTime.Now})";

                ctx.SaveChanges(); 
            }
        }
    }
}
