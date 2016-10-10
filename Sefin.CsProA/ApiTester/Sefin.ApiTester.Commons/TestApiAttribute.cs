using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.ApiTester.Commons
{
    public class TestApiAttribute : Attribute
    {
        public string Label { get; private set; }

        public TestApiAttribute(string label = null) {
            Label = label;
        }

    }
}
