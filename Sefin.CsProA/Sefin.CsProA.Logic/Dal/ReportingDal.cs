using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProA.Logic.Dal
{
    public class ReportingDal
    {
        public DataTable ListQuarterlyOrders() {
            var sql = "select * from [dbo].[Quarterly Orders]";

            using (var ctx = new NorthwindContext()) {
                var cmd = ctx.Database.Connection.CreateCommand()  as SqlCommand;
                cmd.CommandText = sql;

                DataTable result = null;

                // ... carica datatable

                return result;
            }

        }
    }
}
