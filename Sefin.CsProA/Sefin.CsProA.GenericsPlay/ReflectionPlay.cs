using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProA.GenericsPlay
{
    [Category("test")]
    public class ReflectionPlay
    {
        public void TestReflection() {
            var doc = new Documento {
                Id = "24",
                Data = DateTime.Now,
                Nome = "pippo.txt"                
            };
            var type = doc.GetType();

            Trace.WriteLine("type:   " + type.Name);

            var properties = type.GetProperties();

            foreach (var prop in properties) {

                var val = prop.GetValue(doc);

                Trace.WriteLine($">  {prop.Name}; {val} ");
            }

            // CodeDOM
        }


    }
}
