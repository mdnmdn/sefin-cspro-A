using Sefin.CsPro.Commons.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsPro.Commons
{
    public class NorthwindDatabase
    {
        static NortwindData _data;

        public NorthwindDatabase() {
            if (_data == null) _data = new DataFactory().LoadNortwhind();
        }

        public IQueryable<Category> Categories => _data.Categories.AsQueryable();
        public IQueryable<Customer> Customers => _data.Customers.AsQueryable();
        public IQueryable<Region> Regions => _data.Regions.AsQueryable();
        public IQueryable<Territory> Territories => _data.Territories.AsQueryable();
        public IQueryable<Employee> Employees => _data.Employees.AsQueryable();
        public IQueryable<Supplier> Suppliers => _data.Suppliers.AsQueryable();
        public IQueryable<Product> Products => _data.Products.AsQueryable();
        public IQueryable<Order> Orders => _data.Orders.AsQueryable();
        public IQueryable<Shipper> Shippers => _data.Shippers.AsQueryable();

    }
}
