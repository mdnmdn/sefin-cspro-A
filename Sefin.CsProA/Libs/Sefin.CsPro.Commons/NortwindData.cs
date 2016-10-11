using Sefin.CsPro.Commons.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsPro.Commons
{
    [Serializable]
    internal class NortwindData
    {
        internal List<Category> Categories { get; set; }
        internal List<Customer> Customers { get; set; }
        internal List<Region> Regions { get; set; }
        internal List<Territory> Territories { get; set; }
        internal List<Employee> Employees { get; set; }
        internal List<Supplier> Suppliers { get; set; }
        internal List<Product> Products { get; set; }
        internal List<Order> Orders { get; set; }
        internal List<Shipper> Shippers { get; set; }

    }
}
